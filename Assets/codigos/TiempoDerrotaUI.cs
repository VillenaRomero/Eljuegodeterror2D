using UnityEngine;
using UnityEngine.UI;

public class TiempoDerrotaUI : MonoBehaviour
{
    public Text textoTiempo;

    void Start()
    {
        if (TiempoTotalJuego.instancia != null)
        {
            float tiempo = TiempoTotalJuego.instancia.tiempoJugado;
            int segundos = Mathf.FloorToInt(tiempo);
            textoTiempo.text = "Sobreviviste: " + segundos + " segundos";
        }
    }
}
