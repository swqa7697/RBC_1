using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RequestStretch(float val)
    {
        //Debug.Log("parent received message");
        if (val == 1.0f)
            gameObject.BroadcastMessage("Stretch", 1.0f);
        if (val == 2.0f)
            gameObject.BroadcastMessage("Stretch", 2.0f);
    }

}
