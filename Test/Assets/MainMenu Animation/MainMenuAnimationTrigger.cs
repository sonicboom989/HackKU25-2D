using UnityEngine;

public class MainMenuAnimationTrigger : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component
        animator.SetTrigger("PlayAnimation");  // Set the trigger for animation
    }
}
