using UnityEngine;
using UnityEngine.SceneManagement;

public class puertasiguientelevel : InteractuableObject, Iinteractuable
{
    public int NextLevel;

    public override void OnSelect()
    {
        SceneManager.LoadScene(NextLevel);

    }
}
