using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGun : MonoBehaviour
{
    public UnityEvent OnGunShoot;

    public float fireCooldown;

    public bool automaticFiring;

    private float currentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(automaticFiring)
        {
            if(Input.GetMouseButton(0))
            {
                if(currentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    currentCooldown = fireCooldown;
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(currentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    currentCooldown = fireCooldown;
                }
            }
        }
        currentCooldown -= Time.deltaTime;
    }
}
