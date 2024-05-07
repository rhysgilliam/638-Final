using UnityEngine;

public class MasterControl
{
    private static MasterControl master;

    private float _saturation;

    public int Day { get; set; }

    private MasterControl()
    {
        _saturation = -85f;
        Day = 0;
    }

    public static MasterControl GetMasterControl()
    {
        return master ??= new MasterControl();
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
