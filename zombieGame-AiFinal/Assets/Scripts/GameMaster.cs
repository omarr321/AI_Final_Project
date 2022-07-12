using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject player;
    public GameObject starterGun;
    public GameObject hitMarkerScreen;

    public float xPosOne = 0;
    public float yPosOne = 0;
    public float zPosOne = 0;
    public float xPosTwo = 0;
    public float yPosTwo = 0;
    public float zPosTwo = 0;

    public GameObject zombiePrefab;
    public GameObject bossZombiePrefab;
    private int startingZombies;
    private float timer = 0.0f;
    private float roundTime = 0.0f;
    private int totalTime;
    private int zombies;
    private bool newNum = true;
    private int numOfZombies = 0;
    private int timeRounds = 15;

    private GameObject zombieCounter;
    private GameObject nextWaveCount;
    private GameObject timerWaveCount;
    private GameObject totalTimerCount;
    private GameObject totalZombiesKilled;

    private int totalKilled = 0;

    private GameObject deathScreen;
    private bool isDead = false;

    private GameObject scoreUI;
    private GameObject cursorCanvas;
    private GameObject playerCamera;
    
    public float spawnNormal = 49.5f;
    public float spawnStrong = 30.0f;
    public float spawnFast = 20.0f;
    public float spawnBoss = 0.5f;
    private float megaBossTimer = 0f;
    public int maxZombies = 600;
    private int currSpawnAmount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        zombieCounter = GameObject.Find("ZombieCounter");
        nextWaveCount = GameObject.Find("NextWaveCount");
        timerWaveCount = GameObject.Find("TimerWaveCount");
        totalTimerCount = GameObject.Find("TotalTimerCount");
        totalZombiesKilled = GameObject.Find("TotalZombiesKilledCount");

        currSpawnAmount = Random.Range(10, 25) / 3;
        newNum = false;
        calcuZombie();

        totalTime = 0;
        //zombies = 0;
        startingZombies = Random.Range(10, 25) / 3;
        //startingZombies = 500;
        for (int i = 0; i < startingZombies; i++) {
            //Debug.Log("Creating zombie " + i + "...");
            numOfZombies++;
            summonZombie();
        }

        //zombies = Random.Range(20, 30) / 3;
        //Debug.Log("Next spawn num: " + zombies);

        deathScreen = GameObject.Find("GameOverScreen");
        deathScreen.SetActive(false);
        scoreUI = GameObject.Find("ScoreUI");
        cursorCanvas = GameObject.Find("CursorCanvas");
        playerCamera = GameObject.Find("PlayerCamera");
        playerCamera.GetComponent<Equip>().equip(starterGun);
    }

    // Update is called once per frame
    void Update()
    {
        megaBossTimer += Time.deltaTime;
        timer += Time.deltaTime;
        totalTime = ((int)timer % 60) + ((int)timer / 60 * 60);
        //Debug.Log(totalTime);
        roundTime += Time.deltaTime;
        if (newNum) {
            calcuZombie();
            //Debug.Log("Next spawn num: " + zombies);
        } else {
            if (roundTime % 60 >= timeRounds) {
                for (int i = 0; i < zombies; i++) {
                    //Debug.Log("Creating zombie " + i + "...");
                    numOfZombies++;
                    summonZombie();
                }
                roundTime = 0.0f;
                newNum = true;
            }
        }
        updateUI();
    }

    public void calcuZombie()
    {
        Debug.Log("CalcuZombie...");
        if (newNum) {
            Debug.Log("Gening new number...");
            currSpawnAmount = Random.Range(20, 30) * (totalTime / timeRounds) / 3;
        }
        int zombieNum = currSpawnAmount;
        float percent = 1f - ((float)numOfZombies / (float)maxZombies);
        Debug.Log("Percent: " + percent);
        if (percent < 0f)
        {
            percent = 0f;
        }
        zombies = (int)Mathf.Round(zombieNum * percent);
        newNum = false;
        Debug.Log("Curr Spawn Amount: " + currSpawnAmount);
        Debug.Log("Zombies Amount: " + zombies);
    }

    void summonZombie() {
        if (!isDead)
        {

            float xPlace;
            float yPlace;
            float zPlace;
            while (true)
            {
                xPlace = Random.Range(xPosOne, xPosTwo);
                yPlace = Random.Range(yPosOne, yPosTwo);
                zPlace = Random.Range(zPosOne, zPosTwo);

                float vecX = (xPlace - player.transform.position.x);
                float vecY = (yPlace - player.transform.position.y);
                float vecZ = (zPlace - player.transform.position.z);
                float dist = Mathf.Sqrt((vecX * vecX) + (vecY * vecY) + (vecZ * vecZ));
                if (dist > 30)
                {
                    break;
                }
            }
            float megaTimer = ((int)megaBossTimer % 60) + ((int)megaBossTimer / 60 * 60);
            if (megaTimer >= 120f) {
                megaBossTimer = 0f;
                GameObject zombie = Instantiate(bossZombiePrefab, new Vector3(xPlace, yPlace, zPlace), transform.rotation);
                BossAI script = zombie.GetComponent<BossAI>();
                zombie.GetComponent<Renderer>().material.color = new Color(1f, 0.9f, 0f);
            } else {
                GameObject zombie = Instantiate(zombiePrefab, new Vector3(xPlace, yPlace, zPlace), transform.rotation);

                float chance = Random.Range(0f, 100f);
                if (chance <= spawnNormal)
                {
                    ZombieAI script = zombie.GetComponent<ZombieAI>();
                    script.speed = Random.Range(1.5f, 8f) * (totalTime / timeRounds) / 15 + 1;
                    if (script.speed >= player.GetComponent<Movement>().speed + .4f)
                    {
                        script.speed = player.GetComponent<Movement>().speed + .4f;
                    }
                    script.wakeUpDistance = Random.Range(30f, 120f) * (totalTime / timeRounds) / 5 + 30;
                    script.size = Random.Range(-0.2f, 1f);
                    script.hitMarker = hitMarkerScreen;
                }
                else if (chance <= spawnNormal + spawnStrong)
                {
                    ZombieAI script = zombie.GetComponent<ZombieAI>();
                    script.speed = Random.Range(.75f, 4f) * (totalTime / timeRounds) / 15 + 1;
                    if (script.speed >= player.GetComponent<Movement>().speed + .4f)
                    {
                        script.speed = player.GetComponent<Movement>().speed + .4f;
                    }
                    script.setHealth(200);
                    script.wakeUpDistance = Random.Range(30f, 120f) * (totalTime / timeRounds) / 5 + 30;
                    script.size = Random.Range(-0.2f, 1f);
                    script.hitMarker = hitMarkerScreen;
                    zombie.GetComponent<Renderer>().material.color = new Color(0f, 0.5f, 0.5f);
                }
                else if (chance <= spawnNormal + spawnStrong + spawnFast)
                {
                    ZombieAI script = zombie.GetComponent<ZombieAI>();
                    script.speed = Random.Range(3f, 16f) * (totalTime / timeRounds) / 15 + 1;
                    if (script.speed >= player.GetComponent<Movement>().speed + .4f)
                    {
                        script.speed = player.GetComponent<Movement>().speed + .4f;
                    }
                    script.setHealth(50);
                    script.wakeUpDistance = Random.Range(30f, 120f) * (totalTime / timeRounds) / 5 + 30;
                    script.size = Random.Range(-0.2f, 1f);
                    script.hitMarker = hitMarkerScreen;
                    zombie.GetComponent<Renderer>().material.color = new Color(0.4f, 0f, 0f);
                }
                else {
                    ZombieAI script = zombie.GetComponent<ZombieAI>();
                    script.speed = Random.Range(.5f, 2f) * (totalTime / timeRounds) / 15 + 1;
                    if (script.speed >= player.GetComponent<Movement>().speed + .4f)
                    {
                        script.speed = player.GetComponent<Movement>().speed + .4f;
                    }
                    script.setHealth(600);
                    script.wakeUpDistance = Random.Range(30f, 120f) * (totalTime / timeRounds) / 5 + 30;
                    script.size = Random.Range(1.5f, 2.5f);
                    script.hitMarker = hitMarkerScreen;
                    zombie.GetComponent<Renderer>().material.color = new Color(0.4f, 0.4f, 0.4f);
                }
            }
        }
    }

    void updateUI() {
        int round = (int)roundTime % 60;
        zombieCounter.GetComponent<TMPro.TextMeshProUGUI>().text = numOfZombies.ToString();
        //Debug.Log("Next Wave Zombie Amount: " + zombies);
        nextWaveCount.GetComponent<TMPro.TextMeshProUGUI>().text = zombies.ToString();
        timerWaveCount.GetComponent<TMPro.TextMeshProUGUI>().text = convertToTimer(timeRounds - round);
        totalTimerCount.GetComponent<TMPro.TextMeshProUGUI>().text = convertToTimer(totalTime);
        totalZombiesKilled.GetComponent<TMPro.TextMeshProUGUI>().text = totalKilled.ToString();
    }

    string convertToTimer(int time) {
        int sec = time;
        int min = sec / 60;
        sec = sec % 60;

        string minLabel = "";
        string secLabel = "";
        if (min.ToString().Length == 1) {
            minLabel = "0" + min.ToString();
        }
        else {
            minLabel = min.ToString();
        }

        if (sec.ToString().Length == 1)
        {
            secLabel = "0" + sec.ToString();
        }
        else
        {
            secLabel = sec.ToString();
        }
        return minLabel + ":" + secLabel;
    }

    public void subZombie() {
        numOfZombies--;
        totalKilled++;
        Debug.Log("subZmobie");
        calcuZombie();
    }

    public int getNumZombies() {
        return numOfZombies;
    }

    public void gameOver() {
        isDead = true;
        scoreUI.SetActive(false);
        cursorCanvas.SetActive(false);
        playerCamera.GetComponent<Rotation>().enabled = false;
        player.SetActive(false);
        new WaitForSeconds(1);
        Cursor.lockState = CursorLockMode.Confined;
        deathScreen.SetActive(true);
        GameObject.Find("TotalTimeCount").GetComponent<TMPro.TextMeshProUGUI>().text = convertToTimer(totalTime);
        GameObject.Find("TotalZombiesCount").GetComponent<TMPro.TextMeshProUGUI>().text = totalKilled.ToString();
        GameObject[] hits = GameObject.FindGameObjectsWithTag("hitTag");
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("clickable");
        foreach (GameObject zom in zombies)
        {
            zom.GetComponent<HitScreen>().clear();
        }
    }

    public void tryAgain() {
        Debug.Log("Try Again was Clicked!");
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("clickable");
        foreach (GameObject zom in zombies) {
            if (zom.name != "ZombiePrefab") {
                Destroy(zom);
            }
        }

        GameObject[] powerup = GameObject.FindGameObjectsWithTag("powerup");
        foreach (GameObject pow in powerup)
        {
            Destroy(pow);
        }

        isDead = false;
        numOfZombies = 0;
        timer = 0.0f;
        roundTime = 0.0f;
        totalKilled = 0;

        scoreUI.SetActive(true);
        cursorCanvas.SetActive(true);
        playerCamera.GetComponent<Rotation>().enabled = true;
        player.SetActive(true);
        player.GetComponent<PlayerMaster>().reset();
        player.GetComponent<Movement>().reset();
        Cursor.lockState = CursorLockMode.Locked;
        Start();
    }       

    public void quit() {
        Application.Quit();
    }
}
