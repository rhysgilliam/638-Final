using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private bool CanBePressed { get; set; }

    public KeyCode keyToPress;
    // Start is called before the first frame update
    private void Start()
    {
        // Debug.Log("Rotation is: " + gameObject.GetComponent<Transform>().rotation.eulerAngles.z);
        keyToPress = gameObject.GetComponent<Transform>().rotation.eulerAngles.z switch
        {
            0 => KeyCode.RightArrow,
            90 => KeyCode.UpArrow,
            180 => KeyCode.LeftArrow,
            270 => KeyCode.DownArrow,
            _ => KeyCode.RightArrow
        };
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(keyToPress) && CanBePressed)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
            CanBePressed = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
            CanBePressed = false;
    }
}
