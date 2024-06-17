using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgroundGroups;
    public float[] parallaxScales;
    public float backgroundSize;
    public Transform player;

    private bool movingRight = true;

    void Update()
    {
        float direction = movingRight ? -1 : 1;

        for (int i = 0; i < backgroundGroups.Length; i++)
        {
            for (int j = 0; j < backgroundGroups[i].childCount; j++)
            {
                Transform background = backgroundGroups[i].GetChild(j);
                float parallax = parallaxScales[i] * direction * Time.deltaTime;
                background.position += new Vector3(parallax, 0, 0);

                if (direction > 0 && background.position.x > player.position.x + backgroundSize)
                {
                    background.position = new Vector3(background.position.x - backgroundGroups[i].childCount * backgroundSize, background.position.y, background.position.z);
                }
                else if (direction < 0 && background.position.x < player.position.x - backgroundSize)
                {
                    background.position = new Vector3(background.position.x + backgroundGroups[i].childCount * backgroundSize, background.position.y, background.position.z);
                }
            }
        }
    }

    public void ChangeDirection()
    {
        movingRight = !movingRight;
    }
}
