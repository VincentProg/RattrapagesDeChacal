using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = transform.position + Vector3.left;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, MapManager.instance.speedMaps * Time.deltaTime);
    }


}
