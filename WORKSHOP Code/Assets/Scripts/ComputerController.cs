using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    [SerializeField] private WorkMoodController _workMoodCont = null;

    [SerializeField] private float _workUp = 0.1f;
    
    
    public void Work()
    {
        _workMoodCont.LinearIncreaseWork(_workUp);
    }

    public void StopWork()
    {
        _workMoodCont.StopLinearIncreaseWork();
    }
}
