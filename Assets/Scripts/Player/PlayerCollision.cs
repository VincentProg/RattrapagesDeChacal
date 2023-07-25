using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    public event Action Death;
    public event Action WindItem;
    public event Action Score;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadWall"))
        {
            OnDeath();
        } else if (other.CompareTag("WindItem"))
        {
            OnWind();
            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ScoreIncrementer"))
        {
            OnScore();
        }
    }

    private void OnDeath()
    {
        Death?.Invoke();
        this.enabled = false;
    }

    private void OnWind()
    {
        WindItem?.Invoke();
    }

    private void OnScore()
    {
        Score?.Invoke();
    }

}
