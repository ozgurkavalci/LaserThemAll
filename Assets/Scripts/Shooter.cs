using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
   [Header("General")]
   [SerializeField] GameObject projectilePrefab;

   [SerializeField] float projectileSpeed=10f;
   [SerializeField] float projectileLifeTime=5f;
   [SerializeField] private float basefireRate=0.2f;

   [Header("AI")]
   [SerializeField] bool useAI;
   [SerializeField] private float fireRateVariance=0f;
   [SerializeField] private float minFireRate=0.1f;


   [HideInInspector]
   public  bool isShooting;

   AudioManager audioManager;

   Coroutine firingCoroutine;

   private void Awake() 
   {
    audioManager=FindObjectOfType<AudioManager>();
   }
    void Start()
    {
        if(useAI==true)
        {
            isShooting=true;
        }
    }

    
    void Update()
    {
       Fire();
    }

    void Fire()
    {
        if(isShooting&& firingCoroutine==null)
        {
           firingCoroutine=StartCoroutine(FireConstantly());
        }
        else if(!isShooting&& firingCoroutine!=null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine=null;
        }
         

    }

    IEnumerator FireConstantly()
    {
       
        while(true)
        {
            GameObject projectile;
            projectile=Instantiate(projectilePrefab,transform.position,Quaternion.identity);
            Rigidbody2D rb=projectile.GetComponent<Rigidbody2D>();
            if(rb!=null)
            {
                rb.velocity= transform.up*projectileSpeed;
            }
            Destroy(projectile,projectileLifeTime);
            
            float timeOfNextProjectile=Random.Range(basefireRate-fireRateVariance,basefireRate+fireRateVariance);
            timeOfNextProjectile=Mathf.Clamp(timeOfNextProjectile,minFireRate,float.MaxValue);
            audioManager.PlayShootingShound();
            yield return new WaitForSecondsRealtime(timeOfNextProjectile);
        }
        
    }


}
