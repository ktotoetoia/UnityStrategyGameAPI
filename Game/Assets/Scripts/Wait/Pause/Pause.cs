using UnityEngine;

namespace TDS.PauseSystem
{
    public class Pause : MonoBehaviour, IPause
    {
        private bool _isPaused;

        public bool IsPaused
        {
            get => _isPaused;
            set
            {
                _isPaused = value;
                Time.timeScale = value ? 0 : 1;
            }
        }
    }
}