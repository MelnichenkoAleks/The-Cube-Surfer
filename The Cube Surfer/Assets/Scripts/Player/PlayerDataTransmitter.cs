using UnityEngine;

public class PlayerDataTransmitter : MonoBehaviour
{
    [SerializeField] private PlayerInputController playerInputController;

    // ���������� �������� ��������������� ����� ������.
    public float GetHeroHorizontalValue()
    {
        return playerInputController.HorizontalValue;
    }
}
