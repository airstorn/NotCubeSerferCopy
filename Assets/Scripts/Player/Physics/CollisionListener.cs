using Core.Interfaces;
using UnityEngine;

namespace Player.Physics
{
    public abstract class CollisionListener : MonoBehaviour,
        IInitializable
    {
        public abstract void Initialize();
    }
    
    [RequireComponent(typeof(StackCollisionsMediator))]
    public abstract class CollisionListener<T> : CollisionListener where T : IInteractable
    {
        private StackCollisionsMediator _mediator;

        public override void Initialize()
        {
            _mediator = GetComponent<StackCollisionsMediator>();
            _mediator.CubeInteracted += OnInteracted;
        }

        private void OnInteracted(CubeFacade facade, IInteractable interatable)
        {
            if (interatable is T obj)
            {
                HandleInteraction(facade, obj);
            }
        }

        protected abstract void HandleInteraction(CubeFacade cube, T interactable);
    }
}