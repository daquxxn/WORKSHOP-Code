using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneGame : MonoBehaviour
{
    [SerializeField] GameObject _phoneSprite = null;
    private bool _isRinging = true;

    [SerializeField] private int _rotationSpeed = 10;
    [SerializeField] private int _dir = -1;
    [SerializeField] private float _clampRotation = 0f;

    private AudioSource _audioSource = null;

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
            if (_dir == 1 && transform.rotation.z >= _clampRotation / 1000)
            {
                _dir = -1;
            }
            else if (transform.rotation.z <= -_clampRotation / 1000)
            {
                _dir = 1;
            }
            transform.Rotate(Vector3.down * (_rotationSpeed * _dir * Time.deltaTime));

            _audioSource.Play();
        }
    }
}
