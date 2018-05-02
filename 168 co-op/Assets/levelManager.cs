using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class levelManager : MonoBehaviour {

    private NetworkManager nm;

    public int currentLevel = 0;

	// Use this for initialization
	void Start() {
        //DontDestroyOnLoad(this.gameObject);
        nm = GameObject.FindGameObjectWithTag("Network").GetComponent<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}

    public void loadScene(string s)
    {
        ++currentLevel;
        nm.ServerChangeScene(s);
    }

    public void reloadLevel()
    {
        Vector3 position = GameObject.FindGameObjectWithTag("EditorOnly").transform.position;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject p in players)
        {
            Debug.Log("Looped");
            p.transform.position = position;
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("box");

        foreach(GameObject b in boxes)
        {
            if(b.name.Contains("up"))
            {
                Vector3 b_position = GameObject.Find("Box Spawn (up)").transform.position;
                b.transform.position = b_position;
            }
            else if(b.name.Contains("top"))
            {
                Vector3 b_position = GameObject.Find("Box Spawn (top)").transform.position;
                b.transform.position = b_position;
            }
            else if(b.name.Contains("bot"))
            {
                Vector3 b_position = GameObject.Find("Box Spawn (bot)").transform.position;
                b.transform.position = b_position;
            }
            else
            {
                Vector3 b_position = GameObject.FindGameObjectWithTag("BOX_SPAWN").transform.position;
                b.transform.position = b_position;
            }
        }

        
    }
}
