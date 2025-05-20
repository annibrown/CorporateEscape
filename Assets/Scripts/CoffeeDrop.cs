using UnityEngine;

public class CoffeeDrop : TimedObject
{
    public void Start()
    {
        minimumSecondsOnScreen = GameParameters.CoffeeDropMinimumSecondsOnScreen;
        maximumSecondsOnScreen = GameParameters.CoffeeDropMaximumSecondsOnScreen;
        base.Start();
    }
}
