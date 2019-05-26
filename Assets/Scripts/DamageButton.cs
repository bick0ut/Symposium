using UnityEngine;
using UnityEngine.UI;


public class DamageButton : MonoBehaviour
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
        cost = 2 + 2*pc.DUpgrade();
        text.text = "+20% Damage\nCost: " + cost;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ClickStart()
    {
        if (pc.GetGold() >= cost) {
            pc.ChangeGold(-cost);
            pc.ChangeDamage(0.2f);
            cost += 2;
            text.text = "+20% Damage\nCost: " + cost;
        }
    }
}
