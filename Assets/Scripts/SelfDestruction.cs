using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{

    //Variablendefinition
    public float timer = 0;     //Zählt der Timer bis 0 wird das Objekt zerstört

    void Update()
    {
        timer -= Time.deltaTime;

        //Bei timer = 0 wird das Objekt zerstört
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
