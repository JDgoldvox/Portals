using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private PlayerInputActions S_PlayerInputActions;
    public float mouseSensitivity;
    private float cameraVerticalRotation = 0f;
    private float cameraHorizontalRotation = 0f;
    public Transform forward;

    private Rigidbody rb;
    public float speed;

    InputAction move, look;

    void Start()
    {
        // Lock and Hide the Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        S_PlayerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
        move = S_PlayerInputActions.Player.Move;
        look = S_PlayerInputActions.Player.Look;
    }

    private void OnEnable()
    {
        move.Enable();
        look.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable() ;
    }

    private void Update()
    {
        OnMove();
        OnLook();
        OnRotate();
    }
    private void OnMove()
    {
        Vector2 direction = move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(-direction.x, 0.0f, -direction.y);
        rb.AddForce(movement * speed, ForceMode.Impulse);
    }

    private void OnLook()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalRotation += inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -65f, 65f);

        cameraHorizontalRotation += inputX;

        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        transform.Rotate(Vector3.up * cameraHorizontalRotation);    
    }

    void OnRotate() 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y - 180, Camera.main.transform.eulerAngles.z);
        }
    }
}
