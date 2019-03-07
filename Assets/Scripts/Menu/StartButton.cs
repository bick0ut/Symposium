using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button button;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartGame()
    {
        int startingScene = Random.Range(1, 3);
        SceneManager.LoadScene("room"+startingScene);
        player.SetActive(true);
    }
}
