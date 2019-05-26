using UnityEngine;
using UnityEngine.UI;

public class InstructionsButton : MonoBehaviour
{
    public Button button;
    public Text instructions;
    private bool showing;
    

    // Start is called before the first frame update
    void Start()
    {
        showing = true;
        button.onClick.AddListener(ClickStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClickStart()
    {
        if (showing)
        {
            instructions.text = "WASD to move around. Mouse to aim. 1~3 to select weapons. Left click for normal attack. Right click for special attack. Special attacks require energy, which regenerates over time. Q to display stats. Kill all enemies in the room to unlock a portal. Press E next to the portal to proceed into next room. All enemies have a chance to drop gold which can be spent after the boss room to upgrade stats.";
        } else
        {
            instructions.text = "";
        }
        showing = !showing;
    }
}
