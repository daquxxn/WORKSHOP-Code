using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownMoodTasks : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] GameObject  _filled;
    [SerializeField] private int _cooldownTime = 2;


    public bool IsFinished => _timeStamp >= _cooldownTime;

    private bool _isActive = false;

    private float _timeStamp = 0f;

    public float CurCooldown
    {
        get { return _timeStamp; }
        set { _timeStamp = value;  }
    }

    private void Start()
    {
        LaunchCooldown();
    }

    private void SetCooldown(float theCooldown)
    {
        _bar.fillAmount = theCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            _timeStamp += Time.deltaTime;
            float perc = _timeStamp / _cooldownTime;
            
        SetCooldown(perc);
        }

        if (IsFinished == true)
        {
            _filled.SetActive(true);
            _bar.gameObject.SetActive(false);
            _isActive = false;

        }

    }

    public void LaunchCooldown()
    {
        _timeStamp = 0;
        _isActive = true;
        _filled.SetActive(false);
        _bar.gameObject.SetActive(true);
    }

    public void ResetCooldown()
    {

    }
}
