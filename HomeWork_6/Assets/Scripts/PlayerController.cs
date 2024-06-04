using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float rotationSpeed = 0.5f;
    public float sprintSpeed = 5.0f;
    public float animaionBlendSpeed = 0.2f;
    public float jumpSpeed = 7.0f;
    public int countAttack = 4;

    CharacterController controller;
    Camera characterCamera;
    Animator characterAnimator;
    float rotationAngle = 0.0f;
    float targetAnimationSpeed = 0.0f;
    bool isSprint = false;

    float speedY = 0.0f;
    float gravity = -9.81f;
    bool isJumping = false;
    bool isDead = false;
    bool isSpawn = true;

    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }

    public Camera CharacterCamera { get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); } }

    public Animator CharacterAnimator { get { return characterAnimator = characterAnimator ?? GetComponent<Animator>(); } }

    public void Start()
    {
        CharacterAnimator.SetTrigger("Spawn");
    }

    public void Update()
    {
        if (isSpawn)
        {
            return;
        }

        if (isDead)
        {
            return;
        }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            CharacterAnimator.SetTrigger("Jump");
            speedY += jumpSpeed;
        }
        if (!Controller.isGrounded)
        {
            speedY += gravity * Time.deltaTime;
        }
        else if (speedY < 0.0f)
        {
            speedY = 0.0f;
        }

        CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);

        if (isJumping && speedY < 0.0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f, LayerMask.GetMask("Default")))
            {
                isJumping = false;
                CharacterAnimator.SetTrigger("Land");
            }
        }

        isSprint = Input.GetKey(KeyCode.LeftShift);
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        Vector3 rotateMovement = Quaternion.Euler(0.0f, CharacterCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
        Vector3 verticalMovement = Vector3.up * speedY;

        float currentSpeed = isSprint ? sprintSpeed : movementSpeed;
        Controller.Move((verticalMovement + rotateMovement * currentSpeed) * Time.deltaTime);

        if (rotateMovement.sqrMagnitude > 0.0f)
        {
            rotationAngle = Mathf.Atan2(rotateMovement.x, rotateMovement.z) * Mathf.Rad2Deg;
            targetAnimationSpeed = isSprint ? 1.0f : 0.5f;
        }
        else
        {
            targetAnimationSpeed = 0.0f;
        }

        CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animaionBlendSpeed));
        Quaternion currentRotation = Controller.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
        Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);

        Attack();
        Death();
    }

    public void Death()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isDead = true;
            CharacterAnimator.SetTrigger("Die");
        }
    }

    public void Attack()
    {
        if (Input.GetMouseButton(0) && !isJumping)
        {
            int indexAttack = Random.Range(0, countAttack);           
            CharacterAnimator.SetInteger("Index", indexAttack);
            CharacterAnimator.SetTrigger("Attack");
        }
    }

    public void spawnAnimationEnd()
    {
        isSpawn = false;
    }
}