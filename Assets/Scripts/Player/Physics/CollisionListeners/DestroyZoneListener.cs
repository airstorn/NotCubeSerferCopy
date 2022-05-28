using Game.Core.Level.Interactables;
using UnityEngine;

namespace Player.Physics.CollisionListeners
{
    public class DestroyZoneListener : CollisionListener<DestroyZone>
    {
        [SerializeField] 
        private StackContainer _container;
        
        protected override void HandleInteraction(CubeFacade cube, DestroyZone interactable)
        {
            _container.Remove(cube);
            cube.gameObject.SetActive(false);
        }
    }
}