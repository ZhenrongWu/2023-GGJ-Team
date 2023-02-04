using UI.Base;
using UnityEngine;

namespace UI
{
    public class GuidePanel : BasePanel
    {
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            if (_canvasGroup == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
            }

            _canvasGroup.alpha = 0;
        }

        public override void OnEnter()
        {
            _canvasGroup.alpha          = 1;
            _canvasGroup.blocksRaycasts = true;
        }

        public override void OnExit()
        {
            _canvasGroup.alpha          = 0;
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnClosePanel()
        {
            UIManager.Instance.PopPanel();
        }
    }
}