using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
  
    public enum PlayerType
    {
        HUMAN, AI
    };
    public AIStates currentState = AIStates.Idle;
    public PlayerType player;


    private Rigidbody rigidbody;
    private float random;
    private float randomSetTime;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        

    }

    public bool attacking
    {
        get
        {
            return currentState == AIStates.Attack;
        }
    }

    public bool attack2
    {
        get
        {
            return currentState == AIStates.Attack2;
        }
    }

    public Rigidbody Body
    {
        get
        {
            return this.rigidbody;
        }
    }

}


