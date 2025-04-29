using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace.BusinessScripts
{
    public class BusinessSpawnSystem: IEcsRunSystem
    {
        public readonly EcsWorld World = null;
        private readonly EcsFilter<BusinessSpawnComponent> _spawnFilter = null;
        public void Run()
        {
            foreach (var i in _spawnFilter)
            {
                ref var spawnComponent = ref _spawnFilter.Get1(i);
                
                // Спавн объекта
                GameObject spawnedObject = Object.Instantiate(spawnComponent.Prefab, spawnComponent.ParentTransform);

                //Удаляем компонент после спавна. Это гарантирует что объект спавнится только 1 раз.
                _spawnFilter.GetEntity(i).Del<BusinessSpawnComponent>();
            }
        }
    }
}