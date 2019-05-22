using UnityEngine;
using UnityEngine.UI;


public class HealthButton : MonoBehaviour
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
        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (pc.GetGold() >= 10) {
            pc.ChangeGold(-10);
            pc.ChangeMaxHealth(1);
        }
    }
}
