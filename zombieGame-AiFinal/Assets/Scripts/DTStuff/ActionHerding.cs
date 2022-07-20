using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHerding: Action
{
    public bool newActivated = false;
    
    public override DTNode MakeDecision()
    {
        // TODO: Add decision logic here
        return this;
    }

    public override void LateUpdate()
    {
        if (!newActivated)
        {
            return;
        }
        //TODO: Implement Agent behaviors here
    }
}
