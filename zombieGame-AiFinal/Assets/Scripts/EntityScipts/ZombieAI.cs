using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [Header("General")]
    public float speed = 1.0f;
    public float size = 1.0f;
    public GameObject deathParticle;
    public GameObject hitMarker;
    private GameObject player;
    private float timer = 0.0f;

    //ref to powerups
    [Header("PowerUps")]
    public GameObject healthPowerUp;
    public GameObject maxHealthPowerUp;
    public GameObject bulletPenPowerUp;
    public GameObject speedUpPowerUp;
    public GameObject nukePowerUp;

    [Header("Guns")]
    public GameObject sniperGun;
    public GameObject smgGun;
    public GameObject shotGun;

    private int health = 100;
    private bool spawnedPower = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale += new Vector3(size, size, size);
        player = GameObject.Find("Player");
        GetComponent<ActionRushing>().speed = speed;
        GetComponent<ActionHerding>().speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") {
            collision.gameObject.GetComponent<PlayerMaster>().loseHealth(5);
            player.GetComponent<HitScreen>().hit();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Player") {
            if (timer % 60 >= 1) {
                collision.gameObject.GetComponent<PlayerMaster>().loseHealth(5);
                player.GetComponent<HitScreen>().hit();
                timer = 0.0f;
            } else {
                timer += Time.deltaTime;
            }
        }
    }

    public void setHealth(int health) {
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
                GameObject DeathCloud = Instantiate(deathParticle, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.Euler(-90, transform.eulerAngles.y + 90, 0));
                GameObject.Find("GameController").GetComponent<GameMaster>().subZombie();
                int chance = Random.Range(0, 100);
                if (chance <= 15)
                {
                    chance = Random.Range(0, 7);
                    if (chance == 0)
                    {
                        GameObject health = Instantiate(healthPowerUp, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.Euler(0, transform.eulerAngles.y + 90, 0));
                        health.tag = "powerup";
                        health.GetComponent<AddHealth>().player = player;
                    }
                    else if (chance == 1)
                    {
                        GameObject maxHealth = Instantiate(maxHealthPowerUp, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.Euler(0, transform.eulerAngles.y + 90, 0));
                        maxHealth.tag = "powerup";
                        maxHealth.GetComponent<MaxHealth>().player = player;
                    }
                    else if (chance == 2)
                    {
                        GameObject nuke = Instantiate(nukePowerUp, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.Euler(0, transform.eulerAngles.y + 90, 0));
                        nuke.tag = "powerup";
                        nuke.GetComponent<Nuke>().player = player;
                    }
                    else if (chance == 3)
                    {
                        GameObject speedUp = Instantiate(speedUpPowerUp, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.Euler(0, transform.eulerAngles.y + 90, 0));
                        speedUp.tag = "powerup";
                        speedUp.GetComponent<SpeedUp>().player = player;
                    }
                    else if (chance == 4)
                    {
                        GameObject sniper = Instantiate(sniperGun, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.Euler(0, transform.eulerAngles.y + 90, 0));
                        sniper.tag = "powerup";
                        GunSpawn script = sniper.GetComponent<GunSpawn>();
                        script.player = player;
                        script.newCamera = GameObject.Find("PlayerCamera");
                    }
                    else if (chance == 5)
                    {
                        GameObject smg = Instantiate(smgGun, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.Euler(0, transform.eulerAngles.y + 90, 0));
                        smg.tag = "powerup";
                        GunSpawn script = smg.GetComponent<GunSpawn>();
                        script.player = player;
                        script.newCamera = GameObject.Find("PlayerCamera");
                    }
                    else if (chance == 6)
                    {
                        GameObject shotgun = Instantiate(shotGun, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.Euler(0, transform.eulerAngles.y + 90, 0));
                        shotgun.tag = "powerup";
                        GunSpawn script = shotgun.GetComponent<GunSpawn>();
                        script.player = player;
                        script.newCamera = GameObject.Find("PlayerCamera");
                    }
                    else
                    {
                        Debug.Log("Error");
                    }

                }
            }
            Destroy(gameObject);
        }
    }
}
