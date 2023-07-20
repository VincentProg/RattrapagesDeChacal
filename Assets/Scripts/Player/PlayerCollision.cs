using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    PlayerComponents myComponents;
    Player myPlayer;
    [HideInInspector]
    public bool canDie = true;

    private void Start()
    {
        myComponents = GetComponent<PlayerComponents>();
        myPlayer = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(canDie)
        if (other.CompareTag("DeadWall"))
        {
            myPlayer.Death();
        }
    }

}
