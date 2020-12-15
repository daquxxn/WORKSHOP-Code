using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkMoodController : MonoBehaviour
{
    [SerializeField] private float _maxWork = 100f;
    [SerializeField] private float _maxMood = 100f;

    [SerializeField] private float _decreasingMoodFactor = 1f;
    private float _increasingMoodFactor = 1f;
    private float _increasingWorkFactor = 1f;

     private float _currentWork = 0f;
     private float _currentMood = 100f;

    private bool _isMoodIncreasing = false;

    private bool _isWorking = false;

    public float CurrentWork
    {
        get { return _currentWork; }
    }

    public float CurrentMood
    {
        get { return _currentMood; }
        set
        {
            _currentMood = value;
            _currentMood = Mathf.Clamp(_currentMood, 0, _maxMood);
        }
    }

    public float WorkPerc
    {
        get { return _currentWork / _maxWork; }
    }

    public float MoodPerc
    {
        get { return _currentMood / _maxMood; }
    }

    [SerializeField] private GameObject _losePanel = null;
    [SerializeField] private GameObject _winPanel = null;

    [SerializeField] private CooldownTimer _cooldownTimer = null;

    private bool _isGameFinished = false;

    public bool IsGameFinished
    { get { return _isGameFinished; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(_currentMood <= 0 || _cooldownTimer.TimerCD <= 0)
        {
            _losePanel.SetActive(true);
            _isGameFinished = true;
        }

        if(_currentWork >= 100)
        {
            _winPanel.SetActive(true);
            _isGameFinished = true;
        }

        if(_isMoodIncreasing)
        {
            CurrentMood += _increasingMoodFactor * Time.deltaTime;
        }
        else
        {
            CurrentMood -= _decreasingMoodFactor * Time.deltaTime;
        }

        if(_isWorking)
        {
            _currentWork += _increasingWorkFactor * Time.deltaTime;
        }

       
    }

    public void LinearIncreaseMood(float increaseFactor)
    {
        _isMoodIncreasing = true;
        _increasingMoodFactor = increaseFactor;
    }

    public void LinearIncreaseWork (float increaseFactor)
    {
        _isWorking = true;
        _increasingWorkFactor = increaseFactor;
    }

    public void InstantIncreaseMood(float increaseValue)
    {
        CurrentMood += increaseValue;
    }

    public void InstantDecreaseMood(float increaseValue)
    {
        CurrentMood -= increaseValue;
    }

    public void StopLinearIncreaseMood()
    {
        _isMoodIncreasing = false;
    }

    public void StopLinearIncreaseWork()
    {
        _isWorking = false;
    }
}
