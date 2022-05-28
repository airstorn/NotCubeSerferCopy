using Core.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Physics
{
    public class StackCollisionsMediator : MonoBehaviour,
        IInitializable
    {
        [SerializeField]
        private StackContainer _container;

        public event UnityAction<CubeFacade, IInteractable> CubeInteracted; 

        public void Initialize()
        {
            _container.Added += OnAdded;
            _container.Removed += OnRemoved;

            var listeners = GetComponents<CollisionListener>();

            foreach (var listener in listeners)
            {
                listener.Initialize();
            }
        }
        
        private void OnAdded(CubeFacade cube)
        {
            cube.Interactor.CollidedWithInteractable += OnCubeInteracted;
        }
        
        private void OnRemoved(CubeFacade cube)
        {
            cube.Interactor.CollidedWithInteractable -= OnCubeInteracted;
        }
        
        private void OnCubeInteracted(CubeFacade cube, IInteractable interactable)
        {
            CubeInteracted?.Invoke(cube, interactable);
        }
    }
}