using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmButtonController : MonoBehaviour
{
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    
    private SpriteRenderer _sr;
    // Start is called before the first frame update
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
            _sr.sprite = pressedImage;
        else if (Input.GetKeyUp(keyToPress))
            _sr.sprite = defaultImage;
    }
}
