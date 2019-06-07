using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    //Variablendefinition

    //zu spawnendes Particle System
    public ParticleSystem particleSystem;
    
    //Spawned ein neues ParticleSystem
    public void spawn()
    {
        Instantiate(particleSystem, gameObject.transform.position, gameObject.transform.rotation);
    }
}
