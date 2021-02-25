using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    //Animation String IDs
    private int Move;
    private int Attack;
    private int Defend;
    private int Hit;

    public void SetupBehaviour()
    {
        SetupAnimationIDs();
    }

    void SetupAnimationIDs()
    {
        Move = Animator.StringToHash("Speed");
        Attack = Animator.StringToHash("Punch");
        Defend = Animator.StringToHash("Defend");
        Hit = Animator.StringToHash("Hit");
    }

    public void MovementAnimation(float movementBlendValue)
    {
        anim.SetFloat(Move, movementBlendValue);
    }

    public void AttackAnimation()
    {
        anim.SetTrigger(Attack);
    }
    public void DefendAnimation()
    {
        anim.SetTrigger(Defend);
    }

    public void HitAnimation()
    {
        anim.SetTrigger(Hit);
    }
}
