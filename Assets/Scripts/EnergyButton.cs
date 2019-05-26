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
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        button.onClick.AddListener(ClickStart);
        cost = 5 + 5*pc.EUpgrade();
        text.text = "+25% Max Energy\nCost: " + cost;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ClickStart()
    {
        if (pc.GetGold() >= cost) {
            pc.ChangeGold(-cost);
            pc.ChangeMaxEnergy(25.0f);
            cost += 5;
            text.text = "+25% Max Energy\nCost: " + cost;
        }
    }
}
