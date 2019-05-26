using UnityEngine;
using UnityEngine.UI;


public class EnergyButton : MonoBehaviour
{
    public Button button;
    public Text text;
    private PlayerController pc;
    private int cost;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ClickStart);
        cost = 5;
        text.text = "+20% Max Energy\nCost: " + cost;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ClickStart()
    {
        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (pc.GetGold() >= cost) {
            pc.ChangeGold(-cost);
            pc.ChangeMaxEnergy(25.0f);
            cost += 5;
            text.text = "+20% Max Energy\nCost: " + cost;
        }
    }
}
