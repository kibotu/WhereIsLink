using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float Speed;
	public AttackController attackCtrl;
	public AnimationController animationController;

	void Start(){
		//animationController = GetComponent<AnimationController> ();
		}
	
	void Update () {

		if (Input.GetKey ("down") || Input.GetKey (KeyCode.S)) {
						WalkDown ();
						animationController.playWalkDown ();
		} else if (Input.GetKey ("up") || Input.GetKey (KeyCode.W)) {
						WalkUp ();
						animationController.playWalkUp ();
		} else if (Input.GetKey ("left") || Input.GetKey (KeyCode.A)) {

						WalkLeft ();
						animationController.playWalkLeft ();
		} else if (Input.GetKey ("right") || Input.GetKey (KeyCode.D)) {
						WalkRight ();
						animationController.playWalkRight ();
		} else {
						animationController.playIdle();
		}

		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.Space))
			Attack ();
		if(Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");
		if(Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");

	}

	void WalkRight ()
	{
		transform.position += Vector3.right * Speed;
		attackCtrl.Direction(Vector3.right);
	}

	void WalkLeft ()
	{	
		transform.position += Vector3.left * Speed;
		attackCtrl.Direction(Vector3.left);
	}

	void WalkUp ()
	{
		transform.position += Vector3.up * Speed;
		attackCtrl.Direction(Vector3.up);
	}

	void WalkDown ()
	{
		transform.position += Vector3.down * Speed;
		attackCtrl.Direction(Vector3.down);
	}

	void Attack ()
	{
		attackCtrl.Attack ();
	}
	void Flip(){
		Vector3 theScale = transform.localScale;																
		theScale.x *= -1;																						
		transform.localScale = theScale;
	}									
}



