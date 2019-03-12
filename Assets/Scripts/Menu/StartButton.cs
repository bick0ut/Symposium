using UnityEngine;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{
    public Button button;
    public GameObject MapController;

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
        MapController map = this.MapController.GetComponent<MapController>();
        map.StartGame();
    }
}
