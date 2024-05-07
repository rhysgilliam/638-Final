using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlleywayEntrance : MonoBehaviour, IInteractable
{
    private MasterControl _masterControl;

    private void Start()
    {
        _masterControl = MasterControl.GetMasterControl();
    }
    public void Interact()
    {
        SceneManager.LoadScene(_masterControl.Day == 1 ? "Alley 1" : "Alley 2");
    }
}
