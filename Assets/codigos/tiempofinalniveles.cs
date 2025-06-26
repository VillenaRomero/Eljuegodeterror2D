using UnityEngine;
using UnityEngine.UI;

public class tiempofinalniveles : MonoBehaviour
{
    private movedplayer player;
    public Text Uigame;

    void Awake()
    {
        if (player == null)
            player = FindObjectOfType<movedplayer>();
    }

    void Start()
    {
        if (player != null)
        {
            // Carga tiempo guardado y continúa sumando desde ahí
            player.currentTime = PlayerPrefs.GetFloat("CurrentTime", 0f);
        }
    }

    void Update()
    {
        UiTimeGAME();  // Mostrar el tiempo real cada frame
    }

    public void levelfinished()
    {
        if (player != null)
        {
            Debug.Log("Tiempo actual antes de guardar: " + player.currentTime); // DEBUG
            float tiempoPrevio = PlayerPrefs.GetFloat("CurrentTime", 0f);
            float tiempoActual = player.currentTime;
            float tiempoTotal = tiempoPrevio + tiempoActual;

            PlayerPrefs.SetFloat("CurrentTime", tiempoTotal);
            PlayerPrefs.Save(); // ⬅ IMPORTANTE
            Debug.Log("Tiempo total guardado en PlayerPrefs: " + tiempoTotal); // DEBUG
        }
        else
        {
            Debug.LogWarning("player es null al intentar guardar tiempo");
        }
    }

    public void UiTimeGAME()
    {
        if (player != null && Uigame != null)
        {
            int segundos = Mathf.FloorToInt(player.currentTime);
            Uigame.text = "Time Game: " + segundos + " segundos";
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
