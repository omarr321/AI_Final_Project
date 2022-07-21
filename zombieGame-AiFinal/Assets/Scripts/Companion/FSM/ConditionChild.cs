using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionChild : Condition
{
    private int min, max, x;
    
    public ConditionChild(int min, int max, int x)
    {
        this.min = min;
        this.max = max;
        this.x = x;
    }

    public override bool Test()
    {
        return min < x && x < max;
    }
}
