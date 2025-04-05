    using UnityEngine;

public class dumbell : MonoBehaviour
{
    public class Dumbbell : MonoBehaviour
    {
        public float lifetime = 3f;

        void Start()
        {
            Destroy(gameObject, lifetime);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            // Example: hit enemy or wall
            Debug.Log("Dumbbell hit " + collision.gameObject.name);
        }
    }
}