using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    public float speed = 1.000f;
    //public float jumpHeight = 2.0f;
    [Space(5)]

    [Header("Movement")]
    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    //public KeyCode jump = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void reset() {
        speed = 1.000f;
    }

    public void increaseSpeed(float val) {
        speed += val;
        if (speed > 2.100f) {
            speed = 2.100f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(speed);
        if (Input.GetKey(forward)) {
            transform.Translate(Vector3.forward * speed * 10 * Time.deltaTime);
        }
        if (Input.GetKey(back))
        {
            transform.Translate(Vector3.back * speed * 10 * Time.deltaTime);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(Vector3.left * speed * 10 * Time.deltaTime);
        }
        if (Input.GetKey(right))
        {
            transform.Translate(Vector3.right * speed * 10 * Time.deltaTime);
        }
    }
}
