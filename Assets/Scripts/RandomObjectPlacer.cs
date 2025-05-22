using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RandomObjectPlacer : MonoBehaviour
{
    public GameObject PrefabToPlace;

    public float MinimumSecondsToCreate;
    public float MaximumSecondsToCreate;
    
    private bool isWaitingToCreate = false;

    private bool isRunning = true;
    
    private Coroutine coroutine;
    
    void Update()
    {
        if (isRunning)
        {
            if (!isWaitingToCreate)
            {
                coroutine = StartCoroutine(CountdownUntilCreation());
            }
        }
    }

    public virtual void Stop()
    {
        isRunning = false;
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    public void Restart()
    {
        isWaitingToCreate = false;
        isRunning = true;
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
