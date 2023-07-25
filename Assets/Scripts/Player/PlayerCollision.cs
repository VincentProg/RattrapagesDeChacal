using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    public event Action Death;
    public event Action WindItem;


    private void OnTriggerEnter(Collider other)
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

    private void OnDeath()
    {
        Death.Invoke();
        this.enabled = false;
    }

    private void OnWind()
    {
        WindItem?.Invoke();
    }

}
