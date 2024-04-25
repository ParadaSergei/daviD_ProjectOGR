using UnityEngine;
using UnityEngine.SceneManagement;

public class LastDoor : MonoBehaviour
{
    [SerializeField] private GameObject openDoorUI;
    public int numberScene;
    private bool isLoadScene = false;
    private int healthPlayerSave;
    private void Update()
    {
        if (isLoadScene)
        {
            SaveHealth();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            healthPlayerSave = ((int)collision.transform.GetComponent<PlayerHealth>().currentHealth);
            openDoorUI.SetActive(true);
            isLoadScene = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            openDoorUI.SetActive(false);
            isLoadScene = true;
        }
    }
    private void SaveHealth()
    {
        PlayerPrefs.SetInt("health", healthPlayerSave);
        if (Input.GetKey(KeyCode.E))
        {
            Invoke("LoadFinishScene", 1f);
        }
    }
    public void LoadFinishScene()=>SceneManager.LoadScene(numberScene);
}
