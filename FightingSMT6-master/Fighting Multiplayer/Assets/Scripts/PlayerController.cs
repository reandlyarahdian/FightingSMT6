using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput input;
    public Rigidbody character;
    private float raw;
    public float speed;

    public PlayerAnimation anim;
    public string currentControl;
    public void SetupPlayer()
    {
        currentControl = input.currentControlScheme;

        anim.SetupBehaviour();
    }
    public void OnControlsChanged()
    {

        if (input.currentControlScheme != currentControl)
        {
            currentControl = input.currentControlScheme;

            RemoveAllBindingOverrides();
        }
    }

    private void RemoveAllBindingOverrides()
    {
        InputActionRebindingExtensions.RemoveAllBindingOverrides(input.currentActionMap);
    }

    public void OnMovement(InputAction.CallbackContext callback)
    {
        Vector2 dir = callback.ReadValue<Vector2>();
        raw = dir.x;
    }
    public void OnAttack(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            anim.AttackAnimation();
        }
    }

    public void OnDefend(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            anim.DefendAnimation();
        }
    }

    public void AnimatorMove()
    {
        anim.MovementAnimation(raw);
    }

    private void FixedUpdate()
    {
        character.velocity = new Vector3(raw * speed, 0, 0);
        AnimatorMove();
    }
}
