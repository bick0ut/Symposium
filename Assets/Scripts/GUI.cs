using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public GameObject bar;
    public GameObject empty;

    public GameObject barBoss;
    public GameObject emptyBoss;

    public GameObject canvas;
    public Text floorDisplay;
    public Text roomDisplay;
    public Text goldDisplay;

    ArrayList WeaponList = new ArrayList();

    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

    public Text stats;
    public GameObject statsBg;
    private bool statsDisplay;

    private void Start()
    {
        statsBg.SetActive(false);
        statsDisplay = true;
        DontDestroyOnLoad(gameObject);
        WeaponList.Add(weapon1);
        WeaponList.Add(weapon2);
        WeaponList.Add(weapon3);
    }

    public bool IsDisplaying(){
        return !statsDisplay;
    }

    public void StatsDisplay(float hp, float energy, float damage, int kills) {
        statsDisplay = !statsDisplay;
        if (statsDisplay)
        {
            stats.text = "";
            statsBg.SetActive(false);
        } else
        {
            stats.text = "Max Health: " + hp + "\nMax Energy: " + energy + "%\nDamage: " + (int)(damage*100) + "%\nKills: " + kills;
            statsBg.SetActive(true);
        }
    }

    public void UpdateHP(float health, float maxHealth)
    {
        Vector3 size = new Vector3((health / maxHealth * 50f), 2, 0);
        bar.transform.localScale = size;
    }

    public void UpdateBossHP(float health, float maxHealth)
    {
        Vector3 size = new Vector3((health / maxHealth * 50f), 2, 0);
        barBoss.transform.localScale = size;
    }

    public void Show()
    {
        bar.SetActive(true);
        empty.SetActive(true);
        canvas.SetActive(true);
        weapon1.SetActive(true);
    }

    public void Hide()
    {
        bar.SetActive(false);
        empty.SetActive(false);
        HideBoss();
        canvas.SetActive(false);

        foreach (GameObject w in WeaponList)
        {
            w.SetActive(false);
        }
    }

    public void ChangeWeapon(int weapon)
    {
        foreach(GameObject w in WeaponList)
        {
            w.SetActive(false);
        }

        GameObject selected = (GameObject)WeaponList[weapon];

        selected.SetActive(true);
    }

    public void UpdateFloor(int floor)
    {
        floorDisplay.text = "Floor: " + floor;
    }

    public void UpdateRoom(int floor)
    {
        roomDisplay.text = "Room: " + floor;
    }

    public void UpdateGold(int gold)
    {
        goldDisplay.text = "" + gold;
    }

    public void ShowBoss()
    {
        barBoss.SetActive(true);
        emptyBoss.SetActive(true);
    }

    public void HideBoss()
    {
        barBoss.SetActive(false);
        emptyBoss.SetActive(false);
    }
}
