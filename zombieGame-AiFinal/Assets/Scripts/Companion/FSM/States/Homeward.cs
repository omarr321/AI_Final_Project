using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homeward : State
{
    public override void Update()
    {
        bool flag = false;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2);
        foreach (var hit in hitColliders) {
            if (hit.name == "Player") {
                flag = true;
            }
        }
        if (!flag) 
        {
            Debug.Log(player.transform.position);
            companion.transform.position = Vector3.MoveTowards(companion.transform.position, player.transform.position, 5.0f*Time.deltaTime);
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
        Condition idle = new Condition('b');
        State i = companion.GetComponent<Idle>();
        this.transitions.Add(new Transition(idle, i));
        Condition fetch = new Condition('a');
        State f = companion.GetComponent<Fetch>();
        this.transitions.Add(new Transition(fetch, f));
    }
}
