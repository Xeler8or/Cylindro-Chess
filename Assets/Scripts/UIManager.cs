using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject gameController;
    private GameController gmc;
    // private UnityEngine.UI.Text scoreText;
    public TextMeshProUGUI scoreText;
    public GameObject scoreGameObjectText;

    private void Start()
    {
        // scoreText = scoreGameObjectText.GetComponent<Text>();
        gmc = gameController.GetComponent<GameController>();
    }
    // Update is called once per frame
    void Update()
    {
       
        scoreText.text = gmc.GetScore().ToString();
        //Debug.Log(player.position.z);
    }
}