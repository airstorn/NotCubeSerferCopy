using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class StackContainer : MonoBehaviour
    {
        public IReadOnlyList<CubeFacade> UsedCubes => _usedCubes;

        [SerializeField] 
        private List<CubeFacade> _usedCubes = new List<CubeFacade>();

        private Vector3 _spawnOffset = Vector3.up;

        public event UnityAction<CubeFacade> Added; 
        public event UnityAction<CubeFacade> Removed;

        public void Add(CubeFacade item)
        {
            if (_usedCubes.Contains(item))
            {
                throw new Exception($"{item.name} already exists in list!");
            }
            var position = transform.position + _spawnOffset;

            if (UsedCubes.Count > 0)
            {
                position = UsedCubes.Last().Physics.position + _spawnOffset;
            }

            var instance = Instantiate(item, position, Quaternion.identity);
            instance.Initialize();
            instance.Physics.MovePosition(position);
            
            _usedCubes.Add(instance);
            
            Added?.Invoke(instance);
        }

        public void Remove(CubeFacade item)
        {
            if (_usedCubes.Contains(item) == false)
            {
                throw new ArgumentOutOfRangeException();
            }

            _usedCubes.Remove(item);
            
            Removed?.Invoke(item);
        }
    }
}