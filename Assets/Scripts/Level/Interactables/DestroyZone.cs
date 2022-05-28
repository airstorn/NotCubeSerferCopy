using Core.Interfaces;
using UnityEngine;

namespace Game.Core.Level.Interactables
{
    public class DestroyZone : MonoBehaviour,
        IInteractable
    {
        public bool CanInteract => true;
        
        public void Interact()
        {
            
        }
    }
}