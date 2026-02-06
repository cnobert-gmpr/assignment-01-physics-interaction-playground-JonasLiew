
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private float _seconds = 0;
    
    void Awake()
    {
        Debug.Log("DZ Workening");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Debug.Log("DZ Really workening biatch");
        }
    }
}
