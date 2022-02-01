using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hi my world");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey (KeyCode.LeftArrow)){
            this.transform.Translate (-0.1f,0.0f,0);
        }
        if(Input.GetKey (KeyCode.RightArrow)){
            this.transform.Translate (0.1f,0.0f,0);
        }
    }
}
