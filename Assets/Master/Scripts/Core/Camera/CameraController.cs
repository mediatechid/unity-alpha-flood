using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float m_cameraSpeed = 0;
    [SerializeField] private BoxCollider2D m_boundary;
    [Space]
    [Header("Zoom:")]
    [SerializeField] private float m_camMinView = 10;
    [SerializeField] private float m_camMaxView = 20;
    [SerializeField] private float m_zoomSpeed = 0.2f;
    
    private Camera _camera;
    private BoxCollider2D _cameraBox;

    private float _translationX;
    private float _translationY;
    
    private float _bottomPivot;
    private float _topPivot;
    private float _leftPivot;
    private float _rightPivot;

    private Vector2 _inputDirection;
    private Vector3 _step;
    private Vector3 _destination;

    private float _zoomValue;

    private InputSystem.GameplayInputActions _characterInput;

    // Start is called before the first frame update
    void Start()
    {

        _camera = gameObject.GetComponent<Camera>();
        _cameraBox = _camera.GetComponent<BoxCollider2D>();

        _characterInput = GameplayInputManager.Instance.CharacterInput;

        _characterInput.CameraZoom.performed += context =>
        {
            var tempZoom = -context.ReadValue<float>();
            CameraZoom(tempZoom);
        };
        
        CalculateCameraPivot();
    }

    // Update is called once per frame
    void Update()
    {
        var camMovementInput = _characterInput.CameraLook;
        
        // input from keyboard (A or D; left arrow or right arrow)
        _inputDirection = camMovementInput.ReadValue<Vector2>().normalized;
            
        // mouse edge-scrolling
        var mouseX = Mouse.current.position.x.ReadValue();
        var mouseY = Mouse.current.position.y.ReadValue();
        if (mouseX > Screen.width - 10f)
        {
            _inputDirection.x += m_cameraSpeed * 2 * Time.deltaTime;
        }
        if (mouseX < 10f)
        {
            _inputDirection.x -= m_cameraSpeed * 2 * Time.deltaTime;
        }
        if (mouseY > Screen.height - 10f)
        {
            _inputDirection.y += m_cameraSpeed * 2 * Time.deltaTime;
        }
        if (mouseY < 10f)
        {
            _inputDirection.y -= m_cameraSpeed * 2 * Time.deltaTime;
        }

        _step = _inputDirection * (m_cameraSpeed * Time.deltaTime);

        _destination = transform.position + _step;

        _destination.x = Mathf.Clamp(_destination.x, _leftPivot, _rightPivot);
        _destination.y = Mathf.Clamp(_destination.y, _bottomPivot, _topPivot);

        transform.position = _destination;
    }

    private void CameraZoom(float zoomAxisValue)
    {
        var orthographicSize = _camera.orthographicSize;
        
        var finZoomAddition = (orthographicSize * zoomAxisValue * m_zoomSpeed);

        orthographicSize += finZoomAddition;

        orthographicSize = Mathf.Clamp(orthographicSize, m_camMinView, m_camMaxView);

        _camera.orthographicSize = orthographicSize;
    }
    
    private void CalculateCameraPivot()
    {
        var bounds = m_boundary.bounds;
        var size = _cameraBox.size;
        
        _bottomPivot = bounds.min.y + size.y / 2;
        _topPivot = bounds.max.y - size.y / 2;
        _leftPivot = bounds.min.x + size.x / 2;
        _rightPivot = bounds.max.x - size.x / 2;
    }
}
