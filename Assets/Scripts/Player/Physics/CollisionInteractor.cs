using System;
using Core.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Physics
{
    [RequireComponent(typeof(CubeFacade))]
    public class CollisionInteractor : MonoBehaviour,
        IInitializable
    {
        private CubeFacade _facade;
        
        public event UnityAction<CubeFacade, IInteractable> CollidedWithInteractable; 
        
        public void Initialize()
        {
            _facade = GetComponent<CubeFacade>();
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.TryGetComponent(out IInteractable interactable))
            {
                CollidedWithInteractable?.Invoke(_facade, interactable);
            }
        }
    }
}