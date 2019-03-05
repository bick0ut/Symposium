using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button button;


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
        SceneManager.LoadScene("room1");
    }
}
