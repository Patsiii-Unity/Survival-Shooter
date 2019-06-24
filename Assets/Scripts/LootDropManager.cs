using System;
using UnityEngine;

public class LootDropManager : MonoBehaviour
{
    //Variablendefinition
    public GameObject[] lootItems;

    Vector3 position;

    public float y = -0.82f;
    public float z = -1f;

    public void Spawn(Transform transform, string name, bool defaultWeapon)
    {
        if (defaultWeapon == false) { 

            //position wird definiert
            position.x = transform.position.x;
            position.y = y;
            position.z = z;

            //Die Liste wird nach einem Item durchsucht die zu dem mitgegebenem Namen passt
            GameObject x = Array.Find(lootItems, loot => loot.name == name);

            if (x == null)
            {
                Debug.LogWarning("Der Loot mit dem Namen " + name + " wurde nicht in der Liste gefunden");
                return;
            }

            //Spawnen
            Instantiate(x, position, transform.rotation);
            }

        else if(defaultWeapon == true)
        {
            //position wird definiert
            position.x = transform.position.x;
            position.y = transform.position.y;
            position.z = z;

            //Die Liste wird nach einem Item durchsucht die zu dem mitgegebenem Namen passt
            GameObject x = Array.Find(lootItems, loot => loot.name == name);

            if (x == null)
            {
                Debug.LogWarning("Der Loot mit dem Namen " + name + " wurde nicht in der Liste gefunden");
                return;
            }

            //Spawnen
            Instantiate(x, position, transform.rotation);
        }
    }

    //Bei diesem Spawn kann man selbst die genauen Koordinaten für den Spawn bestimmen
    public void Spawn(Transform transform, string name, bool defaultWeapon, float xAxis, float yAxis, float zAxis)
    {
        if (defaultWeapon == false)
        {
            //position wird definiert
            position.x = xAxis;
            position.y = yAxis;
            position.z = zAxis;

            //Die Liste wird nach einem Item durchsucht die zu dem mitgegebenem Namen passt
            GameObject x = Array.Find(lootItems, loot => loot.name == name);

            if (x == null)
            {
                Debug.LogWarning("Der Loot mit dem Namen " + name + " wurde nicht in der Liste gefunden");
                return;
            }

            //Spawnen
            Instantiate(x, position, transform.rotation);
        }

        else if (defaultWeapon == true)
        {
            //position wird definiert
            position.x = xAxis;
            position.y = yAxis;
            position.z = zAxis;

            //Die Liste wird nach einem Item durchsucht die zu dem mitgegebenem Namen passt
            GameObject x = Array.Find(lootItems, loot => loot.name == name);

            if (x == null)
            {
                Debug.LogWarning("Der Loot mit dem Namen " + name + " wurde nicht in der Liste gefunden");
                return;
            }

            //Spawnen
            Instantiate(x, position, transform.rotation);
        }
    }
}

