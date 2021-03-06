﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public float jumpPower = 150f;
    public float maxSpeed = 10f;

    private SpriteRenderer PSR;
    public Sprite[] PS;

    public Sprite localRed1;
    public Sprite localRed2;

    private bool flipped = false;
    public bool beingGrabbed = false;

    //public GameObject GameOverUI;

    public bool grounded = false;
    public bool canGrab = false;
    public bool grabbing = false;
    public bool can_pp = true;/*ADDED*/
    public bool pulling = false;/*ADDED*/
    public bool can_jump = true;/*ADDED*/

    private Rigidbody2D rb2d;
    public Rigidbody2D rb2db;
    public GameObject obj;

    public Transform thingToPull;
    public Transform originalParent;


    void Start()
    {
        //GameOverUI.SetActive(false);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        PSR = gameObject.GetComponent<SpriteRenderer>();

    }

    public override void OnStartLocalPlayer()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        PSR = gameObject.GetComponent<SpriteRenderer>();

        Debug.Log("IS CALLED");
        Debug.Log(localRed1);
        PSR.sprite = localRed1;

    }

    void FixedUpdate()
    {

        if (!isLocalPlayer)
            return;

        if (beingGrabbed == false)
        {
            float h = Input.GetAxis("Horizontal");

            if (grabbing == true)
            {
                if (h > 0)
                {
                    if (flipped == false)
                    {
                        h = 0;
                    }
                }
                if (h < 0)
                {
                    if (flipped == true)
                    {
                        h = 0;
                    }
                }
                if (obj.CompareTag("stone_box"))
                {
                    h = 0;
                }
            }
            else
            {
                if (h < 0)
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);//turn left
                    flipped = true;
                    CmdFlipLeft();
                }
                if (h > 0)
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    flipped = false;
                    CmdFlipRight();
                }
            }
            rb2d.velocity = new Vector2(h * maxSpeed, rb2d.velocity.y);
        }


        if (grabbing == true)
        {
            PSR.color = Color.black;
        }
        if (grabbing == false)
        {
            PSR.color = Color.white;
        }
    }


    void Update()
    {

        if (!isLocalPlayer)
            return;

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded == true)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                grounded = false;
            }
        }

        if (Input.GetButtonDown("Grab"))
        {
            if (canGrab == true)
            {
                grabbing = true;
                CmdGrab();
            }
        }

        if (Input.GetButtonUp("Grab"))
        {
            grabbing = false;
            CmdStopGrab();
        }

    }

    [Command]
    void CmdGrab()
    {
        obj.transform.SetParent(gameObject.transform);
        Debug.Log("Parent: " + obj.transform.parent);
        //if (obj.CompareTag ("Player")) {
        obj.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    [Command]
    void CmdStopGrab()
    {
        obj.transform.SetParent(null);
    }

    [Command]
    void CmdFlipLeft()
    {
        transform.localEulerAngles = new Vector3(0, 180, 0);//turn left
        flipped = true;
    }

    [Command]
    void CmdFlipRight()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        flipped = false;
    }

}
