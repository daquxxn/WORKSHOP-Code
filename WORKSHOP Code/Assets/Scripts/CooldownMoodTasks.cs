using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownMoodTasks : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] GameObject  _filled;
    [SerializeField] private float _maxCooldown = 100f;
    [SerializeField] private float _curCooldown = 0f;
    [SerializeField] private int _cooldownTime = 2;

    public float CurCooldown
    {
        get { return _curCooldown; }
        set { _curCooldown = value;  }
    }
        

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DecreaseCooldown", 0f, 1f);
    }

    private void DecreaseCooldown()
    {
        if (_curCooldown + _cooldownTime >= 100)
        {
            _curCooldown += 100 - _curCooldown;
        }
        else
        {
            _curCooldown += _cooldownTime;
          
        }
        float calcCD = _curCooldown / _maxCooldown;
        SetCooldown(calcCD);

    }

    private void SetCooldown(float theCooldown)
    {
        _bar.fillAmount = theCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (_curCooldown >= 100)
        {
            _filled.SetActive(true);
        }
        else
        {
            _filled.SetActive(false);
        }
    }
}
