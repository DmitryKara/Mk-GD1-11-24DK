using UnityEngine;
using UnityEngine.SceneManagement;

public class BugDeath : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (collision.contacts[0].normal.y > 0.1f && otherObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(otherObject);
        }

        if (collision.contacts[0].normal.y <= 0.1f && otherObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
