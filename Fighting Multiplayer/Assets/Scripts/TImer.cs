using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TImer : MonoBehaviour
{
    public float timer;
    Text TextTimer;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        TextTimer = GameObject.Find("timerText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TextTimer.text = "" + timer.ToString("0");
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 120;
        }
    }
}
