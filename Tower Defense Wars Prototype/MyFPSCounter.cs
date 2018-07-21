using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyFPSCounter : MonoBehaviour {

	public float FrameRate;
	public Text TextFrameRate;

	float FrameCountTimer, FrameCounter;

	void Update () {
		FrameCountTimer += Time.deltaTime;
		FrameCounter++;
		if (FrameCountTimer >= 1) {
			FrameRate = FrameCounter;
			TextFrameRate.text = "FPS: " + FrameRate.ToString ();
			FrameCounter = 0;
			FrameCountTimer = 0;
		}
	}
}
