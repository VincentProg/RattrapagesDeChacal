using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player m_prefab;

    [SerializeField] CanvasScore canvasScore;
    PlayerMouvementManager playerMouvementManager;
    
    private List<Player> m_players;

    private void Awake()
    {
        m_players = new List<Player>();
        playerMouvementManager = GetComponent<PlayerMouvementManager>();
    }

    public Player AddPlayer(Vector3 p_pos)
    {
        Player l_player = Instantiate(m_prefab, p_pos, Quaternion.identity);
        l_player.Death += RemovePlayer;
        l_player.Score += canvasScore.IncrementScore;
        m_players.Add(l_player);
        playerMouvementManager.m_rbs.Add(l_player.rigidBody);
        return l_player;
    }

    public void RemovePlayer(Player p_player )
    {
        m_players.Remove(p_player);
        playerMouvementManager.m_rbs.Remove(p_player.rigidBody);
        Destroy(p_player.gameObject);

        if (!m_players.Any())
        {
            Death();
        }
    }

    public void Death()
    {
        playerMouvementManager.enabled = false;
        canvasScore.OnDeath();
        this.enabled = false;
    }

}
