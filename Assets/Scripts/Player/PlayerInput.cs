using Player;
using UnityEngine;

public partial class PlayerInput : MonoBehaviour
{
    #region Serialized Fields

    [Header("Components")]
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private PlayerAnimation playerAnimation;

    #endregion

    private InputActions.PlayerActions actions;

    #region Event Functions

    private void Awake()
    {
        actions = new InputActions().Player;
    }

    private void Update()
    {
        if (isDashing)
        {
            DashPlayer();
        }
        else
        {
            MovePlayer();
        }

        MoveCamera();
    }

    private void LateUpdate()
    {
        UpdateCamera();
    }

    private void OnEnable()
    {
        actions.Enable();
        actions.CameraZoom.performed += OnCameraZoomChange;
        actions.Jump.performed += OnJump;
        actions.Dash.performed += OnDash;
    }

    private void OnDisable()
    {
        actions.Disable();
        actions.CameraZoom.performed -= OnCameraZoomChange;
        actions.Jump.performed -= OnJump;
        actions.Dash.performed -= OnDash;
    }

    #endregion
}
