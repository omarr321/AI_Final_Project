using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : DTNode
{
    public bool activated = false;
    
    public override DTNode MakeDecision()
    {
        return this;
    }

    public virtual void LateUpdate()
    {
        if (!activated)
        {
            return;
        }
        //Implement Agent behaviors here
    }
}
