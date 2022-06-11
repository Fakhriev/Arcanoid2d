using Unity.Entities;
using Unity.Jobs;

public class PlayerCollidesEnemy : SystemBase
{
    private EntityManager _dstManager;
    private bool _playerDead;

    protected override void OnStartRunning()
    {
        _dstManager = World.EntityManager;
    }

    protected override void OnUpdate()
    {
        Entities
        .WithNone<NeedToDestroy>()
        .ForEach((DynamicBuffer<CollisionBuffer> collisionBuffer, Entity entity, in Player player) =>
        {
            for (int i = 0; i < collisionBuffer.Length; i++)
            {
                Entity hitEntity = collisionBuffer[i].entity;

                if (HasComponent<Enemy>(hitEntity) && HasComponent<NeedToDestroy>(hitEntity) == false)
                {
                    _playerDead = true;
                }
            }

        }).WithoutBurst().Run();

        if (_playerDead)
        {
            Entity playerEntity = GetSingletonEntity<Player>();
            _dstManager.AddComponent<NeedToDestroy>(playerEntity);

            EntityQuery playerPartsQuery = GetEntityQuery(ComponentType.ReadOnly<PlayerPart>());
            _dstManager.AddComponent<NeedToDestroy>(playerPartsQuery);

            _playerDead = false;
        }
    }
}