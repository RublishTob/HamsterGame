using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]

public class PlayerViewDetect: MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Transform _targetOfCamera;
    [SerializeField] private float _radiousCheckGround;
    [SerializeField] private LayerMask _layerCheckGround;
    [SerializeField] private LayerMask _layerCheckStairs;
    private CharacterController _characterController;

    public bool IsOnGround { get; private set; }
    public bool IsStairs { get; private set; }
    public Vector3 NormalOfVector { get; private set; }
    public bool IsCheckGround { get; private set; }
    public Transform TargetOfCamera { get => _targetOfCamera;}

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        IsOnGround = _characterController.isGrounded;
        IsOnGround = CheckGroundSphere(_radiousCheckGround, _groundChecker.position, _layerCheckGround);
        CheckStairRay();
    }
    private bool CheckGroundSphere(float _radious, Vector3 position, LayerMask layer)
    {
        bool result = Physics.CheckSphere(position, _radious, layer);
        return result;
    }
    private void CheckStairRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.4f, _layerCheckStairs))
        {
            NormalOfVector = hit.normal;
            IsCheckGround = false;
            IsStairs = true;
        }
        else
        {
            IsStairs = false;
            IsCheckGround = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundChecker.position, _radiousCheckGround);
    }
}
