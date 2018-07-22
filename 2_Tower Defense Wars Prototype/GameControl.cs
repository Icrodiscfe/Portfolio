using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    [Header("Pre-Settings")]
    public float PreTimerIncome;
    public int PreIncome, PreLives, PreGold;

    [Header("Live-Values")]
    public string PlayerName;
	public int Lives, Gold, Income;
	public float TimerIncome;


	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {
        TimerIncome = PreTimerIncome;
        Income = PreIncome;
        Lives = PreLives;
        Gold = PreGold;
    }


    void Update () {
		TimerIncome -= Time.deltaTime;
		if (TimerIncome <= 0) {
			Gold += Income;
			TimerIncome = PreTimerIncome;
		}
	}

	public void SubLive(int _amount) {
		Lives -=_amount;
	}
}
