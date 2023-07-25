using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasDeath : MonoBehaviour
{

    [SerializeField] GameObject UIDeath;
    [SerializeField] Text scoreText;

    private int score;

    private void Start()
    {
        UIDeath.SetActive(false);
    }

    public void IncrementScore()
    {
        score++;
    }
    
    public void OnDeath()
    {
        scoreText.text = "Score : " + score;
        UIDeath.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
