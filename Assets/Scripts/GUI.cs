using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    public GameObject bar;
    public GameObject empty;

    ArrayList WeaponList = new ArrayList();

    public GameObject weapon1;
    public GameObject weapon2;



    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        WeaponList.Add(weapon1);
        WeaponList.Add(weapon2);
    }

    public void UpdateHP(float health, float maxHealth)
    {
        Vector3 size = new Vector3((health / maxHealth * 50f), 2, 0);
        bar.transform.localScale = size;
    }

    public void Show()
    {
        bar.SetActive(true);
        empty.SetActive(true);
        weapon1.SetActive(true);
    }

    public void Hide()
    {
        bar.SetActive(false);
        empty.SetActive(false);
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
}
