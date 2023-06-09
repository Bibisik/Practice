using UnityEngine;
using System.Collections;
using UnityEngine.Playables;

public class StartTimeline : MonoBehaviour
{
    private GameObject player;
    private GameObject eventSystem;

    private PauseMenu pauseMenu;
    private PlayerController playerController;
    private PlayerAttack playerAttack;
    private PlayableDirector playableDirector;

    private BoxCollider2D boxCol;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        playerAttack = player.GetComponent<PlayerAttack>();

        eventSystem = GameObject.Find("EventSystem");
        pauseMenu = eventSystem.GetComponent<PauseMenu>();

        boxCol = GetComponent<BoxCollider2D>();
        playableDirector = GetComponent<PlayableDirector>();
    }

    //�������� ���������� �������
    public void NoMove()
    {
        pauseMenu.enabled = false;
        playerController.enabled = false;
        playerAttack.enabled = false;

    }
    //������ ����������
    public void Move()
    {
        pauseMenu.enabled = true;
        playerController.enabled = true;
        playerAttack.enabled = true;
        boxCol.enabled = false;

        StartCoroutine(inActivTimeLine());
    }

    IEnumerator inActivTimeLine()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playableDirector.Play();
        }
    }
}
