using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] projectilePrefabs;
    public Transform spawnPoint;

    private int currentProjectileIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefabs == null || projectilePrefabs.Length == 0)
            return;

        GameObject projectilePrefab = projectilePrefabs[currentProjectileIndex];
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

        if (projectile != null)
        {
            Vector3 direction = spawnPoint.forward;
            Projectils projScript = projectile.GetComponent<Projectils>();

            if (projScript != null)
            {
                projScript.Launch(direction);
            }
        }
    }

    public void SetProjectileType(int index)
    {
        if (index >= 0 && index < projectilePrefabs.Length)
        {
            currentProjectileIndex = index;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ProjectilsTypeTrigger trigger = other.GetComponent<ProjectilsTypeTrigger>();

        if (trigger != null)
        {
            SetProjectileType(trigger.projectilTypeIndex);
        }
    }
}
