using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ButcherControl : MonoBehaviour
{
    public GameObject instructions;
    private AudioSource[] SoundEffects { set; get; }

    private bool _canChop;
    private bool _done;
    private int _doneTimer;
    private int _chopCounter;
    
    public PostProcessVolume postProcessVolume;
    private ColorGrading _colorGrading;
    private bool _isFlashing = false;
    private const float FlashDuration = 0.5f; // Duration of the flash in seconds
    private Color _originalColor;
    private MasterControl _masterControl;
    

    // Start is called before the first frame update
    private void Start()
    {
        _masterControl = MasterControl.GetMasterControl();
        SoundEffects = gameObject.GetComponents<AudioSource>();
        _chopCounter = 0;
        postProcessVolume.profile.TryGetSettings(out _colorGrading);
        _done = false;
        _doneTimer = 0;
    }

    private void FixedUpdate()
    {
        switch (_done)
        {
            case true when _doneTimer > 70:
                _masterControl.Day++;
                _masterControl.SetSaturation(Mathf.Max(-100f, _masterControl.GetSaturation() - 20f));
                SceneManager.LoadScene("Town");
                break;
            case true:
                _doneTimer++;
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_done)
        {
            instructions.SetActive(false);
            _canChop = true;
            foreach (var soundEffect in SoundEffects)
            {
                if (soundEffect.isPlaying)
                {
                    _canChop = false;
                }
            }

            if (_canChop)
            {
                var rand = Random.Range(1, SoundEffects.Length);
                SoundEffects[rand].Play();
                _chopCounter++;
                StartCoroutine(FlashRed());
                if (_chopCounter > 5) 
                    _done = true;
            }
        }
    }
    
    private IEnumerator FlashRed()
    {
        if (!_isFlashing)
        {
            _isFlashing = true;

            // Store the original lift value
            _originalColor = _colorGrading.lift.value;

            // Set the lift value to a red tint
            var redColor = new Color(1f, 0f, 0f, 0f); // Adjust to the desired red tint
            _colorGrading.lift.value = redColor;

            yield return new WaitForSeconds(FlashDuration);

            // Gradually return to the original color
            var elapsedTime = 0f;
            while (elapsedTime < FlashDuration)
            {
                _colorGrading.lift.value = Color.Lerp(redColor, _originalColor, elapsedTime / FlashDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the lift value is exactly the original color
            _colorGrading.lift.value = _originalColor;

            _isFlashing = false;
        }
    }
}
