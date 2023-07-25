using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnZone : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Map"))
        {
            MapManager.instance.canSpawn = true;
        }
    }

}
