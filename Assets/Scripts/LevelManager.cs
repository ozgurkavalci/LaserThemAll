using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] float waitTime=1f;

    ScoreKeeper scoreKeeper;
    private void Awake() 
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadEndScene()
    {
        StartCoroutine(WaitAndLoad("EndScene",waitTime));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName,float timeToWait)
    {
       
       yield return new WaitForSecondsRealtime(timeToWait);
       SceneManager.LoadScene(sceneName);
    }
}
