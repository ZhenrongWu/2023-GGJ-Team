using System;
using UnityEngine;

namespace UI.Base
{
    [Serializable]
    public class UIPanelInfo : ISerializationCallbackReceiver
    {
        [NonSerialized] public UIPanelType UIPanelType;

        public string uiPanelTypeString;
        public string path;

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            UIPanelType type = (UIPanelType)Enum.Parse(typeof(UIPanelType), uiPanelTypeString);
            UIPanelType = type;
        }
    }
}