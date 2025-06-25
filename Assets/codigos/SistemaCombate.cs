using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SistemaCombate : MonoBehaviour
{
    public GameObject cartaPrefab;
    public Transform zonaJugador, zonaEnemigo;
    public Sprite[] imagenesCartas;
    public Sprite reversoCarta;

    public Text textoEstado;
    public Text textoResultado;
    public Text vidaJugadorText;
    public Text vidaEnemigoText;

    private cartas[] cartasJugador = new cartas[12];
    private cartas[] cartasEnemigo = new cartas[12];
    private GameObject[] cartasObjJugador = new GameObject[12];
    private GameObject[] cartasObjEnemigo = new GameObject[12];

    private int vidaJugador = 5;
    private int vidaEnemigo = 5;
    private int rondasCompletas = 0;
    private bool turnoJugador = true;

    private cartas cartaAtacante;
    private cartas cartaDefensora;

    private int indexAtacante;
    private int indexDefensor;

    void Start()
    {
        IniciarJuego();
    }

    void IniciarJuego()
    {
        cartas[] baraja = CrearBaraja();
        RepartirCartas(baraja);
        MostrarCartasOcultas();
        ActualizarUI();
        textoEstado.text = "Tu turno: Ataca";
    }

    cartas[] CrearBaraja()
    {
        cartas[] baraja = new cartas[52];
        int index = 0;
        for (int palo = 0; palo < 4; palo++)
        {
            for (int valor = 1; valor <= 13; valor++)
            {
                baraja[index] = new cartas((Palo)palo, valor, imagenesCartas[index]);
                index++;
            }
        }

        for (int i = 0; i < 52; i++)
        {
            int r = Random.Range(0, 52);
            cartas temp = baraja[i];
            baraja[i] = baraja[r];
            baraja[r] = temp;
        }

        return baraja;
    }

    void RepartirCartas(cartas[] baraja)
    {
        for (int i = 0; i < 12; i++)
        {
            cartasJugador[i] = baraja[i];
            cartasEnemigo[i] = baraja[i + 12];
        }
    }

    void MostrarCartasOcultas()
    {
        for (int i = 0; i < 12; i++)
        {
            cartasObjJugador[i] = CrearCarta(i, zonaJugador, true);
            cartasObjEnemigo[i] = CrearCarta(i, zonaEnemigo, false);
        }
    }

    GameObject CrearCarta(int index, Transform zona, bool esJugador)
    {
        GameObject carta = Instantiate(cartaPrefab, zona);
        carta.GetComponent<Image>().sprite = reversoCarta;
        Button btn = carta.GetComponent<Button>();
        btn.interactable = esJugador;
        if (esJugador)
        {
            btn.onClick.AddListener(() => AlSeleccionarCarta(index));
        }
        return carta;
    }

    void AlSeleccionarCarta(int index)
    {
        if (turnoJugador)
        {
            cartaAtacante = cartasJugador[index];
            indexAtacante = index;
            cartasObjJugador[index].GetComponent<Image>().sprite = cartaAtacante.imagen;

            indexDefensor = BuscarSiguienteCartaEnemigo();
            if (indexDefensor == -1) return;

            cartaDefensora = cartasEnemigo[indexDefensor];
            cartasObjEnemigo[indexDefensor].GetComponent<Image>().sprite = cartaDefensora.imagen;

            ResolverTurno(index);
        }
        else
        {
            cartaDefensora = cartasJugador[index];
            indexDefensor = index;
            cartasObjJugador[index].GetComponent<Image>().sprite = cartaDefensora.imagen;

            cartasObjEnemigo[indexAtacante].GetComponent<Image>().sprite = cartaAtacante.imagen;

            ResolverTurno(index);
        }

        cartasObjJugador[index].GetComponent<Button>().interactable = false;
    }

    int BuscarSiguienteCartaEnemigo()
    {
        for (int i = 0; i < 12; i++)
        {
            if (cartasObjEnemigo[i].GetComponent<Image>().sprite == reversoCarta)
                return i;
        }
        return -1;
    }

    void ResolverTurno(int indexJugador)
    {
        if (cartaAtacante.valor > cartaDefensora.valor)
        {
            if (turnoJugador)
            {
                vidaEnemigo--;
                textoResultado.text = "¡Ganaste la ronda!";
            }
            else
            {
                vidaJugador--;
                textoResultado.text = "¡El enemigo ganó la ronda!";
            }
        }
        else
        {
            textoResultado.text = "¡Defensa exitosa!";
        }

        turnoJugador = !turnoJugador;
        cartaAtacante = null;
        cartaDefensora = null;
        rondasCompletas++;
        ActualizarUI();
        VerificarFin();

        if (!turnoJugador)
        {
            Invoke("TurnoEnemigo", 2f);
        }
    }

    void TurnoEnemigo()
    {
        indexAtacante = BuscarSiguienteCartaEnemigo();
        if (indexAtacante == -1) return;

        cartaAtacante = cartasEnemigo[indexAtacante];
        textoEstado.text = "Te toca defenderte";
        textoResultado.text = "El enemigo ataca...";
    }

    void ActualizarUI()
    {
        vidaJugadorText.text = "Vida Jugador: " + vidaJugador;
        vidaEnemigoText.text = "Vida Enemigo: " + vidaEnemigo;

        if (vidaJugador > 0 && vidaEnemigo > 0)
        {
            textoEstado.text = turnoJugador ? "Tu turno: Ataca" : "Tu turno: Defiéndete";
        }
    }

    void VerificarFin()
    {
        if (vidaJugador <= 0)
        {
            SceneManager.LoadScene("derrota5");
        }
        else if (vidaEnemigo <= 0)
        {
            SceneManager.LoadScene("Fin");
        }
        else if (rondasCompletas >= 12) // todas las rondas jugadas
        {
            if (vidaJugador > vidaEnemigo)
            {
                SceneManager.LoadScene("Fin");
            }
            else if (vidaJugador < vidaEnemigo)
            {
                SceneManager.LoadScene("derrota5");
            }
            else
            {
                // Opcional: puedes hacer empate
                SceneManager.LoadScene("derrota5"); // o usar: "Empate"
            }
        }
    }
}
