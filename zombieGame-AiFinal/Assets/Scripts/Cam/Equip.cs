using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    private GameObject equiped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void equip(GameObject gun)
    {
        if (equiped != null) {
            Destroy(equiped);
        }
        equiped = Instantiate(gun, gameObject.transform, false);
        equiped.transform.Rotate(new Vector3(0f, 90f, 0f));
        equiped.transform.position += transform.forward * .8f + transform.right * .55f + transform.up * -.1f;
        if (equiped.name == "PistolShootable(Clone)")
        {
            equiped.GetComponent<ShootProjectilesPistol>().newCamera = gameObject;
        }
        else if (equiped.name == "SmgShootable(Clone)")
        {
            equiped.GetComponent<ShootProjectilesSmg>().newCamera = gameObject;
        }
        else if (equiped.name == "ShotgunShootable(Clone)")
        {
            equiped.GetComponent<ShootProjectilesShotgun>().newCamera = gameObject;
        }
        else if (equiped.name == "SniperShootable(Clone)")
        {
            equiped.GetComponent<ShootProjectilesSniper>().newCamera = gameObject;
        }
        else if (equiped.name == "MiniGunShootable(Clone)")
        {
            equiped.GetComponent<ShootProjectilesMini>().newCamera = gameObject;
        }
    }

    public void reset(GameObject gun)
    {
        equip(gun);
    }
}
