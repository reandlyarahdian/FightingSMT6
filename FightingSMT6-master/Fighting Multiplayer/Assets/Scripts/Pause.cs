using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public bool isPaused;
    public float sec = 0.1f;
    private BTNSFX bTNSFX;
    // Start is called before the first frame update
    void Start()
    {
        pause = GameObject.Find("Pause");
        bTNSFX = GetComponent<BTNSFX>();
        StartCoroutine(IlanginPause());
    }
        // Update is called once per frame
        void Update()
    {
        
    }

    public void Paused(InputAction.CallbackContext callback)
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        bTNSFX.PauseSFX();
    }

    public void continueG()
    {
       pause.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    IEnumerator IlanginPause()
    {
        yield return new WaitForSeconds(sec);

        pause.SetActive(false);
    }
}
