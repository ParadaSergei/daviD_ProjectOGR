using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

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
        healthSlider.value = currentHealth;
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
