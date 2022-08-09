using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHerding: Action
{
    Collider[] zombeanSphere;
    int i=0;
    public static List<GameObject> Test = new List<GameObject>();
    public override DTNode MakeDecision()
    {
        return GetComponent<DecisionHerding>().GetBranch();
    }
        public float distance;
        public  Vector3 diffDistance;
        public int count = 0;



    public override void LateUpdate()
    {
        GameObject[] childBeans = GameObject.FindGameObjectsWithTag("clickable");


        for (int i=0; i<childBeans.Length; i++){
            distance = Vector3.Distance(this.transform.position, childBeans[i].transform.position);
            if (distance < 10){
                childBeans[i].transform.LookAt(this.transform.position);
                childBeans[i].transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
                distance = Vector3.Distance(this.transform.position, childBeans[i].transform.position);
            if (distance<2){
                count++;
                if (count>3){
                    GameObject Player = GameObject.Find("Player");
                    childBeans[i].transform.LookAt(Player.transform.position);
                    childBeans[i].transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
                    this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
                    this.transform.LookAt(Player.transform.position);
                }
            }
            }
        }
    }
}
