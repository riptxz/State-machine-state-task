using Unity.VisualScripting;
using UnityEngine;

public class CrouchAttackState : State
{
    public CrouchAttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("Player has crouched");

        player.animator.SetBool("isCrouching", true);
    }

    public override void Update()
    {
        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
            player.animator.SetBool("isCrouching", false);
        }

        if (player.moveAction.IsPressed())
        {
            sm.ChangeState(sm.runState);
            player.animator.SetBool("isCrouching", false);
        }
        if (!player.crouchAction.IsInProgress())
        {
            sm.ChangeState(sm.idleState);
            player.animator.SetBool("isCrouching", false);
        }

        if(player.crouchAction.IsPressed())
        {
            sm.ChangeState(sm.crouchState);
            player.animator.SetBool("isCrouching", false);
        }

    }

    public override void Exit()
    {
         base.Exit();
    }
}
