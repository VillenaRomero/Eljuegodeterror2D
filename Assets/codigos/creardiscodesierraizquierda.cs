using UnityEngine;

public class creardiscodesierraizquierda : MonoBehaviour
{
    public GameObject prefabEnemy;
    private Transform comTransform;

    public float timeTiCreate = 5;
    public float currentTimetuCreate;

    public float timeTiCreate1 = 5;
    public float currentTimetuCreate1;

    public float timeTiCreate2 = 5;
    public float currentTimetuCreate2;

    public float timeTiCreate3 = 5;
    public float currentTimetuCreate3;

    public float timeTiCreate4 = 5;
    public float currentTimetuCreate4;

    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Transform spawner4;
    public Transform spawner5;

    private void Update()
    {
        currentTimetuCreate = currentTimetuCreate + Time.deltaTime;
        if (currentTimetuCreate >= timeTiCreate)
        {
            ShootBullet1();

            currentTimetuCreate = 0;
        }
        currentTimetuCreate1 = currentTimetuCreate1 + Time.deltaTime;
        if (currentTimetuCreate1 >= timeTiCreate1)
        {
            ShootBullet2();

            currentTimetuCreate1 = 0;
        }
        currentTimetuCreate2 = currentTimetuCreate2 + Time.deltaTime;
        if (currentTimetuCreate2 >= timeTiCreate2)
        {
            ShootBullet3();

            currentTimetuCreate2 = 0;
        }
        currentTimetuCreate3 = currentTimetuCreate3 + Time.deltaTime;
        if (currentTimetuCreate3 >= timeTiCreate3)
        {
            ShootBullet4();

            currentTimetuCreate3 = 0;
        }
        currentTimetuCreate4 = currentTimetuCreate4 + Time.deltaTime;
        if (currentTimetuCreate4 >= timeTiCreate4)
        {
            ShootBullet5();

            currentTimetuCreate4 = 0;
        }
    }
    private void ShootBullet1()
    {
        GameObject bullet = Instantiate(prefabEnemy);
        bullet.transform.position = spawner1.position;
        bullet.transform.rotation = transform.rotation;
    }
    private void ShootBullet2()
    {
        GameObject bullet = Instantiate(prefabEnemy);
        bullet.transform.position = spawner2.position;
        bullet.transform.rotation = transform.rotation;
    }
    private void ShootBullet3()
    {
        GameObject bullet = Instantiate(prefabEnemy);
        bullet.transform.position = spawner3.position;
        bullet.transform.rotation = transform.rotation;
    }
    private void ShootBullet4()
    {
        GameObject bullet = Instantiate(prefabEnemy);
        bullet.transform.position = spawner4.position;
        bullet.transform.rotation = transform.rotation;
    }
    private void ShootBullet5()
    {
        GameObject bullet = Instantiate(prefabEnemy);
        bullet.transform.position = spawner5.position;
        bullet.transform.rotation = transform.rotation;
    }
}
