using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialNetwork : MonoBehaviour
{
    [SerializeField] private WorkMoodController _workMoodCont = null;

    [SerializeField] private float _socialNetwUp = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        _workMoodCont.LinearIncreaseMood(_socialNetwUp);
    }

    private void OnDisable()
    {
        _workMoodCont.StopLinearIncreaseMood(_socialNetwUp);
    }
}
