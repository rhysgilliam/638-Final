using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.SpriteAssetUtilities;
using UnityEngine;

public class FinalNote : MonoBehaviour
{
    public GameObject text;
    public RhythmGameManager manager;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
            text.gameObject.SetActive(true);
        
        manager.done = true;
    }
}
