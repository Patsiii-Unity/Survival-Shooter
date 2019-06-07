using UnityEngine.UI;
using UnityEngine;

public class Bullet : MonoBehaviour

{
    //Variablendefinition
    public Rigidbody2D rb;

    public float speed = 20f;

    public int damage = 30;

    public float despawnTime = 0.5f;

    public GameObject impact;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Destroy(gameObject, despawnTime);
    }

    //CollisionDetection
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Enemy")
        {
            collisionInfo.gameObject.GetComponent<Enemy>().takeDamage(damage);

            if (impact != null)
            {
                //Impact Effect Spawn
                Instantiate(impact, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }

        if(collisionInfo.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
