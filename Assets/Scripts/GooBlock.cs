using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooBlock : MonoBehaviour {

    private bool p1_touch = false;
    private bool p2_touch = false;
    private bool p1_stretch = false;
    private bool p2_stretch = false;
    private bool can_transform = false;
    private bool compressed = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (p1_stretch == true && p2_stretch == true)
            can_transform = true;
		if(p1_touch == true && p2_touch == true && can_transform == true)
        {
            if (transform.localScale.x == 1.0f)
            {
                transform.localScale += new Vector3(1.0f, -0.5f, 0.0f);
                can_transform = false;
                p1_stretch = false;
                p2_stretch = false;
            }
            else
            {
                transform.localScale += new Vector3(.5f, 1.5f, 0.0f);
                can_transform = false;
                p1_stretch = false;
                p2_stretch = false;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("contact made");
        if(other.gameObject.tag == "Player1")
        {
            Debug.Log("p1 touch");
            p1_touch = true;
        }
        if (other.gameObject.tag == "Player2")
        {
            Debug.Log("p2 touch");
            p2_touch = true;
        }
        if (other.gameObject.tag == "Wall" && compressed == false)
        {
            Debug.Log("hit wall");
            Compress();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            Debug.Log("p1 exit");
            p1_touch = false;
        }
        if (other.gameObject.tag == "Player2")
        {
            Debug.Log("p2 exit");
            p2_touch = false;
        }

    }

    void Stretch(float val)
    {
        if (val == 1.0f)
        {
            Debug.Log("received stretch message from p1");
            p1_stretch = true;

        }
        if (val == 2.0f)
        {
            Debug.Log("received stretch message from p2");
            p2_stretch = true;
        }
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
