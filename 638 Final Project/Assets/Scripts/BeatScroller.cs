using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;
    // Start is called before the first frame update
    private void Start()
    {
        hasStarted = false;
        beatTempo /= 60f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (hasStarted)
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
