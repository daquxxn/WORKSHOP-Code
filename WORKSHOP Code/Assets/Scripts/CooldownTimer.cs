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

    [SerializeField] private int _timeMultiplicator = 50;

    void Start()
    {
        StartCoroutine (Timer());
    }

    #region Timer

    private IEnumerator Timer()
    {
        _timer = _startTime;

        do
        {
            _timer -= Time.deltaTime* _timeMultiplicator;

            FormatText();

            yield return null;
        }
        while(_timer > 0);
    }

    private void FormatText()
    {
        int hours = (int)(_timer / 3600) % 24;
        int minutes = (int)(_timer / 60) % 60;
        //int seconds = (int)(_timer % 60);

        timerText1.text = "";
        if(hours >0) { timerText1.text += hours + "h "; }
        if (minutes >0) { timerText1.text += minutes + "m "; }
       // if (seconds >0) { timerText1.text += seconds + "s "; }
    }
    #endregion
}
