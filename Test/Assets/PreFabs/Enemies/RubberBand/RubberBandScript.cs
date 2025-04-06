using UnityEngine;

public class RubberBandEnemy : MonoBehaviour
{
    public Sprite[] colorVariants; // Optional, for visual reference
    public RuntimeAnimatorController[] animControllers; // Assign matching Animator Controllers

    void Start()
    {
        int randomIndex = Random.Range(0, animControllers.Length);

        // Set the animator controller based on random index
        Animator animator = GetComponent<Animator>();
        if (animator != null && animControllers.Length > 0)
        {
            animator.runtimeAnimatorController = animControllers[randomIndex];
        }

        // Also change sprite visually if you want static variation too 
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && colorVariants.Length > 0)
        {
            sr.sprite = colorVariants[randomIndex];
        }
    }
}
