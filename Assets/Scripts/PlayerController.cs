using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float Speed;

	void Start () {
	
	}
	
	void Update () {

		if (Input.GetKey ("down") || Input.GetKey (KeyCode.S))
		{
			WalkDown();
		}

		if (Input.GetKey ("up") || Input.GetKey (KeyCode.W))
		{
			WalkUp();
		}

		if (Input.GetKey ("left") || Input.GetKey (KeyCode.A))
		{
			WalkLeft();
		}

		if (Input.GetKey ("right") || Input.GetKey (KeyCode.D))
		{
			WalkRight();
		}

		if (Input.GetMouseButtonDown (0))
			Attack ();
		if(Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");
		if(Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");

	}

	void WalkRight ()
	{
		transform.position += Vector3.right * Speed;
	}

	void WalkLeft ()
	{
		transform.position += Vector3.left * Speed;
	}

	void WalkUp ()
	{
		transform.position += Vector3.up * Speed;
	}

	void WalkDown ()
	{
		transform.position += Vector3.down * Speed;
	}

	void Attack ()
	{

	}
}
