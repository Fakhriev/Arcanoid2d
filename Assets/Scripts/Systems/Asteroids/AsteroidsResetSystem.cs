using Unity.Entities;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class AsteroidsResetSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;

        Entities.ForEach((Entity entity, ref Movable movable, ref Rotative rotative, in AsteroidReset asteroidReset) => 
        {
            //RND Movable
            float randomSpeed = Random.Range(asteroidReset.minimalMoveSpeed, asteroidReset.maximalMoveSpeed);
            float randomAngle = Random.Range(0, 360);

            float radians = math.radians(randomAngle);
            float3 direction = new float3(math.cos(radians), math.sin(radians), 0);

            movable.speed = randomSpeed;
            movable.moveVector = direction;
            dstManager.SetComponentData(entity, movable);


            //RND Rotative
            float3 randomDirection = new float3(Random.Range(asteroidReset.minimalRotationDirection.x, asteroidReset.maximalRotationDirection.x),
                                                Random.Range(asteroidReset.minimalRotationDirection.y, asteroidReset.maximalRotationDirection.y),
                                                Random.Range(asteroidReset.minimalRotationDirection.z, asteroidReset.maximalRotationDirection.z));

            rotative.rotateDirection = randomDirection;
            rotative.rotationSpeed = Random.Range(asteroidReset.minimalRotationSpeed, asteroidReset.maximalRotationSpeed);
            dstManager.SetComponentData(entity, rotative);

            //
            dstManager.RemoveComponent<AsteroidReset>(entity);

        //}).Schedule();
        }).WithStructuralChanges().Run();
    }
}