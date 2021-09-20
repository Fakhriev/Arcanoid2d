using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class InputToMoveVectorSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Movable movable , in Rotation rotation, in InputData inputData) => {

            movable.moveVector = math.mul(rotation.Value, inputData.moveInput);

        }).Schedule();
    }
}