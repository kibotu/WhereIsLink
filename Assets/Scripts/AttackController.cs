using UnityEngine;
using System.Collections;
using System;

public class AttackController : MonoBehaviour {

	public AudioSource swosh;
	public float AttackRange;
	public float AttackSpeed;
	public float Damage;
	public Vector3 direction;
	public Animator animator;
	public SpriteRenderer SwordSprite;
	public TrailRenderer trailrenderer;
	public PolygonCollider2D SwordCollider;
	private bool IsAttacking;

	private float _starTime;

	public void Attack() 
	{
		if (_starTime >= 0) 
			return;

		_starTime = AttackSpeed;
		animator.StopPlayback();
		animator.Play ("SwordAttack");
		swosh.Stop ();
		swosh.Play ();
	}

	public void Direction(Direction dir) {

		Quaternion rot = transform.rotation;

		/**
		 * 			  (N)
		 *	    (NW)   0°   (NE)
		 * 		  315° |   45°
		 * 		     \ |  /
		 * 	(W) 270°-------------90° (E)
		 * 			 / |  \
		 *		  225° |   135°
		 * 	    (SW)  180°   (SE)
		 * 			  (S)
		 */		
		switch(dir) {
			case global::Direction.NORTH: rot = Quaternion.Euler(new Vector3(0,0,0)); break;
			case global::Direction.NORTH_EAST: rot = Quaternion.Euler(new Vector3(0,0,45)); break; 
			case global::Direction.EAST: rot = Quaternion.Euler(new Vector3(0,0,90)); break; 
			case global::Direction.SOUTH_EAST: rot = Quaternion.Euler(new Vector3(0,0,135)); break;
			case global::Direction.SOUTH: rot = Quaternion.Euler(new Vector3(0,0,180)); break;
			case global::Direction.SOUTH_WEST: rot = Quaternion.Euler(new Vector3(0,0,225)); break;
			case global::Direction.WEST: rot = Quaternion.Euler(new Vector3(0,0,270)); break; 
			case global::Direction.NORTH_WEST: rot = Quaternion.Euler(new Vector3(0,0,315)); break;
		}

		transform.rotation = rot;
	}


	public void Update() {

		_starTime -= Time.deltaTime;

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack")) {
			SwordSprite.enabled = true;
			SwordCollider.enabled = true;
			trailrenderer.enabled = true;
		} else {
			SwordSprite.enabled = false;
			SwordCollider.enabled = false;
			trailrenderer.enabled = false;
		}
	}
}
