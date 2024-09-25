using UnityEngine;

public class Footstep : MonoBehaviour
{
    AudioSource soundStep;
    // Start is called before the first frame update
    void Start()
    {
        soundStep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public  void PlayerFootStepSound()
    {
        soundStep.Play();
    }

}
