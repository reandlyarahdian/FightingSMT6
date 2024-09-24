using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public UnityEngine.InputSystem.PlayerInput input;
    public Rigidbody character;
    private float raw;
    public float speed;

    public PlayerAnimation anim;
    public string currentControl;
    public HealthStats health;
    public int index = 0;
    
   

    public void SetupPlayer(HealthStats stats, int i)
    {
        currentControl = input.currentControlScheme;
        stats.SetupBehaviour();
        anim.SetupBehaviour();
        health = stats;
        index = i;
    }

    public void onDamage(int i)
    {
        health.UpdateHealth(i);
        if (health.GameDeath)
        {
            GameManager.Instance.index = index;
            GameManager.Instance.GameDeath();
        }
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
        if(callback.started)
        {
            anim.AttackSecond();
          
        }
    }

    public void OnHeavyAttack(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            anim.HeavyAttackAnimation();
        }
    }

    

    public void OnDefend(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            anim.DefendAnimation(callback.started);
        }
        else if (callback.canceled)
        {
            anim.DefendAnimation(!callback.canceled);
        }
    }

    public void AnimatorMove()
    {
        anim.MovementAnimation(raw);
    }

    private void Update()
    {
        StartCoroutine(onBuff());
    }

    private void FixedUpdate()
    {
        character.velocity = new Vector3(raw * speed, 0, 0);
        AnimatorMove();
    }

    IEnumerator onBuff()
    {
        if (health.health2.activeSelf)
        {
            speed = 18.75f;
            yield return new WaitForSeconds(5);
            speed = 15f;
        }
    }

  
}
