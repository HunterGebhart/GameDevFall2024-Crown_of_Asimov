using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*
 * A class that defines the behavior for the UI canvas the player sees as HUD
 */
public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject bullet1;
    [SerializeField] GameObject bullet2;
    [SerializeField] GameObject bullet3;
    
    //Set all bullets images to active at game-start
    private void Start()
    {
        bullet1.SetActive(true);
        bullet2.SetActive(true);
        bullet3.SetActive(true);
    }

    //Set which bullet images are visible based on the current ammo of the player gun
    public void SetBulletVisibility(int currAmmo)
    {
        switch(currAmmo)
        {
            case 0:
                bullet1.SetActive(false);
                bullet2.SetActive(false);
                bullet3.SetActive(false);
                break;
            case 1:
                bullet1.SetActive(true);
                bullet2.SetActive(false);
                bullet3.SetActive(false);
                break;
            case 2:
                bullet1.SetActive(true);
                bullet2.SetActive(true);
                bullet3.SetActive(false);
                break;
            case 3:
                bullet1.SetActive(true);
                bullet2.SetActive(true);
                bullet3.SetActive(true);
                break;
            default:
                break;
        }
    }
}
