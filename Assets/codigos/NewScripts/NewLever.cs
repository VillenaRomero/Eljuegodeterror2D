
using UnityEngine;

public class NewLever : InteractuableObject , Iinteractuable
{
    [SerializeField] private bool isActive = false;

    
    void Start()
    {
        
    }
    public void ResetLever()
    {
        isActive = false;
        GetComponent<SpriteRenderer>().flipX = false;
    }
    public override void OnSelect()
    {
        isActive = !isActive;
        GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX ? false: true ;

        if (isActive == true)
        {
            GameManager.Instance.ActiveLever(this);
        }
    }
}
