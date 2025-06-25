using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightinMainMenu : MonoBehaviour
{
    public Light2D light2D;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f;
    public float offChance = 0.1f;

    private float timer;

    void Start()
    {
        if (light2D == null)
            light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= flickerSpeed)
        {
            if (Random.value < offChance)
            {
                light2D.intensity = 0f;
            }
            else
            {
                light2D.intensity = Random.Range(minIntensity, maxIntensity);
            }

            timer = 0f;
        }
    }
}
