using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour {
	
	private bool facingLeft = true;
	
	void FlipHorizontal(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;																
		theScale.x *= -1;																						
		transform.localScale = theScale;
	}

	void Update () {					
		if (Input.GetKey ("left") || Input.GetKey (KeyCode.A))						
			if(facingLeft) FlipHorizontal ();
		if (Input.GetKey ("right") || Input.GetKey (KeyCode.D))						
			if(!facingLeft) FlipHorizontal ();
	}

}
