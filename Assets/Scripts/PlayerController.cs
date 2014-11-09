using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float Speed;
	public AttackController attackCtrl;
	public AnimationController animationController;
	public HealthController life;
	public HealthbarSlider healtbar;
	public AudioSource CombatSound;
	public AudioSource DefaultBackgroundSound;

	public bool IsInCombat;
	public float CombatTimeOut;
	public float _currentTimeInCombat;

	public void Start() {
		LeaveCombat ();
	}

	public void EnterCombat() {
		IsInCombat = true;
		_currentTimeInCombat = CombatTimeOut;

		// play combat sound
		if (!CombatSound.isPlaying) {
			// CombatSound.audio.time = 60+54;
			CombatSound.Play ();
			DefaultBackgroundSound.Pause ();
		}
	}

	public void LeaveCombat() {
		IsInCombat = false;

		// play default music
		if (!DefaultBackgroundSound.isPlaying) {
			CombatSound.Pause ();
			DefaultBackgroundSound.Play ();
		}
	}

	void Update () {

		if (IsInCombat) {
			_currentTimeInCombat -= Time.deltaTime;
			if(_currentTimeInCombat <= 0) 
				LeaveCombat();
		}

		updateHealth ();

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

	public void updateHealth () {
		healtbar.SetHealthBar (Mathf.Clamp(life.Health / life.MaxHealth,0f, 1f));
	}

	void WalkRight ()
	{
		animationController.playWalkRight ();
		transform.position += Vector3.right * Speed;
		attackCtrl.Direction(Vector3.right);
	}

	void WalkLeft ()
	{	
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

	public void AttackEnemy (AiController enemy)
	{
		// player attacks enemy
		enemy.Defend (attackCtrl);
		EnterCombat ();
	}

	public void Defend(AiController enemy) {
		EnterCombat ();
	}
}



