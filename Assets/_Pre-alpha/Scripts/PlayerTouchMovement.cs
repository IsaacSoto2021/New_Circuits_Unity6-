using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerTouchMovement : MonoBehaviour
{   //CHANGE BOTTOM MARGIN TO MOVE JOYSTICK
    [SerializeField] private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField] private FloatingJoystick Joystick;
    [SerializeField] private NavMeshAgent Player;
    [SerializeField] public PlayerShooting PlayerShooting;
    [SerializeField] public Animator PlayerAnimator;
    [SerializeField] private float animationSmoothTime = 0.1f;
    [SerializeField] private float aimingMovementMultiplier = 1f; // can move slower while aiming here
    private bool isAiming = false;


    [SerializeField] private float BottomMargin = 200;

    private Finger MovementFinger;
    private Vector2 MovementAmount;
    private Vector3 previousPosition;
    private float currentForwardVelocity;
    private float currentHorizontalVelocity;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleLoseFinger;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleLoseFinger;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }

    private void HandleFingerMove(Finger MovedFinger)
    {
        if (MovedFinger == MovementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = JoystickSize.x / 2f;
            ETouch.Touch currentTouch = MovedFinger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition, Joystick.RectTransform.anchoredPosition) > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition;
            }

            Joystick.Knob.anchoredPosition = knobPosition;
            MovementAmount = knobPosition / maxMovement;
        }
    }

    private void HandleLoseFinger(Finger LostFinger)
    {
        if (LostFinger == MovementFinger)
        {
            MovementFinger = null;
            Joystick.Knob.anchoredPosition = Vector2.zero;
            Joystick.gameObject.SetActive(false);
            MovementAmount = Vector2.zero;
        }
    }

    private void HandleFingerDown(Finger TouchedFinger)
    {
        if (MovementFinger == null)
        {
            MovementFinger = TouchedFinger;
            MovementAmount = Vector2.zero;
            Joystick.gameObject.SetActive(true);
            Joystick.RectTransform.sizeDelta = JoystickSize;
            Joystick.RectTransform.anchoredPosition = new Vector2(Screen.width / 2f, JoystickSize.y / 2f + BottomMargin);

        }
    }

    public void SetAimingMovement(bool aiming)
    {
        isAiming = aiming;
    }

    private void UpdateAnimator()
    {
        if (PlayerAnimator == null) return;

        // Calculate velocity 
        Vector3 currentPosition = transform.position;
        Vector3 velocity = (currentPosition - previousPosition) / Time.deltaTime;
        previousPosition = currentPosition;

        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        float movementMultiplier = isAiming ? aimingMovementMultiplier : 1f;

        float targetForwardVelocity = (localVelocity.z / Player.speed) * movementMultiplier;
        float targetHorizontalVelocity = (localVelocity.x / Player.speed) * movementMultiplier;

        currentForwardVelocity = Mathf.Lerp(currentForwardVelocity, targetForwardVelocity,
                                          Time.deltaTime / animationSmoothTime);

        currentHorizontalVelocity = Mathf.Lerp(currentHorizontalVelocity, targetHorizontalVelocity,
                                             Time.deltaTime / animationSmoothTime);

        PlayerAnimator.SetFloat("Forward/Back", currentForwardVelocity);
        PlayerAnimator.SetFloat("Left/Right", currentHorizontalVelocity);
    }

    private void Update()
    {
        UpdateAnimator();
    }
    private void FixedUpdate()
    {
        Vector3 scaledMovement = Player.speed * Time.deltaTime * new Vector3(MovementAmount.x, 0, MovementAmount.y);

        if (isAiming)
        {
            scaledMovement *= aimingMovementMultiplier;
        }

        if (PlayerShooting._shouldLookAtEnemy == false)
        {
            Player.transform.LookAt(Player.transform.position + scaledMovement, Vector3.up);
        }
        else if (PlayerShooting.target == null || !PlayerShooting.IsTargetVisible())
            Player.transform.LookAt(Player.transform.position + scaledMovement, Vector3.up);

        Player.Move(scaledMovement);
    }
}
