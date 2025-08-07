using UnityEngine;

namespace TDS
{
    public class ThreadMovementCheck : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;
        [SerializeField] private float distance = 3f;

        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            var offset = Mathf.Sin(Time.time * speed) * distance;
            transform.position = _startPosition + new Vector3(offset, 0f, 0f);
        }
    }
}