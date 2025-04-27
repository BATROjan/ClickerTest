using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace.BusinessScripts
{
    public struct BusinessSpawnComponent : IEcsIgnoreInFilter
    {
        public GameObject Prefab;
        public Transform ParentTransform;
    }
}