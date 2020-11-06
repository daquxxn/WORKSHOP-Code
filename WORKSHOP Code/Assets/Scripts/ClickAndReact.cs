using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAndReact : MonoBehaviour
{
    [SerializeField] private Slider _moodSlider;
    [SerializeField] private float _tvMoodUp = 0.1f;
    [SerializeField] private float _stereoMoodUp = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))

            #region TV
            {
                if (hit.transform.tag == "TV")
                    _moodSlider.value += _tvMoodUp;
            }
            #endregion

            #region STEREO
            {
                if (hit.transform.tag == "Stereo")
                    _moodSlider.value += _stereoMoodUp;
            }
            #endregion
        }
    }
}
