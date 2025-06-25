using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering.LookDev;

public class Nivelesdeboton : MonoBehaviour
{
    public GameObject[] botones;         // Los 4 botones
    public GameObject puerta;            // La puerta a activar
    public float tiempoPorBoton = 10f;
    public float timeTiCreate = 100f;
    public float currentTimetuCreate;

    public string nivel;     // Nivel de derrota
    public string nivel2;    // Nivel de victoria

    public Text textoVida;           // Texto UI para mostrar la vida
    public Text textoTemporizador;   // Texto UI para mostrar el tiempo restante

    private movedplayer jugador;     // Referencia al jugador

    private float cronometro = 0f;
    private int botonActual = 0;
    private bool esperandoPresionar = false;
    private bool Siguientenivelperder = false;
    private bool Siguientenivelganar = false;

    void Start()
    {
        jugador = FindObjectOfType<movedplayer>();

        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].SetActive(false);
        }

        if (puerta != null)
            puerta.SetActive(false);

        ActivarSiguienteBoton();
    }

    void Update()
    {
        // Temporizador para siguiente botón
        if (!esperandoPresionar && botonActual < botones.Length)
        {
            cronometro += Time.deltaTime;

            if (textoTemporizador != null)
            {
                float tiempoRestante = tiempoPorBoton - cronometro;
                if (tiempoRestante < 0) tiempoRestante = 0;
                textoTemporizador.text = "Siguiente botón en: " + Mathf.Ceil(tiempoRestante) + "s";
            }

            if (cronometro >= tiempoPorBoton)
            {
                ActivarSiguienteBoton();
                cronometro = 0f;
            }
        }

        // Actualizar vida en pantalla
        if (jugador != null && textoVida != null)
        {
            textoVida.text = "Vida: " + jugador.life;
        }

        // Temporizador general para cambiar de nivel
        currentTimetuCreate += Time.deltaTime;
        if (currentTimetuCreate >= timeTiCreate)
        {
            SceneManager.LoadScene(nivel); // Nivel derrota por tiempo
        }

        if (Siguientenivelperder)
        {
            SceneManager.LoadScene(nivel);
        }

        if (Siguientenivelganar)
        {
            SceneManager.LoadScene(nivel2);
        }
    }

    public void Niveldederrota()
    {
        Siguientenivelperder = true;
    }

    public void NiveldeGanar()
    {
        Siguientenivelganar = true;
    }

    void ActivarSiguienteBoton()
    {
        if (botonActual < botones.Length)
        {
            botones[botonActual].SetActive(true);
            esperandoPresionar = true;
        }
    }

    public void BotonPresionado()
    {
        botonActual++;
        esperandoPresionar = false;

        if (botonActual >= botones.Length && puerta != null)
        {
            puerta.SetActive(true);
        }
    }
}
