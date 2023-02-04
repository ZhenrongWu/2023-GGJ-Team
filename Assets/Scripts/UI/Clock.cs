using UnityEngine;

namespace UI
{
    public class Clock : MonoBehaviour
    {
        [SerializeField] private RectTransform pointer;

        private TimeManager _timeManager;

        private void Start()
        {
            _timeManager = GetComponent<TimeManager>();
        }

        private void Update()
        {
            pointer.rotation = Quaternion.Euler(0, 0, -_timeManager.GetSeconds() * 360);
        }
    }
}