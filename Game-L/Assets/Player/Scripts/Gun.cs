using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Animator animator;

    private float nextTimeToFire = 0f;

    AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    private UIManager uiManager;

    void Start()
    {
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
        uiManager = GameObject.Find("CanvasPlayerUI").GetComponent<UIManager>();
        uiManager.UpdateAmmo(currentAmmo);
    }
    
    void OnEnable()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReloading)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
            audioSource.PlayOneShot(shootSound);
        }
    }

    IEnumerator Reload()
    {
        if (isReloading || currentAmmo == maxAmmo)
        {
            yield break;
        }

        isReloading = true;
        animator.SetBool("Reloading", true);
        audioSource.PlayOneShot(reloadSound);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        uiManager.UpdateAmmo(currentAmmo);
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;
        uiManager.UpdateAmmo(currentAmmo);

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            EnemyHP target = hit.transform.GetComponent<EnemyHP>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
