using System;
using Core.Interfaces;
using UnityEngine;

namespace Game.Core.Level.Interactables
{
    public class Collectable : MonoBehaviour,
        IInteractable
    {
        public bool CanInteract { get; private set; }

        private void Awake()
        {
            CanInteract = true;
        }

        public void Interact()
        {
            CanInteract = false;
            gameObject.SetActive(false);
        }
    }
}