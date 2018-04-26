using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
	public float mySpeed, jumpSpeed;

    private Rigidbody myRigidbody;
    private bool grounded = true;

	private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
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

    private void Move()
    {
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            input += Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow))
            input += Vector3.right;

        input.Normalize();

        Vector3 newPosition = myRigidbody.position + input * mySpeed * Time.deltaTime;
        myRigidbody.MovePosition(newPosition);
    }

    private void Jump()
    {
        Debug.Log(grounded);
        if (grounded == true)
        {
            myRigidbody.AddForce(Vector3.up * jumpSpeed);
            grounded = false;
        }
    }
}
