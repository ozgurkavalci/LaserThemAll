using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    WaveConfigSO currentWave;

    [SerializeField] float timeBetweenWaves=0f;

    bool isLooping=true;


   
    void Start()
    {
        
        StartCoroutine(SpawnerOfEnemyWaves());
    }

    private void Update() 
    {
       
    }

    public WaveConfigSO GetCurrentWave()
    {
      return currentWave;
    }

   

   IEnumerator SpawnerOfEnemyWaves()
   {

    do{
        foreach(WaveConfigSO item in waveConfigs)
        {
          currentWave=item;

          for(int i=0; i<currentWave.GetEnemyCount() ;i++)
          {
           Instantiate(currentWave.GetEnemyPrefab(i),currentWave.GetStartingWayPoint().position,Quaternion.Euler(0,0,180),transform);

           yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());

          }

         yield return new WaitForSecondsRealtime(timeBetweenWaves);       
        }

    }while(isLooping);

   }

   

}
