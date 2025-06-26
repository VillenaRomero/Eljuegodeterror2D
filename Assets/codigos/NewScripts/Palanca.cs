using UnityEngine;

public class Palanca : InteractuableOvbject , Iinteractualbe
{
    private GameManagernivel1 gm;
    public bool isEnabled = false;

    private void Start()
    {
        gm = FindObjectOfType<GameManagernivel1>();
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
        // ✅ Solo si es la 4ta palanca y colisiona con el jugador
        if (isEnabled && gm != null && gm.newPalancas.Count > 3 &&
            gm.newPalancas[3] == this && collision.gameObject.CompareTag("player"))
        {
            if (gm.puerta != null)
            {
                gm.puerta.SetActive(true); // ✅ Ahora sí abrimos la puerta
            }

            // Opcional: ocultar palanca 4 tras colisión
            gameObject.SetActive(false);
            isEnabled = false;
        }
    }
}
