using TMPro;
using UnityEngine;

public class WeaponPickUpSystem : MonoBehaviour
{

    //Variablendefinition
    public GameObject weapon = null;

    //zeigt an ob in der Runde bereits eine Waffe ausgerüstet wurde
    bool equipDefW = false;

    //zeigt die maximale und aktuelle Munition der ausgerüsteten Waffe an
    public int maxAmmo;
    public int ammo;

    //zeigt die aktuelle Zeit des Timers an
    public float weaponTime;

    //Player Damage Script
    public GetDamage getDamage;

    //Um doppelte Standart Waffen spawns zu verhindern
    bool spawnProtection = false;

    public Transform weaponpoint;

    public AudioManager audioManager;
    public LootDropManager lootDropManager;

    //Ammo Texts
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI maxAmmoText;
    public TextMeshProUGUI ammoLine;

    //Timer Texts
    public TextMeshProUGUI weaponTimeText;

    //Damit der Mafia Boss Sound nur 1mal abgespielt wird
    public bool soundPlaying = false;

    //verhindert dass 2 Waffen auf einmal aufgenommen werden
    float cooldown = 0.25f;

    //Animator
    public Animator animator;

    //Camera-Shake Objekt für Shake oder Zoom Animationen an der Kamera
    public Shake cameraShake;

    //Lootdropmanager für Waffenspawns
    public LootDropManager manager;

    //Sorgt dafür das bestimmte Waffen nur einmal gespawnt werden
    bool bossWeaponAlr = false;

    //Trigger-Stay
    void OnTriggerStay2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Weapon" || collisionInfo.gameObject.tag == "MafiaBoss Weapon" || collisionInfo.gameObject.tag == "AutoWeapon")
        {

            //Wenn man die Waffe berührt und "e" drückt wird diese aufgehoben
            if (Input.GetButton("Interaction") && collisionInfo.gameObject != weapon && cooldown <= 0)
            {
                //Ist bereits eine Waffe ausgerüstet wird diese zerstört
                if (weapon != null)
                {
                    Destroy(weapon);
                }

                //Objekt wird abgespeichert
                weapon = collisionInfo.gameObject;

                //PickUp-Sound wird abgespielt
                audioManager.Play("Gun Cocking");

                //Waffe aufgehoben
                collisionInfo.gameObject.GetComponent<Weapon>().pickUp();

                //Schießen wird aktiviert
                collisionInfo.gameObject.GetComponent<Weapon>().enabled = true;

                //equipDefW wird auf true gesetzt
                if (equipDefW == false)
                {
                    equipDefW = true;
                }

                //Cooldown für das Ausrüsten von Waffen wird zurückgesetzt
                cooldown = 0.25f;               
            }

            //Cooldown wird runtergezählt
            if(cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }

        }
        else if (collisionInfo.gameObject.tag == "Heart")
        {
            //Wenn man die Waffe berührt und "e" drückt wird diese aufgehoben
            if (Input.GetButton("Interaction") && getDamage.health < 3)
            {
                //Gesundheit wird um eins erhöht
                getDamage.health = getDamage.health + 1;

                //Particle Spawn
                collisionInfo.gameObject.GetComponent<SpawnParticles>().spawn();

                //Heart Pick Up sound
                audioManager.Play("Heart");

                //Herz wird zerstört
                Destroy(collisionInfo.gameObject);
            }
        }

