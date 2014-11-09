using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float Speed;
	public AttackController attackCtrl;
	public AnimationController animationController;
	private bool facingLeft = true;

	void Start(){
		//animationController = GetComponent<AnimationController> ();
		}
	
	void Update () {

		if (Input.GetKey ("down") || Input.GetKey (KeyCode.S)) {
						WalkDown ();
		} else if (Input.GetKey ("up") || Input.GetKey (KeyCode.W)) {
						WalkUp ();						
		} else if (Input.GetKey ("left") || Input.GetKey (KeyCode.A)) {						
						WalkLeft ();
		} else if (Input.GetKey ("right") || Input.GetKey (KeyCode.D)) {						
						WalkRight ();
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
		
		animationController.playWalkRight ();
		if(!facingLeft)
			Flip();
		transform.position += Vector3.right * Speed;
		attackCtrl.Direction(Vector3.right);
	}

	void WalkLeft ()
	{	
		if(facingLeft)
			Flip();
		
		animationController.playWalkLeft ();
		transform.position += Vector3.left * Speed;
		attackCtrl.Direction(Vector3.left);
	}

	void WalkUp ()
	{
		animationController.playWalkUp ();
		transform.position += Vector3.up * Speed;
		attackCtrl.Direction(Vector3.up);
	}

	void WalkDown ()
	{		
		animationController.playWalkDown ();
		transform.position += Vector3.down * Speed;
		attackCtrl.Direction(Vector3.down);
	}

	void Attack ()
	{
		attackCtrl.Attack ();
	}
	void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;																
		theScale.x *= -1;																						
		transform.localScale = theScale;
	}									
}



