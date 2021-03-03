using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCombo : MonoBehaviour
{
    Animator animator;
    ControlManager controlManager;

    int CurrentComboPriorty = 0;

    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (controlManager == null)
            controlManager = FindObjectOfType<ControlManager>();
    }

    public void PlayMove(Moves move, int ComboPriorty) //Get the Move and the Priorty
    {
        if (Moves.None != move) //if the move is none ignore the function
        {
            if (ComboPriorty >= CurrentComboPriorty) //if the new move is higher Priorty play it and ignore everything else
            {
                CurrentComboPriorty = ComboPriorty; //Set the new Combo
                ResetTriggers(); //Reset All Animation Triggers
                controlManager.ResetCombo(); //Reset the List in the ControlsManager
            }
            else
                return;


            //Set the Animation Triggers
            switch (move)
            {
                case Moves.A:
                    animator.SetTrigger("A");
                    break;
                case Moves.B:
                    animator.SetTrigger("B");
                    break;
                case Moves.C:
                    animator.SetTrigger("C");
                    break;
            }
            CurrentComboPriorty = 0; //Reset the Combo Priorty
        }
    }

    void ResetTriggers() //Reset All the Animation Triggers so we don't have overlapping animations
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.ResetTrigger(parameter.name);
        }
    }


}
