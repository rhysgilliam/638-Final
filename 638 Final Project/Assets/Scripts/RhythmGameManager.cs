using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RhythmGameManager : MonoBehaviour
{
    public AudioSource music;

    public bool start;

    public bool done;

    public BeatScroller beatScroller;

    private int _timer;

    private int _grayscaleTimer;

    private MasterControl _master;
    // Start is called before the first frame update
    private void Start()
    {
        _timer = 100;
        _grayscaleTimer = 0;
        _master = MasterControl.GetMasterControl();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!start)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                start = true;
                beatScroller.hasStarted = true;
                
                music.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        switch (start)
        {
            case true when _grayscaleTimer < 50:
                _grayscaleTimer++;
                break;
            case true:
                _grayscaleTimer = 0;
                _master.SetSaturation(_master.GetSaturation() + 1f);
                break;
        }

        if (done)
        {
            _timer--;
            if (_timer < 0)
                SceneManager.LoadScene("Alley 1");
        }
    }
}
