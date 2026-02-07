using System.Collections;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float _bumperforce = 150, _litDuration = 0.75f;
    [SerializeField] private Color _litColour = Color.yellow;
    private bool _isLit = false;
    private Color _originalColour;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColour = _spriteRenderer.color;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = Vector2.zero;
        if(collision.collider.CompareTag("Ball"))
        {
            if(collision.contactCount > 0)
            {
                ContactPoint2D contact = collision.GetContact(0);
                normal = contact.normal;
            }
            else if (normal == Vector2.zero)
            {
                Vector2 direction = (collision.rigidbody.position = (Vector2)transform.position).normalized;
                normal = direction;
            }
            Vector2 impulse = normal * _bumperforce;
            impulse *= -1;
            collision.rigidbody.AddForce(impulse, ForceMode2D.Impulse);
        }
        if(!_isLit)
        {
            StartCoroutine(LightUp());
        }
    }
    private IEnumerator LightUp()
    {
        _spriteRenderer.color = _litColour;
        _isLit = true;
        yield return new WaitForSeconds(_litDuration);
        _isLit = false;
        _spriteRenderer.color = _originalColour;

    }
}
