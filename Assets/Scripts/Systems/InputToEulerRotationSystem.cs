using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class InputToEulerRotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotative rotative, in InputData inputData) => {

            rotative.eulerRotation = new float3(0, 0, inputData.rotationInput.z);

        }).Schedule();
    }
}