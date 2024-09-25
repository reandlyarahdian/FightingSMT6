using System.Collections;
using UnityEngine;

public class SFXUtil 
{
    public static void PlaySound(AudioClip clip, AudioSource source)
    {
        source.Stop();
        source.clip = clip;
        source.loop = false;
        source.time = 0;
        source.Play();
    }
}
