using UnityEngine;

public class PlayerDataTransmitter : MonoBehaviour
{
    [SerializeField] private PlayerInputController playerInputController;

    // Возвращает значение горизонтального ввода игрока.
    public float GetHeroHorizontalValue()
    {
        return playerInputController.HorizontalValue;
    }
}
