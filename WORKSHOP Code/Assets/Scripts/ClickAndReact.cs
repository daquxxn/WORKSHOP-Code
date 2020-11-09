using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAndReact : MonoBehaviour
{
    [SerializeField] private Slider _moodSlider;
    [SerializeField] private float _tvMoodUp = 0.1f;
    [SerializeField] private float _stereoMoodUp = 0.1f;

    [SerializeField] private List <CooldownMoodTasks> _cdMoodTasks = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _cdMoodTasks.Count; i++)
        {
            if (Input.GetMouseButtonDown(0) && _cdMoodTasks[i].CurCooldown >= 100)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))

                #region TV
                {
                    if (hit.transform.tag == "TV" && i == 0)
                    {
                        _moodSlider.value += _tvMoodUp;
                        _cdMoodTasks[i].CurCooldown = 0;
                    }
                #endregion

                #region STEREO

                    if (hit.transform.tag == "Stereo" && i == 1)
                    {
                        _moodSlider.value += _stereoMoodUp;
                        _cdMoodTasks[i].CurCooldown = 0;
                    }
                }
                #endregion
            }
        }
    }
}
