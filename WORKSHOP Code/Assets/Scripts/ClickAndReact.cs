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
    [SerializeField] private List<GameObject> _imageBoss = new List<GameObject>();
    [SerializeField] private List<GameObject> _imageCharac = new List<GameObject>();
    [SerializeField] private GameObject _panelConv = null;
    [SerializeField] private List<GameObject> _questionBoss = new List<GameObject>();
    [SerializeField] private List<GameObject> _answerBoss = new List<GameObject>();
    [SerializeField] private List<GameObject> _answerBoss2 = new List<GameObject>();
    [SerializeField] private List<GameObject> _answerBoss3 = new List<GameObject>();
    [SerializeField] private List<GameObject> _answersCharac = new List<GameObject>();
    [SerializeField] private List<GameObject> _answerCharac = new List<GameObject>();
    [SerializeField] private List<GameObject> _answerCharac2 = new List<GameObject>();
    [SerializeField] private List<GameObject> _answerCharac3 = new List<GameObject>();
    [SerializeField] private List<GameObject> _nextTextButton = new List<GameObject>();
    [SerializeField] private List<GameObject> _nextTextButton2 = new List<GameObject>();

    [SerializeField] private int _indexSet = 0;
    public int IndexSet
    {
        get { return _indexSet; }
        set { _indexSet = value; }
    }
    


    [SerializeField] private List<GameObject> _introDialogue1 = new List<GameObject>();

    public List<GameObject> IntroDialogue
    { get { return _introDialogue1; } }

    [SerializeField] private float _questionsMoodUp = 0.1f;
    [SerializeField] private float _questionsMoodDown= 0.1f;

    [SerializeField] private CameraZoom _cameraZoomScript = null;

    [SerializeField] private GameObject _computerScreen = null;

    [SerializeField] private WorkMoodController _workMoodCont = null;

    private bool _doesntIncrease = false;
    private float _increaseTime = 1f;

    
    [SerializeField] private float _tvAndMusicDuration = 1f;

    public GameObject ComputerScreen
    { get { return _computerScreen; } }

    //[SerializeField] private GameObject _panels = null;

    private bool _phoneGameOn = false;
    private bool _coffeeGameOn = false;
    private bool _computerOn = false;
  //  private bool _coffeeGameOn = false;
   // private bool _computerGameOn = false;

        public bool PhoneGameOn
    { get { return _phoneGameOn; } }

    public bool CoffeeGameOn
    { get { return _coffeeGameOn; }
        set { _coffeeGameOn = value; }
    }

    public bool ComputerOn
    { get { return _computerOn; }
        set { _computerOn = value; }
    }

    [SerializeField] private float interpolationPeriodTV = 0.1f;
    private float _tempTimeStartTV = 0f;

    private Coroutine _currentCoroutine = null;

    [SerializeField] private GameObject _canvasIcone = null;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    IEnumerator StopIncrease()
    {
        yield return new WaitForSeconds(_tvAndMusicDuration);
        _workMoodCont.StopLinearIncreaseMood();
    }
        // Update is called once per frame
        void Update()
    {

        if (_cameraZoomScript.PopIt == true)
        { _introDialogue1[_indexSet].SetActive(true);}

        if (_cameraZoomScript.PopItComputer == true)
        {
            _computerScreen.SetActive(true);
        }

        for (int i = 0; i < _cdMoodTasks.Count; i++)
        {
            if (Input.GetMouseButtonDown(0) && _cdMoodTasks[i].IsFinished)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                    
                {
                    if (hit.transform.tag == "TV" && i == 0)
                    {
                        _workMoodCont.LinearIncreaseMood(_tvMoodUp);
                        if (_currentCoroutine != null)
                        { StopCoroutine(_currentCoroutine); }
                       _currentCoroutine = StartCoroutine(StopIncrease());
                        _cdMoodTasks[i].LaunchCooldown();
                    }
                    
                    
                    if (hit.transform.tag == "Stereo" && i == 1)
                    {
                        _workMoodCont.LinearIncreaseMood(_stereoMoodUp);
                        if (_currentCoroutine != null)
                        { StopCoroutine(_currentCoroutine); }
                        _currentCoroutine=  StartCoroutine(StopIncrease());
                        _cdMoodTasks[i].LaunchCooldown();
                        _audioSource.Play();
                    }

                    if (hit.transform.tag == "Coffee" && i == 2)
                    {
                        _coffeeGameOn = true;
                        _canvasIcone.SetActive(false);
                        //  _panels.SetActive(false);
                    }

                   /* if(hit.transform.tag == "Socials" && i == 3)
                    {
                        Debug.Log("social");
                    }

                    if (hit.transform.tag == "Aste" && i == 4)
                    {
                        Debug.Log("aste");
                    }*/

                }


            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    #region PHONE

                    if (hit.transform.tag == "Phone" && _phoneGame.IsRinging == true )
                    {
                        _phoneGameOn = true;
                        //  _panels.SetActive(false);
                        _phoneGame.IsRinging = false;
                        _canvasIcone.SetActive(false);
                    }


                    if (hit.transform.tag == "Computer")
                    {
                        _computerOn = true;
                        _canvasIcone.SetActive(false);
                    }
                }
            }
            #endregion
        }   
    }

    public void ComputerStop()
    {
        _computerOn = false;
     //   _computerScreen.SetActive(false);
    }

    public void UpMoodBar()
    {
        _workMoodCont.InstantIncreaseMood(_questionsMoodUp);
        _imageBoss[_indexSet].SetActive(false);
        _questionBoss[_indexSet].SetActive(false);
        _answersCharac[_indexSet].SetActive(false);
        _answerCharac[_indexSet].SetActive(true);
        _imageCharac[_indexSet].SetActive(true);
        _nextTextButton[_indexSet].SetActive(true);
    }

    public void StagMoodBar()
    {
        _imageBoss[_indexSet].SetActive(false);
        _questionBoss[_indexSet].SetActive(false);
        _answersCharac[_indexSet].SetActive(false);
        _answerCharac2[_indexSet].SetActive(true);
        _imageCharac[_indexSet].SetActive(true);
        _nextTextButton[_indexSet].SetActive(true);
    }

    public void DownMoodBar()
    {
        _workMoodCont.InstantDecreaseMood(_questionsMoodDown);
        _imageBoss[_indexSet].SetActive(false);
        _questionBoss[_indexSet].SetActive(false);
        _answersCharac[_indexSet].SetActive(false);
        _answerCharac3[_indexSet].SetActive(true);
        _imageCharac[_indexSet].SetActive(true);
        _nextTextButton[_indexSet].SetActive(true);
    }

    public void NextTextButton()
    {
        if (_answerCharac[_indexSet].activeSelf)
        {
            _answerCharac[_indexSet].SetActive(false);
            _answerCharac2[_indexSet].SetActive(false);
            _answerCharac3[_indexSet].SetActive(false);
            _imageCharac[_indexSet].SetActive(false);
            _imageBoss[_indexSet].SetActive(true);
            _answerBoss[_indexSet].SetActive(true);
            _nextTextButton[_indexSet].SetActive(false);
            _nextTextButton2[_indexSet].SetActive(true);
        }

        if (_answerCharac2[_indexSet].activeSelf)
        {
            _answerCharac[_indexSet].SetActive(false);
            _answerCharac2[_indexSet].SetActive(false);
            _answerCharac3[_indexSet].SetActive(false);
            _imageCharac[_indexSet].SetActive(false);
            _imageBoss[_indexSet].SetActive(true);
            _answerBoss2[_indexSet].SetActive(true);
            _answerBoss[_indexSet].SetActive(false);
            _answerBoss3[_indexSet].SetActive(false);
            _nextTextButton[_indexSet].SetActive(false);
            _nextTextButton2[_indexSet].SetActive(true);
        }

        if (_answerCharac3[_indexSet].activeSelf)
        {
            _answerCharac[_indexSet].SetActive(false);
            _answerCharac2[_indexSet].SetActive(false);
            _answerCharac3[_indexSet].SetActive(false);
            _imageCharac[_indexSet].SetActive(false);
            _imageBoss[_indexSet].SetActive(true);
            _answerBoss3[_indexSet].SetActive(true);
            _answerBoss2[_indexSet].SetActive(false);
            _answerBoss[_indexSet].SetActive(false);
            _nextTextButton[_indexSet].SetActive(false);
            _nextTextButton2[_indexSet].SetActive(true);
        }
    }

    public void NextTextButton2()
    {

        _introDialogue1[_indexSet].SetActive(false);
        _answersCharac[_indexSet].SetActive(true);
        _panelConv.SetActive(true);
        _imageBoss[_indexSet].SetActive(true);
        _questionBoss[_indexSet].SetActive(true);
        _answerBoss[_indexSet].SetActive(false);
        _nextTextButton2[_indexSet].SetActive(false);
        _answerBoss3[_indexSet].SetActive(false);
        _answerBoss2[_indexSet].SetActive(false);
        _phoneGameOn = false;

        _indexSet++;

        if(_indexSet == _introDialogue1.Count)
        {
            _indexSet = 0;
        }
    }


    public void CoffeeGameStop()
    {
        _coffeeGameOn = false;
    }
}

