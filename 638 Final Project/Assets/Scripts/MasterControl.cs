using UnityEngine;

public class MasterControl
{
    private static MasterControl _master;

    private float _saturation;

    private MasterControl()
    {
        _saturation = -85f;
    }

    public static MasterControl GetMasterControl()
    {
        return _master ??= new MasterControl();
    }

    public float GetSaturation()
    {
        return _saturation;
    }

    public void SetSaturation(float sat)
    {
        _saturation = sat;
    }
}
