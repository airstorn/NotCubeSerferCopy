using Core.Interfaces;
using Game.Core;
using UnityEngine;

namespace Player
{
    public class InputHandler : MonoBehaviour,
        IInitializable
    {
        [SerializeField] 
        private MouseInputRaiser _raiser;

        [SerializeField] 
        private HorizontalMovement _horizontalMovement;

        [SerializeField] 
        private StackMovement _movement;


        public void Initialize()
        {
            _raiser.Pressed += OnPressed;
            _raiser.DragDeltaChanged += OnMoved;
        }

        private void OnMoved(Vector2 delta)
        {
            _horizontalMovement.AddValue(delta.x);
        }

        private void OnPressed()
        {
            _movement.StartMove();
            _raiser.Pressed -= OnPressed;
        }
    }
}