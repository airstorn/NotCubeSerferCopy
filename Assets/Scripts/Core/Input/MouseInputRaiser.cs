using Core.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Core
{
    public class MouseInputRaiser : MonoBehaviour,
        IInitializable
    {
        [SerializeField] 
        private float _valueMultiplier;
        
        private Camera _camera;
        private Vector2 _delta;
        private Vector2 _pressPosition;
        
        public event UnityAction Pressed;
        public event UnityAction Released;
        public event UnityAction<Vector2> DragDeltaChanged;

        public void Initialize()
        {
            _camera = Camera.main;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _pressPosition = Input.mousePosition;
                Pressed?.Invoke();
            }

            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = Input.mousePosition;

                _delta = mousePosition - _pressPosition;
                
                _pressPosition = mousePosition;

                DragDeltaChanged?.Invoke(_delta * _valueMultiplier);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Released?.Invoke();
            }
        }
    }
}
