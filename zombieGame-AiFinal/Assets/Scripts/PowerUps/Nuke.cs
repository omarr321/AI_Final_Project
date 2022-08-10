using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : powerup
{
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
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("clickable");
            foreach (GameObject zom in zombies)
            {
                if (zom.name != "ZombiePrefab")
                {
                    zom.GetComponent<ZombieAI>().clicked(10000);
                }
            }
            StateController.instance.powerups.Remove(this);
            Destroy(gameObject);
        }
    }
}
