using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    private GameObject Player;

    public GameObject PlayerToSpawn;

    public GameObject enemy1;

    private int floor = 0;
    private int room = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int GgetFloor()
    {
        return floor;
    }

    public int GetRoom()
    {
        return room;
    }

    public void StartGame()
    {
        Player = Instantiate(PlayerToSpawn, new Vector3(-5, 0, 0), Quaternion.identity);
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

        Player.transform.position = new Vector3(-5, 0, 0);
        Invoke("SpawnEnemies", 0.5f);
  
    }

    public void SpawnEnemies()
    {
        int mobCount = Random.Range(3, 6);
        for (int i = 0; i < mobCount; i++)
        {
            int xRange = Random.Range(-3, 8);
            int yRange = Random.Range(-3, 4);
            Instantiate(enemy1, new Vector3(xRange, yRange, 0), Quaternion.identity);
        }
    }
}
