using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
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
                State.powerups.Remove(this);
                Destroy(gameObject);
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("clickable");
            foreach (GameObject zom in zombies)
            {
                if (zom.name != "ZombiePrefab")
                {
                    zom.GetComponent<ZombieAI>().clicked(10000);
                }
            }
            State.powerups.Remove(this);
            Destroy(gameObject);
        }
    }
}
