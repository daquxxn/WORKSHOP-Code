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
    [SerializeField]  private float _clamp = 0.741267f;

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
            if (transform.rotation.y < _clamp/1000)
            {
                transform.Rotate(Vector3.down, 35f * Time.deltaTime, Space.World);
            }
        }

        if(_coffeeGameOn == false && _phoneGameOn == false && _computerOn == false)
        {
            if (transform.rotation.y > 0)
            {
                transform.Rotate(-Vector3.down, 60f * Time.deltaTime, Space.World);
            }
            transform.position = Vector3.Lerp(transform.position, _cameraBase.position, Time.deltaTime);
        }
    }
}
