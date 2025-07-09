using UnityEngine;

public class Palanca : InteractuableObject , Iinteractuable
{
    public bool isEnabled = false;
    private bool yaActivada = false;

    public override void OnSelect()
    {
        if (!yaActivada)
        {
            yaActivada = true;
            isEnabled = true;

            if (GameManagernivel1.Instance != null)
            {
                GameManagernivel1.Instance.UpdatePalancas(this);
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

    public void ResetearPalanca()
    {
        isEnabled = false;
        yaActivada = false;
    }
}
