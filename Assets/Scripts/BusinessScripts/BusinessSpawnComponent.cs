using System;
using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace.BusinessScripts
{
    [Serializable]
    public struct BusinessSpawnComponent 
    {
        public GameObject Prefab;
        public Transform ParentTransform;
    }
}