using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LuteController : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("Guitar Minigame");
    }
}
