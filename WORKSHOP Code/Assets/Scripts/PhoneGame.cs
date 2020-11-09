using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneGame : MonoBehaviour
{
    public bool _isRinging = true;

    [SerializeField] private int _rotationSpeed = 10;
    [SerializeField] private int _dir = -1;
    [SerializeField] private float _clampRotation = 0f;

    [SerializeField] private RectTransform _rectTrans = null;

    private AudioSource _audioSource = null;

    private bool _tempRinging = false;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
     if(_isRinging == true)
        {
            if (_tempRinging == false)
            {
                _audioSource.Play();
                _tempRinging = true;
            }
            if (_dir == 1 && _rectTrans.rotation.z >= _clampRotation / 1000)
            {
                _dir = -1;
            }
            else if (_rectTrans.rotation.z <= -_clampRotation / 1000)
            {
                _dir = 1;
            }
            _rectTrans.Rotate(Vector3.forward * (_rotationSpeed * _dir * Time.deltaTime));
            
        }
     else
        {
            _tempRinging = false;
            _audioSource.Stop();
        }
    }
}
