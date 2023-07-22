using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    public event Action Death;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadWall"))
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Death.Invoke();
        this.enabled = false;
    }

}
