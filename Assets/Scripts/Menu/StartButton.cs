using UnityEngine;
using UnityEngine.UI;


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
        player.SetActive(true);
        MapController map = player.GetComponent<MapController>();
        map.NextRoom();
    }
}
