using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Variablendefinition
    public GameObject firePoint;
    public GameObject firePointTwo;
    public GameObject bullet;
    public GameObject bulletTwo;

    //Spawnt eine Kugel
    public void shoot()
    {
        //Es wird überprüft ob mehrere Spawnpunkte existieren, ist der Fall wird bei beiden eine Kugel gespawnt
        if (firePoint != null && firePointTwo == null)
        {

            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
        else if (firePoint != null && firePointTwo != null)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            Instantiate(bulletTwo, firePointTwo.transform.position, firePointTwo.transform.rotation);
        }
    }
}
