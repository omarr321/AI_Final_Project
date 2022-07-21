using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public Condition condition;
    public State target;

    public Transition(Condition c, State s)
    {
        this.condition = c;
        this.target = s;
    }
}
