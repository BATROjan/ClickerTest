using DefaultNamespace.BusinessScripts;
using DefaultNamespace.IncomeScripts;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace DefaultNamespace
{
    public class GameStartup : MonoBehaviour
    {
        public GameObject prefab;
        public Transform ParTransform;
        
        [SerializeField] private IncomeConfig incomeConfig;
        
        private EcsWorld _world;
        private EcsSystems _systems;
        private RunTimeData _runTimeData;
        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _runTimeData = new RunTimeData();
            _runTimeData.ParentTransform = ParTransform;
            
            AddInjections();
            AddOneFrames();
            AddSystems();

            _systems
                .Inject(incomeConfig)
                .Inject(_runTimeData);

            _systems.ConvertScene();

            _systems.Init();
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

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        
            _systems = null;
            _world = null;
        }
    }
}