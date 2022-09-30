using Unity.VisualScripting;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Constants.Pieaces piece;
    public Constants.Color color;
    private Constants.Color _prevColor;
    public Material whiteMat;
    public Material blackMat;
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
        if (_prevColor != color)
        {
            _renderer.material = ToggleMaterial(color);
            color = _prevColor;
        }
    }

    private void Start()
    {
        _renderer = gameObject.GetComponent<MeshRenderer>();
        _player = FindObjectOfType<PlayerController>();
        _prevColor = color;
    }

    private void Update()
    {
        if (_player.piece == Constants.Pieaces.King)
        {
            ChangeMaterial();
        }
        else
        {
            RevertMaterial();
        }
    }
}