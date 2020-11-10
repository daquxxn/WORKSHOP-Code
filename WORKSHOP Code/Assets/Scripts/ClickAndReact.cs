using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAndReact : MonoBehaviour
{
    [SerializeField] private Slider _moodSlider;
    [SerializeField] private float _tvMoodUp = 0.1f;
    [SerializeField] private float _stereoMoodUp = 0.1f;

    [SerializeField] private AudioSource _audioSource = null;

    [SerializeField] private List <CooldownMoodTasks> _cdMoodTasks = null;
    [SerializeField] private PhoneGame _phoneGame = null;

    [Header("PhoneGame")]
    [SerializeField] private GameObject _imageBoss = null;
    [SerializeField] private GameObject _imageCharac = null;
    [SerializeField] private GameObject _panelConv = null;
    [SerializeField] private GameObject _questionBoss = null;
    [SerializeField] private GameObject _answerBoss = null;
    [SerializeField] private GameObject _answerBoss2 = null;
    [SerializeField] private GameObject _answerBoss3 = null;
    [SerializeField] private GameObject _answersCharac = null;
    [SerializeField] private GameObject _answerCharac = null;
    [SerializeField] private GameObject _answerCharac2 = null;
    [SerializeField] private GameObject _answerCharac3 = null;
    [SerializeField] private GameObject _nextTextButton = null;
    [SerializeField] private GameObject _nextTextButton2 = null;


    [SerializeField] private GameObject _introDialogue = null;

    [SerializeField] private float _questionsMoodUp = 0.1f;
    [SerializeField] private float _questionsMoodDown= 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
                        _audioSource.Play();
                    }
                }
                #endregion


            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    #region PHONE

                    if (hit.transform.tag == "Phone" && _phoneGame.IsRinging == true)
                    {
                        _phoneGame.IsRinging = false;
                        _introDialogue.SetActive(true);
                    }
                }
            }
            #endregion
        }   
    }
    
    public void UpMoodBar()
    {
        _moodSlider.value += _questionsMoodUp;
        _imageBoss.SetActive(false);
        _questionBoss.SetActive(false);
        _answersCharac.SetActive(false);
        _answerCharac.SetActive(true);
        _imageCharac.SetActive(true);
        _nextTextButton.SetActive(true);
    }

    public void StagMoodBar()
    {
        _imageBoss.SetActive(false);
        _questionBoss.SetActive(false);
        _answersCharac.SetActive(false);
        _answerCharac2.SetActive(true);
        _imageCharac.SetActive(true);
        _nextTextButton.SetActive(true);
    }

    public void DownMoodBar()
    {
        _moodSlider.value -= _questionsMoodDown;
        _imageBoss.SetActive(false);
        _questionBoss.SetActive(false);
        _answersCharac.SetActive(false);
        _answerCharac3.SetActive(true);
        _imageCharac.SetActive(true);
        _nextTextButton.SetActive(true);
    }

    public void NextTextButton()
    {
        if (_answerCharac == isActiveAndEnabled)
        {
            _answerCharac.SetActive(false);
            _answerCharac2.SetActive(false);
            _answerCharac3.SetActive(false);
            _imageCharac.SetActive(false);
            _imageBoss.SetActive(true);
            _answerBoss.SetActive(true);
            _nextTextButton.SetActive(false);
            _nextTextButton2.SetActive(true);
        }

        if (_answerCharac2 == isActiveAndEnabled)
        {
            _answerCharac.SetActive(false);
            _answerCharac2.SetActive(false);
            _answerCharac3.SetActive(false);
            _imageCharac.SetActive(false);
            _imageBoss.SetActive(true);
            _answerBoss2.SetActive(true);
            _answerBoss.SetActive(false);
            _answerBoss3.SetActive(false);
            _nextTextButton.SetActive(false);
            _nextTextButton2.SetActive(true);
        }

        if (_answerCharac3 == isActiveAndEnabled)
        {
            _answerCharac.SetActive(false);
            _answerCharac2.SetActive(false);
            _answerCharac3.SetActive(false);
            _imageCharac.SetActive(false);
            _imageBoss.SetActive(true);
            _answerBoss3.SetActive(true);
            _answerBoss2.SetActive(false);
            _answerBoss.SetActive(false);
            _nextTextButton.SetActive(false);
            _nextTextButton2.SetActive(true);
        }
    }

    public void NextTextButton2()
    {
        _panelConv.SetActive(false);
        _imageBoss.SetActive(false);
        _answerBoss.SetActive(false);
        _nextTextButton2.SetActive(false);
    }
}

