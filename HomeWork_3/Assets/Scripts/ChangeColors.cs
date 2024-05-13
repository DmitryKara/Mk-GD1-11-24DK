using UnityEngine;
using UnityEngine.UI;

public class ChangeColors : MonoBehaviour
{
    public Button[] colorsButton;
    public Material[] materials;
    public MeshRenderer[] sparrows;

    void Start()
    {
        ChangeMaterial();
    }

    public void ChangeMaterial()
    {
        for (int i = 0; i < colorsButton.Length; i++)
        {
            int index = i;

            colorsButton[i].onClick.AddListener(() =>
            {
                for (int j = 0; j < sparrows.Length; j++)
                {
                    if (sparrows[j].gameObject.activeInHierarchy)
                    {
                        sparrows[j].material = materials[index];
                    }
                }
            });
        }
    }
}
