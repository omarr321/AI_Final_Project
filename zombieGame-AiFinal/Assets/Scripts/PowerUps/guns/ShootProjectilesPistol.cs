using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectilesPistol : MonoBehaviour
{
    public GameObject newCamera;
    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletHit;
    public GameObject bulletPath;
    public float maxSpread = 0.02f;
    public int clipSize = 12;
    private int currClip;
    public int ammoCam = -1;
    private int currAmmo;
    private GameObject ClipRem;
    private GameObject AmmoRem;

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
        } else {
            AmmoRem.GetComponent<TMPro.TextMeshProUGUI>().text = currAmmo.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currClip > 0)
            {
                shootMissle();
            }
        } else if (Input.GetKeyDown(KeyCode.R)) {
            reload();
        }
        
    }

    void reload()
    {
        if (ammoCam == -1)
        {
            currClip = clipSize;
        }
        else {
            currAmmo = currAmmo - (clipSize - currClip);
            currClip = clipSize;
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
        currClip = currClip - 1;
        ClipRem.GetComponent<TMPro.TextMeshProUGUI>().text = currClip.ToString();
        muzzleFlash.Play();
        RaycastHit hit;
        float randX = Random.Range(-maxSpread, maxSpread);
        float randY = Random.Range(-maxSpread, maxSpread);
        float randZ = Random.Range(-maxSpread, maxSpread);

        if (Physics.Raycast(newCamera.transform.position, newCamera.transform.TransformDirection(Vector3.forward + new Vector3(randX, randY, randZ)), out hit, Mathf.Infinity)) {
            ParticleSystem objHit = Instantiate(bulletHit, hit.point, transform.localRotation);
            ParticleSystem.MainModule ma = objHit.main;

            if (hit.collider.tag == "clickable")
            {
                hit.transform.gameObject.GetComponent<ZombieAI>().clicked(50);
                ma.startColor = new Color(.75f, .1f, 0f, .8f);
            }
            else if (hit.collider.tag == "clickableBoss") {
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