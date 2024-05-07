using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour
{
    public GameObject alley;
    private MasterControl _master;
    public GameObject barrel;
    // Start is called before the first frame update
    private void Start()
    {
        _master = MasterControl.GetMasterControl();
        if (_master.Day == 0)
        {
            alley.SetActive(false);
            barrel.SetActive(true);
        }
        else
        {
            alley.SetActive(true);
            barrel.SetActive(false);
        }
            
    }
    
}
