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

    public GameObject boss1;

    public GameObject GUI;
    public GameObject menu;

    private int floor = 1;
    private int room = 0;

    private int mobCount = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(menu);
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
        GUI.GetComponent<GUI>().UpdateFloor(floor);
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
        if (room > 2)
        {
            NextFloor();
        }

        Player.transform.position = new Vector3(-9, 0, 0);
        Invoke("SpawnEnemies", 0.1f);
        GUI.GetComponent<GUI>().UpdateRoom(room);
    }

    public void NextFloor()
    {
        this.floor++;
        room = 0;
        NextRoom();

        GUI.GetComponent<GUI>().UpdateFloor(floor);
    }

    public void SpawnEnemies()
    {
        if (room != 2)
        {
            int spawnCount = Random.Range(8, 13);
            for (int i = 0; i < spawnCount; i++)
            {
                int xRange = Random.Range(-5, 10);
                int yRange = Random.Range(-3, 4);
                if (Random.Range(0, 2) == 1)
                {
                    Instantiate(enemy1, new Vector3(xRange, yRange, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(enemy2, new Vector3(xRange, yRange, 0), Quaternion.identity);
                }
            }

            mobCount = spawnCount;
        } else
        {
            mobCount = -1;
            Instantiate(boss1, new Vector3(-5, 0, 0), Quaternion.identity);
        }

    }

    public void EnemyKilled()
    {
        mobCount--;

        if (mobCount == 0)
        {
            SpawnPortal();
        }
    }

    public void SpawnPortal()
    {
        Instantiate(green, new Vector3(9, 0, 0), Quaternion.identity);
    }

    public void EnableMenu()
    {
        menu.SetActive(true);
    }
}
