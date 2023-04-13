using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text score;
    public static int enemys;

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = enemys.ToString();
    }
}
