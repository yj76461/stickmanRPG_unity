using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public Text MoneyText;
    public Text STAGE_num;
    public int moneycount;

    public GameObject[] stages;
    public int stageIdx;
    public GameObject lobby;
    public GameObject store;
    private bool onStore = false;

    
    void Start()
    {
        STAGE_num.text = stageIdx.ToString();
    }

    public void OnClickPlayButton()
    {
        lobby.SetActive(false);
        stages[stageIdx].SetActive(true);
    }
    public void OnClickStoreButton()
    {
        if(onStore == true){
            store.SetActive(false);
            onStore = false;
        }
        else{
            store.SetActive(true);
            onStore = true;
        }
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
