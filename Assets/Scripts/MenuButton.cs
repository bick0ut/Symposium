using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButton : MonoBehaviour
{
    public Button button;
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ClickStart);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ClickStart()
    {
        var objects = Object.FindObjectsOfType<GameObject>();

        foreach (GameObject o in objects)
        {
            if (o.tag != "Menu" && o.tag != "MainCamera")
            {
                Destroy(o);
            }
        }

        SceneManager.LoadScene("menu");
    }
}
