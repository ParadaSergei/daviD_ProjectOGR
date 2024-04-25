using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lezzing : MonoBehaviour
{
   public int damage = 20;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamade(damage);
        }
    }
}
