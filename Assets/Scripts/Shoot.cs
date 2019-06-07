using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Variablendefinition
    public GameObject firePoint;
    public GameObject bullet;

    //Spawnt eine Kugel
    public void shoot()
    {
        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    }
}
