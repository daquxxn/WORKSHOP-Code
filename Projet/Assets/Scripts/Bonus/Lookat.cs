using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{

    [SerializeField] private Transform _target = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target);
    }
}
