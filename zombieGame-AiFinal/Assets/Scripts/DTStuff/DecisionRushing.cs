using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionRushing : Decision
{
    public override Action GetBranch()
    {
        return nodeTrue;
    }
}