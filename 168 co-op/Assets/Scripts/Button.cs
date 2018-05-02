﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	private GameObject Door;

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

	public static bool open = false;

	void Start () {
        if (this.gameObject.tag == "Respawn")
            Door = GameObject.FindGameObjectWithTag("door2");
        else
            Door = GameObject.FindGameObjectWithTag("door");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D col){
		open = true;
		Door.gameObject.transform.Translate(1f,0,0);
	}

	void OnTriggerStay2D(Collider2D col){
        spriteRenderer.sprite = sprites[1];
		open = true;
	}

	void OnTriggerExit2D(Collider2D col){
        spriteRenderer.sprite = sprites[0];
		open = false;
		Door.gameObject.transform.Translate(-1f,0,0);
	}
}
