using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour {

	public AttackController attackCtrl;
	public PlayerController player;
	public float AggroRange;
	public HealthController life;
	public float MovementSpeed;

	public bool IsInCombat;

	public void Defend (AttackController attackCtrl)
	{
		life.Health -= attackCtrl.Damage;
	}

	public void Update() {

		float distance = Vector3.Distance (player.transform.position, transform.position);

		if (distance <= AggroRange) {
			Debug.Log (gameObject.name + ": Target in sight!");
			IsInCombat = true;
		}

		if (IsInCombat) {
			if(distance <= attackCtrl.AttackRange)
				AttackPlayer();
			else
				MoveTowardsPlayer();
		}
	}

	void AttackPlayer ()
	{
		Debug.Log ("Attack player");
	}

	void MoveTowardsPlayer ()
	{
		Debug.Log ("MoveTowardsPlayer");
		//transform.Translate ();
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, MovementSpeed*Time.deltaTime);
	}
}
