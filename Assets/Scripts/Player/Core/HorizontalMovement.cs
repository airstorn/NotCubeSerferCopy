using UnityEngine;

namespace Player
{
    public class HorizontalMovement : MonoBehaviour
    {
        [SerializeField] 
        private Transform _pivot;

        [SerializeField] 
        private float _minMaxRange;

        private float _currentValue = 0.5f;

        public void AddValue(float value)
        {
            _currentValue = Mathf.Clamp(_currentValue + value, 0, 1);
            
            var min = transform.position + transform.right * -_minMaxRange;
            var max = transform.position + transform.right * _minMaxRange;

            var lerped = Vector3.Lerp(min, max, _currentValue);
            _pivot.position = lerped;
        }
    }
}