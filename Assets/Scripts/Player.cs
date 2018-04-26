using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
    public float mySpeed, jumpSpeed;

    private Rigidbody2D myRigidbody;
    private bool grounded = true;

	private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
//        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Standable")  //All things can be stood on will have this tag
		{
			grounded = true;
		}
	}

    private void Move()
    {
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            input += Vector2.left;
            myRigidbody.transform.eulerAngles = new Vector3(0f, 180f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            input += Vector2.right;
            myRigidbody.transform.eulerAngles = new Vector3(0f, 0f);
        }
		
        input.Normalize();

        Vector2 newPosition = myRigidbody.position + input * mySpeed * Time.deltaTime;
        myRigidbody.MovePosition(newPosition);
    }

    private void Jump()
    {
        if (grounded == true)
        {
            myRigidbody.AddForce(Vector2.up * jumpSpeed);
            grounded = false;
        }
    }
}
