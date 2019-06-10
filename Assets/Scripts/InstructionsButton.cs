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
            instructions.text = "WASD/Arrow keys to move around. Mouse to aim. 1~3 or mouse wheel to select weapons. Left/Right click for normal/special attack. Special attacks require energy which regenerates by 1% per tick. Q to display stats. Press E next to the portal to proceed into next room. Enemies gets stronger after every 4 floors, try to get as far as you can.";
        } else
        {
            instructions.text = "";
        }
        showing = !showing;
    }
}
