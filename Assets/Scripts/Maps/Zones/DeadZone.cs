using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Map"))
        {
            MapManager.instance.RemoveMap(other.transform);            
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Death();
        }
    }
}
