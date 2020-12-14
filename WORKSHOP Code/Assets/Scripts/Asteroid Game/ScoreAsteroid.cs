﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAsteroid : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI _printScore = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _printScore.text = _score.ToString();
    }

    public void Score()
    {
        _score += 1;
    }
}
