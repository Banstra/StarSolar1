using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking") | animator.GetBool("isWalkingBack");
        bool Moving = Input.GetKey("s") | Input.GetKey("d");
        bool MovingBack = Input.GetKey("a") | Input.GetKey("w");
        if (!isWalking && Moving)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !Moving)
        {
            animator.SetBool("isWalking", false);
        }
        if (!isWalking && MovingBack)
        {
            animator.SetBool("isWalkingBack", true);
        }

        if (isWalking && !MovingBack)
        {
            animator.SetBool("isWalkingBack", false);
        }
    }
}
