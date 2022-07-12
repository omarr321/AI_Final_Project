using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public GameObject player;
    public float offsetX = 0;
    public float offsetY = 0;
    public float offsetZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
        this.transform.rotation = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, 0);
    }
}
