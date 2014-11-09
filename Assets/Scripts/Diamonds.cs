using UnityEngine;
using System.Collections;

public class Diamonds : MonoBehaviour
{
    public int worth;    
    public Animator animator;

    
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
    
}

