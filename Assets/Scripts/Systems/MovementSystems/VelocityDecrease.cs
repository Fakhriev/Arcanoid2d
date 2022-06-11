using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

public class VelocityDecrease : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Velocity velocity, in VelocityDeacceleration velocityDeacceleration) => {

            if (velocity.isDecreasing)
            {
                float velocityMagnitude = math.sqrt(math.pow(velocity.vector.x, 2) + math.pow(velocity.vector.y, 2));
                float newVelocityMagnitude = velocityMagnitude - (velocityDeacceleration.speed * deltaTime);

                if(newVelocityMagnitude <= velocityDeacceleration.stopThreshold)
                {
                    newVelocityMagnitude = 0;
                }

                velocity.vector *= newVelocityMagnitude / velocityMagnitude;
            }

        }).Schedule();
    }
}