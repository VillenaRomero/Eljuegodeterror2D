using UnityEngine;
using UnityEngine.UI;

public class TemporizadorenUI : MonoBehaviour
{
    public float startTime = 10f;
    private float currentTime;
    public Text uiText;
    void Start()
    {
        currentTime = startTime;
        UpdateTimerUI();
    }
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            if (currentTime < 0)
                currentTime = 0;

            UpdateTimerUI();
        }
    }
    void UpdateTimerUI()
    {
        int seconds = Mathf.CeilToInt(currentTime);
        uiText.text = "Tiempo: " + seconds.ToString();
    }
}
