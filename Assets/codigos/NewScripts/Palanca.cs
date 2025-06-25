using UnityEngine;

public class Palanca : InteractuableOvbject , Iinteractualbe
{
    public GameManagernivel1 gm;
    public bool isEnabled = false;

    public override void OnSelect()
    {
        isEnabled = true? false: true;
        gm.UpdatePalancas();
    }
}
