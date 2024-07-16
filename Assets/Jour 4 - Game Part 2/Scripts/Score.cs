using UnityEngine;

public class Score : MonoBehaviour
{
    public int points = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        GameObject sm = GameObject.Find("ScoreManager");
        if (sm)
        {
            ScoreManager scoreManager = sm.GetComponent<ScoreManager>();
            if (scoreManager)
            {
                scoreManager.addScore(points);
            }
        }
    }
}
