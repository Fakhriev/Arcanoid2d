using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

public class InertiaResistanceValueCalculation : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref InertiaResistance inertiaResistance, in Velocity velocity, in VelocityAcceleration velocityAcceleration) =>
        {
            if (velocity.vector.Equals(float3.zero) == false && velocityAcceleration.vector.Equals(float3.zero) == false)
            {
                float3 vVector = velocity.vector;
                float3 aVector = velocityAcceleration.vector;

                float scalar = vVector.x * aVector.x + vVector.y * aVector.y + vVector.z * aVector.z;
                float velocityMagnitude = math.sqrt(math.pow(vVector.x, 2) + math.pow(vVector.y, 2) + math.pow(vVector.z, 2));
                float accelerationMagnitude = math.sqrt(math.pow(aVector.x, 2) + math.pow(aVector.y, 2) + math.pow(aVector.z, 2));

                float angleCos = math.clamp(scalar / (velocityMagnitude * accelerationMagnitude), -1, 1);
                float degreesAngle = math.degrees( math.acos(angleCos) );
                inertiaResistance.value = math.lerp(0, inertiaResistance.maximum, degreesAngle / 180);
            }
            else
            {
                inertiaResistance.value = 0;
            }

        }).Schedule();
    }
}