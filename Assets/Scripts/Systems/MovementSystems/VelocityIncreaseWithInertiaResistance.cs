using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

public class VelocityIncreaseWithInertiaResistance : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities
            .ForEach((ref Velocity velocity, in VelocityAcceleration velocityAcceleration, in InertiaResistance inertiaResistance) => {

                if (velocity.isDecreasing == false)
                {
                    velocity.vector += velocityAcceleration.vector * (velocityAcceleration.speed + inertiaResistance.value) * deltaTime;
                    float velocityMagnitude = math.sqrt(math.pow(velocity.vector.x, 2) + math.pow(velocity.vector.y, 2));

                    if (velocityMagnitude != 0 && velocityMagnitude > velocity.maximum)
                    {
                        velocity.vector = math.normalize(velocity.vector) * velocity.maximum;
                    }
                }

            }).Schedule();
    }
}