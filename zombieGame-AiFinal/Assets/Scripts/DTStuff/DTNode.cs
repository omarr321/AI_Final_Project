using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTNode : MonoBehaviour
{
    public virtual DTNode MakeDecision()
    {
        return null;
    }
}
