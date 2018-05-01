using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class levelManager : MonoBehaviour {

    private NetworkManager nm;

	// Use this for initialization
	void Start() {
        DontDestroyOnLoad(this.gameObject);
        nm = GameObject.FindGameObjectWithTag("Network").GetComponent<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}

    public void loadScene(string s)
    {
        nm.ServerChangeScene(s);
    }
}
