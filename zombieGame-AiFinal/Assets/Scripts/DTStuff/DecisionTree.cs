using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTree : MonoBehaviour
{
    public DTNode root;
    private Action actionNew;
    private Action actionOld;

    void Start()
    {
        actionNew = GetComponent<ActionHerding>();
    }

    void Update()
    {
        actionNew.enabled = false;
        actionOld = actionNew;
        actionNew = actionNew.MakeDecision() as Action;
        if (actionNew == null)
        {
            actionNew = actionOld;
        }
        actionNew.enabled = true;
    }
}
