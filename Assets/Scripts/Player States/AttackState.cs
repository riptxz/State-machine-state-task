using Unity.VisualScripting;
using UnityEngine;

public class AttackState : State
{
    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()  // Put code for functions here
    {
        Debug.Log("Has attacked");

        player.animator.SetBool("isAttacking", true);
    }

    public override void Update()  // Check to get out of the states
    {
        if(player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
            player.animator.SetBool("isAttacking", false);
        }

        if (player.moveAction.IsPressed())
        {
            sm.ChangeState(sm.runState);
            player.animator.SetBool("isAttacking", false);
        }
        if (!player.attackAction.IsInProgress())
        {
            sm.ChangeState(sm.idleState);
            player.animator.SetBool("isAttacking", false);
        }

        if (player.crouchAction.IsPressed())
        {
            sm.ChangeState(sm.crouchState);
            player.animator.SetBool("isAttacking", false);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


}
