using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Sensitivity")]
    public float Sensitivity;
    public Camera PlayerCamera;
    [SerializeField] private Transform _body;

    [Header("Clamp Rotation")]
    [SerializeField] private float _minRotation = -90;
    [SerializeField] private float _maxRotation = 90;

    private Vector3 _clampVerticalRotation;

    private void Start()
    {
        PlayerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        MouseRotation();
    }

    private void MouseRotation()
    {
        //Mouse Rotation
        float mouseHorizontal = Input.GetAxis("Mouse X") * Sensitivity;
        float mouseVertical = Input.GetAxis("Mouse Y") * -Sensitivity;

        _clampVerticalRotation.x += mouseVertical;
        _clampVerticalRotation.x = Mathf.Clamp(_clampVerticalRotation.x, _minRotation, _maxRotation);

        PlayerCamera.transform.Rotate(_clampVerticalRotation.x, 0f, 0f);
        PlayerCamera.transform.localEulerAngles = _clampVerticalRotation;

        //Body Rotation
        _body.Rotate(0f, mouseHorizontal, 0f);
    }

}