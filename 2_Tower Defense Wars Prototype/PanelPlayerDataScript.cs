using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPlayerDataScript : MonoBehaviour {

	public Text TextLives, TextGold, TextIncome, TextNextIncome;

	GameControl gameControl;
    
	void Start () {
		gameControl = GameObject.Find ("GameController").GetComponent<GameControl> ();
	}
	
	void Update () {
		TextLives.text = gameControl.Lives.ToString ();
		TextGold.text = gameControl.Gold.ToString ();
		TextIncome.text = gameControl.Income.ToString ();
		TextNextIncome.text = gameControl.TimerIncome.ToString ("##.000");
	}
}
