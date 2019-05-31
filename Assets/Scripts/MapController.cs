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
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;

    public GameObject GUI;

    public GameObject shopPrefab;

    private int floor = 1;
    private int room = 0;

    private int mobCount = 0;

    private int bossRoom = 3;

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
        if (room > bossRoom+1)
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
        room = 1;

        GUI.GetComponent<GUI>().UpdateFloor(floor);
    }

    public void SpawnEnemies()
    {
        if (floor % 5 == 1)
        {
            if (room == bossRoom + 1)
            {
                mobCount = -1;
                SpawnPortal();
                Instantiate(shopPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if (room != bossRoom)
            {
                int spawnCount = Random.Range(8, 13);
                for (int i = 0; i < spawnCount; i++)
                {
                    int xRange = Random.Range(-5, 10);
                    int yRange = Random.Range(-3, 4);

                    int rando = Random.Range(0, 2);
                    if (rando == 0)
                    {
                        Instantiate(enemy5, new Vector3(xRange, yRange, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(enemy2, new Vector3(xRange, yRange, 0), Quaternion.identity);
                    }
                }

                mobCount = spawnCount;
            }
            else
            {
                mobCount = -1;
                Instantiate(boss1, new Vector3(0, 0, 0), Quaternion.identity);
            }
        } else if (floor % 5 == 2)
        {
            if (room == bossRoom + 1)
            {
                mobCount = -1;
                SpawnPortal();
                Instantiate(shopPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if (room != bossRoom)
            {
                int spawnCount = Random.Range(8, 13);
                for (int i = 0; i < spawnCount; i++)
                {
                    int xRange = Random.Range(-5, 10);
                    int yRange = Random.Range(-3, 4);

                    int rando = Random.Range(0, 4);
                    if (rando == 0)
                    {
                        Instantiate(enemy1, new Vector3(xRange, yRange, 0), Quaternion.identity);
                    }
                    else if (rando == 1)
                    {
                        Instantiate(enemy3, new Vector3(xRange, yRange, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(enemy4, new Vector3(xRange, yRange, 0), Quaternion.identity);
                    }
                }

                mobCount = spawnCount;
            }
            else
            {
                mobCount = -1;
                Instantiate(boss2, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }else if (floor % 5 == 3)
        {
            if (room == bossRoom + 1)
            {
                mobCount = -1;
                SpawnPortal();
                Instantiate(shopPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if (room != bossRoom)
            {
                int spawnCount = Random.Range(8, 13);
                for (int i = 0; i < spawnCount; i++)
                {
                    int xRange = Random.Range(-5, 10);
                    int yRange = Random.Range(-3, 4);

                    int rando = Random.Range(0, 4);
                    if (rando == 0)
                    {
                        Instantiate(enemy1, new Vector3(xRange, yRange, 0), Quaternion.identity);
                    }
                    else if (rando == 1)
                    {
                        Instantiate(enemy3, new Vector3(xRange, yRange, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(enemy4, new Vector3(xRange, yRange, 0), Quaternion.identity);
                    }
                }

                mobCount = spawnCount;
            }
            else
            {
                mobCount = -1;
                Instantiate(boss3, new Vector3(0, 0, 0), Quaternion.identity);
            }
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
}
