using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour {

	public AttackController attackCtrl;
	public AnimationController animCtrl;
	public PlayerController player;
	public float AggroRange;
	public HealthController life;
	public float MovementSpeed;

	public bool IsInCombat;

	public Color startColor;

	public void Start() {
		startColor = transform.GetChild(0).GetComponent<SpriteRenderer> ().color;		
	}

	public void Defend (AttackController attackCtrl)
	{
		life.Health -= attackCtrl.Damage;
		transform.GetChild(0).GetComponent<SpriteRenderer> ().color = Color.red;
		Debug.Log (gameObject.name + " red");
		StopCoroutine ("Colorize");
		StartCoroutine ("Colorize");
	}

	public IEnumerator Colorize() {
		yield return new WaitForSeconds (0.3f);
		Debug.Log (gameObject.name + " reset color");
		transform.GetChild(0).GetComponent<SpriteRenderer> ().color = startColor;
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
			attackCtrl.Direction(Direction.EAST);

		if (transform.position.x < player.transform.position.x)
			attackCtrl.Direction(Direction.WEST);

		if (transform.position.y > player.transform.position.y)
			attackCtrl.Direction(Direction.SOUTH);

		if (transform.position.y < player.transform.position.y)
			attackCtrl.Direction(Direction.NORTH);
		
		attackCtrl.Attack ();
	}

	void MoveTowardsPlayer ()
	{
	    float x = (transform.position.x - player.transform.position.x);
	    float y = (transform.position.y - player.transform.position.y);
        
        // x<0, wenn player rechts von AI
        // y<0, wenn player über AI

	    if (Mathf.Abs(x) < Mathf.Abs(y))
	    {
	        if (y < 0)
	        {
	            animCtrl.playWalkUp();
	        }
	        else animCtrl.playWalkDown();
	    }
	    else if (x < 0)
	    {
	        animCtrl.playWalkRight();
	    }
        else if (x >= 0) 
        {
            animCtrl.playWalkLeft();
	    }
		else animCtrl.playIdle();

		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, MovementSpeed*Time.deltaTime);
	}
}
