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

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
			Attack ();

		if(Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");

		if(Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");

		#region catch inputs

		// NORTH_EAST
		if (pressedNorth() && pressedEast()) {
			WalkNorthEast();
		} 
		
		// NORTH_WEST
		else if (pressedNorth() && pressedWest()) {
			WalkNorthWest();
		}
		
		// SOUTH_EAST
		else if (pressedSouth() && pressedEast()) {
			WalkSouthEast();
		}
		
		// SOUTH_WEST
		else if (pressedSouth() && pressedWest()) {
			WalkSouthWest();
		}

		// NORTH
		else if(pressedNorth()) {
			WalkNorth();
		}

		// EAST
		else if (pressedEast()) {
			WalkEast();
		}

		// WEST
		else if (pressedWest()) {
			WalkWest();
		}

		// SOUTH
		else if (pressedSouth()) {
			WalkSouth();
		}
		
		// MIDDLE 
		else {
			animationController.playIdle();
		}

		#endregion

	}

	#region player inputs

	public bool pressedNorth() {
        return Input.GetKey("up") || Input.GetKey(KeyCode.W) ;
	}

	public bool pressedEast() {
		return Input.GetKey ("left") || Input.GetKey (KeyCode.A);
	}

	public bool pressedSouth() {
		return Input.GetKey ("down") || Input.GetKey (KeyCode.S);
	}

	public bool pressedWest() {
		return Input.GetKey ("right") || Input.GetKey (KeyCode.D);
	}

	#endregion

	#region handle inputs

	void WalkNorthEast ()
	{
		animationController.playWalkUp ();
		transform.position += (Vector3.up + Vector3.left) * Speed;
		attackCtrl.Direction(Direction.NORTH_EAST);
	}

	void WalkNorth ()
	{
		animationController.playWalkUp ();
		transform.position += Vector3.up * Speed;
		attackCtrl.Direction(Direction.NORTH);
	}

	void WalkNorthWest ()
	{
		animationController.playWalkUp ();
		transform.position += (Vector3.up + Vector3.right) * Speed;
		attackCtrl.Direction(Direction.NORTH_WEST);
	}

	void WalkEast ()
	{
		animationController.playWalkLeft ();
		transform.position += Vector3.left * Speed;
		attackCtrl.Direction(Direction.EAST);
	}

	void WalkWest ()
	{
		animationController.playWalkRight ();
		transform.position += Vector3.right * Speed;
		attackCtrl.Direction(Direction.WEST);
	}

	void WalkSouthEast ()
	{
		animationController.playWalkDown ();
		transform.position += (Vector3.down + Vector3.left) * Speed;
		attackCtrl.Direction(Direction.SOUTH_EAST);
	}

	void WalkSouth ()
	{
		animationController.playWalkDown ();
		transform.position += Vector3.down * Speed;
		attackCtrl.Direction(Direction.SOUTH);
	}

	void WalkSouthWest ()
	{
		animationController.playWalkDown ();
		transform.position += (Vector3.down + Vector3.right) * Speed;
		attackCtrl.Direction(Direction.SOUTH_WEST);
	}

	#endregion

	public void updateHealth () {
		healtbar.SetHealthBar (Mathf.Clamp(life.Health / life.MaxHealth,0f, 1f));
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

	public void Defend(AttackController enemy) {
		EnterCombat ();
		life.Health -= attackCtrl.Damage;
	}
}



