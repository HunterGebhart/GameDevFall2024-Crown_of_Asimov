using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public Transform playerCamera;

    public float damage;
    public float bulletRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Shoot()
    {
        Ray gunRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if(Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            if(hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= damage;
            }
        }
    }
}
