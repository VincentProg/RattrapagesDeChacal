using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] CanvasDeath canvasDeath;
    PlayerMouvement playerMouvement;
    PlayerCollision playerCollision;

    private void Start()
    {
        playerMouvement = GetComponent<PlayerMouvement>();
        playerCollision = GetComponent<PlayerCollision>();
    }

    public void Death()
    {
        playerMouvement.enabled = false;
        playerCollision.enabled = false;
        canvasDeath.OnDeath();
    }

}
