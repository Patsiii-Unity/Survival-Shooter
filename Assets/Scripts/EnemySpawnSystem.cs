﻿using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    //Variablendefinition

    //Gegner Prefabs
    public GameObject enemy;        //Standart "Enemy" Prefab
    public GameObject acorn;        //Eichel Prefab (Endboss Attacke)

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public static int killCounter;

    //Ultra easy 
    public float timerMin = 2.5f;
    public float timerMax = 5f;

    Vector3 spawnPoint;

    float timer = 5f;           //Timer für das Spawnen von "Enemys"
    float acornTimer = 1f;      //Timer für das Spawnen von "Eicheln"
    float saveAcornTimer;       //Dient dazu um den acornTimer später wieder zun urpünglichen Wert zurückzusetzen

    int acornAmount = 10;       //Anzahl der Eicheln die in einer Attacke gespawnt werden

    //Spawnrate für Waffen
    public int maxRandomValue;

    //Animator des Endbosses
    public Animator endboss;

    void Start()
    {
        //Da es static ist muss der killCounter am Anfang immer auf 0 gesetzt werden
        //Wegen static wird die Variable beim laden einer neue
        killCounter = 0;

        //Spawnrate von Waffen
        maxRandomValue = 8;

        //Speichert den urspünglichen acornTimer Wert
        saveAcornTimer = acornTimer;
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
            timerMax = 4.5f;

            maxRandomValue = 7;
        }
        
        //easy
        if (killCounter == 20)
        {
            timerMin = 2f;
            timerMax = 4.5f;

            maxRandomValue = 7;
        }
        //medium
        if (killCounter == 30)
        {
            timerMin = 2f;
            timerMax = 4f;

            maxRandomValue = 7;
        }
        //hard
        if (killCounter == 40)
        {
            timerMin = 1.5f;
            timerMax = 4f;

            maxRandomValue = 6;
        }
        //very hard
        if (killCounter == 50)
        {
            timerMin = 1.5f;
            timerMax = 3.5f;

            maxRandomValue = 6;
        }
        //ultra hard
        if (killCounter == 60)
        {
            timerMin = 1.5f;
            timerMax = 3f;

            maxRandomValue = 6;
        }
        //epic
        if (killCounter == 70)
        {
            timerMin = 1.25f;
            timerMax = 3f;

            maxRandomValue = 6;
        }
        //legendary
        if (killCounter == 80)
        {
            timerMin = 1.25f;
            timerMax = 2.5f;

            maxRandomValue = 5;
        }
        //impossible
        if (killCounter == 90)
        {
            timerMin = 1.25f;
            timerMax = 2.25f;

            maxRandomValue = 5;
        }
        //hell fire
        if (killCounter >= 100)
        {
            timerMin = 1f;
            timerMax = 2f;

            maxRandomValue = 5;

            //Endboss Erwachungs-Animation
            endboss.SetTrigger("Awake");
        }
    }

    //killCounter erhöhen
    public void IncreaseKillCounter()
    {
        killCounter = killCounter + 1;
    }

    //Methode für das Spawnen von Eicheln (Endboss Attacke)
    public bool AcornAttack()
    {
        while (acornAmount > 0) {

            //acornTimer wird runtergezählt (Countdown für das Spawnen der nächsten Eichel)
            acornTimer -= Time.deltaTime;

            //timer <= 0, Gegner wird gespawnt
            if (acornTimer <= 0)
            {
                //Der spawnpoint wird zufalls generiert
                spawnPoint.x = Random.Range(spawnPointLeft.position.x, spawnPointRight.position.x);
                spawnPoint.y = Random.Range(spawnPointLeft.position.y, spawnPointRight.position.y);

                Instantiate(acorn, spawnPoint, transform.rotation);

                //Der acornTimer wird wieder zum ursprünglichen Wert zurückgesetzt
                acornTimer = saveAcornTimer;
            }

            //Es wird nach dem Spieler gesucht, wird dieser nicht gefunden ist er tot und das Spawnscipt deaktiviert sich
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                //Script wird deaktiviert
                gameObject.GetComponent<EnemySpawnSystem>().enabled = false;
            }

            //Zeigt an das die Attacke noch nicht beendet wurde
            return false;
        }

        //Es wird true zurückgegeben
        //Dies gibt dem Endboss Bescheid, dass diese Attacke beendet wurde und dieser nun eine neue Attacke starten kanns
        return true;
    }
}

