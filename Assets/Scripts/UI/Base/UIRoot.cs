using UnityEngine;

namespace UI.Base
{
    public class UIRoot : MonoBehaviour
    {
        private void Start()
        {
            UIManager.Instance.PushPanel(UIPanelType.Main);
        }
    }
}