using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private LayerMask aimLayer;

    private Camera mainCamera;
    private Animator animator;
    private PlayerController playerController;
    private Health health;

    private void Awake() {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        health = GetComponent<Health>();
    }

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if(health.GetIsDead()) { return; }
        if(GetComponent<Grenade>().GetIsThrowing()) { return; }

        AimTowardsMouse();

        Vector3 movement = new Vector3(playerController.horizontalMove, 0f, playerController.verticalMove);
        if(movement.magnitude > 0) {
            movement.Normalize();
            movement *= speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }

        // Animating
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);
        
        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }

    private void AimTowardsMouse() {
        if(PauseMenu.isGamePaused) { return; }
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimLayer)) {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f;
            direction.Normalize();
            transform.forward = direction;
        }
    }
}
