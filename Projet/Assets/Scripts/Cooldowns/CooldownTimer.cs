using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownTimer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float _startTime = 0f;
    [SerializeField] private TextMeshProUGUI timerText1;
    private float _timer = 0f;

    [SerializeField] private int _workTimeMultiplicator = 50;

    /*public float TimerCD
    {
        get { return _timer; }
    }*/

    public float TimerCD => _timer;

    [SerializeField] private WorkMoodController _workMoodCont = null;

    void Start()
    {
        _timer = _startTime;
    }

    #region Timer
    
    private void Update()
    {
        if (_workMoodCont.IsGameFinished == false)
        {
            _timer -= Time.deltaTime * _workTimeMultiplicator;
        }

        FormatText();
    }

    private void FormatText()
    {
        int hours = (int)(_timer / 3600) % 24;
        int minutes = (int)(_timer / 60) % 60;
        //int seconds = (int)(_timer % 60);

        timerText1.text = "";
        if(hours >0)
        {
            timerText1.text += hours + "h ";
        }
        if (minutes >0)
        {
            timerText1.text += minutes + "m ";
        }
       // if (seconds >0) { timerText1.text += seconds + "s "; }
    }
    #endregion
}
