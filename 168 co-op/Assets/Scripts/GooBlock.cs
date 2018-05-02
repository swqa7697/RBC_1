using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooBlock : MonoBehaviour {

    private int players = 0;
    private int p_stretch_request = 0;

    private bool can_transform = false;
    private bool compressed = false;
    private bool stretched = false;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(players);
        if (players == 2)
            can_transform = true;
        if (players == 2 && can_transform == true && p_stretch_request == 2)
        {
            if (transform.localScale.x == 1.0f && stretched == false) // for stretching basic 1x1 block
            {
                transform.localScale += new Vector3(1.0f, -0.5f, 0.0f);
                can_transform = false;
                p_stretch_request = 0;
                players = 0;
                stretched = true;

            }
            else if(stretched == true)// for stretching basic  block
            {
                transform.localScale += new Vector3(-1.0f, 0.5f, 0.0f);
                can_transform = false;
                p_stretch_request = 0;
                stretched = false;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        var direction = transform.InverseTransformPoint(other.transform.position);
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("player touch");
            players += 1;
            //p1_touch = true;
        }
        else if(other.gameObject.tag != "Level" && compressed == false)
        {
            if (direction.x > 0f)
            {
                Debug.Log("rightside");
               Compress();
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("player exit");
            if (players != 0)
            {
                players -= 1;
                p_stretch_request -= 1;
            }
        }
    }

    void Stretch(float val)
    {
       // Debug.Log(p_stretch_request);
        if(p_stretch_request != 2)
            p_stretch_request += 1;
    }

    void Compress()
    {
        if (transform.localScale.x == 2.0f)
            transform.localScale += new Vector3(-1.0f, 0.5f, 0.0f);
        else
        {
            transform.localScale += new Vector3(-.5f, 1.0f, 0.0f);
            transform.position = new Vector2(transform.position.x, transform.position.y + .515f);
            compressed = true;
        }
    }
}
