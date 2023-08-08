using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerInputController playerInputController;

    // —корость движени€ вперед.
    [SerializeField] private float forwardMovementSpeed;
    // —корость горизонтального движени€.
    [SerializeField] private float horizontalMovementSpeed;
    // ћаксимальное значение горизонтального смещени€.
    [SerializeField] private float horizontalLimitValue;


    private float newPositionX;


    void FixedUpdate()
    {
        SetPlayerForwardMovement();
        SetPlayerHorizontalMovement();
    }

    // ”становка движени€ игрока вперед.
    private void SetPlayerForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);
    }

    // ”становка горизонтального движени€ игрока.
    private void SetPlayerHorizontalMovement()
    {
        newPositionX = transform.position.x + playerInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
