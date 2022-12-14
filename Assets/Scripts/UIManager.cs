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
    public PauseGame pauseGame;
    private void Start()
    {
        // scoreText = scoreGameObjectText.GetComponent<Text>();
        gmc = gameController.GetComponent<GameController>();
        _healthText = healthGm.GetComponent<TextMeshProUGUI>();
        _coinsText = coinsGm.GetComponent<TextMeshProUGUI>();
        _analyticsVariables = FindObjectOfType<AnalyticsVariables>();
        _playerController = FindObjectOfType<PlayerController>();
        pauseGame = FindObjectOfType<PauseGame>();
        
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
        if (_analyticsVariables.GetCoins() >= Constants.CONTINUE_COINS && GetReplayFlag() != true)
        {
            //print("Replay If");
            SetReplayFlag();
            _playerController.Restart();
        }
        else
        {
            //print("Replay Else");
            ResetReplayFlag();
            PauseGame.continueGame();
            pauseGame.showPause();
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
    }
    
    public void Continue(){
        print("Entered Continue");
        restartDialogue.SetActive(false);
        PauseGame.continueGame();
        pauseGame.showPause();
        _analyticsVariables.UpdateCoins(-(Constants.CONTINUE_COINS));
        _playerController.ToggleImmortal();
    }

    

}