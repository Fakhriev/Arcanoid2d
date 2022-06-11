using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

public class InputToRotateDirection : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotative rotative, in InputData inputData) => {

            rotative.rotateDirection = new float3(0, 0, inputData.rotationInput.z);

        }).Schedule();
    }
}