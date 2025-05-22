using System.Collections.Generic;
using System.Linq;
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

    public override void Stop()
    {
        base.Stop();
        
        List<GameObject> drops = GameObject.FindGameObjectsWithTag("CoffeeDrop").ToList();

        for (int i = 0; i < drops.Count; i++)
        {
            Destroy(drops[i]);
        }
    }
}
