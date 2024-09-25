using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateBehaviour : StateMachineBehaviour
{
    public AIStates fighterStates;
    public AudioClip SoundFX;
    public float HorizontalForce;
    public float verticalForce;
    protected PlayerTarget player;
    protected AI fighter;
    protected Human human;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fighter == null)
        {
            fighter = animator.gameObject.GetComponent<AI>();
            human= animator.gameObject.GetComponent<Human>();
        }
        if (SoundFX != null)
        {
            fighter.PlaySound(SoundFX);
            human.PlaySound(SoundFX);
        }
        human.currentState = fighterStates;
        fighter.currentState = fighterStates;
        fighter.Body.AddRelativeForce(new Vector3(0, verticalForce, 0));
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fighter.Body.AddRelativeForce(new Vector3(HorizontalForce, 0, 0));
    }
}
