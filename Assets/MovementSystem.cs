using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    sealed class MovementSystem : IEcsRunSystem
    {
        public readonly EcsWorld World = null;
        private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> movableFilter = null;
        
        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var modelCompoment = ref movableFilter.Get1(i);
                ref var movableCompoment = ref movableFilter.Get2(i);
                ref var directionCompoment = ref movableFilter.Get3(i);

                ref var direction = ref directionCompoment.Direction;
                ref var transform = ref modelCompoment.PlayerTransform;

                ref var characterController = ref movableCompoment.CharacterController;
                ref var speed = ref movableCompoment.Speed;

                var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);
                characterController.Move(rawDirection * speed * Time.deltaTime);

            }
        }
    }
}