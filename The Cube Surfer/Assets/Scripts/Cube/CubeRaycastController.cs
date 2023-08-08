using UnityEngine;

public class CubeRaycastController : MonoBehaviour
{
    [SerializeField] private PlayerStackController playerStackController;

    // ����������� ���� ��� �������� (���������� �����).
    private Vector3 direction = Vector3.back;

    // ����, ����������� ��������� �� ��� � �����.
    private bool isStack = false;

    // ���������� � ����������� ���� � ��������.
    private RaycastHit hit;

    private void Start()
    {
        playerStackController = GameObject.FindObjectOfType<PlayerStackController>();
    }

    void FixedUpdate()
    {
        // ��������� ������� �� ������� ������� ���� � �������� �����������.
        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if (!isStack)
            {
                // ��������� ��� � ���� ������ � ������ �����������.
                isStack = true;
                playerStackController.IncreaseNewBlock(gameObject);
                SetDirection();
            }

            if (hit.transform.name == "ObstacleCube")
            {
                // ������� ��� �� ����� ������, ��� ��� ��������� �����������.
                playerStackController.DecreaseBlock(gameObject);
            }
        }
    }

    // ����� ��� ��������� ����������� ���� ������.
    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
