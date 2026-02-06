using System.Collections;
using UnityEditor.Callbacks;
using UnityEngine;

public class FreezeZone : MonoBehaviour
{
    private Vector2 _initialBallVelocity;
    private bool _frozen;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        GameObject ball = collider2D.gameObject;
        Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
        _initialBallVelocity = ballRB.linearVelocity;

        if(collider2D.CompareTag("Ball") && !_frozen)
        {
            _frozen = true;
            ballRB.linearVelocity = Vector2.zero;
            StartCoroutine(FreezeBall(ballRB));
        }
    }
    private IEnumerator FreezeBall(Rigidbody2D ballRB)
    {
        ballRB.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(1f);
        ballRB.bodyType = RigidbodyType2D.Dynamic;
        ballRB.linearVelocity = _initialBallVelocity;
        yield return new WaitForSeconds(1f);
        _frozen = false;
    }
}
