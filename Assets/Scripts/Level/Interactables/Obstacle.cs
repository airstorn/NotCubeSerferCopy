using Core.Interfaces;
using UnityEngine;

namespace Game.Core.Level.Interactables
{
    public class Obstacle : MonoBehaviour,
        IInteractable
    {
        public bool CanInteract => true;

        public void Interact()
        {
            
        }
    }
}