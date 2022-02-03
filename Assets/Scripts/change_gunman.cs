using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_gunman : MonoBehaviour
{

    public GameObject objGunMan;
    public GameObject objSwordMan;
    private bool isOn = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void visualize()
    {
        if(!isOn)
        {
            isOn = true;
            objGunMan.SetActive(true);
            objSwordMan.SetActive(false);
            Debug.Log("건맨으로 체인지");
            objGunMan.transform.position = new Vector3(0,0,0);
        }
            isOn = false;
    
    }
}
