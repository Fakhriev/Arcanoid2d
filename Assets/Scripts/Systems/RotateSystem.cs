using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class RotateSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Rotation rotation, in Rotative rotative) => {

            quaternion quat = math.mul(rotation.Value, quaternion.RotateZ(rotative.eulerRotation.z * rotative.rotationSpeed * deltaTime));
            rotation.Value = quat;

        }).Schedule();
    }
}