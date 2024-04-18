using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextControl : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }
}
