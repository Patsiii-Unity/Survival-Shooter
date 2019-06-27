using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{ 
    //Variablendefinition
    public Animator cameraAni;

    //Camera shake methods
    public void GunShake1()
    {
        cameraAni.SetTrigger("GunShake1");
    }

    public void ShotGunShake1()
    {
        cameraAni.SetTrigger("ShotGunShake1");
    }
    
    public void AcornShake()
    {
        cameraAni.SetTrigger("AcornShake");
    }

    public void EnemyShake()
    {
        cameraAni.SetTrigger("EnemyShake");
    }
}
