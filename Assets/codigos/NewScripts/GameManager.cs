using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<NewLever> levers;

    public GameObject FinalDoor;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        FinalDoor.SetActive(false);
        InitializeLevers();
        ActiveLeverByIndex(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCompleteLevel()
    {
        FinalDoor.SetActive(true);
    }

    #region LEVER MECHANISM
    public void ActiveLever(NewLever lever)
    {
        //bool test = levers.Find(x => x.Equals(lever));

        int leverPos = levers.IndexOf(lever);
        print( lever.name + " has been active in the position OF " + leverPos);
        if(leverPos +1 < levers.Count)
        {
            ActiveLeverByIndex(leverPos + 1);
        }
        else
        {
            OnCompleteLevel();
        }
        DesactiveLeverByIndex(leverPos);

    }
    public void ActiveLeverByIndex(int value)
    {
        levers[value].gameObject.SetActive(true);
    }
    public void DesactiveLeverByIndex(int value)
    {
        levers[value].gameObject.SetActive(false);
        levers[value].ResetLever();
    }
    public void InitializeLevers()
    {
        foreach (var lever in levers)
        {
            lever.ResetLever();
            lever.gameObject.SetActive(false);
        }
    }
    #endregion
}
