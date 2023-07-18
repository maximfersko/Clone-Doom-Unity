using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float gunShotRadius = 20.0f;
    public EnemyManager enemyManager;
    public float fireRate = 1.0f;
    public float bigDamage = 2f;
    public float lowDamage = 1f;
    public int maxAmmo;
    private int ammo;
    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;
    private BoxCollider gunTrigger;
    private float nextTimeToFire;


    // Start is called before the first frame update
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new UnityEngine.Vector3(1, verticalRange, range);
        gunTrigger.center = new UnityEngine.Vector3(0, 0, range * 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask) ;

        foreach (var enemyCollider in enemyColliders)
        {
            //enemyCollider.GetComponent<EnemyAwareness>().isAgro = true;
        }

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        foreach(var enemy in enemyManager.enemiesTrigger)
        {
            var dir = enemy.transform.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir,out hit, range * 1.5f, raycastLayerMask)) 
            {
               if (hit.transform == enemy.transform)
               {
                    float dist = UnityEngine.Vector3.Distance(enemy.transform.position, transform.position);

                  if (dist > range * 0.5f)
                  {
                        enemy.TakeDamage(lowDamage);
                  } 
                  else
                  {
                        enemy.TakeDamage(bigDamage);
                  }
                    //UnityEngine.Debug.DrawRay(transform.position, dir, Color.green);
                    //UnityEngine.Debug.Break();
               } 
            }
        }

        nextTimeToFire = Time.time + fireRate;

        ammo--;
    }

    public void GiveAmmo(int amount, GameObject gameObject)
    {
        if (ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(gameObject);
        }

        if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