        //Wenn man bei Lvl 100 ist und mit dem Endboss interagiert, dann wird eine speziele Waffe gespawnt 
        if (collisionInfo.gameObject.tag == "Endboss" && Input.GetButton("Interaction") && EnemySpawnSystem.killCounter == 100 && bossWeaponAlr == false)
        {
            //Die Waffe wird mit selbst bestimmten Koordinaten gespawnt
            manager.Spawn(collisionInfo.gameObject.transform, "EndbossTreeWeapon", false, 1.887589f, -0.561191f, -1f);
            bossWeaponAlr = true;

            //LootDropSound abspielen
            audioManager.Play("LootDropSound");
        }
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "DefWeapon")
        {
            //Objekt wird abgespeichert
            weapon = collisionInfo.gameObject;

            //PickUp-Sound wird abgespielt
            audioManager.Play("Gun Cocking");

            //Waffe aufgehoben
            collisionInfo.gameObject.GetComponent<Weapon>().pickUp();

            //Schießen wird aktiviert
            collisionInfo.gameObject.GetComponent<Weapon>().enabled = true;

            //equipDefW wird auf true gesetzt
            if (equipDefW == false)
            {
                equipDefW = true;
            }

            spawnProtection = false;
        }

        else if (collisionInfo.gameObject.tag == "Weapon" || collisionInfo.gameObject.tag == "MafiaBoss Weapon" || collisionInfo.gameObject.tag == "AutoWeapon")
        {

            //Wenn man die Waffe berührt und "e" drückt wird diese aufgehoben
            if (Input.GetButton("Interaction") && collisionInfo.gameObject != weapon && cooldown <= 0)
            {
                //Ist bereits eine Waffe ausgerüstet wird diese zerstört
                if (weapon != null)
                {
                    Destroy(weapon);
                }

                //Objekt wird abgespeichert
                weapon = collisionInfo.gameObject;

                //PickUp-Sound wird abgespielt
                audioManager.Play("Gun Cocking");

                //Waffe aufgehoben
                collisionInfo.gameObject.GetComponent<Weapon>().pickUp();

                //Schießen wird aktiviert
                collisionInfo.gameObject.GetComponent<Weapon>().enabled = true;

                //equipDefW wird auf true gesetzt
                if (equipDefW == false)
                {
                    equipDefW = true;
                }

                //Cooldown für das Ausrüsten von Waffen wird zurückgesetzt
                cooldown = 0.25f;
            }

            //Cooldown wird runtergezählt
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }
        }
        
        else if (collisionInfo.gameObject.tag == "Heart")
        {
            //Wenn man die Waffe berührt und "e" drückt wird diese aufgehoben
            if (Input.GetButton("Interaction") && getDamage.health < 3)
            {
                //Gesundheit wird um eins erhöht
                getDamage.health = getDamage.health + 1;

                //Particle Spawn
                collisionInfo.gameObject.GetComponent<SpawnParticles>().spawn();

                //Heart Pick Up sound
                audioManager.Play("Heart");

                //Herz wird zerstört
                Destroy(collisionInfo.gameObject);
            }
        }

        //Wenn man bei Lvl 100 ist und mit dem Endboss interagiert, dann wird eine speziele Waffe gespawnt 
        if (collisionInfo.gameObject.tag == "Endboss" && Input.GetButton("Interaction") && EnemySpawnSystem.killCounter == 100 && bossWeaponAlr == false)
        {
            //Die Waffe wird mit selbst bestimmten Koordinaten gespawnt
            manager.Spawn(collisionInfo.gameObject.transform, "EndbossTreeWeapon", false, 1.887589f, -0.561191f, -1f);
            bossWeaponAlr = true;

            //LootDropSound abspielen
            audioManager.Play("LootDropSound");
        }
    }

    //Update Method
    void Update()
    {
        if (weapon != null)
        {
            //Auf dem Boden liegendes Objekt wird mit den weaponPoint Koordinaten synchronisiert
            weapon.transform.position = weaponpoint.position;
            weapon.transform.rotation = weaponpoint.rotation;

            //Überprüfung ob es sich um eine Waffe mit besonderem Tag handelt
            if (weapon.tag == "MafiaBoss Weapon" && soundPlaying == false)
            {
                //Player Mafia Boss Transformations Animation
                animator.SetBool("MafiaBoss Transform", true);
              
                //Starts Mafia Boss Music
                audioManager.Stop("Theme");
                audioManager.Play("LvL Up");
                audioManager.Play("Pump");

                soundPlaying = true;
            }
            else if (weapon.tag != "MafiaBoss Weapon" && soundPlaying == true)
            {
                animator.SetBool("MafiaBoss Transform", false);

                //Stops Mafia Boss Music
                audioManager.Stop("Pump");
                audioManager.Play("Theme");

                soundPlaying = false;
            }
        }
        else if(weapon == null && equipDefW == true && spawnProtection == false)
        {
            //Standart Waffe wird gespawnt
            lootDropManager.Spawn(weaponpoint, "Gun", true);

            spawnProtection = true;
        }

        //Ammo Text wird aktualisiert & wenn nötig deaktiviert bzw. aktiviert
        ammoText.text = ammo.ToString();
        maxAmmoText.text = maxAmmo.ToString();

        //Weapontime Text wird aktualisiert & wenn nötig deaktiviert bzw. aktiviert
        weaponTimeText.text = weaponTime.ToString("0");

        textActivation();
        
    }

    //Die aktuelle Munition wird definiert
    public void setAmmo(int ammo, GameObject weapon)
    {
        //Es wird überprüft ob die ausgerüstete Waffe die Munitionsanzeige ändern will
        //Verhindert dass eine neu gespawnte Waffe die Anzeige verändert
        if (this.weapon == weapon)
        {
            this.ammo = ammo;
        }
    }

    //Die maximale Munition wird definiert
    public void setMaxAmmo(int ammo, GameObject weapon)
    {
        //Es wird überprüft ob die ausgerüstete Waffe die Munitionsanzeige ändern will & nicht eine nicht ausgerüstete
        //Verhindert dass eine neu gespawnte Waffe die Anzeige verändert
        if (this.weapon == weapon)
        {
            maxAmmo = ammo;
        }
    }
    //Die aktuelle Timerzeit wird definiert
    public void setWeaponTime(float timer, GameObject weapon)
    {
        //Es wird überprüft ob die ausgerüstete Waffe die Timeranzeige ändern will & nicht eine nicht ausgerüstete
        //Verhindert dass eine neu gespawnte Waffe die Anzeige verändert
        if (this.weapon == weapon)
        {
            weaponTime = timer;
        }
    }

    //Methode für die Aktivierung der Munitionsanzeige
    void textActivation()
    {
        if(ammoText.text.Equals("0") || ammoText.text.Equals("-1"))
        {
            ammoText.enabled = false;
            maxAmmoText.enabled = false;
            ammoLine.enabled = false;
        }
        else
        {
            ammoText.enabled = true;
            maxAmmoText.enabled = true;
            ammoLine.enabled = true;
        }

        if(weaponTimeText.text.Equals("-1"))
        {
            weaponTimeText.enabled = false;
        }
        else
        {
            weaponTimeText.enabled = true;
        }
    }
}
