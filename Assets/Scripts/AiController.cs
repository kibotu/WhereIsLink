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

	public void AttackPlayer (PlayerController player)
	{
		// enemy attacks player
		player.Defend (attackCtrl);
	}

	public void Update() {

		if (player == null)
			return;

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

		if (transform.position.x > player.transform.position.x)
			attackCtrl.Direction(Vector3.right);

		if (transform.position.x < player.transform.position.x)
			attackCtrl.Direction(Vector3.left);

		if (transform.position.y > player.transform.position.y)
			attackCtrl.Direction(Vector3.down);

		if (transform.position.y < player.transform.position.y)
			attackCtrl.Direction(Vector3.up);
		
		attackCtrl.Attack ();
	}

	void MoveTowardsPlayer ()
	{
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, MovementSpeed*Time.deltaTime);
	}
}
