using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersController : MonoBehaviour
{
    [SerializeField] private Slider _workSlider = null;
    [SerializeField] private Slider _workSlider2 = null;
    [SerializeField] private Slider _moodSlider = null;

    [SerializeField] private WorkMoodController _workMoodController = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moodSlider.value = _workMoodController.MoodPerc;
        _workSlider.value = _workMoodController.WorkPerc;
        _workSlider2.value = _workMoodController.WorkPerc;
    }
}
