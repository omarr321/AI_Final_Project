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
        public float distance=1.0f;
        public Vector3 beanDistance;
        public  Vector3 diffDistance;
        public int count = 0;


    public override void LateUpdate()
    {
        GameObject[] childBeans = GameObject.FindGameObjectsWithTag("clickable");


        for (int i=0; i<childBeans.Length; i++){
            beanDistance=childBeans[i].transform.position;
            diffDistance=this.transform.position-beanDistance;
            Debug.Log("Hello " + diffDistance);
            childBeans[i].transform.LookAt(this.transform.position);
            childBeans[i].transform.Translate(Vector3.forward * speed * Time.deltaTime);
            count++;
            if (count>3){
                // switch to rushing
            }
        }
    }
}
