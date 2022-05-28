using Game.Core.Level.Interactables;
using UnityEngine;

namespace Player.Physics.CollisionListeners
{
    public class ObstacleListener : CollisionListener<Obstacle>
    {
        [SerializeField] 
        private StackContainer _container;

        [SerializeField] 
        private float _interactionAngle = 40;
        
        protected override void HandleInteraction(CubeFacade cube, Obstacle interactable)
        {
            var direction = interactable.transform.position - cube.transform.position;

            var dot = Vector3.Angle(cube.transform.forward, direction);

            if (Mathf.Abs(dot) < _interactionAngle)
            {
                _container.Remove(cube);
            }
        }
    }
}