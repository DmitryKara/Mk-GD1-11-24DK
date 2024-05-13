using UnityEngine;
using UnityEngine.UI;

public class ChangeSparrows : MonoBehaviour
{
    public GameObject[] sparrows;
    public Button left;
    public Button right;

    private int number;

    void Start()
    {
        number = 0;
        for (int i = 0; i < sparrows.Length; i++)
        {
            sparrows[i].SetActive(false);
        }

        sparrows[number].SetActive(true);

        right.onClick.AddListener(() => ChangeSparrow(1));
        left.onClick.AddListener(() => ChangeSparrow(-1));
    }

    void ChangeSparrow(int direction)
    {
        number = (number + direction + sparrows.Length) % sparrows.Length;
        foreach (GameObject sparrow in sparrows)
        {
            sparrow.SetActive(false);
        }
        sparrows[number].SetActive(true);
    }
}
