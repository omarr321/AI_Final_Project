using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fetch : State
{
    public override void Update()
    {
        if(powerups.Count != 0)
        {
            companion.transform.position = Vector3.MoveTowards(companion.transform.position, powerups[0].transform.position, 1.0f);
        }
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
    public override void OnEnable()
    {
        
    }
    public override void Awake()
    {
        this.transitions = new List<Transition>();

    }
}
