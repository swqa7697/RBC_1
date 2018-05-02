using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Assist : MonoBehaviour
{

    public UnityEngine.UI.Button myButton;
    public levelManager LM;


    // Use this for initialization
    void Start()
    {

        //  this script is necessary because the object that the buttons need to connect with is not from their actual scene 
        //  (and therefore cannot be connected in editor)

        LM = GameObject.FindGameObjectWithTag("GameController").GetComponent<levelManager>();
        myButton = this.gameObject.GetComponent<UnityEngine.UI.Button>();

        //DELEGATES <3 <3 <3

        myButton.onClick.AddListener(delegate {
            LM.exitLevel();
        });
    }
}