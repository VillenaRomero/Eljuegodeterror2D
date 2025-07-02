using UnityEngine;
using UnityEngine.UI;

public class RecordDeTiempos : MonoBehaviour
{
    public Text[] textosRanking;

    void Start()
    {
        float tiempoActual = TiempoTotalJuego.instancia != null ? TiempoTotalJuego.instancia.tiempoJugado : 9999f;

        GuardarNuevoTiempo(tiempoActual);
        MostrarRanking();
    }

    void GuardarNuevoTiempo(float nuevoTiempo)
    {
        float[] tiempos = new float[5];

        for (int i = 0; i < 5; i++)
        {
            tiempos[i] = PlayerPrefs.GetFloat("TiempoRanking" + i, 9999f); // valor alto por defecto
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

    void MostrarRanking()
    {
        for (int i = 0; i < 5; i++)
        {
            float tiempo = PlayerPrefs.GetFloat("TiempoRanking" + i, 9999f);
            if (tiempo < 9999f)
            {
                int segundos = Mathf.FloorToInt(tiempo);
                textosRanking[i].text = (i + 1) + "° - " + segundos + " segundos";
            }
            else
            {
                textosRanking[i].text = (i + 1) + "° - ---";
            }
        }
    }
}
