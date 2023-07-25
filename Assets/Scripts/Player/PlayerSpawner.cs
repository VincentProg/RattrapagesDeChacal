using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private PlayerManager m_manager;

    [SerializeField] private SpriteRenderer m_spriteSpawn;
    private Vector2 m_horizontalRange;
    private Vector2 m_verticalRange;

    [Header("Wind")] [SerializeField] private ParticleSystem l_wind;
    [SerializeField] private float l_duration;

    [SerializeField] private float l_delaySpawn;
    
    private void Start()
    {
        Bounds l_bounds = m_spriteSpawn.bounds;
        m_horizontalRange = new Vector2(l_bounds.min.x, l_bounds.max.x);
        m_verticalRange = new Vector2(l_bounds.min.y, l_bounds.max.y);
        SpawnPlayerAtPos(Vector3.zero);
    }

    // Update is called once per frame
    public void ActivateWind()
    {
        l_wind.Play();
        StartCoroutine(iWind());
    }

    private IEnumerator iWind()
    {
        yield return new WaitForSeconds(0.5f);
        float l_time = 0;
        while (l_time < l_duration)
        {
            l_time += l_delaySpawn;
            SpawnPlayerRandom();
            yield return new WaitForSeconds(l_delaySpawn);
        }
    }

    private void SpawnPlayerRandom()
    {
        Vector3 l_pos = RandomSpawn();
        SpawnPlayerAtPos(l_pos);
    }

    private void SpawnPlayerAtPos(Vector3 p_position)
    {
        if (!Physics.Raycast(p_position, transform.forward, Mathf.Infinity))
        {
            Player l_player = m_manager.AddPlayer(p_position);
            l_player.Wind += ActivateWind;
        }
    }

    private Vector3 RandomSpawn()
    {
        float randX = Random.Range(m_horizontalRange.x, m_horizontalRange.y);
        float randY = Random.Range(m_verticalRange.x, m_verticalRange.y);

        return new Vector3(randX, randY);
    }
}
