using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;
using BoxCollider = Unity.Physics.BoxCollider;

public class PortalsCollidersChangeByScreenSize : SystemBase
{
    protected override void OnStartRunning()
    {
        EntityManager dstManager = World.EntityManager;

        Entity mainCameraEntity = GetSingletonEntity<Camera>();
        Camera mainCamera = dstManager.GetComponentObject<Camera>(mainCameraEntity);

        float width = Screen.width;
        float height = Screen.height;

        Vector2 leftDownPoint = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightUpPoint = mainCamera.ScreenToWorldPoint(new Vector3(width, height, 0));

        float horizontalSize = rightUpPoint.x - leftDownPoint.x;
        float verticalSize = rightUpPoint.y - leftDownPoint.y;

        Entities
            .ForEach((Entity entity, ref PhysicsCollider physicsCollider, in PortalPreparation preparation) => {

                float3 position = new float3(0, 0, 0);
                float3 size = new float3(1, 1, 1);
                float3 moveValue = new float3(0, 0, 0);

                switch (preparation.side)
                {
                    case PortalSide.Left:
                        position = new float3(leftDownPoint.x - 0.5f - preparation.sideDelta, 0, 0);
                        size.y = verticalSize + preparation.sideDelta * 2;
                        moveValue.x = horizontalSize;
                        break;

                    case PortalSide.Right:
                        position = new float3(rightUpPoint.x + 0.5f + preparation.sideDelta, 0, 0);
                        size.y = verticalSize + preparation.sideDelta * 2;
                        moveValue.x = -horizontalSize;
                        break;

                    case PortalSide.Up:
                        position = new float3(0, rightUpPoint.y + 0.5f + preparation.sideDelta, 0);
                        size.x = horizontalSize + preparation.sideDelta * 2;
                        moveValue.y = -verticalSize;
                        break;

                    case PortalSide.Down:
                        position = new float3(0, leftDownPoint.y - 0.5f - preparation.sideDelta, 0);
                        size.x = horizontalSize + preparation.sideDelta * 2;
                        moveValue.y = verticalSize;
                        break;
                }

                unsafe
                {
                    BoxCollider* boxCollider = (BoxCollider*)physicsCollider.ColliderPtr;
                    BoxGeometry boxGeometry = boxCollider->Geometry;

                    boxGeometry.Center = position;
                    boxGeometry.Size = size;

                    boxCollider->Geometry = boxGeometry;
                }

                dstManager.RemoveComponent<PortalPreparation>(entity);
                dstManager.AddComponentData(entity, new Portal()
                {
                    moveValue = moveValue
                });

            }).WithStructuralChanges().Run();
    }

    protected override void OnUpdate()
    {

    }
}