using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy = 2f;

    public int damageAmount = 1;
    public float speed = 50f;

    public List<string> tagsToHit;


    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }


    // Nota - Foi implementado com transform no lugar de rigidbody para otimizar processamento
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(var t in tagsToHit)
        {
            if(collision.transform.tag == t)
            {
                var damageable = collision.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    Vector3 dir = collision.transform.position - transform.position;
                    Debug.Log("Tiro bem sucedido!");
                    dir.y = 0;
                    // Passa, por exemplo, de (0, 0, 35) para (0, 0, 1)
                    dir = -dir.normalized;

                    damageable.Damage(damageAmount, dir);

                }

                break;
            }
        }

        Destroy(gameObject);
    }
}
