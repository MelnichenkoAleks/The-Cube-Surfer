using UnityEngine;

public class CubeRaycastController : MonoBehaviour
{
    [SerializeField] private PlayerStackController playerStackController;

    // Направление луча для рейкаста (изначально назад).
    private Vector3 direction = Vector3.back;

    // Флаг, указывающий находится ли куб в стеке.
    private bool isStack = false;

    // Информация о пересечении луча с объектом.
    private RaycastHit hit;

    private void Start()
    {
        playerStackController = GameObject.FindObjectOfType<PlayerStackController>();
    }

    void FixedUpdate()
    {
        // Выполняем рейкаст из текущей позиции куба в заданном направлении.
        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if (!isStack)
            {
                // Добавляем куб в стек игрока и меняем направление.
                isStack = true;
                playerStackController.IncreaseNewBlock(gameObject);
                SetDirection();
            }

            if (hit.transform.name == "ObstacleCube")
            {
                // Убираем куб из стека игрока, так как встретили препятствие.
                playerStackController.DecreaseBlock(gameObject);
            }
        }
    }

    // Метод для установки направления луча вперед.
    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
