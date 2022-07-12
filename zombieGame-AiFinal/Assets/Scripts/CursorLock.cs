using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    public CursorLockMode lockType;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = lockType;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
