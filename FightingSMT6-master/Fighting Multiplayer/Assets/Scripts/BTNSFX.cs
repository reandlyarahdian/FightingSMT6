using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNSFX : MonoBehaviour
{
    public AudioSource clickFX;
    public AudioSource PauseS;
    public void clickSound()
    {
        clickFX.Play();
    }

    public void PauseSFX()
    {
        PauseS.Play();
    }
}
