using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAndReactButtons : MonoBehaviour
{

    [SerializeField] private List <CooldownMoodTasks> _cdMoodTasks = null;
    

    private bool _startMiniGame = false;

    [SerializeField] private GameObject _menuJeu = null;
    [SerializeField] private GameObject _menuReseau = null;

    private int _indexSet = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if( _cdMoodTasks[_indexSet].IsFinished)
        {
            _startMiniGame = true;
        }
    }

    public void AsteroidGame(int i)
    {
       if (_startMiniGame)
        {
            _indexSet = i;
            _menuJeu.SetActive(true);
            _cdMoodTasks[i].LaunchCooldown();
            _cdMoodTasks[i+2].LaunchCooldown();
        }
    }

    public void SocialNetwork(int i)
    {

        if (_startMiniGame)
        {
            _indexSet = i;
            _menuReseau.SetActive(true);
            _cdMoodTasks[i].LaunchCooldown();
            _cdMoodTasks[i+2].LaunchCooldown();
        }
    }
}
