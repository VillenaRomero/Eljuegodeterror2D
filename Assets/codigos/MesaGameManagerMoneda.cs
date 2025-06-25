using UnityEngine;
using UnityEngine.UI;
public class MesaGameManagerMoneda : MonoBehaviour
{
    public Text contadorText;
    public GameObject puerta;

    private int mesasCompletadas = 0;

    void Start()
    {
        if (puerta != null)
        {
            puerta.SetActive(false);
        }

        if (contadorText != null)
        {
            contadorText.text = "Mesas completadas: 0";
        }
    }

    public void SumarMesa()
    {
        mesasCompletadas++;

        if (contadorText != null)
            contadorText.text = "Mesas completadas: " + mesasCompletadas;

        if (mesasCompletadas >= 4)
        {
            ActivarPuerta();
        }
    }

    private void ActivarPuerta()
    {
        if (puerta != null)
        {
            puerta.SetActive(true);
        }
    }
}
