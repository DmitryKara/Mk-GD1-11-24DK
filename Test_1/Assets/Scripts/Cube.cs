using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool isChangingSize = false; // Флаг, указывающий, происходит ли в данный момент изменение размера
    private Vector3 targetScale; // Целевой размер объекта после изменения

    public float sizeChangeAmount = 1.0f; // Количество, на которое изменяется размер
    public float sizeChangeSpeed = 1.0f; // Скорость изменения размера

    private void OnCollisionEnter(Collision collision)
    {
        if (!isChangingSize)
        {
            isChangingSize = true; // Устанавливаем флаг изменения размера

            // Вычисляем целевой размер объекта
            targetScale = transform.localScale + (transform.localScale.magnitude > 1 ? -Vector3.one : Vector3.one) * sizeChangeAmount;

            // Запускаем плавное изменение размера
            StartCoroutine(SmoothChangeSize());
        }
    }

    private System.Collections.IEnumerator SmoothChangeSize()
    {
        Vector3 initialScale = transform.localScale;
        float t = 0f;

        // Плавно изменяем размер объекта
        while (t < 1.0f)
        {
            t += Time.deltaTime * sizeChangeSpeed;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        isChangingSize = false; // Сбрасываем флаг изменения размера
    }
}
