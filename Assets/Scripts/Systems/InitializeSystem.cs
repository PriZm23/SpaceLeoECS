using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShip
{
    public class InitializeSystem : Injects, IEcsInitSystem
    {
        public void Init()
        {
            Runtime.MainCamera = Camera.main;

            var actors = Object.FindObjectsOfType<Actor>();
            foreach (var actor in actors)
                actor.Init(World);
        }
    }
}