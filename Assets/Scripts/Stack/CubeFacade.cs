using System;
using Core.Interfaces;
using Player.Physics;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubeFacade : MonoBehaviour,
        IInitializable
    {
        public Rigidbody Physics { get; private set; }
        public CollisionInteractor Interactor { get; private set; }
        
        public void Initialize()
        {
            Physics = GetComponent<Rigidbody>();
            Interactor = GetComponent<CollisionInteractor>();
            
            Interactor.Initialize();
        }

        private void FixedUpdate()
        {
            Physics.AddForce(UnityEngine.Physics.gravity * Physics.mass);
        }
    }
}