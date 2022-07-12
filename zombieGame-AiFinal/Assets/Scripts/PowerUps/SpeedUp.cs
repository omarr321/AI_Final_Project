using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float val = 0.010f;
    public GameObject player;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
            timer += Time.deltaTime;
            if (timer % 60 >= 10)
            {
                Destroy(gameObject);
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            other.gameObject.GetComponent<Movement>().increaseSpeed(val);
            Destroy(gameObject);
        }
    }
}
