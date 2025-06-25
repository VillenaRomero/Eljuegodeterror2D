using UnityEngine;

public class CrearPuas : MonoBehaviour
{
    public float TimeTiCreatepua = 16;
    public float currentTimetuCreatepua;

    public float TimeTiCreatepua2 = 20;
    public float currentTimetuCreatepua2;

    public float TimeTiCreatepua3 = 24;
    public float currentTimetuCreatepua3;

    public float TimeTiCreatepua4 = 28;
    public float currentTimetuCreatepua4;

    public GameObject prefabsPuas;
    private Transform comTransform;

    public Transform spawnerpuas1;
    public Transform spawnerpuas2;
    public Transform spawnerpuas3;
    public Transform spawnerpuas4;

    private void Update()
    {
        currentTimetuCreatepua = currentTimetuCreatepua + Time.deltaTime;
        if (currentTimetuCreatepua >= TimeTiCreatepua)
        {
            CrearPuas1();
            currentTimetuCreatepua = 0;
        }

        currentTimetuCreatepua2 = currentTimetuCreatepua2 + Time.deltaTime;
        if (currentTimetuCreatepua2 >= TimeTiCreatepua2)
        {
            CrearPuas2();
            currentTimetuCreatepua2 = 0;
        }

        currentTimetuCreatepua3 = currentTimetuCreatepua3 + Time.deltaTime;
        if (currentTimetuCreatepua3 >= TimeTiCreatepua3)
        {
            CrearPuas3();
            currentTimetuCreatepua3 = 0;
        }

        currentTimetuCreatepua4 = currentTimetuCreatepua4 + Time.deltaTime;
        if (currentTimetuCreatepua4 >= TimeTiCreatepua4)
        {
            CrearPuas4();
            currentTimetuCreatepua4 = 0;
        }
    }
    private void CrearPuas1()
    {
        GameObject puas = Instantiate(prefabsPuas);
        puas.transform.position = spawnerpuas1.position;
        puas.transform.rotation = transform.rotation;
    }
    private void CrearPuas2()
    {
        GameObject puas = Instantiate(prefabsPuas);
        puas.transform.position = spawnerpuas2.position;
        puas.transform.rotation = transform.rotation;

    }
    private void CrearPuas3()
    {
        GameObject puas = Instantiate(prefabsPuas);
        puas.transform.position = spawnerpuas3.position;
        puas.transform.rotation = transform.rotation;

    }
    private void CrearPuas4()
    {
        GameObject puas = Instantiate(prefabsPuas);
        puas.transform.position = spawnerpuas4.position;
        puas.transform.rotation = transform.rotation;

    }
}
