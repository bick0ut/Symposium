using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public GameObject Player;

    public GameObject enemy1;

    private int floor = 0;
    private int room = 0;

    public int getFloor()
    {
        return floor;
    }

    public int getRoom()
    {
        return room;
    }

    public void NextRoom()
    {
        int startingScene = Random.Range(1, 3);
        SceneManager.LoadScene("room" + startingScene);

        this.room++;
        Player.transform.position.Set(-5, 0, 0);

        int mobCount = Random.Range(3, 6);
        for (int i = 0; i < mobCount; i++)
        {
            Instantiate(enemy1, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
