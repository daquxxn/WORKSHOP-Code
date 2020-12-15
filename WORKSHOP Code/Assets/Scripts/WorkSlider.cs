using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkSlider : MonoBehaviour
{
    
    [SerializeField] private float _workUp = 0.1f;
    [SerializeField] private bool _isWorking = false;

    [SerializeField] private WorkMoodController _workMoodCont = null;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_isWorking)
        {
            _workMoodCont.LinearIncreaseWork(_workUp);
        }
        else
        {
            _workMoodCont.StopLinearIncreaseWork();
        }
    }

    public void IsWorking ()
    {
        _isWorking = true;
    }

    public void IsntWorking ()
    {
        _isWorking = false;
    }
    
    

}
