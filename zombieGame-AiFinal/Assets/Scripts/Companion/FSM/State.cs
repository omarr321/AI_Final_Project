using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public GameObject player;
    public GameObject companion;
    public List<Transition> transitions;
    
    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public virtual void LateUpdate()
    {

    }
    public virtual void Awake()
    {

    }
}
