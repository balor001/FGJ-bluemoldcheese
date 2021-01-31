using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathListener : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject gameOverScreen;
    private EnemyStats enemyStats;
    private PlayerStats playerStats;

     void Awake()
    {
        enemyStats = enemy.GetComponent<EnemyStats>();
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyStats.Died)
        {
            gameOverScreen.SetActive(true);
        }
        if (playerStats.Died)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
