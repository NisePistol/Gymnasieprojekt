using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<Transform> allFinnishLines;

    public Transform player;

    public Transform enemy;

    public int spawnDistance = 3;
    public int enemyDistance = 3;

    public static int room = 0;

    public void RespawnPlayer()
    {
        player.position = new Vector2(allFinnishLines[room].position.x - spawnDistance, allFinnishLines[room].position.y);

        enemy.position = new Vector2(player.position.x + enemyDistance, player.position.y);

        room++;
    }
}
