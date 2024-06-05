using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool isChangingSize = false; // ����, �����������, ���������� �� � ������ ������ ��������� �������
    private Vector3 targetScale; // ������� ������ ������� ����� ���������

    public float sizeChangeAmount = 1.0f; // ����������, �� ������� ���������� ������
    public float sizeChangeSpeed = 1.0f; // �������� ��������� �������

    private void OnCollisionEnter(Collision collision)
    {
        if (!isChangingSize)
        {
            isChangingSize = true; // ������������� ���� ��������� �������

            // ��������� ������� ������ �������
            targetScale = transform.localScale + (transform.localScale.magnitude > 1 ? -Vector3.one : Vector3.one) * sizeChangeAmount;

            // ��������� ������� ��������� �������
            StartCoroutine(SmoothChangeSize());
        }
    }

    private System.Collections.IEnumerator SmoothChangeSize()
    {
        Vector3 initialScale = transform.localScale;
        float t = 0f;

        // ������ �������� ������ �������
        while (t < 1.0f)
        {
            t += Time.deltaTime * sizeChangeSpeed;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        isChangingSize = false; // ���������� ���� ��������� �������
    }
}
