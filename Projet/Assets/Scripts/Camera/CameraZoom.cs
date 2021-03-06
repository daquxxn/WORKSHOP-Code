﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Transform _computerMarker = null;
    [SerializeField] private Transform _phoneMarker = null;
    [SerializeField] private Transform _coffeeMarker = null;
    [SerializeField] private Transform _cameraBase = null;

    //[SerializeField]  private bool _phoneGameOn = false;
    //[SerializeField]  private bool _computerOn = false;
    //[SerializeField]  private bool _coffeeGameOn = false;
    [SerializeField] private float _clampCoffee = 0.741267f;
    [SerializeField] private float _clampPhone = 0.741267f;


    [SerializeField] private ClickAndReact _clickAndReactScript = null;

    [SerializeField] private float _cameraThresholdDistance = 0.1f;
    [SerializeField] private float _cameraThresholdDistanceForIcons = 0.3f;

    [SerializeField] private GameObject _canvasIcone = null;

    [SerializeField] private float _speedCamera = 2f;
    [SerializeField] private float _angleSpeedBack = 60f;
    [SerializeField] private float _angleSpeedCoffee = 25f;
    [SerializeField] private float _angleSpeedPhone = 25f;

    private bool _coffeeGameIsOn = false;

    public bool CoffeeGameIsOn 
        {
        get { return _coffeeGameIsOn; }
        }

    private bool _podMoves = false;

    public bool PodMoves
    {
        get { return _podMoves; }
        set { _podMoves = value; }
    }

    private bool _popIt = false;
    private bool _popItComputer = false;

    public bool PopIt
    {
        get { return _popIt; }
    }

    public bool PopItComputer
    {
        get { return _popItComputer; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_clickAndReactScript.ComputerOn == true)
        {
            transform.position = Vector3.Lerp(transform.position, _computerMarker.position, _speedCamera * Time.deltaTime);

            if (Vector3.Distance(transform.position, _computerMarker.position) <= _cameraThresholdDistance && !_clickAndReactScript.ComputerScreen.activeSelf)
            //&& s'il n'est pas déjà affiché
            {
                _popItComputer = true;
            }
            else
            {

                _popItComputer = false;
            }
        }

        if (_clickAndReactScript.PhoneGameOn == true)
        {
            transform.position = Vector3.Lerp(transform.position, _phoneMarker.position, _speedCamera * Time.deltaTime);
            if (transform.rotation.y < _clampPhone / 1000)
            {
                transform.Rotate(-Vector3.down, _angleSpeedPhone * Time.deltaTime, Space.World);
            }

            if (Vector3.Distance(transform.position, _phoneMarker.position) <= _cameraThresholdDistance && !_clickAndReactScript.IntroDialogue[_clickAndReactScript.IndexSet].activeSelf)
                //&& s'il n'est pas déjà affiché
            {
                _popIt = true;
            }
            

        }

        if (_clickAndReactScript.CoffeeGameOn == true)
        {
            _coffeeGameIsOn = true;
            transform.position = Vector3.Lerp(transform.position, _coffeeMarker.position, _speedCamera * Time.deltaTime);
            if (transform.rotation.y > _clampCoffee/1000)
            {
                transform.Rotate(Vector3.down, _angleSpeedCoffee * Time.deltaTime, Space.World);
                _podMoves = true;
            }
        }

        if(_clickAndReactScript.CoffeeGameOn == false && _clickAndReactScript.PhoneGameOn == false && _clickAndReactScript.ComputerOn == false)
        {
            if (transform.rotation.y < 0)
            {
                transform.Rotate(-Vector3.down, _angleSpeedBack * Time.deltaTime, Space.World);
            }

            if (transform.rotation.y > 0)
            {
                transform.Rotate(Vector3.down, _angleSpeedBack * Time.deltaTime, Space.World);
            }
            transform.position = Vector3.Lerp(transform.position, _cameraBase.position, _speedCamera * Time.deltaTime);
            _popIt = false;

            if (Vector3.Distance(transform.position, _cameraBase.position) <= _cameraThresholdDistanceForIcons)
            //&& s'il n'est pas déjà affiché
            {
                _canvasIcone.SetActive(true);
            }
           
        }
    }

    
}
 