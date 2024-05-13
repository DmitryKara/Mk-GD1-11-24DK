using UnityEngine;
using UnityEngine.UI;

public class ButtonCamera : MonoBehaviour
{
    public string tag_object;
    public float distance;
    public Button[] buttons;
    public Transform additionalCamera;

    private GameObject sparrow;

    void Start()
    {
        distance = 15.0f;
        sparrow = GameObject.FindGameObjectWithTag(tag_object);

        additionalCamera.position = new Vector3(0.0f, 0.0f, -distance);
        additionalCamera.rotation = Quaternion.LookRotation(sparrow.transform.position);
        additionalCamera.SetParent(sparrow.transform);

        ChangeCamera();
    }

    public void ChangeCamera()
    {
        buttons[0].onClick.AddListener(() => ChangeCameraPosition(new Vector3(0.0f, distance, 0.0f)));
        buttons[1].onClick.AddListener(() => ChangeCameraPosition(new Vector3(0.0f, -distance, 0.0f)));
        buttons[2].onClick.AddListener(() => ChangeCameraPosition(new Vector3(0.0f, 0.0f, -distance)));
        buttons[3].onClick.AddListener(() => ChangeCameraPosition(new Vector3(distance, 0.0f, 0.0f)));
    }

    public void ChangeCameraPosition(Vector3 position)
    {
        additionalCamera.position = position;
        additionalCamera.transform.LookAt(sparrow.transform);
    }
}
