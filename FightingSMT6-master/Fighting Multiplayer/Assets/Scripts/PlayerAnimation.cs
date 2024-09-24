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
    private int RandomAttack;
    private int HeavyAttack;

    public void SetupBehaviour()
    {
        SetupAnimationIDs();
    }

    void SetupAnimationIDs()
    {
        Move =  Animator.StringToHash("1");
        Attack = Animator.StringToHash("2");
        Defend = Animator.StringToHash("3");
        RandomAttack = Animator.StringToHash("4");
        HeavyAttack = Animator.StringToHash("5");
      
    }

    public void MovementAnimation(float movementBlendValue)
    {
        anim.SetFloat(Move, movementBlendValue);
    }

    public void AttackAnimation(float test)
    { 
        anim.SetFloat(RandomAttack, test);
    }

    public void AttackSecond()
    {
        anim.SetTrigger(Attack);
    }
    public void DefendAnimation(bool test)
    {
        anim.SetBool(Defend, test);
    }

    public void HeavyAttackAnimation()
    {
        anim.SetTrigger(HeavyAttack);
    }

    public void OnHit()
    {
        anim.SetTrigger("6");
    }
}
