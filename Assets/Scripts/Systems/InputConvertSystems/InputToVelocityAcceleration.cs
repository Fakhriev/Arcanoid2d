using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class InputToVelocityAcceleration : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref VelocityAcceleration velocityAcceleration, in Rotation rotation, in InputData inputData) =>
        {
            if (inputData.moveInput.y > 0)
            {
                velocityAcceleration.vector = math.mul(rotation.Value, inputData.moveInput);
            }

            if (inputData.moveInput.y == 0)
            {
                velocityAcceleration.vector = float3.zero;
            }

            if (inputData.moveInput.y < 0)
            {
                //velocityAcceleration.vector = -velocity.vector;
            }

        }).Schedule();
    }
}