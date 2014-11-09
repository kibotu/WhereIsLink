using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {

		foreach (var col in coll.contacts) {

			// hitting swords, do nothing
			if(col.collider.gameObject.name.StartsWith("Sword")) {
				Debug.Log("cling...");
				continue;
			}
			
			// player hits enemy
			if (coll.gameObject.tag.Equals ("Enemy")) {
				Debug.Log ("hits " + coll.gameObject.name);
				//var enemy = coll.gameObject.transform.parent.gameObject.GetComponent<AiController>();
				var player = gameObject.transform.parent.parent.gameObject.GetComponent<PlayerController>();
				//enemy.
			}
			
			// enemy hits player
			if (coll.gameObject.tag.Equals ("Player")) {
				Debug.Log ("hits " + coll.gameObject.name);
				var player = coll.gameObject.transform.parent.gameObject.GetComponent<PlayerController>();
				var enemy = gameObject.transform.parent.parent.gameObject.GetComponent<AiController>();
			}
		}
	}
}
