using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    private GameObject Player;

    public GameObject PlayerToSpawn;

    public GameObject green;

    public GameObject enemy1;
    public GameObject enemy2;

    private int floor = 0;
    private int room = 0;

    private int mobCount = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int GetFloor()
    {
        return floor;
    }

    public int GetRoom()
    {
        return room;
    }

    public void StartGame()
    {
        Player = Instantiate(PlayerToSpawn, new Vector3(-5, 0, 0), Quaternion.identity) as GameObject;
        NextRoom();
    }

    public GameObject GetPlayer()
    {
        return Player;
    }

    public void NextRoom()
    {
        int startingScene = Random.Range(1, 3);

        SceneManager.LoadScene("room" + startingScene);
        this.room++;

        Player.transform.position = new Vector3(-9, 0, 0);
        Invoke("SpawnEnemies", 0.1f);
  
    }

    public void SpawnEnemies()
    {
        int spawnCount = Random.Range(5, 11);
        for (int i = 0; i < spawnCount; i++)
        {
            int xRange = Random.Range(-5, 10);
            int yRange = Random.Range(-3, 4);
            if (Random.Range(0, 2) == 1) { 
                Instantiate(enemy1, new Vector3(xRange, yRange, 0), Quaternion.identity);
            } else
            {
                Instantiate(enemy2, new Vector3(xRange, yRange, 0), Quaternion.identity);
            }
        }
    
        mobCount = spawnCount;
    }

    public void EnemyKilled()
    {
        mobCount--;

        if (mobCount == 0)
        {
            Instantiate(green, new Vector3(9, 0, 0), Quaternion.identity);
        }
    }
}
