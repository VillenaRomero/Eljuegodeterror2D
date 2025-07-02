using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiodeescena : MonoBehaviour
{
    public void Cambiarescenio(string nombreescena)
    {
        SceneManager.LoadScene(nombreescena);
    }
}
