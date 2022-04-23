using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{

    private int jumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
        jumpsLeft = playerData.maxJumps;
    }

    public override void Enter()
    {
        base.Enter();
        
        player.InputHandler.UseJumpInput();
        core.Movement.SetVelocityY(playerData.jumpForce);
        jumpsLeft--;
        isAbilityDone = true;
        player.InAirState.SetIsJumping();
    }

    public bool CanJump()
    {
        if (jumpsLeft > 0)
        {
            return true;
        }
        else if (isAbilityDone)
        {
            return false;
        }
        return true;
    }
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public void ResetAmountOfJumpsLeft() => jumpsLeft = playerData.maxJumps;

    public void DecreaseAmountOfJumpsLeft() => jumpsLeft--;

}
