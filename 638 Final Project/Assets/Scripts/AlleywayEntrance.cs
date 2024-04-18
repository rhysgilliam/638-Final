using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlleywayEntrance : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("Alley 1");
    }
}
