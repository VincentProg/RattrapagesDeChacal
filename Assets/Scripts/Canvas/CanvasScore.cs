using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CanvasScore : MonoBehaviour
{

    [SerializeField] GameObject UIDeath;
    [SerializeField] Text scoreDeathText;
    [SerializeField] private TextMeshProUGUI m_topScore;

    private int score;

    private void Start()
    {
        UIDeath.SetActive(false);
    }

    public void IncrementScore()
    {
        score++;
        m_topScore.text = score.ToString();
    }
    
    public void OnDeath()
    {
        scoreDeathText.text = score.ToString();
        UIDeath.SetActive(true);
        m_topScore.gameObject.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
