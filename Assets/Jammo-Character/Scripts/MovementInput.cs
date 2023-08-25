using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour
{

    [SerializeField] float _speed;
    [Space]

    private Vector3 desiredMoveDirection;
    [SerializeField] bool blockRotationPlayer;
    [SerializeField] float desiredRotationSpeed = 0.1f;
    [SerializeField] Animator anim;
    [SerializeField] float Speed;
    [SerializeField] float allowPlayerRotation = 0.1f;
    [SerializeField] Transform _cam;
    [SerializeField] Rigidbody _body;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    [SerializeField] float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    [SerializeField] float VerticalAnimTime = 0.2f;
    [Range(0, 1f)]
    [SerializeField] float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    [SerializeField] float StopAnimTime = 0.15f;

    private float verticalVel;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        InputMagnitude();
    }

    private void InputMagnitude()
    {
        //Calculate Input Vectors
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        Speed = new Vector2(inputX, inputZ).sqrMagnitude;

        //Physically move player

        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
        }
    }

    private void PlayerMoveAndRotation()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        var forward = _cam.transform.forward;
        var right = _cam.transform.right;

        desiredMoveDirection = (forward * inputZ) + (right * inputX);

        if (blockRotationPlayer) return;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        _body.velocity = desiredMoveDirection * _speed;
    }


}
