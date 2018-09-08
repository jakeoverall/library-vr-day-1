using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    NavMeshAgent agent;
    Animator anim;
    Rigidbody rb;
    float actualSpeed;
    bool dead = false;


    public bool HasTarget;
    public GameObject Target;
    public float DestroyAfterSeconds = 4;
    public float HitForce = 500;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!dead)
        {
            agent.SetDestination(Target.transform.position);
            actualSpeed = agent.speed;
            anim.SetFloat("Speed", agent.speed);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "weapon")
        {
            Destroy(agent);
            dead = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddExplosionForce(HitForce, other.transform.position, 5, 150);
            anim.SetTrigger("Death");
            Destroy(gameObject, DestroyAfterSeconds);
        }
    }


}
