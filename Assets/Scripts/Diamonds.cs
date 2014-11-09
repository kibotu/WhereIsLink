using UnityEngine;
using System.Collections;

public class Diamonds : MonoBehaviour
{
    public int worth;    
    public Animator animator;
	public AudioSource audioSource;

    
    void Start()
    {
        switch (worth)
        {
            case 1:
                animator.Play("GreenDiamond");
                break;
            case 3:
                animator.Play("BlueDiamond");
                break;
            case 5:
                animator.Play("RedDiamond");
                break;

            default:
                animator.Play("GreenDiamond");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
	void OnCollisionEnter2D(Collision2D coll) 
	{
		print(coll.gameObject.tag);
		if (coll.gameObject.tag == "Player")
		{
			audioSource.Play();
			StartCoroutine(Waits(audioSource.clip.length));


		}
	}
	public IEnumerator Waits(float time){
		yield return new WaitForSeconds (time);
		Destroy(this.gameObject);
	}
}

