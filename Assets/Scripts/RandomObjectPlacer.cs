using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class RandomObjectPlacer : MonoBehaviour
{
    public GameObject PrefabToPlace;

    public float MinimumSecondsToCreate;
    public float MaximumSecondsToCreate;
    
    private bool isWaitingToCreate = false;
    
    void Update()
    {
        if (!isWaitingToCreate)
        {
            StartCoroutine(CountdownUntilCreation());
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        isWaitingToCreate = true;
        float secondsToWait = Random.Range(
            MinimumSecondsToCreate, 
            MaximumSecondsToCreate);
        yield return new WaitForSeconds(secondsToWait);
        Create();
        isWaitingToCreate = false;
    }

    public virtual void Create()
    {
        Vector3 randomPosition = 
            SpriteTools.RandomLocationWorldSpace();
        Instantiate(PrefabToPlace, randomPosition, Quaternion.identity);
    }
}
