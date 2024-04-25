using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    private int startHealth;
    private Animator animator;
    [SerializeField] private GameObject allAudioPlayer;
    [SerializeField] private GameObject diePanel;
    [SerializeField] private Slider healthBar;

    [SerializeField] private AudioSource diePlayerAudio;
    [SerializeField] private AudioSource uronPlayerAudio;
    [SerializeField] private AudioSource healthPlayerAudio;



    private void Start()
    {
        animator = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            startHealth = PlayerPrefs.GetInt("health");
            currentHealth = startHealth;
        }
        else
        { 
            currentHealth = maxHealth;
        }
    }
    private void Update() => healthBar.value = Mathf.Lerp(healthBar.value, currentHealth, Time.deltaTime * 2);
    public void TakeDamade(float damage)
    {
        currentHealth -= damage;
        uronPlayerAudio.Play();
        if (currentHealth <= 0)Die();
    }
    public void TakeHealth(int health)
    {
        currentHealth += health;
        healthPlayerAudio.Play();
        if (currentHealth >= 100)currentHealth = 100;
    }


    private void Die()
    {
        GetComponent<PlayerController>().enabled = false;
        animator.SetBool("dead", true);
        allAudioPlayer.SetActive(false);
        diePlayerAudio.Play();
        healthPlayerAudio.Stop();
        diePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
