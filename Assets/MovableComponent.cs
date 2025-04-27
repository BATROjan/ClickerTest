using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct MovableComponent
    {
        public CharacterController CharacterController;
        public float Speed;
    }
}