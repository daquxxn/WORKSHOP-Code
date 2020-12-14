using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeGame : MonoBehaviour
{
    [SerializeField] private Transform _farEnd = null;
    private Vector3 _posA;
    private Vector3 _posB;
    [SerializeField] private float _speed = 1f;

    [SerializeField] private Slider _moodSlider;

   
    [SerializeField] private CameraZoom _cameraZoom = null;

    [SerializeField] private float _podDist = 0f;

    [SerializeField] private ClickAndReact _clickAndReactScript = null;

    [SerializeField] private GameObject _perfect = null;
    [SerializeField] private GameObject _lose = null;

    [SerializeField] private Transform _pivotPoint = null;

    [SerializeField] private float _maxWin = 0.055f;

    [SerializeField] private float _coffeeMoodDown = 0.1f;
    [SerializeField] private float _coffeeMoodUp = 0.1f;

    [SerializeField] private GameObject _backButton = null;



    // Start is called before the first frame update
    void Start()
    {
        _posA = transform.position;
        _posB = _farEnd.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cameraZoom.PodMoves == true)
        {
            transform.position = Vector3.Lerp(_posA, _posB, Mathf.PingPong(Time.time / _speed, 1f));
        }

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.tag == "CoffeePod")
                {
                    _cameraZoom.PodMoves = false;
                    float step = _speed * Time.deltaTime;
                    transform.position = transform.position + Vector3.down * _podDist;
                    if(Vector3.Distance(_pivotPoint.position, hit.transform.position) >= _maxWin)
                    {
                        _lose.SetActive(true);
                        _backButton.SetActive(true);
                        _moodSlider.value -= _coffeeMoodDown;
                    }
                    else
                    {
                        _perfect.SetActive(true);
                        _backButton.SetActive(true);
                        _moodSlider.value += _coffeeMoodUp;
                    }
                }
            }
        }
        
    }

    

}
