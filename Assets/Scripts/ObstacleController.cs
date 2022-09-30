using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Constants.Pieaces piece;
    public Constants.Color color;
    public Material whiteMat;
    public Material blackMat;
    private GameController _gameController;
    private MeshRenderer _renderer;
    private PlayerController _player;


    private Constants.Color ToggleColor(Constants.Color c)
    {
        return c == Constants.Color.Black ? Constants.Color.White : Constants.Color.Black;
    }

    private Material ToggleMaterial(Constants.Color c)
    {
        return c == Constants.Color.Black ? whiteMat : blackMat;
    }
    private void ChangeMaterial()
    {
        if (_player.color == color) return;
        _renderer.material = ToggleMaterial(color);
        color = ToggleColor(color);
    }
    
    private void RevertMaterial()
    {
        if (_player.color != color) return;
        _renderer.material = ToggleMaterial(color);
        color = ToggleColor(color);
    }

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _renderer = gameObject.GetComponent<MeshRenderer>();
        _player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (_player.piece == Constants.Pieaces.King)
        {
            ChangeMaterial();
        }
        else
        {
            
        }
    }
}