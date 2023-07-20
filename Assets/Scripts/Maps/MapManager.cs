using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    // OBJECT POOLING
    [SerializeField]
    int nbrMapToInitialize;
    [SerializeField]
    List<Transform> prefabsMaps;
    Transform[] maps;

    // SPAWN DATAS
    [HideInInspector]
    public bool canSpawn;
    private int indexSpawn = 0;
    [SerializeField]
    private Transform SpawnZone;

    // MAPS VARIABLES
    public float speedMaps;
    [SerializeField] private float accelerationMapOverTime, maxSpeed;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeMaps();
    }

    // Update is called once per frame
    void Update(){

        if (canSpawn)
        {
            canSpawn = false;
            SpawnMap();
        }

        speedMaps += Time.deltaTime * accelerationMapOverTime;
        speedMaps = Mathf.Clamp(speedMaps, 0, maxSpeed);

    }

    void InitializeMaps()
    {
        maps = new Transform[nbrMapToInitialize];
        for(int i = 0; i < nbrMapToInitialize; i++)
        {
            int rand = Random.Range(0, prefabsMaps.Count);
            Transform newMap = Instantiate(prefabsMaps[rand], transform.GetChild(0));

            newMap.transform.position = new Vector3(SpawnZone.transform.position.x, newMap.transform.position.y, 0);
            newMap.gameObject.SetActive(false);
            maps[i] = newMap;
        }
    }


    void SpawnMap()
    {

        maps[indexSpawn].gameObject.SetActive(true);
        indexSpawn++;
        if(indexSpawn >= nbrMapToInitialize)
        {
            indexSpawn = 0;
        }
    }

    public void RemoveMap(Transform map)
    {
        map.gameObject.SetActive(false);
        map.transform.position = new Vector3(SpawnZone.transform.position.x, map.transform.position.y, 0);
    }
}
