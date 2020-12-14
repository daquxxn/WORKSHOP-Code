using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkSlider : MonoBehaviour
{
    [SerializeField] private Transform _barParent = null;
    [SerializeField] private Transform _barParentOriginal = null;
    [SerializeField] private Transform _barLocation = null;

    [SerializeField] private Transform _actualTransform = null;

    [SerializeField] private Slider _workSlider = null;
    [SerializeField] private float _workUp = 0.1f;
    [SerializeField] private bool _isWorking = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_isWorking)
        {
            _workSlider.value += _workUp;
        }
    }

    public void IsWorking ()
    {
        transform.SetParent(_barParent);
        transform.position = _barLocation.position;
        _isWorking = true;
    }

    public void IsntWorking ()
    {
        transform.SetParent(_barParentOriginal);
        transform.position = _actualTransform.position;
        _isWorking = false;
    }
    

}
