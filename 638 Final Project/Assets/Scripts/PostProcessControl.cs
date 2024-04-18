using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessControl : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private ColorGrading _colorGrading;
    private MasterControl _master;

    private void Start()
    {
        postProcessVolume = gameObject.GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out _colorGrading);
        _master = MasterControl.GetMasterControl();

    }
    private void Update()
    {
        _colorGrading.saturation.value = _master.GetSaturation();
        // Debug.Log(_master.GetSaturation());
    }
}
