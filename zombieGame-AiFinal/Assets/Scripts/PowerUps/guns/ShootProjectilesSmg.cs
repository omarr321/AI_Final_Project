using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectilesSmg : MonoBehaviour
{
    public GameObject newCamera;
    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletHit;
    private int fireRate = 10;
    private bool isFiring = false;
    private float timer = 0f;
    public float maxSpread = 0.08f;

    public int clipSize = 24;
    private int currClip;
    public int ammoCam = 120;
    private int currAmmo;
    private GameObject ClipRem;
    private GameObject AmmoRem;
    public GameObject PistolRef;

    void Start()
    {
        currClip = clipSize;
        currAmmo = ammoCam;
        ClipRem = GameObject.Find("ClipRem");
        AmmoRem = GameObject.Find("AmmoRem");
        ClipRem.GetComponent<TMPro.TextMeshProUGUI>().text = currClip.ToString();
        if (currAmmo == -1)
        {
            AmmoRem.GetComponent<TMPro.TextMeshProUGUI>().text = "∞";
        }
        else
        {
            AmmoRem.GetComponent<TMPro.TextMeshProUGUI>().text = currAmmo.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (currClip > 0)
            {
                isFiring = true;

            }
            else
            {
                isFiring = false;
            }
        }
        else if (Input.GetMouseButtonUp(0)) {
            isFiring = false;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }

        if (isFiring)
        {
            if (((timer % 60f) / 60f * 100) * fireRate >= 1f)
            {
                muzzleFlash.Play();
                shootMissle();
                timer = 0f;
            }
        } else {
            muzzleFlash.Stop();
            timer = 0f;
        }
        if (currClip <= 0)
        {
            muzzleFlash.Stop();
        }
        if (currClip == 0 && currAmmo == 0)
        {
            GameObject.Find("PlayerCamera").GetComponent<Equip>().equip(PistolRef);
        }
    }

    void reload()
    {
        if (ammoCam == -1)
        {
            currClip = clipSize;
        }
        else
        {
            if (clipSize - currClip <= currAmmo)
            {
                currAmmo = currAmmo - (clipSize - currClip);
                currClip = clipSize;
            }
            else if (clipSize - currClip > currAmmo)
            {
                if (currAmmo != 0)
                {
                    currClip = currAmmo + currClip;
                    currAmmo = 0;
                }
            }
        }
        ClipRem.GetComponent<TMPro.TextMeshProUGUI>().text = currClip.ToString();
        if (currAmmo == -1)
        {
            AmmoRem.GetComponent<TMPro.TextMeshProUGUI>().text = "∞";
        }
        else
        {
            AmmoRem.GetComponent<TMPro.TextMeshProUGUI>().text = currAmmo.ToString();
        }
    }

    void shootMissle()
    {
        if (currClip > 0)
        {
            currClip = currClip - 1;
            ClipRem.GetComponent<TMPro.TextMeshProUGUI>().text = currClip.ToString();
            RaycastHit hit;
            float randX = Random.Range(-maxSpread, maxSpread);
            float randY = Random.Range(-maxSpread, maxSpread);
            float randZ = Random.Range(-maxSpread, maxSpread);
            if (Physics.Raycast(newCamera.transform.position, newCamera.transform.TransformDirection(Vector3.forward + new Vector3(randX, randY, randZ)), out hit, Mathf.Infinity))
            {
                ParticleSystem objHit = Instantiate(bulletHit, hit.point, transform.localRotation);
                ParticleSystem.MainModule ma = objHit.main;
                if (hit.collider.tag == "clickable")
                {
                    hit.transform.gameObject.GetComponent<ZombieAI>().clicked(40);
                    ma.startColor = new Color(.75f, .1f, 0f, .8f);
                }
                else if (hit.collider.tag == "clickableBoss")
                {
                    hit.transform.gameObject.GetComponent<BossAI>().clicked(50);
                    ma.startColor = new Color(.75f, .1f, 0f, .8f);
                }
                else
                {
                    ma.startColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                }
            }
        }
    }
}
