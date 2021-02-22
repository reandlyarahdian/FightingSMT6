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

    public void SetupBehaviour()
    {
        SetupAnimationIDs();
    }

    void SetupAnimationIDs()
    {
        Move = Animator.StringToHash("Speed");
        Attack = Animator.StringToHash("Punch");
        Defend = Animator.StringToHash("Defend");
    }

    public void MovementAnimation(float Value)
    {
        anim.SetFloat(Move, Value);
    }

    public void AttackAnimation()
    {
        anim.SetTrigger(Attack);
    }
    public void DefendAnimation()
    {
        anim.SetTrigger(Defend);
    }
}
