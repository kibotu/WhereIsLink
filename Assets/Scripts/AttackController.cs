using UnityEngine;
using System.Collections;
using System;

public class AttackController : MonoBehaviour {
	
	public float AttackRadius;
	public float AttackSpeed;
	public Vector3 direction;
	public Animator animator;

	public void Start() 
	{
	}

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

	
	private IEnumerator DelayedCallback(float time, Action callback)
	{
		yield return new WaitForSeconds(time);
		callback();
	}
}
