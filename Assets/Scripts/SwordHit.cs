using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {

	public AudioSource touche;
	public AudioSource hitflesh;

	void OnCollisionEnter2D(Collision2D coll) {

		foreach (var col in coll.contacts) {

			// hitting swords, do nothing
			if(col.collider.gameObject.name.StartsWith("Sword")) {
				Debug.Log("cling...");
				touche.Stop();
				touche.Play();
				continue;
			}
			
			// player hits enemy
            if (coll.gameObject.tag.Equals("Enemy") || coll.gameObject.tag.Equals("AI Link"))
            {
				Debug.Log ("hits " + col.collider.gameObject.name);
				var enemy = coll.transform.gameObject.GetComponent<AiController>();
				var player = gameObject.transform.parent.parent.gameObject.GetComponent<PlayerController>();

				if(player != null) 
					player.AttackEnemy(enemy);
			}
			
			// enemy hits player
			if (coll.gameObject.tag.Equals ("Player")) {
				Debug.Log ("hits " + col.collider.gameObject.name);
				var enemy = gameObject.transform.parent.parent.gameObject.GetComponent<AiController>();
				var player = coll.transform.gameObject.GetComponent<PlayerController>();

				if(enemy != null) 
					enemy.AttackPlayer(player);
			}
		}
	}
}
