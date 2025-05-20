using UnityEngine;

public class CoffeeDropPlacer : RandomObjectPlacer
{
    public void Start()
    {
        MinimumSecondsToCreate = GameParameters.CoffeeDropMinimumSecondsToCreate;
        MaximumSecondsToCreate = GameParameters.CoffeeDropMaximumSecondsToCreate;
    }

    public override void Create()
    {
        Vector3 randomPosition = 
            SpriteTools.RandomTopOfScreenLocationWorldSpace();
        Instantiate(PrefabToPlace, randomPosition, Quaternion.identity);
    }
}
