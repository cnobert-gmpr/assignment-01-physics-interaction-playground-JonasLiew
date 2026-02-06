using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Ball"))
        {
            GameObject ball = collider2D.gameObject;
            StartCoroutine(RespawnBall(ball));
        }
    }
    private IEnumerator RespawnBall(GameObject ball)
    {
        yield return new WaitForSeconds(2);
        Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
        ballRB.linearVelocity = Vector2.zero;
        ballRB.angularVelocity = 0;
        ball.transform.position = _respawnPoint.position;
    }
}
