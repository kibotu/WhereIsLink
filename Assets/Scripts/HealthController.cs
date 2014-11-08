using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public int health = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0) {
			death();
		}
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "enemy")
				health--;
	}
	void death(){
		Destroy (this);
	}
}
