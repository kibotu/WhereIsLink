//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34014
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

public class AiStateInforming : IAiState
{
    private AiController aiController;

    public void Init(AiController aiController)
    {
        this.aiController = aiController;
    }
	
	public void Update()
	{
        // 1) in patrolling combat radius
        if (aiController.InPatrolAttackRadius() == true)
        {
            aiController.State = new AiStateAttacking();
        }
        // 2) In camp?
        else if (Vector3.Distance(aiController.camp.transform.position, aiController.transform.position) <= 0.5f)
        {
            aiController.State = new AiStateAttacking();
            // 2.1) Make other enemies attack the player.
            aiController.camp.BroadcastMessage("GotoPlayer", SendMessageOptions.DontRequireReceiver);
        }
        // 3) walk along way path
        else
        {
            aiController.MoveTowards(aiController.camp.transform.position);
        }
	}
}

