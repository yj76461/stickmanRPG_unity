using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_swordman : MonoBehaviour
{

    public GameObject objGunMan;
    public GameObject objSwordMan;
    private bool isOn = false;
    // Start is called before the first frame update
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
            objGunMan.SetActive(false);
            objSwordMan.SetActive(true);
            Debug.Log("칼맨으로 체인지");
            objSwordMan.transform.position = new Vector3(0,0,0);
        }
            isOn = false;
    }
}
