using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public Transform shotPrefab;

	public float shootingRange = 0.25f;

	private float shootCooldown;

	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;	
		}

	}

	// shooting from another script
	public void Attack(bool isEnemy)
	{
		if (CanAttack) {

			shootCooldown = shootingRange;

			// create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

			// assign position
			shotTransform.position = transform.position;

			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

			if(shot)
			{
				shot.isEnemyShot = isEnemy;
			}

			// make the weapon alwas towards
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if(move)
			{
				move.direction = this.transform.right;
			}
		}
	}

	public bool CanAttack
	{
		get {
			return shootCooldown <= 0f;
		}
	}
}
