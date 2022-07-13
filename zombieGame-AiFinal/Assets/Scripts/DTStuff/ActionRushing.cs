using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRushing: DTNode
{
    public bool activated = false;
    
    public override DTNode MakeDecision()
    {
        // TODO: Add decision logic here
        return this;
    }

    public virtual void LateUpdate()
    {
        if (!activated)
        {
            return;
        }
        //TODO: Implement Agent behaviors here
    }
}
