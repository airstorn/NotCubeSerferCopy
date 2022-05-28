using Game.Core.Level.Interactables;
using UnityEngine;

namespace Player.Physics.CollisionListeners
{
    public class CollectableListener : CollisionListener<Collectable>
    {
        [SerializeField] 
        private ActorFacade _facade;
        
        protected override void HandleInteraction(CubeFacade cube, Collectable interactable)
        {
            if(interactable.CanInteract == false) return;
            interactable.Interact();
            _facade.AddCube();
        }
    }
}