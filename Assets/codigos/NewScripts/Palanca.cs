using UnityEngine;

public class Palanca : InteractuableOvbject , Iinteractualbe
{
    private GameManagernivel1 gm;
    public bool isEnabled = false;

    private void Start()
    {
        gm = FindFirstObjectByType<GameManagernivel1>();
    }

    public override void OnSelect()
    {
        isEnabled = true;
        if (gm != null)
        {
            gm.UpdatePalancas(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isEnabled && gm != null && gm.newPalancas.Count > 3 && gm.newPalancas[3] == this && collision.gameObject.tag == "player" )
        {
            if (gm.puerta != null)
            {
                gm.puerta.SetActive(true);
            }

            gameObject.SetActive(false);
            isEnabled = false;
        }
    }
}
