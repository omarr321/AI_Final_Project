using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [Header("General")]
    public float wakeUpDistance = 30;
    public float speed = 1.0f;
    public float size = 1.0f;
    public GameObject deathParticle;
    public GameObject hitMarker;
    private GameObject player;

    //ref to powerups
    [Header("PowerUps")]
    public GameObject miniGun;
    private float timer = 0f;
    private int health = 10000;
    private bool spawnedPower = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale += new Vector3(size, size, size);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.LookAt(player.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerMaster>().loseHealth(50);
            player.GetComponent<HitScreen>().hit();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (timer % 60 >= 1)
            {
                collision.gameObject.GetComponent<PlayerMaster>().loseHealth(5);
                player.GetComponent<HitScreen>().hit();
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void clicked(int loseHealth)
    {
        health -= loseHealth;

        if (health <= 0)
        {
            if (!spawnedPower)
            {
                spawnedPower = true;
                GameObject.Find("GameController").GetComponent<GameMaster>().subZombie();
                GameObject DeathCloud = Instantiate(deathParticle, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.Euler(-90, transform.eulerAngles.y + 90, 0));
                DeathCloud.transform.localScale *= 2;
                GameObject MiniGun = Instantiate(miniGun, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.Euler(0, transform.eulerAngles.y + 90, 0));
                GunSpawn script = MiniGun.GetComponent<GunSpawn>();
                script.player = player;
                script.newCamera = GameObject.Find("PlayerCamera");
                Destroy(gameObject);
            }
        }
    }
}
