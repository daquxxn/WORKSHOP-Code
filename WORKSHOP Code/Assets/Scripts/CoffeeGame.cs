using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeGame : MonoBehaviour
{
    [SerializeField] private Transform _farEnd = null;
    private Vector3 _posA;
    private Vector3 _posB;
    [SerializeField] private float _speed = 1f;
    private bool _podMoves = true;

    [SerializeField] private float _podDist = 0f;

    [SerializeField] private ClickAndReact _clickAndReactScript = null;
    

    // Start is called before the first frame update
    void Start()
    {
        _posA = transform.position;
        _posB = _farEnd.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_podMoves == true)
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
                    _podMoves = false;
                    float step = _speed * Time.deltaTime;
                    transform.position = transform.position + Vector3.down * _podDist;
                    _clickAndReactScript.CoffeeGameOn = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("jenaimar");
    }

}
