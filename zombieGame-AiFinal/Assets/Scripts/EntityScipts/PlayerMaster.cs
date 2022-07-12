using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaster : MonoBehaviour
{
    public int maxHealth = 100;
    public int spawnX;
    public int spawnY;
    public int spawnZ;
    private int currHealth;
    private GameObject health;
    private int initHealth;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(spawnX, spawnY, spawnZ);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        health = GameObject.Find("HealthCount");
        currHealth = maxHealth;
        initHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health.GetComponent<TMPro.TextMeshProUGUI>().text = convertHealth(currHealth, maxHealth);
    }

    string convertHealth(int health, int maxHealth)
    {
        return health.ToString() + "/" + maxHealth.ToString();
    }

    public void addHealth(int health)
    {
        currHealth += health;
        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }
    }

    public void loseHealth(int health)
    {
        currHealth -= health;
        if (currHealth < 0) {
            currHealth = 0;
        }

        if (currHealth == 0) {
            GameObject.Find("GameController").GetComponent<GameMaster>().gameOver(); 
        }
    }

    public void addMaxHealth(int maxHealth)
    {
        this.maxHealth += maxHealth;
        addHealth(maxHealth);
    }

    public void reset() {
        currHealth = maxHealth;
        maxHealth = initHealth;
        GameObject.Find("Player").GetComponent<Movement>().speed = 10.0f;
        Start();
    }
}
