using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PortalEnter : MonoBehaviour
{
    [SerializeField] private GameObject _portalExit;
    public bool _teleported = true;
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Ball") && !_teleported)
        {
            GameObject ball = collider2D.gameObject;
            ball.transform.position = _portalExit.transform.position;
            StartCoroutine(TeleportBall());
        }
    }
    private IEnumerator TeleportBall()
    {
        PortalEnter _portalScript = _portalExit.GetComponent<PortalEnter>();
        _portalScript._teleported = true;
        yield return new WaitForSeconds(0.5f);;
        _portalScript._teleported = false;
    }
}
