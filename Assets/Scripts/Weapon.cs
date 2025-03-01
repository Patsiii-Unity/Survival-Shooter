﻿using System;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Variablendefinition
    public float timer = 0.33f;         //Zeit die vergeht bis der nächste Schuss abgesetzt wird
    public float weaponTimer = 30f;     //Zeigt die Zeit an wie lange man die Waffe verwenden kann bis sie wieder abgelegt wird

    //max Munition
    public int ammo = 0;

    float safeTime;

    AudioManager audioManager;

    public bool pickedUp = false;

    //Um zu wählen welcher Ton abgespielt wird
    public int soundID = 0;

    //Zeigt an ob max Ammo bereits definiert wurde
    bool alr = false;

    //Animator
    public Animator animator;

    //Camera Shake Variable
    private Shake shake;

    //Um zu wählen welcher Shake abgespielt wird
    public int shakeID = 0;

    //Variable für das Partikelsystem
    public ParticleSystem particles;
    public ParticleSystem smoke;
    public ParticleSystem dropped;  

    //Start
    void Start()
    {
        //der ursprüngliche Zeitwert wird gespeichert
        safeTime = timer;

        audioManager = FindObjectOfType<AudioManager>();


        //shake Variable wird definiert
        shake = GameObject.FindGameObjectWithTag("Screenshake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alr == false && pickedUp == true)
        {
            //Munitionstext wird aktualisiert
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponPickUpSystem>().setMaxAmmo(ammo, gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponPickUpSystem>().setAmmo(ammo, gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponPickUpSystem>().setWeaponTime(timer, gameObject);
            alr = true;

            if (dropped != null)
            {
                dropped.Stop();
            }
        }

        //Countdown
        timer -= Time.deltaTime;

        //Wenn man die "Fire1" Taste drückt, der Counter kleiner gleich 0 ist, die Waffe ausgerüstet ist und das Spiel nicht pausiert ist wird geschossen 
        if (Input.GetButtonDown("Fire1") && timer <= 0 && pickedUp == true && PauseMenü.GameIsPaused == false && gameObject.tag != "AutoWeapon" && ammo != 0 && weaponTimer == -1)
        {
            //es wird geschossen
            GetComponent<Shoot>().shoot();

            //Timer wird zurückgesetzt
            timer = safeTime;

            //Schuss-Sound wird abgegeben
            if (soundID == 0)
            {
                audioManager.Play("GunShot");
            }
            else if (soundID == 1)
            {
                audioManager.Play("Shotgun");
            }
            else if (soundID == 2)
            {
                audioManager.Play("VAPR-XKG");
            }

            //Animation
            if (animator != null)
            {
                animator.SetTrigger("Shoot");
            }

            //Camera Shake wird durchgeführt
            if (shakeID == 0)
            {
                shake.GunShake1();
            }
            else if (shakeID == 1)
            {
                shake.ShotGunShake1();
            }

            //Partikel werden abgespielt
            playParticles();

            //Munitionssystem
            //Munition wird verringert
            deAmmo();
        }
        else if (Input.GetButtonDown("Fire1") && timer <= 0 && pickedUp == true && PauseMenü.GameIsPaused == false && gameObject.tag != "AutoWeapon" && ammo == -1 && weaponTimer > 0)
        {
            //es wird geschossen
            GetComponent<Shoot>().shoot();

            //Timer wird zurückgesetzt
            timer = safeTime;

            //Schuss-Sound wird abgegeben
            if (soundID == 0)
            {
                audioManager.Play("GunShot");
            }
            else if (soundID == 1)
            {
                audioManager.Play("Shotgun");
            }
            else if (soundID == 2)
            {
                audioManager.Play("VAPR-XKG");
            }

            //Animation
            if (animator != null)
            {
                animator.SetTrigger("Shoot");
            }

            //Camera Shake wird durchgeführt
            if (shakeID == 0)
            {
                shake.GunShake1();
            }
            else if (shakeID == 1)
            {
                shake.ShotGunShake1();
            }

            //Partikel werden abgespielt
            playParticles();
        }
    
        else if (gameObject.tag == "AutoWeapon")
        {
            if (Input.GetButton("Fire1") && timer <= 0 && pickedUp == true && PauseMenü.GameIsPaused == false && ammo != 0 && weaponTimer == -1)
            {
                //es wird geschossen
                GetComponent<Shoot>().shoot();

                //Timer wird zurückgesetzt
                timer = safeTime;

                //Schuss-Sound wird abgegeben
                if (soundID == 0)
                {
                    audioManager.Play("GunShot");
                }
                else if (soundID == 1)
                {
                    audioManager.Play("Shotgun");
                }
                else if (soundID == 2)
                {
                    audioManager.Play("VAPR-XKG");
                }
                else if (soundID == 3)
                {
                    audioManager.Play("Minigun");
                }

                //Animation
                if (animator != null)
                {
                    animator.SetTrigger("Shoot");
                }

                //Camera Shake wird durchgeführt
                if (shakeID == 0)
                {
                    shake.GunShake1();
                }
                else if (shakeID == 1)
                {
                    shake.ShotGunShake1();
                }

                //Partikel werden abgespielt
                playParticles();

                if (smoke != null)
                {
                    if (smoke.isPlaying == false)
                    {
                        smoke.Play();
                    }
                }

                //Munitionssystem
                //Munition wird verringert
                deAmmo();
            }

            else if (Input.GetButton("Fire1") && timer <= 0 && pickedUp == true && PauseMenü.GameIsPaused == false && ammo == -1 && weaponTimer > 0)
            {
                //es wird geschossen
                GetComponent<Shoot>().shoot();

                //Timer wird zurückgesetzt
                timer = safeTime;

                //Schuss-Sound wird abgegeben
                if (soundID == 0)
                {
                    audioManager.Play("GunShot");
                }
                else if (soundID == 1)
                {
                    audioManager.Play("Shotgun");
                }
                else if (soundID == 2)
                {
                    audioManager.Play("VAPR-XKG");
                }
                else if (soundID == 3)
                {
                    audioManager.Play("Minigun");
                }

                //Animation
                if (animator != null)
                {
                    animator.SetTrigger("Shoot");
                }

                //Camera Shake wird durchgeführt
                if (shakeID == 0)
                {
                    shake.GunShake1();
                }
                else if (shakeID == 1)
                {
                    shake.ShotGunShake1();
                }

                //Partikel werden abgespielt
                playParticles();

                if (smoke != null)
                {
                    if (smoke.isPlaying == false)
                    {
                        smoke.Play();
                    }
                }
            }
        }

        //Minigun cooldown sound wird abgespielt & cooldown timer wird gesetzt
        if (Input.GetButtonUp("Fire1") && pickedUp == true && PauseMenü.GameIsPaused == false)
        {
            //Handelt es sich um eine Minigun wird der Cooldown gesetzt
            if(soundID == 3)
            {
                //Cooldown Sound bei Minigun
                audioManager.Play("Minigun Cooldown");

                //Cooldown Timer wird gesetzt
                timer = 0.5f;

                //Partikel werden gestoppt
                if (smoke != null)
                {
                    if (smoke.isPlaying == true)
                    {
                        smoke.Stop();
                    }
                }
            }
        }

        //Munitionstext & Weapontimertext wird aktualisiert
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponPickUpSystem>().setAmmo(ammo, gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponPickUpSystem>().setWeaponTime(weaponTimer, gameObject);
        }

        //Objekt wird zerstört wenn die Munition 0 beträgt
        if (ammo == 0 && gameObject.tag != "DefWeapon")
        {
            if (particles != null)
            {
                if (particles.isPlaying == false)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponPickUpSystem>().weapon = null;
                    Destroy(gameObject);
                }
            }
            else {
                GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponPickUpSystem>().weapon = null;
                Destroy(gameObject);
            }
        }

        //Wenn die Waffe nicht mit Munition verwaltet wird sondern mit Zeit & die Waffe bereits ausgerüstet wurde, dann wird die Zeit runtergezählt
        if(weaponTimer > 0 && ammo == -1 && pickedUp == true)
        {
            //Ist die Zeit 0, wird die Waffe zerstört
            weaponTimer -= Time.deltaTime;

            if (weaponTimer <= 0 && weaponTimer > -1)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponPickUpSystem>().weapon = null;
                Destroy(gameObject);
            }
        }
    }

    //pickedUp wird auf true gesetzt
    public void pickUp()
    {
        pickedUp = true;
    }

    //Weapon destroys itself
    public void destroyWeapon()
    {
        Destroy(gameObject);
    }

    //weapon ammo verringert
    public void deAmmo()
    {
        //Munition wird um 1 verringert
        if (ammo > 0)
        {
            //Munition wird verringert
            ammo--;
        }
    }

    //Partikelsystem wird abgespielt
    public void playParticles()
    {
        //Partikelsystem wird abgespielt
        if (particles != null)
        {
            particles.Play();
        }
    }
}
