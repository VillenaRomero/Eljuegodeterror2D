using UnityEngine;
using UnityEngine.SceneManagement;

public class ReintentarCheckpoint : MonoBehaviour
{
    public void Reintentar()
    {
        string escena = PlayerPrefs.GetString("UltimoCheckpoint", "game1");

        if (TiempoTotalJuego.instancia != null)
        {
            float tiempoAnterior = PlayerPrefs.GetFloat("TiempoAlCheckpoint", 0f);
            TiempoTotalJuego.instancia.tiempoJugado = tiempoAnterior;
            TiempoTotalJuego.instancia.GuardarTiempo();
        }

        SceneManager.LoadScene(escena);
    }
}
