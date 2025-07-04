using UnityEngine;

public class Palanca : InteractuableOvbject , Iinteractualbe
{
    private GameManagernivel1 gm;
    public bool isEnabled = false;
    private bool yaActivada = false;

    private void Start()
    {
        gm = FindFirstObjectByType<GameManagernivel1>();
    }

    public override void OnSelect()
    {
        if (!yaActivada)
        {
            yaActivada = true;
            isEnabled = true;

            if (gm != null)
            {
                gm.UpdatePalancas(this);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!yaActivada && collision.CompareTag("Player") && gameObject.activeSelf)
        {
            OnSelect();
        }
    }
}
