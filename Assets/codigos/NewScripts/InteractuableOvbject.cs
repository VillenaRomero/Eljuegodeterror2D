using UnityEngine;

public class InteractuableOvbject : BaseObject ,Iinteractualbe
{
    Rigidbody rb;
    Collider2D col;

    public virtual void OnSelect()
    {
        // Esto se sobrescribe en Palanca
    }


}
