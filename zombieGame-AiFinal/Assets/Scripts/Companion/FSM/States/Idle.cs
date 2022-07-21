using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public override void Update()
    {
        target = GameObject.FindGameObjectsWithTag("powerup");
        companion.transform.position = Vector3.MoveTowards(companion.transform.position, player.transform.position, 1.0f);
    }
    public override void LateUpdate()
    {
        foreach (Transition t in transitions)
        {
            if (t.condition.Test())
            {
                t.target.enabled = true;
                this.enabled = false;
                return;
            }
        }
    }
    /*
    public override void Awake()
    {
        this.transitions = new List<Transition>();
    }
    */
}
