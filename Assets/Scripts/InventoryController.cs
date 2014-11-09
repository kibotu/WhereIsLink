using UnityEngine;
using System.Collections;

public class InventoryController : MonoBehaviour {

    public int coins = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll) 
    {
        print(coll.gameObject.tag);
        if (coll.gameObject.tag == "Diamond")
        {
            coins += coll.gameObject.GetComponent<Diamonds>().worth;
            print(coins);
            Destroy(coll.gameObject);
        }
    }
}
