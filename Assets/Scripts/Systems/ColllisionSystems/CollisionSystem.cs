using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;

public class CollisionSystem : SystemBase
{
    private struct CollisionSystemJob : ICollisionEventsJob
    {
        public BufferFromEntity<CollisionBuffer> collisionsBuffer;

        public void Execute(CollisionEvent collisionEvent)
        {
            if (collisionsBuffer.HasComponent(collisionEvent.EntityA))
            {
                collisionsBuffer[collisionEvent.EntityA].Add(new CollisionBuffer { entity = collisionEvent.EntityB });
            }

            if (collisionsBuffer.HasComponent(collisionEvent.EntityB))
            {
                collisionsBuffer[collisionEvent.EntityB].Add(new CollisionBuffer { entity = collisionEvent.EntityA });
            }
        }
    }

    protected override void OnUpdate()
    {
        PhysicsWorld physicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld;
        ISimulation simulation = World.GetOrCreateSystem<StepPhysicsWorld>().Simulation;

        Entities.ForEach((DynamicBuffer<CollisionBuffer> collisionBuffer) =>
        {
            collisionBuffer.Clear();

        }).Run();

        JobHandle collisionJobHandle = new CollisionSystemJob()
        {
            collisionsBuffer = GetBufferFromEntity<CollisionBuffer>()
        }
        .Schedule(simulation, ref physicsWorld, this.Dependency);

        collisionJobHandle.Complete();
    }
}