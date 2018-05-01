using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCondition : MonoBehaviour {


    [SerializeField]
    private int playerCount;
    public string nextLevelName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(playerCount >= 1)
        {
            levelManager lev = GameObject.FindGameObjectWithTag("GameController").GetComponent<levelManager>();
            lev.loadScene(nextLevelName);

        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            playerCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            playerCount--;
        }
    }
}
