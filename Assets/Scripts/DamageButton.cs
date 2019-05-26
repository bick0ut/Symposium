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
        button.onClick.AddListener(ClickStart);
        cost = 2;
        text.text = "+20% Damage\nCost: " + cost;
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
            pc.ChangeDamage(0.2f);
            cost += 2;
            text.text = "+20% Damage\nCost: " + cost;
        }
    }
}
