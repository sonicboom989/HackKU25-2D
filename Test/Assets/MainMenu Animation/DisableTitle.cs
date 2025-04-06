using UnityEngine;

public class DisableAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DisableAfterAnimation());
    }

    System.Collections.IEnumerator DisableAfterAnimation()
    {
        // Wait until the current animation finishes (adjust 1.3f if needed)
        yield return new WaitForSeconds(5.3f);
        animator.enabled = false;
    }
}
