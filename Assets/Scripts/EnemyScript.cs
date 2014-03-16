using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private WeaponScript[] weapons;

	void Awake()
	{
		weapons = gameObject.GetComponentsInChildren<WeaponScript> ();
	}

	// Update is called once per frame
	void Update () {

		foreach (WeaponScript weapon in weapons) {
			if (weapon && weapon.CanAttack) {
				weapon.Attack(true);
			}
		}
	}
}
