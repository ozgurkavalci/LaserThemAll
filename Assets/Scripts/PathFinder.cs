using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;

    List<Transform> wayPoints;

    int wayPointIndex=0;
    private void Awake() 
    {
        enemySpawner=FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig=enemySpawner.GetCurrentWave();
        wayPoints=waveConfig.GetWayPoints();
        transform.position= wayPoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }


    void FollowPath()
    {

        if(wayPointIndex<wayPoints.Count)
        {
            Vector2 targetPosition= wayPoints[wayPointIndex].position;
            float delta=waveConfig.GetMoveSpeed()*Time.deltaTime;
            transform.position=Vector2.MoveTowards(transform.position,targetPosition,delta);
            if(transform.position==wayPoints[wayPointIndex].position)
            {
                wayPointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
