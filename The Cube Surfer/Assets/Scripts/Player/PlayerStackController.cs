using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    // Список блоков в стеке игрока.
    public List<GameObject> blockList = new List<GameObject>();
    // Последний объект блока в стеке.
    private GameObject lastBlockObject;


    private void Start()
    {
        UpdateLastBlockObject();
    }

    // Увеличение стека игрока на новый блок.
    public void IncreaseNewBlock(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x, lastBlockObject.transform.position.y - 2f, lastBlockObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);

        UpdateLastBlockObject();
    }

    // Уменьшение стека игрока на один блок.
    public void DecreaseBlock(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        blockList.Remove(_gameObject);
        UpdateLastBlockObject();
    }

    // Обновление последнего объекта блока в стеке.
    public void UpdateLastBlockObject()
    {
        lastBlockObject = blockList[blockList.Count - 1];
    }
}
