using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition
{
    public static GameObject player;
    public static GameObject companion;
    public char type;
    public Condition()
    {
        this.type = 'a';
    }
    public Condition(char c)
    {
        this.type = c;
    }
    public virtual bool Test() 
    {
        switch (type)
        {
            case 'a':
                return 0 < StateController.instance.powerups.Count;
                break;
            case 'b':
                return Vector3.Distance(companion.transform.position, player.transform.position) < 1;
                break;
            case 'c':
                return 0 == StateController.instance.powerups.Count;
                break;
            default:
                return false;
                break;
        }
    }

}
