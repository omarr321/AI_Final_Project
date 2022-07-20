using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRushing: Action
{
    public bool newActivated = false;
    public float speed = 10.0f;

    public override DTNode MakeDecision()
    {
        return GetComponent<DecisionRushing>().GetBranch();
    }

    public override void LateUpdate()
    {
        if (!newActivated)
        {
            return;
        }

        GameObject Player = GameObject.Find("Player");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.LookAt(Player.transform.position);
    }
}
