using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Transform cameraTransform;
    public float playerSpeed;
    public PlayerController playerController;
    public PlayerControllerAndroid playerControllerAndroid;
    public PlayerAim playerAim;
    public PlayerLife playerLife;
    public float playerMaxY;
    public float playerMinY;
    public PlayerEffectStatus playerStatus;

    // Use this for initialization
    void Awake()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAbleToMove())
        {
            #if UNITY_EDITOR
                if (playerController.IsInputFire())
                {
                    playerAim.Shoot();
                }
            #elif UNITY_ANDROID
                if(playerControllerAndroid.IsInputFire())
                {
                    playerAim.Shoot();
                }
            #endif
        }
    }
    
    void FixedUpdate()
    {
        ConstraintPlayerMovement();
        if (IsAbleToMove())
        {
            #if UNITY_EDITOR
                Move(playerController.ReadInput());
                //ConstraintPlayerMovement();
            #elif UNITY_ANDROID
                MoveAndroid(playerControllerAndroid.ReadInput());
                //ConstraintPlayerMovement();
            #endif
        }
    }
    private bool IsAbleToMove() {
        return (playerLife.IsAlive() && !playerStatus.isStun);
    }

    void Move(Vector2 input)
    {
        Vector2 deltaVelocity = new Vector2(input.x * playerSpeed, input.y * playerSpeed);
        Vector2 destination = (Vector2)transform.position + deltaVelocity;
        //playerBody.MovePosition(ConstraintMovement(destination));
        playerBody.velocity = deltaVelocity;
    }

    void MoveAndroid(Vector2 input)
    {
        playerBody.MovePosition(ConstraintMovement(input));
        //Debug.Log("Rigidbody Pos" + playerBody.position);
    }

    void ConstraintPlayerMovement()
    {
        float MaxY = playerMaxY + cameraTransform.position.y;
        float MinY = playerMinY + cameraTransform.position.y;
        /*Debug.Log("Player pos = " + transform.position.y);
        Debug.Log("Max Y = " + MaxY);
        Debug.Log("Min Y = " + MinY);
        Debug.Log("Camera pos " + cameraTransform.position.y);*/
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, MinY, MaxY));
    }

    Vector2 ConstraintMovement(Vector2 input)
    {
        float MaxY = playerMaxY + cameraTransform.position.y;
        float MinY = playerMinY + cameraTransform.position.y;
        return new Vector2(input.x, Mathf.Clamp(input.y, MinY, MaxY));
    }
}

