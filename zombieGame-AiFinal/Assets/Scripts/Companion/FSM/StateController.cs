using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public List<powerup> powerups = new List<powerup>();
    public static StateController instance;
    public void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Error");
        }
        else
        {
            instance = this;
        }
    }
}
