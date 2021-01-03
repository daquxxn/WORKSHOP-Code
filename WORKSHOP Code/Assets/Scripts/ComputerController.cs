using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    [SerializeField] private WorkMoodController _workMoodCont = null;

    [SerializeField] private float _workUp = 0.1f;
    
    private AudioSource _audioSource = null;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Work()
    {
        _workMoodCont.LinearIncreaseWork(_workUp);
        _audioSource.Play();
    }

    public void StopWork()
    {
        _workMoodCont.StopLinearIncreaseWork();
        _audioSource.Stop();
    }
}
