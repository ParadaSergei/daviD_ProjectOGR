using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator animator;

    [SerializeField] private AudioSource dieEnemyAudio;
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamade(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("dead", true);
        transform.GetComponent<Enemy>().enabled = false;
        transform.GetComponent<Patroler>().enabled = false;
        dieEnemyAudio.Play();
        Invoke("DestroyEnemy", 2);
    }
    private void DestroyEnemy()
    {
        Destroy(transform.gameObject);
    }
}
