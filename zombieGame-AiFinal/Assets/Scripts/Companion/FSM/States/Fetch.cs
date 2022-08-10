using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fetch : State
{
    public override void Update()
    {
        if(StateController.instance.powerups.Count > 0)
        {
            companion.transform.position = Vector3.MoveTowards(companion.transform.position, StateController.instance.powerups[0].transform.position, 5.0f*Time.deltaTime);
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
    public override void Awake()
    {
        this.transitions = new List<Transition>();
        Condition home = new Condition('c');
        State h = companion.GetComponent<Homeward>();
        this.transitions.Add(new Transition(home, h));
    }
}
