using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{ 
    //Variablendefinition
    public Animator cameraAni;

    //shakes Camera
    public void GunShake1()
    {
        cameraAni.SetTrigger("GunShake1");
    }
    //shakes Camera
    public void ShotGunShake1()
    {
        cameraAni.SetTrigger("ShotGunShake1");
    }
}
