using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRushing: Action
{
    public override DTNode MakeDecision()
    {
        return GetComponent<DecisionRushing>().GetBranch();
    }

    public override void LateUpdate()
    {
        GameObject Player = GameObject.Find("Player");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.LookAt(Player.transform.position);
    }
}
