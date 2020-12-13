using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private List<RectTransform> _spawnsAsteroids;
    [SerializeField] private Transform[] _asteroidsDifference;

    [SerializeField] private float _timeBetween = 1f;
    [SerializeField] private float _movementSpeed = 1f;

    private float _timeSaved = 0f;


    void Update()
    {

        if (Time.time > _timeSaved + _timeBetween) // Pour que les ennemis ne spawn pas tous d'un coup
        {
            Vector3 randomPos = _spawnsAsteroids[Random.Range(0, _spawnsAsteroids.Capacity)].position;
            Transform _clone = Instantiate(_asteroidsDifference[Random.Range(0, _asteroidsDifference.Length)], randomPos, Quaternion.identity, transform.transform);
            _clone.transform.position = Vector3.forward* Time.deltaTime* _movementSpeed;   //Récupération du Player pour que les ennemis le suivent

            _timeSaved = Time.time;


            Debug.Log(_clone);
        }


    }
}
