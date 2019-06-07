using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variablendefintion
    int health = 100;
    LootDropManager manager = null;

    int randomLootNum;
    int randomSoundNum;

    AudioManager audioManager;

    //Max wird für die Zufallsgenerierung, wo entschieden wird welche Waffe gedroppt wird
    int max = 2;

    //Partikel Systeme
    public ParticleSystem killParticles;

    //Start
    void Start()
    {
        GetComponent<EnemyFollow>().enabled = false;

        //Dem manager wird der LootDropManager zugewiesen
        manager = GameObject.FindObjectOfType<LootDropManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    //Methode für Schaden
    public void takeDamage(int damage)
    {
        //Schaden wird erlitten
        health = health - damage;

        //Wenn die Lebenspunkte kleiner als oder gleich 0 sind wird das Objekt zerstört;
        if (health <= 0)
        {

            //großer Burst wird gespawnt
            Instantiate(killParticles, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(gameObject);

            GameObject.FindGameObjectWithTag("Player").GetComponent<KillCounterSystem>().IncreaseKillCounter();
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawnSystem>().IncreaseKillCounter();

            //LootSpawnSystem
            //Es wird zufallsgeneriert ob Loot gedroppt wird
            if (Random.Range(1, GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawnSystem>().maxRandomValue) == 1)
            {
                //Es wird zufallsgeneriert welcher Loot gedroppt wird
                randomLootNum = Random.Range(1, max);

                if (randomLootNum == 1)
                {
                    manager.Spawn(gameObject.transform, "Shotgun");
                }
                else if (randomLootNum == 2)
                {
                    manager.Spawn(gameObject.transform, "Golden Gun");
                }
                else if (randomLootNum == 3)
                {
                    manager.Spawn(gameObject.transform, "VAPR-XKG");
                }
                else if (randomLootNum == 4)
                {
                    manager.Spawn(gameObject.transform, "Minigun");
                }

                //LootDropSound abspielen
                audioManager.Play("LootDropSound");
            }
            //Wenn keine Waffe spawnt ist die Chance 1 zu 50, dass ein Herz spawnt
            else if (Random.Range(0, 50) == 0) {

                manager.Spawn(gameObject.transform, "Full Heart");

                //LootDropSound abspielen
                audioManager.Play("LootDropSound");
            }

   
            //Einer von 3 Zombie-Sounds wird abgespielt
            randomSoundNum = Random.Range(1, 4);

            if(randomSoundNum == 1) {
                audioManager.Play("Zombie 1");
            }
            else if (randomSoundNum == 2)
            {
                audioManager.Play("Zombie 2");
            }
            else if (randomSoundNum == 3)
            {
                audioManager.Play("Zombie 3");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ground")
        {
            GetComponent<EnemyFollow>().enabled = true;
        }
    }

    void Update()
    {
        //Nach einer bestimmten Anzahl Kills werden neu Waffen zum Spawnen freigeschaltet
        if (EnemySpawnSystem.killCounter >= 5 && EnemySpawnSystem.killCounter < 50)
        {
            max = 3;    //beinhaltet Golden Gun
        }
        else if (EnemySpawnSystem.killCounter >= 50 && EnemySpawnSystem.killCounter < 75)
        {
            max = 4;    //beinhaltet VAPR-XKG
        }
        else if (EnemySpawnSystem.killCounter >= 75)
        {
            max = 5;    //beinhaltet Minigun
        }
    }
}
