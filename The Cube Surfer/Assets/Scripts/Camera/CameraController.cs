using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _player;

    // –ассто€ние между камерой и игроком.
    public Vector3 offset;

    // —корость, с которой камера следует за игроком.
    public float smoothSpeed = 5f;

    void FixedUpdate()
    {
        FollowPlayer();
        Offset();
    }

    void FollowPlayer()
    {
        // –ассчет позиции, к которой камера должна двигатьс€.
        Vector3 targetPosition = new Vector3(5, _player.position.y, _player.position.z);

        // ѕлавное интерполирование между текущей позицией камеры и целевой позицией.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, _player.position.z + offset.z);
 
        transform.rotation = Quaternion.Euler(20f, -13f, 0);
    }

    private void Offset()
    {
        // ѕлавное корректирование позиции камеры по оси y в направлении нового смещени€.
        float newY = Mathf.Lerp(transform.position.y, offset.y, Time.fixedDeltaTime * smoothSpeed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
