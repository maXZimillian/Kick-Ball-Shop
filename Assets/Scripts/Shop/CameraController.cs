using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform[] characters; // Массив позиций персонажей
    public float moveSpeed = 5f; // Скорость перемещения камеры

    private int currentIndex = 0; // Индекс текущего персонажа
    private bool isMoving = false; // Флаг движения

    public void MoveTo(int id)
    {
        if (id >= 0 && id < characters.Length && !isMoving) 
        {
            currentIndex = id;
            StartCoroutine(MoveToPosition(characters[currentIndex].position));
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        float duration = Vector3.Distance(startPosition, targetPosition) / moveSpeed; // Время перемещения

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Точная фиксация позиции
        isMoving = false;
    }
}