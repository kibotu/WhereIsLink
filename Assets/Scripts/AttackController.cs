using UnityEngine;
using System.Collections;
using System;

public class AttackController : MonoBehaviour {
	
	public float AttackRange;
	public float AttackSpeed;
	public float Damage;
	public Vector3 direction;
	public Animator animator;
	public SpriteRenderer SwordSprite;
	public PolygonCollider2D SwordCollider;

	public void Attack() 
	{
		animator.StopPlayback();
		animator.Play ("SwordAttack");
	}

	public void Direction(Vector3 dir) 
	{
		direction = dir;
		if (dir.Equals(Vector3.left))
			transform.rotation = Quaternion.Euler(new Vector3(0,0,90));	
		if (dir.Equals(Vector3.right))
			transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
	    if (dir.Equals(Vector3.down))
			transform.rotation = Quaternion.Euler(new Vector3(0,0,-180));	
	    if (dir.Equals(Vector3.up))
			transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
	}

	public void Update() {
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack")) {
			SwordSprite.enabled = true;
			SwordCollider.enabled = true;
		} else {
			SwordSprite.enabled = false;
			SwordCollider.enabled = false;
		}
	}
}
