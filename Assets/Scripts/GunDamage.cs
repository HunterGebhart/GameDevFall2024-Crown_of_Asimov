using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public Transform playerCamera;

    public float damage;
    public float bulletRange;
    public float enemyDamagedTimer;

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

                if(enemy.Health != 0)
                {
                    StartCoroutine(enemyDamaged(enemy));
                }
            }
        }
    }

    IEnumerator enemyDamaged(Entity enemy)
    {
        if(enemy.CompareTag("Gundam"))
        {
            enemy.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            yield return new WaitForSeconds(enemyDamagedTimer);

            enemy.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            yield return null;
        }

        if(enemy.CompareTag("TestObject"))
        {
            enemy.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            yield return new WaitForSeconds(enemyDamagedTimer);

            enemy.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            yield return null;
        }
    }
}
