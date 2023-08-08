using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerInputController playerInputController;

    // �������� �������� ������.
    [SerializeField] private float forwardMovementSpeed;
    // �������� ��������������� ��������.
    [SerializeField] private float horizontalMovementSpeed;
    // ������������ �������� ��������������� ��������.
    [SerializeField] private float horizontalLimitValue;


    private float newPositionX;


    void FixedUpdate()
    {
        SetPlayerForwardMovement();
        SetPlayerHorizontalMovement();
    }

    // ��������� �������� ������ ������.
    private void SetPlayerForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);
    }

    // ��������� ��������������� �������� ������.
    private void SetPlayerHorizontalMovement()
    {
        newPositionX = transform.position.x + playerInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
