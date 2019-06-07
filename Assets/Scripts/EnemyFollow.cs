using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //Variablendefinition
    public float speed = 5f;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
