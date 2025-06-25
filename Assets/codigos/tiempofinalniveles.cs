using UnityEngine;
using UnityEngine.UI;

public class tiempofinalniveles : MonoBehaviour
{
    private movedplayer player;
    public Text Uigame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.currentTime = PlayerPrefs.GetInt("CurrentTime",0);
        UiTimeGAME();
    }
    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void levelfinished()
    {
        PlayerPrefs.SetInt("CurrentTime", (int)player.currentTime);
        UiTimeGAME();
    }
    public void UiTimeGAME() {
        Uigame.text = "Time Game : " + player.currentTime;

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
