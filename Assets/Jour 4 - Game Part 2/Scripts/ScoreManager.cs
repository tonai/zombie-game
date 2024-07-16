using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int scoreToWin = 100;
    public string winScene = "";
    public Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int points)
    {
        score += points;
        UpdateText();

        if (score > scoreToWin)
        {
            Debug.Log("You win");
            if (winScene != "") {
                SceneManager.LoadScene(winScene);
            }
        }
    }

    public void UpdateText()
    {
        if (textScore)
        {
            textScore.text = "" + score;
        }
    }
}
