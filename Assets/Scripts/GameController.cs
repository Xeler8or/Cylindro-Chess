using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void SetScore(int score)
    {
        score = this.score;
    }

    public int GetScore()
    {
        return score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Replay(){
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
