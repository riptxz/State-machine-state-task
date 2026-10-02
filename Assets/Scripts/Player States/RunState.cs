
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using TMPro;
using UnityEngine;

public class RunState : State
{
    protected float speed;
    protected float rotationSpeed;

    public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {

        player.animator.SetBool("isMoving", true);

        speed = 3;
        base.Enter();
        horizontalInput = verticalInput = 0.0f;

        Debug.Log("entering running state");
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {

        TestMethod("hello");

        ReadInput();

        if (!player.moveAction.IsInProgress())
        {
            sm.ChangeState(sm.idleState);
            player.animator.SetBool("isMoving", false);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
            player.animator.SetBool("isMoving", false);
        }

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
            player.animator.SetBool("isMoving", false);
        }

        if (player.crouchAction.IsPressed())
        {
            sm.ChangeState(sm.crouchState);
            player.animator.SetBool("isMoving", false);
        }

        //debug move gameObject
        player.rb.linearVelocity = player.moveAction.ReadValue<Vector2>() * speed;


        UIscript.ui.DrawText("*** This is the running state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move Sprite");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Space = Jump state");



    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided in runstate");

        if( collision.tag == "enemy")
        {
            Debug.Log("Player is colliding with enemy");
        }
    }
    public override void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collision in runstate");

        if (collision.tag == "enemy")
        {
            Debug.Log("Player has stopped colliding with enemy");
        }
    }



    public override void FixedUpdate()
    {
    }
}
