using UnityEngine;

public class EndbossAcornAttack : MonoBehaviour
{
    //Variablendefinition
    public Rigidbody2D rb;

    public float speed = -20f;

    public float despawnTime = -1f;       

    public int damage = 0;

    public ParticleSystem impactParticle;

    AudioManager audioManager;
    Shake shakeManager;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;

        //Die einzelnen Manager werden definiert
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        shakeManager = GameObject.FindObjectOfType<Shake>();

    }

    void Update()
    {
        if (despawnTime != -1)
        {
            Destroy(gameObject, despawnTime);
        }
    }

    //TriggerDetection
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            collisionInfo.gameObject.GetComponent<GetDamage>().getDamage(damage);

            if(impactParticle != null)
            {
                Instantiate(impactParticle);
            }

            //Spielter Damage Sound wird abgespielt
            audioManager.Play("Damage");

            //Screenshake beim Aufprall mit dem Spieler
            shakeManager.AcornShake();

            Destroy(gameObject);
        }
        else if (collisionInfo.gameObject.tag == "Ground")
        {
            if (impactParticle != null)
            {
                Instantiate(impactParticle);
            }

            //Screenshake beim Aufprall mit dem Boden
            shakeManager.AcornShake();

            Destroy(gameObject);
        }
    }
}
