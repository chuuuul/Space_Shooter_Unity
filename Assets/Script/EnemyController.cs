using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Vector2 startWait;
    public Vector2 nextDelay;
    public Vector2 nextWait;
    public float width;
    public float smoothing;
    public Boundary boundary;
    public float tilt;

    private float currentSpeed;
    private Rigidbody rb;
    private float targetPositionX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(CalcTargetX() );
    }

    IEnumerator CalcTargetX()
    {
        yield return new WaitForSeconds (Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetPositionX = -1 * Mathf.Sign(transform.position.x) * Random.Range(0, width) ;
            yield return new WaitForSeconds(Random.Range(nextDelay.x, nextDelay.y));
            targetPositionX = 0;
            yield return new WaitForSeconds(Random.Range(nextWait.x, nextWait.y));
        }
    }

    void FixedUpdate()
    {
        float moveDistance =  Mathf.MoveTowards(rb.velocity.x, targetPositionX, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(moveDistance, 0.0f, currentSpeed);

        
         rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rb.velocity.x* tilt));
            
    }

}
