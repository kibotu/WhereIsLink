using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {


	public Animator animator;
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
	}

	public void playWalkUp(){
		animator.Play ("WalkUp");
	}
	public void playWalkRight(){
		animator.Play ("WalkRight");
	}
	public void playWalkDown(){
		animator.Play ("WalkDown");
	}
	public void playWalkLeft(){
		animator.Play ("WalkLeft");
	}
	public void playIdle(){
		animator.Play ("Idle");
	}
	public void playAttack(){
		animator.Play ("Attack");
	}
	public void playDeath(){
		animator.Play ("Death");
	}


}
