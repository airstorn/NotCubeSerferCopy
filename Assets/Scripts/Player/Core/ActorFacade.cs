using System;
using System.Collections;
using Core.Interfaces;
using Game.Core;
using Player.Physics;
using UnityEngine;

namespace Player
{
    public class ActorFacade : MonoBehaviour,
        IInitializable
    {
        [SerializeField]
        private StackMovement _movement;
        
        [SerializeField]
        private StackContainer _container;

        [SerializeField] 
        private StackCollisionsMediator _stackCollisionsMediator;
        
        [SerializeField]
        private InputHandler _input;
        
        [SerializeField]
        private CubeFacade _reference;
        

        private void Start()
        {
            Application.targetFrameRate = 60;
            
            Initialize();
        }

        public void Initialize()
        {
            _movement.Initialize();
            _stackCollisionsMediator.Initialize();
            _input.Initialize();
            
            AddCube();
        }

        public void AddCube()
        {
            _container.Add(_reference);
        }
    }
}