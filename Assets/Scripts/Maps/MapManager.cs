using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    // OBJECT POOLING
    [SerializeField]
    List<Map> prefabsMaps;
    Map[] maps;

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
        canSpawn = true;
    }

    // Update is called once per frame
    void Update(){

        SpawnMap();
        speedMaps += Time.deltaTime * accelerationMapOverTime;
        speedMaps = Mathf.Clamp(speedMaps, 0, maxSpeed);

    }

    void InitializeMaps()
    {
        maps = new Map[prefabsMaps.Count];
        for(int i = 0; i < prefabsMaps.Count; i++)
        {
            Map newMap = Instantiate(prefabsMaps[i], transform.GetChild(0));
            newMap.transform.position = new Vector3(0, SpawnZone.transform.position.y, 0);
            newMap.gameObject.SetActive(false);
            newMap.GetComponent<MeshRenderer>().enabled = false;
            maps[i] = newMap;
        }
    }


    void SpawnMap()
    {
        if (!canSpawn)
            return;
        
        canSpawn = false;
        int rand = Random.Range(0, maps.Length);
        while (maps[rand].isActiveAndEnabled)
        {
            rand = (rand + 1) % maps.Length;
        }
        maps[rand].gameObject.SetActive(true);
    }

    public void RemoveMap(Map map)
    {
        map.gameObject.SetActive(false);
        map.transform.position = new Vector3(0, SpawnZone.transform.position.y, 0);
    }
}
