using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : DTNode
{
    public Action nodeTrue;
    public Action nodeFalse;

    public virtual Action GetBranch()
    {
        return null;
    }
}
