using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Variablendefintion
    public CharacterController2D controller;

    public float speed = 40f;

    float horizontalMove = 0f;

    public bool jump = false;

    //Run Particle System
    public ParticleSystem runParticle;  //Particle System
    bool alr = false;                   //Überprüft ob das Paritcle System bereits gestartet wurde
    bool inAir = false;                 //Überprüft ob der Spieler in der Luft ist

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        //Wenn man sich auf dem Boden bewegt erscheinen Laufpartikel
        if(horizontalMove != 0 && alr == false && inAir == false)
        {
            runParticle.Play();
            alr = true;
        }
        else if(horizontalMove == 0)
        {
            runParticle.Stop();

            if (alr == true)
            {
                alr = false;
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
    }

    //Spieler bewegen
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
    }

    //Überprüfung ob der Spieler auf dem Boden befindet
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            inAir = false;
        }
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ground")
        {
            runParticle.Stop();

            inAir = true;
        }
    }
}
