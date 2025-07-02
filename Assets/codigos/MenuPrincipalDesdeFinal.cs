using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalDesdeFinal : MonoBehaviour
{
    public void IrAlMenu()
    {
        float tiempoFinal = TiempoTotalJuego.instancia != null ? TiempoTotalJuego.instancia.tiempoJugado : 9999f;

        GuardarNuevoRecord(tiempoFinal);

        if (TiempoTotalJuego.instancia != null)
        {
            TiempoTotalJuego.instancia.ReiniciarTiempo();
        }

        PlayerPrefs.DeleteKey("UltimoCheckpoint");

        SceneManager.LoadScene("Mainmenu");
    }

    void GuardarNuevoRecord(float nuevoTiempo)
    {
        float[] tiempos = new float[5];

        for (int i = 0; i < 5; i++)
        {
            tiempos[i] = PlayerPrefs.GetFloat("TiempoRanking" + i, 9999f);
        }

        for (int i = 0; i < 5; i++)
        {
            if (nuevoTiempo < tiempos[i])
            {
                for (int j = 4; j > i; j--)
                {
                    tiempos[j] = tiempos[j - 1];
                }
                tiempos[i] = nuevoTiempo;
                break;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat("TiempoRanking" + i, tiempos[i]);
        }

        PlayerPrefs.Save();
    }
}
