using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float MoveSpeed = 15.0f;
	Vector3 MoveDir;
	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		MoveDir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;

		if (Input.GetKey (KeyCode.Space))
			MoveDir = MoveDir + new Vector3 (0, 1, 0);
	}

	void FixedUpdate () {
		rigidbody.MovePosition (rigidbody.position + transform.TransformDirection (MoveDir) * MoveSpeed * Time.deltaTime);
	}
}
