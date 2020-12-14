using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _timeDestroy = 5f;

    [SerializeField] private ScoreAsteroid _scoreAsteScript = null;

    public ScoreAsteroid ScoreAste
    {
        get { return _scoreAsteScript; }
        set { _scoreAsteScript = value; }
    }

    public float TimeDestroy
    {
        get { return _timeDestroy; }
        set { _timeDestroy = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _movementSpeed);
        
    }

    public void OnClick()
    {
        _scoreAsteScript.Score();
    }
}
