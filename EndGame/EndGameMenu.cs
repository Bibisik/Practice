using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private Text scorePoints;

    private int scoreEnemys;

    void Start()
    {
        scoreEnemys = ScoreCounter.enemys;
        scorePoints.text = scoreEnemys.ToString(); 
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGameButton()
    {
        Elevator.stopElevator = false;

        ScoreCounter.enemys = 0;
        DataContainer.checkPointIndex = 0;

        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
