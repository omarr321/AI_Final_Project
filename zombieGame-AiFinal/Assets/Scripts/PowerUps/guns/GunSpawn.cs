using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawn : MonoBehaviour
{
    public GameObject gun;
    public GameObject player;
    public GameObject newCamera;
    private float timer = 0;

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
            newCamera.GetComponent<Equip>().equip(gun);
            Destroy(gameObject);
        }
    }
}
