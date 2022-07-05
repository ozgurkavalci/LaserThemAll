using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health=50;
    [SerializeField] int score=50;
    [SerializeField] ParticleSystem hitEffect;

    

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioManager audioManager;

    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake() 
    {
        cameraShake= Camera.main.GetComponent<CameraShake>();

        audioManager=FindObjectOfType<AudioManager>();

        scoreKeeper=FindObjectOfType<ScoreKeeper>();
        levelManager=FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer=other.GetComponent<DamageDealer>();

        if(damageDealer!=null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioManager.PlayDamageTakenSound();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int ReturnHealth()
    {
        return health;
    }


    void TakeDamage(int damage)
    {

        health-=damage;
        if(health<=0)
        {
            Die();
        }
    }

    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.IncreaseScore(score);
        }
        else
        {
            levelManager.LoadEndScene();
        }
        Destroy(gameObject);
    }



    void PlayHitEffect()
    {
        if(hitEffect!=null)
        {
            ParticleSystem instance=Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration+instance.main.startLifetime.constantMax);

        }
    }

    void ShakeCamera()
    {
        if(cameraShake!=null&&applyCameraShake)
        {

            cameraShake.Play();
        }
    }

    
}
