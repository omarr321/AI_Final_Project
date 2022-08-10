using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : powerup
{
    public float val = 0.010f;
    // Start is called before the first frame update
    public override void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    public override void Update()
    {
            timer += Time.deltaTime;
            if (timer % 60 >= 10)
            {
                StateController.instance.powerups.Remove(this);
                Destroy(gameObject);
            }
    }

    public override void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ding");
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Companion")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.gameObject.GetComponent<Movement>().increaseSpeed(val);
            StateController.instance.powerups.Remove(this);
            Destroy(gameObject);
        }
    }
}
