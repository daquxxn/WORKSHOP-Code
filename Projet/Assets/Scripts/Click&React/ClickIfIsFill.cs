using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickIfIsFill : MonoBehaviour
{
    [SerializeField] private Button _button = null;
    [SerializeField] private Image _image = null;

    // Start is called before the first frame update
    void Start()
    {
        _button.interactable = false ;
    }

    // Update is called once per frame
    void Update()
    {
        if(_image.fillAmount == 1)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
