using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace.BusinessScripts
{
    public class BusinessSpawnSystem: IEcsRunSystem
    {
        private EcsFilter<BusinessSpawnComponent> _spawnFilter = null;
        public void Run()
        {
            foreach (var i in _spawnFilter)
            {
                ref var spawnFilter = ref _spawnFilter.Get1(i);
                GameObject businessObject = Object.Instantiate(spawnFilter.Prefab, spawnFilter.ParentTransform);
                _spawnFilter.GetEntity(i).Destroy();
            }
        }
    }
}