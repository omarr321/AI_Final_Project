using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScreen : MonoBehaviour
{
    public float hitTime = 20f;
    public GameObject hitScreen;
    private GameObject hitClone;
    private bool isHit = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit) {
            if (timer >= hitTime)
            {
                Destroy(hitClone);
                timer = 0f;
                isHit = false;
            }
            else {
                timer += Time.deltaTime % 60;
            }
        }
    }

    public void hit()
    {
        if (hitClone == null)
        {
            hitClone = Instantiate(hitScreen);
            hitClone.SetActive(true);
            hitClone.tag = "hitTag";
            isHit = true;
        }
    }

    public void clear() {
        Destroy(hitClone);
    }
}
