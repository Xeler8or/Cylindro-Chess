using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    public GameObject gameController;
    private GameController gmc;
    // private UnityEngine.UI.Text scoreText;
    public TextMeshProUGUI scoreText;
    public GameObject healthGm;
    public GameObject coinsGm;
    private TextMeshProUGUI _healthText;
    private TextMeshProUGUI _healthText_old;
    private TextMeshProUGUI _coinsText;
    private AnalyticsVariables _analyticsVariables;
    private PlayerController _playerController;
    public GameObject buttonContinue;
    public bool replayFlag = false;
    public GameObject restartDialogue;
    private void Start()
    {
        // scoreText = scoreGameObjectText.GetComponent<Text>();
        gmc = gameController.GetComponent<GameController>();
        _healthText = healthGm.GetComponent<TextMeshProUGUI>();
        _coinsText = coinsGm.GetComponent<TextMeshProUGUI>();
        _analyticsVariables = FindObjectOfType<AnalyticsVariables>();
        _playerController = FindObjectOfType<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = gmc.GetScore().ToString();
        _healthText.text = _analyticsVariables.GetHealth().ToString();
        _coinsText.text = _analyticsVariables.GetCoins().ToString();
        if (_analyticsVariables.GetCoins() >= Constants.CONTINUE_COINS)
        {
            buttonContinue.SetActive(true);
        }
        else
        {
            buttonContinue.SetActive(false);
        }
            
    }

    private void SetReplayFlag()
    {
        replayFlag = true;
    }

    public bool GetReplayFlag()
    {
        return replayFlag;
    }
    
    public void ResetReplayFlag()
    {
        replayFlag = false;
    }

    public void Replay(){
        if (_analyticsVariables.GetCoins() >= Constants.CONTINUE_COINS && replayFlag != true)
        {
            //print("Replay If");
            SetReplayFlag();
            _playerController.Restart();
        }
        else
        {
            //print("Replay Else");
            ResetReplayFlag();
            Time.timeScale = 1;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
    }
    
    public void Continue(){
        Time.timeScale = 1; 
        restartDialogue.SetActive(false);
        _analyticsVariables.UpdateCoins(-(Constants.CONTINUE_COINS));
        _playerController.ToggleImmortal();
    }

    

}