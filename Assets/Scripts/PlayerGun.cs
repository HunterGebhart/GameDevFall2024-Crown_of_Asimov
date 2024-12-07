using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] Transform playerCamera;
    [SerializeField] GameObject player;

    [Header("Sound Effects")]
    [SerializeField] AudioClip gunshot;
    [SerializeField] AudioSource noAmmoSound;
    [SerializeField] AudioSource swishSound;
    [SerializeField] AudioSource reloadSound;

    [Header("Gun Attributes")]
    [SerializeField] float fireCooldown;
    [SerializeField] float reloadTime;
    [SerializeField] float damage;
    [SerializeField] float bulletRange;
    [SerializeField] float enemyDamagedTimer;
    [SerializeField] int maxAmmo = 3;
    [SerializeField] bool automaticFiring;

    private AudioSource revolverSFX;

    private RevolverAnimation revolverAnimation;

    private PlayerUI playerUI;

    private float currentCooldown;

    private int currAmmo;

    void Start()
    {
        currentCooldown = fireCooldown;
        currAmmo = maxAmmo;

        revolverAnimation = GetComponent<RevolverAnimation>();
        revolverSFX = GetComponent<AudioSource>();
        playerUI = player.GetComponent<PlayerUI>();
    }

    void Update()
    {

        if(automaticFiring)
        {
            if(Input.GetMouseButton(0))
                {
                if(currentCooldown <= 0f)
                {
                    if(currAmmo <= 0) noAmmoSound.Play();
                    else Shoot();
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(currentCooldown <= 0f)
                {
                    if(currAmmo <= 0) noAmmoSound.Play();
                    else Shoot();
                }
            }
        }

        currentCooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        playerUI.SetBulletVisibility(currAmmo);
    }

    public void Shoot()
    {
        if(revolverAnimation.revolverAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleRevolver"))
        {
            revolverAnimation.ShootRevolver();

            revolverSFX.PlayOneShot(gunshot, 1f);

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

            currentCooldown = fireCooldown;

            currAmmo--;
        }
    }

    public void Reload()
    {
        if(revolverAnimation.revolverAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleRevolver"))
        {
            StartCoroutine(playReloadSFX());
            revolverAnimation.ReloadRevolver();

            currAmmo = maxAmmo;
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

    IEnumerator playReloadSFX()
    {
        swishSound.Play();

        yield return new WaitForSeconds(.45f);

        reloadSound.Play();
    }
}
