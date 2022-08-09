using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : DTNode
{
    public float speed = 4.0f;

    public override DTNode MakeDecision()
    {
        return this;
    }

    public virtual void LateUpdate()
    {
    }
}
