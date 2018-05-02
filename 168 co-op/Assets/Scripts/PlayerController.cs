using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

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


	void Start () {
		//GameOverUI.SetActive(false);
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		PSR = gameObject.GetComponent<SpriteRenderer>();
     
	}

    public override void OnStartLocalPlayer()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        PSR = gameObject.GetComponent<SpriteRenderer>();

        //gameObject.tag = "Player";/*ADDED*/
        //gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Game").transform);/*ADDED*/

        Debug.Log("IS CALLED");
        Debug.Log(localRed1);
        PSR.sprite = localRed1;

    }

	void FixedUpdate () {

		if (!isLocalPlayer)
			return;

		if (beingGrabbed == false) {
			float h = Input.GetAxis ("Horizontal");

			if (grabbing == true) {
				if (h > 0) {
					if (flipped == false) {
						h = 0;
					}
				}
				if (h < 0) {
					if (flipped == true) {
						h = 0;
					}
				}
				if (obj.CompareTag ("stone_box")) {
					h = 0;
				}
			} else {
				if (h < 0) {
                    transform.localEulerAngles = new Vector3 (0, 180, 0);//turn left
                    flipped = true;
                    CmdFlipLeft();
				}
				if (h > 0) {
					transform.localEulerAngles = new Vector3 (0, 0, 0);
					flipped = false;
                    CmdFlipRight();
                }
			}
			rb2d.velocity = new Vector2 (h * maxSpeed, rb2d.velocity.y);
		}


		if (grabbing == true) {
			PSR.color = Color.black;
		}
		if (grabbing == false) {
			PSR.color = Color.white;
		}
	}
        /*------------------------------------------ADDED------------------------------------------
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (thingToPull != null)
            {
                if (can_pp == true)
                {
                    thingToPull.transform.SetParent(gameObject.transform);
                    can_pp = false;
                    can_jump = false;
                    grabbing = true;
                }
                else
                {
                    thingToPull.transform.SetParent(originalParent);
                    can_pp = true;
                    can_jump = true;
                    grabbing = false;
                }
            }
        }

    }*/

	void Update () {

       if (!isLocalPlayer)
            return;

		if (Input.GetButtonDown ("Jump")) {
			if (grounded == true) {
				rb2d.AddForce (Vector2.up * jumpPower);
				grounded = false;
			}
		}

		if (Input.GetButtonDown ("Grab")) {
			if (canGrab == true) {
				grabbing = true;

                obj.transform.SetParent (gameObject.transform);
                Debug.Log("Parent: " + obj.transform.parent);
                obj.GetComponent<Rigidbody2D>().isKinematic = true;
                //if (obj.CompareTag ("Player")) {
                //obj.GetComponent<Rigidbody2D>().isKinematic = true;
                //obj.GetComponent<PlayerController> ().beingGrabbed = true;
                //}*/
                CmdGrab();
            }
		}

		if (Input.GetButtonUp ("Grab")) {
            grabbing = false;
            //if (obj.CompareTag ("Player")) {
            //obj.GetComponent<Rigidbody2D>().isKinematic = false;
            //obj.GetComponent<PlayerController> ().beingGrabbed = false;
            //}
            obj.transform.SetParent (null);

            CmdStopGrab();
		}
        /*------------------------------------------ADDED------------------------------------------
        if (Input.GetKeyDown(KeyCode.D) && can_pp == false && thingToPull != null)
        {
            Debug.Log("D pressed");
            thingToPull.transform.SetParent(originalParent);
            thingToPull.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            StartCoroutine(MakeKinematic());

        }

        if (Input.GetKeyDown(KeyCode.E))
            Want_Stretch();
    }*/

	//void OnCollisionEnter2D(Collision2D col){
        //obj.GetComponent<Rigidbody2D>().isKinematic = false;
        /*ADDED*/
		//if (col.gameObject.tag == "box"||col.gameObject.tag == "g_box"||col.gameObject.tag == "stone_box")
        //{
        //    thingToPull = col.transform;
        //    originalParent = col.transform.parent;
        //}
    //}

    /*ADDED*/
	}

    [Command]
    void CmdGrab()
    {
        obj.transform.SetParent(gameObject.transform);
        Debug.Log("Parent: " + obj.transform.parent);
        obj.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    [Command]
    void CmdStopGrab()
    {
        //grabbing = false;
        //if (obj.CompareTag ("Player")) {
        //obj.GetComponent<Rigidbody2D>().isKinematic = false;
        //obj.GetComponent<PlayerController> ().beingGrabbed = false;
        //}
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

    void Want_Stretch()
    {
        Debug.Log("stretch?");
        gameObject.SendMessageUpwards("RequestStretch", 1.0f);
    }

    /*ADDED*/
    IEnumerator MakeKinematic()
    {
        yield return new WaitForSeconds(1.3f);
        Debug.Log("waited");
        thingToPull.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        can_pp = true;
        thingToPull = null;
        originalParent = null;
        StopCoroutine(MakeKinematic());
    }
}
