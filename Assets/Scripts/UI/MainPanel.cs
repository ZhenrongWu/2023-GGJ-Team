﻿using System;
using UI.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainPanel : BasePanel
    {
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            if (_canvasGroup == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
            }
        }

        public override void OnPause()
        {
            _canvasGroup.blocksRaycasts = false;
        }

        public override void OnResume()
        {
            _canvasGroup.blocksRaycasts = true;
        }

        public void OnStartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void OnPushPanel(string panelTypeString)
        {
            UIPanelType panelType = (UIPanelType)Enum.Parse(typeof(UIPanelType), panelTypeString);
            UIManager.Instance.PushPanel(panelType);
        }

        public void OnExitGame()
        {
            Debug.Log("Exit Game");
        }
    }
}