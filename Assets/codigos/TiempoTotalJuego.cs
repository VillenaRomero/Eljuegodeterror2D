using UnityEngine;

public class TiempoTotalJuego : MonoBehaviour
{
    public static TiempoTotalJuego instancia;

    public float tiempoJugado = 0f;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            tiempoJugado = PlayerPrefs.GetFloat("TiempoTotal", 0f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        tiempoJugado += Time.deltaTime;
    }

    public void GuardarTiempo()
    {
        PlayerPrefs.SetFloat("TiempoTotal", tiempoJugado);
        PlayerPrefs.Save();
    }

    public void ReiniciarTiempo()
    {
        tiempoJugado = 0f;
        PlayerPrefs.DeleteKey("TiempoTotal");
    }
}
