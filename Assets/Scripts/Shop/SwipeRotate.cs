using UnityEngine;
using UnityEngine;

public class SwipeRotate : MonoBehaviour
{
    public GameObject targetObject; // Объект для вращения
    public float rotationSpeed = 0.2f; // Скорость вращения
    public float inertiaDamping = 0.95f; // Коэффициент затухания инерции

    private bool isDragging = false;
    private float velocity = 0f; // Скорость вращения
    private float lastMouseX;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Начало свайпа
        {
            isDragging = true;
            lastMouseX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0)) // Завершение свайпа
        {
            if(isDragging)
                velocity /= 5f;
            isDragging = false;
        }

        if (isDragging)
        {
            float deltaX = Input.mousePosition.x - lastMouseX;
            velocity = -deltaX * rotationSpeed; // Обновляем скорость вращения
            targetObject.transform.Rotate(0f, velocity, 0f);
            lastMouseX = Input.mousePosition.x;
        }
        else
        {
            // Добавляем инерцию
            if (Mathf.Abs(velocity) > 0.01f) // Если скорость выше порога
            {
                targetObject.transform.Rotate(0f, velocity, 0f);
                if(velocity>0)
                    velocity -= inertiaDamping; // Плавное затухание
                if(velocity<0)
                    velocity += inertiaDamping; // Плавное затухание
            }
            else
            {
                velocity = 0f; // Останавливаем вращение при достижении порога
            }
        }
    }
}