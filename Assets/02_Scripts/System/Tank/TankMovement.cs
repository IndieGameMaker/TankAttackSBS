using TankAttack;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private TankData _tankData;
    private InputManager _inputManager;

    private float h, v;

    private void OnEnable()
    {
        if (_inputManager != null)
        {
            _inputManager.OnMoveInput += Move;
        }
    }

    private void OnDisable()
    {
        if (_inputManager != null)
        {
            _inputManager.OnMoveInput -= Move;
        }
    }
    
    public void Init(Tank tank)
    {
        _tankData = tank.TankData;
        _inputManager = tank.Input;
        _inputManager.OnMoveInput += Move;
    }

    private void Move(Vector2 moveInput)
    {
        h = moveInput.x;
        v = moveInput.y;
        
        Debug.Log($"h={h}, v={v}");
    }
}
