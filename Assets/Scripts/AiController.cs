using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AiController : MonoBehaviour {

	public AttackController attackCtrl;
	public AnimationController animCtrl;
	public PlayerController player;
	public float AggroRange;
	public HealthController life;
	public float MovementSpeed;

	public bool IsInCombat;

	public Color startColor;

    public GameObject camp;
    public float spawnWanderingRadius;
    public float patrolAttackRadius;
    public float patrolSightRadius;

    public GameObject pathSet;
    public List<Vector3> Path = new List<Vector3>();
    public bool isPatrolling;

    private IAiState _state;
    public IAiState State
    {
        get { return _state;  }
        set
        {
            _state = value;
            _state.Init(this);
        }

    }

	public void Start() {
		startColor = transform.GetChild(0).GetComponent<SpriteRenderer> ().color;

	    if (isPatrolling)
	    {
            var children = pathSet.transform.GetComponentsInChildren<Transform>();
            foreach (var transf in children)
            {
                Path.Add(transf.position);
            }

            State = new AiStatePatrolling();
	    }
	    else
	    {
            State = new AiStateWaiting();
	    }
	}


	public void Defend (AttackController attackCtrl)
	{
		life.Health -= attackCtrl.Damage;
		transform.GetChild(0).GetComponent<SpriteRenderer> ().color = Color.red;
		Debug.Log (gameObject.name + " red");
		StopCoroutine ("Colorize");
		StartCoroutine ("Colorize");
	}

	public IEnumerator Colorize() {
		yield return new WaitForSeconds (0.3f);
		Debug.Log (gameObject.name + " reset color");
		transform.GetChild(0).GetComponent<SpriteRenderer> ().color = startColor;
	}

	public void AttackPlayer (PlayerController player)
	{
		// enemy attacks player
		player.Defend (attackCtrl);
	}

	public void Update() {

		if (player == null)
			return;

		State.Update();
	}

    public bool InPatrolAttackRadius()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        return distance <= patrolAttackRadius;
    }
    public bool InPatrolSightRadius()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        return distance <= patrolSightRadius;
    }
    public bool InAggroRadius()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        return distance <= AggroRange;
    }
    public bool InAttackRadius()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        return distance <= attackCtrl.AttackRange;
    }

    public void AttackPlayer ()
	{
		Debug.Log ("Attack player");

        #region catch inputs

        // NORTH_EAST
        if (isNorth() && isEast())
        {
            attackCtrl.Direction(Direction.NORTH_EAST);
        }

        // NORTH_WEST
        else if (isNorth() && isWest())
        {
            attackCtrl.Direction(Direction.NORTH_WEST);
        }

        // SOUTH_EAST
        else if (isSouth() && isEast())
        {
            attackCtrl.Direction(Direction.SOUTH_EAST);
        }

        // SOUTH_WEST
        else if (isSouth() && isWest())
        {
            attackCtrl.Direction(Direction.SOUTH_WEST);
        }

        // NORTH
        else if (isNorth())
        {
            attackCtrl.Direction(Direction.NORTH);
        }

        // EAST
        else if (isEast())
        {
            attackCtrl.Direction(Direction.EAST);
        }

        // WEST
        else if (isWest())
        {
            attackCtrl.Direction(Direction.WEST);
        }

        // SOUTH
        else if (isSouth())
        {
            attackCtrl.Direction(Direction.SOUTH);
        }

        #endregion

        attackCtrl.Attack();
	}

    private bool isEast()
    {
        return transform.position.x > player.transform.position.x;
    }

    private bool isWest()
    {
        return transform.position.x < player.transform.position.x;
    }

    private bool isSouth()
    {
        return transform.position.y > player.transform.position.y;
    }

    private bool isNorth()
    {
        return transform.position.y < player.transform.position.y;
    }

    public void MoveTowardsPlayer()
    {
        MoveTowards(player.transform.position);
    }

	public void MoveTowards (Vector3 target)
	{
        float x = (transform.position.x - target.x);
        float y = (transform.position.y - target.y);
        
        // x<0, wenn player rechts von AI
        // y<0, wenn player über AI

	    if (Mathf.Abs(x) < Mathf.Abs(y))
	    {
	        if (y < 0)
	        {
	            animCtrl.playWalkUp();
	        }
	        else animCtrl.playWalkDown();
	    }
	    else if (x < 0)
	    {
	        animCtrl.playWalkRight();
	    }
        else if (x >= 0) 
        {
            animCtrl.playWalkLeft();
	    }
		else animCtrl.playIdle();

        transform.position = Vector3.MoveTowards(transform.position, target, MovementSpeed * Time.deltaTime);
	}

    public void GotoPlayer()
    {
        Debug.Log("SetToAttackMode");
        State = new AiStateGotoPlayer();
    }
}
