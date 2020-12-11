using System.Collections;
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
    [SerializeField]  private float _clampCoffee = 0.741267f;
    [SerializeField]  private float _clampPhone = 0.741267f;


    [SerializeField] private ClickAndReact _clickAndReactScript = null;

    [SerializeField] private float _cameraThresholdDistance = 0.1f;
    

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
            transform.position = Vector3.Lerp(transform.position, _computerMarker.position, Time.deltaTime);

            if (Vector3.Distance(transform.position, _computerMarker.position) <= _cameraThresholdDistance && !_clickAndReactScript.ComputerScreen.activeSelf)
            //&& s'il n'est pas déjà affiché
            {
                _popItComputer = true;
            }
        }

        if (_clickAndReactScript.PhoneGameOn == true)
        {
            transform.position = Vector3.Lerp(transform.position, _phoneMarker.position, Time.deltaTime);
            if (transform.rotation.y < _clampPhone / 1000)
            {
                transform.Rotate(-Vector3.down, 25f * Time.deltaTime, Space.World);
            }

            if (Vector3.Distance(transform.position, _phoneMarker.position) <= _cameraThresholdDistance && !_clickAndReactScript.IntroDialogue[_clickAndReactScript.IndexSet].activeSelf)
                //&& s'il n'est pas déjà affiché
            {
                _popIt = true;
            }
            

        }

        if (_clickAndReactScript.CoffeeGameOn == true)
        {
            transform.position = Vector3.Lerp(transform.position, _coffeeMarker.position, Time.deltaTime);
            if (transform.rotation.y > _clampCoffee/1000)
            {
                transform.Rotate(Vector3.down, 25f * Time.deltaTime, Space.World);
                _podMoves = true;
            }
        }

        if(_clickAndReactScript.CoffeeGameOn == false && _clickAndReactScript.PhoneGameOn == false && _clickAndReactScript.ComputerOn == false)
        {
            if (transform.rotation.y < 0)
            {
                transform.Rotate(-Vector3.down, 60f * Time.deltaTime, Space.World);
            }

            if (transform.rotation.y > 0)
            {
                transform.Rotate(Vector3.down, 60f * Time.deltaTime, Space.World);
            }
            transform.position = Vector3.Lerp(transform.position, _cameraBase.position, Time.deltaTime);
            _popIt = false;
        }
    }

    
}
 