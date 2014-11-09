using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public float Health;
	public float MaxHealth;
	public float HealthRegen;
	public float HealthRegenInterval;
	public float startTime;
	public GameObject DeathAnim;
	
	void Update () {
		if (Health <= 0) {
			Die();
		}

		startTime += Time.deltaTime;
		if (startTime >= HealthRegenInterval) 
		{
			startTime = 0;
			Health = Mathf.Clamp(Health + HealthRegen, 0, MaxHealth);
		}
	}

	void Die(){
		(Instantiate (DeathAnim) as GameObject).transform.position = transform.position;
		Destroy (gameObject);
	}
}
