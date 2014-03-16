using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 1;

	public bool isEmeny = true;

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		if(hp <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) 
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();

		if (shot && shot.isEnemyShot != isEmeny ) {
			Damage(shot.damage);

			Destroy(shot.gameObject);
		}
	}
}
