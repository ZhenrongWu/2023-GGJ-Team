using System.Collections.Generic;
using UnityEngine;

namespace UI.Base
{
    public class UIManager
    {
        private static UIManager instance;
        public static  UIManager Instance => instance ?? (instance = new UIManager());

        private UIManager()
        {
            ParseUIPanelTypeJson();
        }

        private Dictionary<UIPanelType, string>    _panelPathDict;
        private Dictionary<UIPanelType, BasePanel> _panelDict;
        private Transform                          _canvasTrans;

        private Transform CanvasTrans
        {
            get
            {
                if (_canvasTrans == null)
                {
                    _canvasTrans = GameObject.Find("Canvas").transform;
                }

                return _canvasTrans;
            }
        }

        private Stack<BasePanel> _panelStack;

        public void PushPanel(UIPanelType panelType)
        {
            if (_panelStack == null)
            {
                _panelStack = new Stack<BasePanel>();
            }

            if (_panelStack.Count > 0)
            {
                BasePanel currentPanel = _panelStack.Peek();
                currentPanel.OnPause();
            }

            BasePanel panel = GetPanel(panelType);
            panel.OnEnter();
            _panelStack.Push(panel);
        }

        public void PopPanel()
        {
            if (_panelStack == null)
            {
                _panelStack = new Stack<BasePanel>();
            }

            BasePanel currentPanel = _panelStack.Pop();
            currentPanel.OnExit();

            if (_panelStack.Count <= 0) return;

            BasePanel panel = _panelStack.Peek();
            panel.OnResume();
        }

        private void ParseUIPanelTypeJson()
        {
            _panelPathDict = new Dictionary<UIPanelType, string>();

            TextAsset       textAsset       = Resources.Load<TextAsset>("UIPanelType");
            UIPanelInfoJson uiPanelInfoJson = JsonUtility.FromJson<UIPanelInfoJson>(textAsset.text);

            foreach (UIPanelInfo info in uiPanelInfoJson.uiPanelInfoList)
            {
                _panelPathDict.Add(info.UIPanelType, info.path);
            }
        }

        private BasePanel GetPanel(UIPanelType panelType)
        {
            if (_panelDict == null)
            {
                _panelDict = new Dictionary<UIPanelType, BasePanel>();
            }

            BasePanel panel = _panelDict.TryGetValue(panelType);

            if (panel == null)
            {
                string path = _panelPathDict.TryGetValue(panelType);

                GameObject uiPanel = Object.Instantiate(Resources.Load<GameObject>(path), CanvasTrans, false);
                _panelDict.Add(panelType, uiPanel.GetComponent<BasePanel>());

                return uiPanel.GetComponent<BasePanel>();
            }

            return panel;
        }
    }
}