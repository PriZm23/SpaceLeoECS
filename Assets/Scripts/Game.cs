using Leopotam.Ecs;
using UnityEngine;

namespace SpaceShip 
{
    sealed class Game : MonoBehaviour 
    {
        EcsWorld _world;
        EcsSystems _systems;

        public StaticData _static;
        public SceneData _scene;

        void Start () 
        {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            var _runtime = new RuntimeData();

            _systems

                .Add(new InitializeSystem())
                // .Add (new TestSystem2 ())

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () 
        {
            _systems?.Run ();
        }

        void OnDestroy () 
        {
            if (_systems != null) 
            {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}