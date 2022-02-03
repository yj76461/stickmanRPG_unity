using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storescript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject store;
    private bool isOn = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(isOn)
        {
            store.SetActive(true);
            //Debug.Log("상점이 나타났다.");
        }
        else
        {
            store.SetActive(false);
            //Debug.Log("사라진다뿅");
        }
    
    }

    public void visualize()
    {
        if(isOn)
            isOn = false;
        else
            isOn = true;
    }
}
