using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private PlayerInputActions S_PlayerInputActions;
    public float mouseSensitivity;
    public Transform forward;

    private Rigidbody rb;
    public float speed;

    InputAction move, look;
    private void Awake()
    {
        S_PlayerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
        move = S_PlayerInputActions.Player.Move;
    }

    private void OnEnable()
    {
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        OnMove();
        OnRotate();
    }
    private void OnMove()
    {
        Vector2 direction = move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(-direction.x, 0.0f, -direction.y);
        rb.AddForce(movement * speed, ForceMode.Impulse);
    }

    void OnRotate() 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y - 180, Camera.main.transform.eulerAngles.z);
        }
    }
}
