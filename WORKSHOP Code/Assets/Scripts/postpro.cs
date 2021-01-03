using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.PostProcessing;

public class postpro : MonoBehaviour
{

    private PostProcessVolume v;
    private Vignette vg;

    // Start is called before the first frame update
    void Start()
    {
        v = GetComponent<PostProcessVolume>();
        v.profile.TryGetSettings(out vg);
    }

    // Update is called once per frame
    void Update()
    {

        vg.intensity.value = 0.5f;
    }
}
