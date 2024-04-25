using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDie : MonoBehaviour
{
    private float damage = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamade(damage);
        }
        if (other.transform.GetComponent<Enemy>())
        {
            other.transform.GetComponent<Enemy>().TakeDamade(((int)damage));
        }
    }
}
