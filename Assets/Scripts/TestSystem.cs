using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class TestSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, in Rotation rotation) => {

        }).Schedule();
    }
}
