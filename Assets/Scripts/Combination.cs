using UnityEngine;
using System.Collections.Generic;

public class Combination : MonoBehaviour
{
    private List<int> combination;
    private List<int> defaultCombination = new List<int>{1, 2, 3, 4};

    public Combination()
    {
        combination = CombinationLoader.Load(defaultCombination);
    }

    public int GetCombinationDigit(int digitNumber)
    {
        if (digitNumber < 0 || digitNumber >= combination.Count)
            return 0;
        return combination[digitNumber];
        
    }

    public int GetCombinationLength()
    {
        return combination.Count;
    }
}