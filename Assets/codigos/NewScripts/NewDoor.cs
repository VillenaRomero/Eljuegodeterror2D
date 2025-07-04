using UnityEngine;
using UnityEngine.SceneManagement;

public class NewDoor : InteractuableObject, Iinteractuable
{
    public int NextLevel;
    void Start()
    {
        
    }
    public override void OnSelect()
    {
        SceneManager.LoadScene(NextLevel);

    }
}
