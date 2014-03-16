using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// speed of the ship
	public Vector2 speed = new Vector2(20, 20);

	// store the movment
	protected Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		// 4 - Movement per direction
		movement = new Vector2(speed.x * inputX, 
		                       speed.y * inputY);

		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon) {
				weapon.Attack(false);
			}
		}
	}

	void FixedUpdate(){
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
	}
}
