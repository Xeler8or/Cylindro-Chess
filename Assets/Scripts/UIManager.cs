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
    public GameObject health;
    private TextMeshProUGUI _healthText;
    private AnalyticsVariables _analyticsVariables;

    private void Start()
    {
        // scoreText = scoreGameObjectText.GetComponent<Text>();
        gmc = gameController.GetComponent<GameController>();
        _healthText = health.GetComponent<TextMeshProUGUI>();
        _analyticsVariables = FindObjectOfType<AnalyticsVariables>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = gmc.GetScore().ToString();
        _healthText.text = _analyticsVariables.GetHealth().ToString();
    }

    public void Replay(){
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}