using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlleyExitController : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("Town");
    }
}
