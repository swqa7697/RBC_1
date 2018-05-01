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
    }
}
