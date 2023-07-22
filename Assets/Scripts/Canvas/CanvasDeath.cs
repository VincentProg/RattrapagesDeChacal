using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasDeath : MonoBehaviour
{

    [SerializeField] GameObject UIDeath;
    [SerializeField] Text timetext;

    private float m_startTime;

    private void Start()
    {
        UIDeath.SetActive(false);
        m_startTime = Time.time;
    }
    public void OnDeath()
    {
        timetext.text = (int)(Time.time - m_startTime)+ " seconds";
        UIDeath.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
