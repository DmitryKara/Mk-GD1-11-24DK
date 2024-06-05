using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;

    void Start()
    {
        // Устанавливаем случайное направление и скорость для движения
        direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        speed = 3.0f;

        // Добавляем Rigidbody, если он отсутствует
        if (!GetComponent<Rigidbody>())
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true; // Делаем Rigidbody кинематическим, чтобы избежать влияния физических сил
        }

        // Устанавливаем слой, чтобы объект не сталкивался с другими объектами
        gameObject.layer = LayerMask.NameToLayer("NoCollision");
    }

    void Update()
    {
        // Перемещаем объект в случайном направлении с заданной скоростью
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, чтобы столкновение было не с объектом, имеющим Rigidbody
        if (collision.gameObject.GetComponent<Rigidbody>() == null)
        {
            // Изменяем направление при столкновении
            direction = Vector3.Reflect(direction, collision.contacts[0].normal);
        }
    }
}
