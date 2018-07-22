using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGenerator : MonoBehaviour {

	public float Gravity = -8.9f;

	public void Attract (Transform attractedTrans) {
		Rigidbody attractorBody = this.GetComponent<Rigidbody> ();
		Rigidbody attractedBody = attractedTrans.GetComponent<Rigidbody> ();

		Vector3 gravityUp = (attractedTrans.position - transform.position).normalized;
		Vector3 attractedBodyUp = attractedTrans.up;

		attractedBody.AddForce (gravityUp * Gravity);

		Quaternion targetRotation = Quaternion.FromToRotation (attractedBodyUp, gravityUp) * attractedTrans.rotation;

		attractedTrans.rotation = Quaternion.Slerp (attractedTrans.rotation, targetRotation, 50 * Time.deltaTime);
	}
}
