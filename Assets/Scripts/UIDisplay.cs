using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    Health health;

    private void Awake() 
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
        
    }
    void Start()
    {
        scoreText.text="00000000";
        healthSlider.value= playerHealth.ReturnHealth();

    }
    void Update()
    {
        scoreText.text=scoreKeeper.ReturnScore().ToString("00000000");
        healthSlider.value=playerHealth.ReturnHealth();
    }
}
