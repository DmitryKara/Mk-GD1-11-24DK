using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;

    void Start()
    {
        // ������������� ��������� ����������� � �������� ��� ��������
        direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        speed = 3.0f;

        // ��������� Rigidbody, ���� �� �����������
        if (!GetComponent<Rigidbody>())
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true; // ������ Rigidbody ��������������, ����� �������� ������� ���������� ���
        }

        // ������������� ����, ����� ������ �� ����������� � ������� ���������
        gameObject.layer = LayerMask.NameToLayer("NoCollision");
    }

    void Update()
    {
        // ���������� ������ � ��������� ����������� � �������� ���������
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���������, ����� ������������ ���� �� � ��������, ������� Rigidbody
        if (collision.gameObject.GetComponent<Rigidbody>() == null)
        {
            // �������� ����������� ��� ������������
            direction = Vector3.Reflect(direction, collision.contacts[0].normal);
        }
    }
}
