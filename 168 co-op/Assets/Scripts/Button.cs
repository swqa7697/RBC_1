using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	private GameObject Door;

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

	public static bool open = false;

	void Start () {
		Door = GameObject.FindGameObjectWithTag ("door");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void FixedUpdate (){
		if (open == true) {
			Door.gameObject.SetActive (false);
		} else {
			Door.gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		open = true;
	}

	void OnTriggerStay2D(Collider2D col){
        spriteRenderer.sprite = sprites[1];
		open = true;
	}

	void OnTriggerExit2D(Collider2D col){
        spriteRenderer.sprite = sprites[0];
		open = false;
	}
}
