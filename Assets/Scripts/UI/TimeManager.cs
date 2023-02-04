using UnityEngine;

namespace UI
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float counter;

        private          float _totalTime;
        private          float _currentTime;
        private readonly float _duration = 30f;

        private void Update()
        {
            if (_currentTime <= counter)
            {
                _totalTime   += Time.deltaTime;
                _currentTime =  _totalTime % _duration;
            }
        }

        public float GetSeconds()
        {
            return _currentTime % 60;
        }
    }
}