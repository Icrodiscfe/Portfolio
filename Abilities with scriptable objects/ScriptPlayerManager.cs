using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScriptPlayerManager : MonoBehaviour {

	public Transform AbilitysPanel;
	public GameObject AbilityPrefab;
	public List<ScriptableObjectAbility> Abilitys;
    
    void Start () {
		IniAbilitys ();
    }

	void IniAbilitys () {
		foreach (ScriptableObjectAbility Ability in Abilitys) {
			if (Ability.Level > 0) {
				Instantiate (AbilityPrefab, AbilitysPanel).GetComponent<ScriptAbilityPrefab> ().SetAbility (Ability);
			}
		}
	}

	public void ButtonAddAbilitys () {
		foreach (ScriptableObjectAbility Ability in Abilitys) {
			if (Ability.Level == 0) {
				Ability.AddAbility ();
				Instantiate (AbilityPrefab, AbilitysPanel).GetComponent<ScriptAbilityPrefab> ().SetAbility (Ability);
			}
		}
	}
}


