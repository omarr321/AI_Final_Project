using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHerding: Action
{
    public override DTNode MakeDecision()
    {
        return GetComponent<DecisionHerding>().GetBranch();
    }

    public override void LateUpdate()
    {
        //TODO: Write the code here so that the zombie heads towards the cloest zombies
    }
}
