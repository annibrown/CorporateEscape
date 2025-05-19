using System.Collections;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    protected float minimumSecondsOnScreen;
    protected float maximumSecondsOnScreen;
    
    public void Start()
    {
        StartCoroutine(CountdownUntilDeath());
    }

    IEnumerator CountdownUntilDeath()
    {
        float secondsToWait = Random.Range(
            minimumSecondsOnScreen, maximumSecondsOnScreen);
        yield return new WaitForSeconds(secondsToWait);
        Destroy(gameObject);
    }
}
