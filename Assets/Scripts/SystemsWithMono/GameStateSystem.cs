using Unity.Entities;
using UnityEngine.SceneManagement;

[UpdateBefore(typeof(DestroySystem))]
[UpdateAfter(typeof(PlayerCollidesEnemy))]
public class GameStateSystem : SystemBase
{
    protected override void OnUpdate()
    {
        if(SceneManager.GetActiveScene().name.Equals("Game"))
        {
            if(TryGetSingletonEntity<Player>(out Entity playerEntity) && HasComponent<NeedToDestroy>(playerEntity))
            {
                GameManager.instance.Loose();
            }
        }
    }
}
