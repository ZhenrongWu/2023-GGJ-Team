#nullable enable
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GGJ.DebugTool
{
    public class CharacterMoveDebug : MonoBehaviour
    {
        [SerializeField] Slider? debugSlider;
        [SerializeField] TMP_Text? debugSliderText;
        [SerializeField] UnityEvent<float> OnSlideValueChangedEvent;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (debugSlider != null)
            {
                debugSlider.onValueChanged.AddListener((value) =>
                {
                    if (debugSliderText != null)
                    {
                        debugSliderText.SetText(value.ToString("0.00"));
                    }
                });

                debugSlider.onValueChanged.AddListener(OnSlideValueChangedEvent.Invoke);
            }
        }
    }
}
