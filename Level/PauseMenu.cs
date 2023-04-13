using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Tooltip("Панель паузы")]
    [SerializeField] private GameObject pauseMenu;
    [Tooltip("Объект игрок")]
    [SerializeField] private GameObject keyPanel;

    [Space]
    [Tooltip("Объект игрок")]
    [SerializeField] private GameObject player;

    private PlayerController playerController;
    private PlayerAttack playerAttack;

    private bool keyPanelPressed;

    void Awake()
    {
        playerAttack = player.GetComponent<PlayerAttack>();
        playerController = player.GetComponent<PlayerController>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !keyPanelPressed)
        {
            Pause();
        }
        
    }

    public void Pause()
    {
        playerController.enabled = false;
        playerAttack.enabled = false;

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        keyPanelPressed = true;

    }

    public void ResumeButton()
    {
        playerController.enabled = true;
        playerAttack.enabled = true;

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        keyPanelPressed = false;
    }

    public void RestartGame()
    {
        Elevator.stopElevator = false;

        ScoreCounter.enemys = 0;
        DataContainer.checkPointIndex = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void KeyPanelGame()
    {
        keyPanel.SetActive(true);
        pauseMenu.SetActive(false);
        keyPanelPressed = true;
    }
   
}
