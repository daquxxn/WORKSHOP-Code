using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Transform _computerMarker = null;
    [SerializeField] private Transform _phoneMarker = null;
    [SerializeField] private Transform _coffeeMarker = null;
    [SerializeField] private Transform _cameraBase = null;

    [SerializeField]  private bool _phoneGameOn = false;
    [SerializeField]  private bool _computerOn = false;
    [SerializeField]  private bool _coffeeGameOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_computerOn == true)
        {
            transform.position = Vector3.Lerp(transform.position, _computerMarker.position, Time.deltaTime);
        }

        if (_phoneGameOn == true)
        {
            transform.position = Vector3.Lerp(transform.position, _phoneMarker.position, Time.deltaTime);
        }

        if (_coffeeGameOn == true)
        {
            transform.position = Vector3.Lerp(transform.position, _coffeeMarker.position, Time.deltaTime);
            transform.Rotate(Vector3.down, 20f * Time.deltaTime);
        }

        if(_coffeeGameOn == false && _phoneGameOn == false && _computerOn == false)
        {
            transform.position = Vector3.Lerp(transform.position, _cameraBase.position, Time.deltaTime);
        }
    }
}
