using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenuPrincipal : MonoBehaviour
{
    public void IrAlMenu()
    {
        PlayerPrefs.DeleteKey("UltimoCheckpoint");
        PlayerPrefs.DeleteKey("TiempoTotal");

        if (TiempoTotalJuego.instancia != null)
        {
            TiempoTotalJuego.instancia.ReiniciarTiempo();
        }

        PlayerPrefs.Save();
        SceneManager.LoadScene("Mainmenu");
    }
}
