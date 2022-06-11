using Unity.Entities;
using Unity.Transforms;
using UnityEngine.SceneManagement;

public class ParametresUpdate : SystemBase
{
    protected override void OnUpdate()
    {
        if (SceneManager.GetActiveScene().name.Equals("Game"))
        {
            if (TryGetSingletonEntity<Player>(out Entity playerEntity))
            {
                Translation playerTranslation = GetComponent<Translation>(playerEntity);
                Rotation rotation = GetComponent<Rotation>(playerEntity);

                Velocity playerVelocity = GetComponent<Velocity>(playerEntity);
                CanLaserShoot playerLaser = GetComponent<CanLaserShoot>(playerEntity);

                GameManager.instance.UpdateParametres(playerTranslation, rotation, playerVelocity, playerLaser);
            }
        }
    }
}
