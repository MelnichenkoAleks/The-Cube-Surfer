using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _player;

    // ���������� ����� ������� � �������.
    public Vector3 offset;

    // ��������, � ������� ������ ������� �� �������.
    public float smoothSpeed = 5f;

    void FixedUpdate()
    {
        FollowPlayer();
        Offset();
    }

    void FollowPlayer()
    {
        // ������� �������, � ������� ������ ������ ���������.
        Vector3 targetPosition = new Vector3(5, _player.position.y, _player.position.z);

        // ������� ���������������� ����� ������� �������� ������ � ������� ��������.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, _player.position.z + offset.z);
 
        transform.rotation = Quaternion.Euler(20f, -13f, 0);
    }

    private void Offset()
    {
        // ������� ��������������� ������� ������ �� ��� y � ����������� ������ ��������.
        float newY = Mathf.Lerp(transform.position.y, offset.y, Time.fixedDeltaTime * smoothSpeed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
