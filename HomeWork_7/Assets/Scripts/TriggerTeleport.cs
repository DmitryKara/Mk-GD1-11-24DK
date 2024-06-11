using UnityEngine;

public class TriggerTeleport : MonoBehaviour
{
    public Transform targetTrigger;

    void OnTriggerEnter(Collider other)
    {
        CharacterController characterController = other.GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false;

            characterController.transform.position = targetTrigger.position;

            characterController.enabled = true;
        }
    }
}
