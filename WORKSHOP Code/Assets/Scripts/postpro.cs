using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.PostProcessing;

public class postpro : MonoBehaviour
{

    private PostProcessVolume _vol;
    private Vignette _vg;


    [SerializeField] private WorkMoodController _wMController = null;

    [SerializeField] private float _vignIntensity = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _vol = GetComponent<PostProcessVolume>();
        _vol.profile.TryGetSettings(out _vg);
    }

    // Update is called once per frame
    void Update()
    {
        if (_wMController.VigIsChanging == true)
        {
            VignetteChange();
        }
        else
        {
            VignetteChangeBack();
        }
    }

    public void VignetteChange()
    {
        _vg.intensity.value = _vignIntensity;
    }

    public void VignetteChangeBack()
    {
        _vg.intensity.value = 0;
    }
}
