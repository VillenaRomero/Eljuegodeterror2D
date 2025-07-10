using UnityEngine;
using UnityEngine.SceneManagement;

public class temporizadorDeath : MonoBehaviour
{
    public string nivel2;
    public float timeTiCreate;
    private float currentTimetuCreate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimetuCreate += Time.deltaTime;

        if (currentTimetuCreate >= timeTiCreate)
        {
            SceneManager.LoadScene(nivel2);
        }
    }
}
