using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_game : MonoBehaviour
{
    public Text MoneyText;
    public int moneycount;

    
    void Start()
    {
        
    }

    public void IncreaseMoney()
    {
        moneycount += 1;
        MoneyText.text = moneycount.ToString();
    }

    void Update()
    {

    }
}
