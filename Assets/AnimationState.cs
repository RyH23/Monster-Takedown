using UnityEngine;

public class AnimationState : MonoBehaviour
{

    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    int VelocityHash;

   // int isWalkingHash;
   // int isRunningHash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        animator = GetComponent<Animator>();

        VelocityHash = Animator.StringToHash("Velocity");
        // isWalkingHash = Animator.StringToHash("isWalking");
        //isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
 
        if (forwardPressed)
        {
            velocity += Time.deltaTime * acceleration;
        }

        animator.SetFloat(VelocityHash, velocity);
        // bool isRunning = animator.GetBool(isRunningHash);
        // bool isWalking = animator.GetBool(isWalkingHash);

        //if (!isWalking && forwardPressed)
        // {
        //    animator.SetBool(isWalkingHash, true);
        // }

        //  if (!forwardPressed && isWalking)
        //  {
        //      animator.SetBool(isWalkingHash, false);
        //  }

        //  if (forwardPressed && runPressed)
        //  {
        //     animator.SetBool(isRunningHash, true);
        //   }

        //    if ( isRunning && (!forwardPressed || !runPressed))
        //  {
        //       animator.SetBool(isRunningHash, false);
        //  }
    }
}
