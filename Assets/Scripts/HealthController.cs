using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public float Health;
	public float MaxHealth;
	public float HealthRegen;
	public float HealthRegenInterval;
	public float startTime;
	public GameObject DeathAnim;
	public HealthbarSlider healthbar;
	
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
		
		if (gameObject.tag.Equals ("AI Link")) {
			Application.LoadLevel ("endScreen");
		}else if (gameObject.tag.Equals ("Player")) {
			Application.LoadLevel("loseScreen");
		} else {
			(Instantiate (DeathAnim) as GameObject).transform.position = transform.position;
		}
		(Instantiate (DeathAnim) as GameObject).transform.position = transform.position;
		Destroy (gameObject);

		if(healthbar != null) 
			healthbar.SetHealthBar (0);

	}

	private IEnumerator RotateCamera() {
		yield return new WaitForEndOfFrame();
		//Camera.main.transform.Rotate ();

		//(Instantiate (DeathAnim) as GameObject).transform.position = transform.position;
	}
}
