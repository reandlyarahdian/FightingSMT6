using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public enum PlayerType
    {
        HUMAN, AI
    };
   
    public AIStates currentState = AIStates.Idle;
    public PlayerType player;
    public Human oponent;
  
    public Animator animator;
    private Rigidbody rigidbody;

    public HealthStats health;
    public int index = 0;
    public float speed;
    private float random;
    private float randomSetTime;
     public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        oponent = FindObjectOfType<Human>();
        
    }

    public void SetupPAI(HealthStats stats, int i)
    {
        
        stats.SetupBehaviour();
        health = stats;
        index = i;
    }

    // Update is called once per frame
    void Update()
    {
        //if (player == PlayerType.HUMAN)
        //{
        //  UpdateHumanInput();
        //}
        //else
        //{
        //  UpdateAI();
        //}
        UpdateAI();
    }

    //public void UpdateHumanInput()
    //{
    // if (Input.GetAxis("Horizontal") > 0.1)
    //{
    //  animator.SetBool("walk", true);
    //}
    //else
    //{
    // animator.SetBool("walk", false);
    //}

    //if (Input.GetAxis("Horizontal") < -0.1)
    //{
    //  animator.SetBool("walk_back", true);
    //}
    //else
    //{
    //  animator.SetBool("walk_back", false);
    //}
    //if (Input.GetKeyDown(KeyCode.A))
    //{
    //  animator.SetTrigger("Punch");
    //}
    //if (Input.GetKeyDown(KeyCode.S))
    //{
    //  animator.SetTrigger("attack2");
    //}

    //}


   

    public void UpdateAI()
    {
        animator.SetBool("defending", defending);
        animator.SetBool("OpponentAttacking", oponent.attacking);
        animator.SetBool("GetBack", oponent.attack2);

        animator.SetFloat("distanceToOponent", getDistancetoOponent());

        if (Time.time - randomSetTime > 1)
        {
            random = Random.value;
            randomSetTime = Time.time;
        }
        animator.SetFloat("random", random);
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

    private float getDistancetoOponent()
    {
        return Mathf.Abs(transform.position.x - oponent.transform.position.x);
    }

    public bool attacking
    {
        get
        {
            return currentState == AIStates.Attack;
        }
    }

    public bool defending
    {
        get
        {
            return currentState == AIStates.Defend;
        }
    }

    public bool attack2
    {
        get
        {
            return currentState == AIStates.Attack2;
        }
    }

    public void PlaySound(AudioClip sound)
    {
        SFXUtil.PlaySound(sound, source);
    }

    public Rigidbody Body
    {
        get
        {
            return this.rigidbody;
        }
    }

    public bool HIT
    {
        get
        {
            return currentState == AIStates.Hit;
        }
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

    public void pain()
    {
        animator.SetTrigger("Hit");
    }
}
