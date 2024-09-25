using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using Photon.Pun;

public class PlayerOnlineControl : MonoBehaviourPun
{
    public UnityEngine.InputSystem.PlayerInput input;
    public Rigidbody character;
    private float raw;
    public float speed;

    public Animator animator;
    public string currentControl;
    public HealthStats health;
    public int index = 0;
    private PhotonView pv;

    private void Start()
    {
        pv = PhotonView.Get(this);
    }

    public void onDamage(int i)
    {
        pv.RPC("Dmg", RpcTarget.All);
    }

    [PunRPC]

    void Dmg(int i)
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
        if (callback.started)
        {
            animator.SetTrigger("2");

        }
    }

    public void OnHeavyAttack(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            animator.SetTrigger("5");
        }
    }



    public void OnDefend(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            animator.SetBool("3", true);
        }
        else if (callback.canceled)
        {
            animator.SetBool("3", false);
        }
    }

    public void AnimatorMove()
    {
        animator.SetFloat("1", raw);
    }

    private void FixedUpdate()
    {
        character.velocity = new Vector3(raw * speed, 0, 0);
        AnimatorMove();
    }

}
