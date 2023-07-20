using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Map"))
        {
            MapManager.instance.canSpawn = true;
        }
    }

}
