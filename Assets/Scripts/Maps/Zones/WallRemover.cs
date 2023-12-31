using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Map l_map = other.GetComponent<Map>();
        if (!l_map) 
            return;
        
        MapManager.instance.RemoveMap(l_map);
    }
}
