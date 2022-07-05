using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0,1)] float shootingVolume=0.3f;

    [Header("Damage")]
    [SerializeField] AudioClip damageTakenSound;
    [SerializeField] [Range(0,1)] float damageTakenVolume=0.3f;

    static AudioManager instance;

    private void Awake() 
    {
        ManageSingleton();
    }


    void ManageSingleton()
    {
        if(instance!=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingShound()
    {
       PlayClip(shootingSound,shootingVolume);
        
    }

    public void PlayDamageTakenSound()
    {
        PlayClip(damageTakenSound,damageTakenVolume);
       

    }

    void PlayClip(AudioClip clip,float volume)
    {
        
        if(clip!=null)
        {
            Vector3 CameraPos= Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,CameraPos,volume);
        }
    }

}
