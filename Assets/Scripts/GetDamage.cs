using UnityEngine;

public class GetDamage : MonoBehaviour
{
    //Variablendefinition
    public int health = 3;

    public float cooldown = 3f;

    float safeCooldown;

    public GameObject threeHearts;
    public GameObject twoHearts;
    public GameObject oneHeart;
    public GameObject zeroHearts;

    public AudioManager audioManager;

    int randomSoundNum;

    //Particle System
    public ParticleSystem deathParticles;

    void Start()
    {
        safeCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {

        cooldown -= Time.deltaTime;

        if(health == 3)
        {
            threeHearts.SetActive(true);
            twoHearts.SetActive(false);
            oneHeart.SetActive(false);
            zeroHearts.SetActive(false);
        }
        else if(health == 2)
        {
            threeHearts.SetActive(false);
            twoHearts.SetActive(true);
            oneHeart.SetActive(false);
            zeroHearts.SetActive(false);
        }
        else if(health == 1)
        {
            threeHearts.SetActive(false);
            twoHearts.SetActive(false);
            oneHeart.SetActive(true);
            zeroHearts.SetActive(false);
        }
        else if(health <= 0)
        {
            threeHearts.SetActive(false);
            twoHearts.SetActive(false);
            oneHeart.SetActive(false);
            zeroHearts.SetActive(true);

            //Partikel werden abgespielt
            Instantiate(deathParticles, gameObject.transform.position, gameObject.transform.rotation);          

            //Player gets destroyed 
            Destroy(gameObject);
           
            //Alle Arten von Songs werden gestoppt 
            audioManager.Stop("Theme");
            audioManager.Stop("Pump");

            //Game Over Sound wird gespielt
            randomSoundNum = Random.Range(1, 4);

            if(randomSoundNum == 1)
            {
                audioManager.Play("Game Over");
            }
            else if (randomSoundNum == 2)
            {
                audioManager.Play("Game Over 2");
            }
            else if (randomSoundNum == 3)
            {
                audioManager.Play("Game Over 3");
            }

            //Weapon gets destroyed
            if (GetComponent<WeaponPickUpSystem>().weapon == null)
            {
                return;
            }
            else
            {
                GetComponent<WeaponPickUpSystem>().weapon.GetComponent<Weapon>().destroyWeapon();
            }
        }
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Enemy" && cooldown < 0)
        {
            health -= 1;

            //Sound
            audioManager.Play("Damage");

            //cooldown wird zurückgesetzt
            cooldown = safeCooldown;
        }
    }
}
