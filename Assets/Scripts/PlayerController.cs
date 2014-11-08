using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float Speed;

    private Animator animator;

	void Start ()
	{
	    animator = GetComponent<Animator>();
	}
	
	void Update () {

       

	    if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
	    {
	        WalkDown();
	        animator.Play("WalkDown");
	    }else

		if (Input.GetKey ("up") || Input.GetKey (KeyCode.W))
		{
			WalkUp();
            animator.Play("WalkUp");
        }else

		if (Input.GetKey ("left") || Input.GetKey (KeyCode.A))
		{
			WalkLeft();
            animator.Play("WalkLeft");
        }else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            WalkRight();
            animator.Play("WalkRight");
        }
        else
        {
            animator.Play("idle");
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
