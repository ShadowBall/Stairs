using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineTimer : MonoBehaviour
{
    public Image timerBar;
    public float maxTime = 2f;
    public float timeLeft;
    public GameObject timesUpText;
    public GameOverScript Gmos;
    private int linecounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        timesUpText.SetActive(false);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else if(linecounter == 0 & timeLeft <= 0)
        {
            linecounter += 1;
            timesUpText.SetActive(true);
            Gmos.Setup(ScoreScript.scoreValue);
        }
    }
}
