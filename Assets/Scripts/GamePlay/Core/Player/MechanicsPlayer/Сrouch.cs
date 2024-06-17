using UnityEngine;

public class Сrouch : MonoBehaviour
{
    private CharacterController _characterController;
    private float _crouchHeight;
    private float _currentHeight;
    private float _height;
    private bool _isCrouching;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _currentHeight = _characterController.height;
        _crouchHeight = _characterController.height / 2;
        _height = _currentHeight;
    }
    private void Update()
    {
        _characterController.height = _height;
    }
    public void Crouching()
    {
        _height = _crouchHeight;
    }
    public void Standing()
    {
        _height = _currentHeight;
    }
}
