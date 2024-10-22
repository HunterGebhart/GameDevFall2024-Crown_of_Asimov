using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    //bullet 
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce, spread, bulletDespawnTime;

  

    //Reference
    //public Camera fpsCam;
    public Transform attackPoint, headLocation, player;

    //Graphics
    //public GameObject muzzleFlash;

    public void Shoot()
    {
        //Find the exact hit position using a raycast
        Ray ray = new Ray(headLocation.transform.position, player.position - transform.position - new Vector3(0,1.5f,0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the entity

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(headLocation.transform.up * upwardForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
       // if (muzzleFlash != null)
          //  Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);



    }
}
