using DefaultNamespace.BusinessScripts;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace DefaultNamespace
{
    public class GameStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        public GameObject prefab;
        public Transform ParTransform;
        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            AddInjections();
            AddOneFrames();
            AddSystems();

            _systems.ConvertScene();
        
            _systems.Init();
            CreatSpawn(prefab, ParTransform);
        }

        private void AddSystems()
        {
            _systems.Add(new BusinessSpawnSystem());
        }

        private void AddOneFrames()
        {
            
        }

        private void AddInjections()
        {
            
        }
        void Update()
        {
            _systems.Run();
        }

        private void CreatSpawn(GameObject prefab, Transform transform)
        {
           var entity = _world.NewEntity();
         
            entity.Get<BusinessSpawnComponent>() = new BusinessSpawnComponent
            {
                Prefab = prefab,
                ParentTransform = transform
            };
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        
            _systems = null;
            _world = null;
        }
    }
}