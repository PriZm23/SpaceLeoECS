using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace SpaceShip
{
    public abstract class Actor : MonoBehaviour
    {
        public EcsEntity Entity;
        public EcsWorld World;

        public void Init(EcsWorld world)
        {
            World = world;
            Entity = World.NewEntity();
            Entity.Get<TransformRef>();
        }

        public void SelfDestroy(float delay = 0f) => StartCoroutine(SelfDestroyCoroutine(delay));

        public IEnumerator SelfDestroyCoroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            Entity.Destroy();
            Destroy(gameObject);
        }
    }
}
