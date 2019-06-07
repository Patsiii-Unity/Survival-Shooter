using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    //Variablendefinition
    public GameObject enemy;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public static int killCounter;

    //Ultra easy 
    public float timerMin = 3f;
    public float timerMax = 7f;

    Vector3 spawnPoint;

    float timer = 5f;

    //Spawnrate für Waffen
    public int maxRandomValue;

    void Start()
    {
        //Da es static ist muss der killCounter am Anfang immer auf 0 gesetzt werden
        //Wegen static wird die Variable beim laden einer neue
        killCounter = 0;

        //Spawnrate von Waffen
        maxRandomValue = 8;
    }

    // Update is called once per frame
    void Update()
    {

        //At every 10. kill the difficulty gets increased
        if (killCounter % 10 == 0)
        {
            increasDifficluty(killCounter);
        }

        //timer wird runtergezählt (Countdown)
        timer -= Time.deltaTime;

        //timer <= 0, Gegner wird gespawnt
        if(timer <= 0)
        {
            //Der spawnpoint wird zufalls generiert
            spawnPoint.x = Random.Range(spawnPointLeft.position.x, spawnPointRight.position.x);
            spawnPoint.y = Random.Range(spawnPointLeft.position.y, spawnPointRight.position.y);

            Instantiate(enemy, spawnPoint, transform.rotation);

            //Der timer wird zufalls generiert
            timer = Random.Range(timerMin, timerMax);
        }

        //Es wird nach dem Spieler gesucht, wird dieser nicht gefunden ist er tot und das Spawnscipt deaktiviert sich
        if(GameObject.FindGameObjectWithTag("Player") == null) {

            //Script wird deaktiviert
            gameObject.GetComponent<EnemySpawnSystem>().enabled = false;
        }
    }

    //increases the difficulty
    void increasDifficluty(int killCounter)
    {
        //very easy
        if(killCounter == 10)
        {
            timerMin = 2.5f;
            timerMax = 6f;

            maxRandomValue = 8;
        }
        
        //easy
        if (killCounter == 20)
        {
            timerMin = 2.5f;
            timerMax = 5f;

            maxRandomValue = 8;
        }
        //medium
        if (killCounter == 30)
        {
            timerMin = 2f;
            timerMax = 5f;

            maxRandomValue = 8;
        }
        //hard
        if (killCounter == 40)
        {
            timerMin = 1.5f;
            timerMax = 5f;

            maxRandomValue = 7;
        }
        //very hard
        if (killCounter == 50)
        {
            timerMin = 1.5f;
            timerMax = 4.5f;

            maxRandomValue = 7;
        }
        //ultra hard
        if (killCounter == 60)
        {
            timerMin = 1.25f;
            timerMax = 4.25f;

            maxRandomValue = 7;
        }
        //epic
        if (killCounter == 70)
        {
            timerMin = 1f;
            timerMax = 4f;

            maxRandomValue = 6;
        }
        //legendary
        if (killCounter == 80)
        {
            timerMin = 1f;
            timerMax = 3.75f;

            maxRandomValue = 6;
        }
        //impossible
        if (killCounter == 90)
        {
            timerMin = 0.75f;
            timerMax = 3.25f;

            maxRandomValue = 5;
        }
        //hell fire
        if (killCounter >= 100)
        {
            timerMin = 0.5f;
            timerMax = 2f;

            maxRandomValue = 5;
        }
    }

    //killCounter erhöhen
    public void IncreaseKillCounter()
    {
        killCounter = killCounter + 1;
    }
}
