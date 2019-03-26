using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuButton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        button.onClick.AddListener(ClickMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Show()
    {
        button.gameObject.SetActive(true);
    }
}
