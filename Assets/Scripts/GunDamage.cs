using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
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
                if(enemy.Health != 0)
                {
                    StartCoroutine(enemyDamaged(enemy));
                }

                enemy.Health -= damage;
            }
        }
    }

    IEnumerator enemyDamaged(Entity enemy)
    {
        if(!enemy.IsDestroyed() && enemy.CompareTag("Gundam"))
        {
            enemy.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            yield return new WaitForSeconds(enemyDamagedTimer);

            if(!enemy.IsDestroyed())
            {
                enemy.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }

            yield return null;
        }

        else if(!enemy.IsDestroyed() && enemy.CompareTag("TestObject"))
        {
            enemy.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            yield return new WaitForSeconds(enemyDamagedTimer);

            if(!enemy.IsDestroyed())
            {
                enemy.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }

            yield return null;
        }
    }
}
