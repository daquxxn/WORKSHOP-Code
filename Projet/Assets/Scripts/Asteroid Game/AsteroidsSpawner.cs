using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnsAsteroids;
    [SerializeField] private Transform[] _asteroidsDifference;

    [SerializeField] private float _timeBetween = 1f;

    [SerializeField] private Vector2 _timesToDestroy = Vector2.zero;

    [SerializeField] private ScoreAsteroid _scoreAsteroid = null;
    //[SerializeField] private float _movementSpeed = 1f;

    private float _timeSaved = 0f;


    void Update()
    {

        if (Time.time > _timeSaved + _timeBetween) // Pour que les ennemis ne spawn pas tous d'un coup
        {
            int randomIndex = Random.Range(0, _spawnsAsteroids.Capacity);
            Quaternion lookAtCenter = Quaternion.identity;

            Vector3 randomPos = _spawnsAsteroids[randomIndex].position;

            float rightTimeToDestroy = 0f;

            switch (randomIndex)
            {
                case 0:
                    lookAtCenter = Quaternion.AngleAxis(0, Vector3.back);
                    rightTimeToDestroy = _timesToDestroy.x;
                    break;

                case 1:
                    lookAtCenter = Quaternion.AngleAxis(190, Vector3.back);
                    rightTimeToDestroy = _timesToDestroy.x;
                    break;

                case 2:
                    lookAtCenter = Quaternion.AngleAxis(70, Vector3.back);
                    rightTimeToDestroy = _timesToDestroy.y;
                    break;
            }
            Transform _clone = Instantiate(_asteroidsDifference[Random.Range(0, _asteroidsDifference.Length)], randomPos, lookAtCenter, transform.transform);
            _clone.gameObject.GetComponent<Asteroids>().TimeDestroy = rightTimeToDestroy;
            _clone.gameObject.GetComponent<Asteroids>().ScoreAste = _scoreAsteroid;

            _timeSaved = Time.time;
            
        }


    }
}
