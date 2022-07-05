using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;
    private int currentScore;

    private void Awake() 
    {
        HandleSingleton();
    }
    
    void Start()
    {
        currentScore=0;
    }

    void HandleSingleton()
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

    

    public void IncreaseScore(int value)
    {
        currentScore+=value;
        Debug.Log(currentScore);

    }

    public void ResetScore()
    {
        currentScore=0;
    }

    public int ReturnScore()
    {
        return currentScore;
    }
}
