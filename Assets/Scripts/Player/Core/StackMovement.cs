using System;
using System.Collections;
using BezierSolution;
using Core.Interfaces;
using UnityEngine;

namespace Player
{
    public class StackMovement : MonoBehaviour,
        IInitializable,
        IMovable
    {
        [SerializeField] 
        private BezierWalkerWithSpeed _bezierWalker;

        [SerializeField] 
        private Transform _pivot;

        [SerializeField] 
        private StackContainer _container;
        
        private Coroutine _activeMovement;
        
        public void Initialize()
        {
            _bezierWalker.Execute(0);
        }
        
        public void Stop()
        {
            if (_activeMovement != null)
            {
                StopCoroutine(MovementLoop());
            }
        }

        public void StartMove()
        {
            if(_activeMovement != null) return;
            
            _activeMovement = StartCoroutine(MovementLoop());
        }

        private IEnumerator MovementLoop()
        {
            while (true)
            {
                _bezierWalker.Execute(Time.fixedDeltaTime);
                MoveStackTo(_pivot.position, _pivot.rotation);
                yield return new WaitForFixedUpdate();
            }
        }
        
        public void MoveStackTo(Vector3 position, Quaternion rotation)
        {
            foreach (var cube in _container.UsedCubes)
            {
                var physics = cube.Physics;
                var origin = new Vector3(position.x, physics.position.y, position.z);
                physics.MovePosition(origin);
                physics.MoveRotation(rotation);
            }
        }
    }
}