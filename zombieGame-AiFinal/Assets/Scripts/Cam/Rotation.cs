using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("General")]
    public float sensitivity = 1.0f;
    public bool diableX = false;
    public bool diableY = false;
    public bool invertY = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!diableX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * 10 * Time.deltaTime, 0);
        }
        if (!diableY) {
            if (invertY) {
                transform.Rotate(Input.GetAxis("Mouse Y") * sensitivity * 10 * Time.deltaTime, 0, 0);
            }
            else {
                transform.Rotate(-1 * Input.GetAxis("Mouse Y") * sensitivity * 10 * Time.deltaTime, 0, 0);
            }
        }
    }
}
