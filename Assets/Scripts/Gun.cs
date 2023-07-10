using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    public int balas_carregador,d_bala_c;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public ParticleSystem muzzleFlash;
    AudioSource shootSound;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start()
    {
        //GameManager.nbalas = maxAmmo;
    }


    void Update()
    {
        if (isReloading)
        {
            // Check if the reload animation has finished
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Reload"))
            {
                isReloading = false;
                animator.SetBool("Reloading", false);
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            if (GameManager.podedisparar)
            {
                nextTimeToFire = Time.time + 5f / fireRate;
                if (balas_carregador > 0)
                {
                    Shoot();
                }
                else
                {
                    StartCoroutine(Reload());
                }
            }
            
        }
    }

    IEnumerator Reload()
    {
        if (balas_carregador == 10)
        {
            // No need to reload if the ammo in the inventory is already sufficient
            yield break;
        }
        if ((balas_carregador > 0) && (balas_carregador < 10))
        {
            d_bala_c = 10 - balas_carregador;
            if (GameManager.nbalas <=    d_bala_c)
            {
                balas_carregador = balas_carregador + GameManager.nbalas;
                GameManager.nbalas = 0;
            }
            else if (GameManager.nbalas > d_bala_c)
            {
                balas_carregador = balas_carregador + d_bala_c;
                GameManager.nbalas = GameManager.nbalas - d_bala_c;
            }
        }
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        // Refill the gun with ammo from the inventory
        if ((GameManager.nbalas > 0) && (GameManager.nbalas <= 10))
        {
            balas_carregador = GameManager.nbalas;
            GameManager.nbalas = 0;
            
        }
        else if (GameManager.nbalas > 10)
        {
            balas_carregador = 10;
            GameManager.nbalas = GameManager.nbalas - 10;
        }
        else
        {
            Debug.Log("No ammo in inventory. Cannot reload.");
        }

        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Shoot()
    {
        shootSound = GetComponent<AudioSource>();
        shootSound.Play();
        muzzleFlash.Play();
        balas_carregador--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
