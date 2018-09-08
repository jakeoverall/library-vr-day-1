using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploadable : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer mesh;
    public GameObject Pieces;
    public float ExplosiveForce = 500;
    public float ExplosionRadius = 5;
    public float UpForce = 50;
    public float DestroyAfterSeconds = 4;
    public float VelocityToExplode = 50;
    bool hit = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (!hit && other.relativeVelocity.sqrMagnitude > VelocityToExplode)
        {
            hit = true;
            mesh.enabled = false;
            var pieces = Instantiate(Pieces, transform.position, transform.rotation);
            rb.AddExplosionForce(
                ExplosiveForce,
                other.transform.position,
                ExplosionRadius,
                UpForce
                );
            Destroy(gameObject, DestroyAfterSeconds);
            Destroy(pieces, DestroyAfterSeconds);
        }
    }


}
