using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointEnEscena : MonoBehaviour
{
    void Start()
    {
        string escenaActual = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("UltimoCheckpoint", escenaActual);

        if (TiempoTotalJuego.instancia != null)
        {
            float tiempoCheckpoint = TiempoTotalJuego.instancia.tiempoJugado;
            PlayerPrefs.SetFloat("TiempoAlCheckpoint", tiempoCheckpoint);
        }

        PlayerPrefs.Save();
        Debug.Log("Checkpoint guardado: " + escenaActual);
    }
}
