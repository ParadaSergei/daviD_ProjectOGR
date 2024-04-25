using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsUI : MonoBehaviour
{
    private bool _isPause = false;
    [SerializeField] private GameObject pause;
    private Camera _camera;
    public void LoadScene(int i) => SceneManager.LoadScene(i);
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void ContinueScene()
    {
        Time.timeScale = 1.0f;
        pause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        _camera.transform.GetComponent<AudioListener>().enabled = true;
    }

    public void Exit() => Application.Quit();
    private void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        { Cursor.lockState = CursorLockMode.None; }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPause = !_isPause;
            if (_isPause)
            {
                _camera.transform.GetComponent<AudioListener>().enabled = false;
                Time.timeScale = 0.0f;
                pause.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else ContinueScene();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadScene(0);
            }
        }
    }
}
