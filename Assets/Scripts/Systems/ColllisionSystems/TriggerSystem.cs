using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;

public class TriggerSystem : SystemBase
{
    private struct TriggerSystemJob : ITriggerEventsJob
    {
        public BufferFromEntity<TriggerBuffer> triggersBuffer;

        public void Execute(TriggerEvent triggerEvent)
        {
            if (triggersBuffer.HasComponent(triggerEvent.EntityA))
            {
                triggersBuffer[triggerEvent.EntityA].Add(new TriggerBuffer { entity = triggerEvent.EntityB });
            }

            if (triggersBuffer.HasComponent(triggerEvent.EntityB))
            {
                triggersBuffer[triggerEvent.EntityB].Add(new TriggerBuffer { entity = triggerEvent.EntityA });
            }
        }
    }

    protected override void OnUpdate()
    {
        PhysicsWorld physicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld;
        ISimulation simulation = World.GetOrCreateSystem<StepPhysicsWorld>().Simulation;

        Entities.ForEach((DynamicBuffer<TriggerBuffer> triggersBuffer) =>
        {
            triggersBuffer.Clear();

        }).Run();

        JobHandle triggersJobHandle = new TriggerSystemJob()
        {
            triggersBuffer = GetBufferFromEntity<TriggerBuffer>()
        }
        .Schedule(simulation, ref physicsWorld, this.Dependency);

        triggersJobHandle.Complete();
    }
}