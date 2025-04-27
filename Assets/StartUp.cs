using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class StartUp : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;
    void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        AddInjections();
        AddOneFrames();
        AddSystems();

        _systems.ConvertScene();
        
        _systems.Init();
    }

    private void AddOneFrames()
    {
       
    }

    private void AddSystems()
    {
        _systems.Add(new PlayerInputSystem())
            .Add(new MovementSystem());
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
