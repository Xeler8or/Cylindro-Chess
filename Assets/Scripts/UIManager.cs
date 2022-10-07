using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject gameController;
    private GameController gmc;
    // private UnityEngine.UI.Text scoreText;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // scoreText = scoreGameObjectText.GetComponent<Text>();
        gmc = gameController.GetComponent<GameController>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = gmc.GetScore().ToString();
    }

    public void Replay(){
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}