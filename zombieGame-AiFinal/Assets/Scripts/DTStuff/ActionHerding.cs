using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHerding: Action
{
    public override DTNode MakeDecision()
    {
        GameObject cloestZombean = this.FindClosestZombean();
        float dis = Vector3.Distance(cloestZombean.transform.position, this.transform.position);

        if (dis < 3) {
            Debug.Log("Rushing...");
            return GetComponent<DecisionRushing>().GetBranch();
        } else {
            return GetComponent<DecisionHerding>().GetBranch();
        }
    }
        public float distance;
        public  Vector3 diffDistance;
        public int count = 0;

    public GameObject FindClosestZombean() {
        GameObject[] zombeans = GameObject.FindGameObjectsWithTag("clickable");
        GameObject closest = null;

        float distance = Mathf.Infinity;
        foreach (GameObject zombean in zombeans) {
            float dis = Vector3.Distance(zombean.transform.position, this.transform.position);
            if (dis < distance) {
                if (zombean != gameObject)
                {
                    closest = zombean;
                    distance = dis;
                }
            }
        }

        return closest;
    }

    public override void LateUpdate()
    {
        GameObject cloestZombean = this.FindClosestZombean();

        this.transform.LookAt(cloestZombean.transform.position);
        this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
    }
}
