using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasDeath : MonoBehaviour
{

    [SerializeField] GameObject UIDeath;
    [SerializeField] Text timetext;


    private void Start()
    {
        UIDeath.SetActive(false);
    }
    public void OnDeath()
    {
        timetext.text = ((int)Time.time).ToString() + " seconds";
        UIDeath.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
