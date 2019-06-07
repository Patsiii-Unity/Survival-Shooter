using System;
using UnityEngine;

public class LootDropManager : MonoBehaviour
{
    //Variablendefinition
    public GameObject[] lootItems;

    Vector3 position;

    public float y = -0.82f;

    public void Spawn(Transform transform, string name)
    {
        //position wird definiert
        position.x = transform.position.x;
        position.y = y;
        position.z = transform.position.z;

        //Die Liste wird nach einem Item durchsucht die zu dem mitgegebenem Namen passt
        GameObject x = Array.Find(lootItems, loot => loot.name == name);

        if(x == null)
        {
            Debug.LogWarning("Der Loot mit dem Namen " + name + " wurde nicht in der Liste gefunden");
            return;
        }

        //Spawnen
        Instantiate(x, position, transform.rotation);
    }
}
