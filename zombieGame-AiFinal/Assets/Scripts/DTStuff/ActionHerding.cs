using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHerding: Action
{
    Collider[] zombeanSphere;
    int i=0;
    public static List<GameObject> Test = new List<GameObject>();
    public override DTNode MakeDecision()
    {
        return GetComponent<DecisionHerding>().GetBranch();
    }

    public override void LateUpdate()
    {
        int count = 0;
        zombeanSphere=Physics.OverlapSphere(transform.position, 0.5f);
        foreach (var zombeanNeighbor in zombeanSphere)
        {
            if (zombeanNeighbor.tag=="clickable"){
                count++;
                zombeanNeighbor.transform.position=Vector3.MoveTowards(zombeanNeighbor.transform.position, transform.position, 1.0f);
            }
        }

        if (count > 3) {
           zombeanNeighbor.transform.position=Vector3.MoveTowards(zombeanNeighbor.transform)
        } else {
           
            //TODO: GO to cloest zombean
        }
    }
}
