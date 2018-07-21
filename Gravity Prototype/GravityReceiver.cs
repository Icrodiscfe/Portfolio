using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReceiver : MonoBehaviour {

	public GravityGenerator GravityGeneratorObject;
		

	void FixedUpdate () {
		GravityGeneratorObject.Attract (transform);
	}
}
