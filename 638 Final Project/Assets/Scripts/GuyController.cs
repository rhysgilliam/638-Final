using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuyController : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("TTT");
    }
}
