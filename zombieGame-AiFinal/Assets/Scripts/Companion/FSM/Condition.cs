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
        player = GameObject.FindGameObjectWithTag("Player");
        companion = GameObject.FindGameObjectWithTag("Companion");
    }
    public Condition(char c)
    {
        this.type = c;
        player = GameObject.FindGameObjectWithTag("Player");
        companion = GameObject.FindGameObjectWithTag("Companion");
    }
    public virtual bool Test() 
    {
        switch (type)
        {
            case 'a':
                return 0 < StateController.instance.powerups.Count;
                break;
            case 'b':
                return Vector3.Distance(companion.transform.position, player.transform.position) < 2.5;
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
