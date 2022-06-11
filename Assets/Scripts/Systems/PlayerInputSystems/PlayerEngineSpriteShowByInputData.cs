using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class PlayerEngineSpriteShowByInputData : SystemBase
{
    protected override void OnUpdate()
    {
        if (TryGetSingletonEntity<Player>(out Entity playerEntity))
        {
            EntityManager dstManager = World.EntityManager;
            InputData inputData = dstManager.GetComponentData<InputData>(playerEntity);

            Entities.ForEach((SpriteRenderer sprite, in PlayerEngineSprite pes) => {

                if (inputData.moveInput.y > 0 && sprite.enabled == false)
                {
                    sprite.enabled = true;
                }

                if (inputData.moveInput.y == 0 && sprite.enabled)
                {
                    sprite.enabled = false;
                }

            }).WithoutBurst().Run();
        }
    }
}