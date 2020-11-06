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
    [SerializeField] private float _cooldownTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DecreaseCooldown", 0f, 1f);
       
    }

    private void DecreaseCooldown()
    {
        _curCooldown += _cooldownTime;
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
        if (_curCooldown == 100)
        {
            _filled.SetActive(true);
        }
    }
}
