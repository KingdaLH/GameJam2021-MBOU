using UnityEngine;

[System.Serializable]
public class AIBoundarie
{
    public float xMin, xMax, zMin, zMax;
}

public class AIController : MonoBehaviour {

    private Rigidbody rb;
    private GameObject puckObject;
    private bool opponentSide = true;
    private float puckOffset;
    private Vector3 targetPos;
    private Vector3 startPos;

    public GameObject disk;
    public AIBoundarie boundarie;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        puckObject = GameObject.Find ("Puck");
    }

    void LateUpdate ()
    {
        var aiPos = new Vector3
        (
            Mathf.Clamp (rb.position.x, boundarie.xMin, boundarie.xMax),
            0.05f,
            Mathf.Clamp (rb.position.z, boundarie.zMin, boundarie.zMax)
        );

        float speed;

        if (puckObject.transform.position.x < 0)
        {
            if (opponentSide)
            {
                opponentSide = false;
                puckOffset = Random.Range(-1f, 1f);
            }
 
            speed = 10 * Random.Range(0.1f, 0.3f);

            targetPos = new Vector3
            (
                Mathf.Clamp(puckObject.transform.position.x + puckOffset, boundarie.xMin, boundarie.xMax),
                0.0f,
                5.0f
            );
        }
        else
        {
            opponentSide = true;
 
            speed = Random.Range(20 * 20f, 20);

            targetPos = new Vector3
            (
                Mathf.Clamp(puckObject.transform.position.x, boundarie.xMin, boundarie.xMax),
                0.0f,
                Mathf.Clamp(puckObject.transform.position.z, boundarie.zMin, boundarie.zMax)
            );
        }

        if (puckObject.transform.position.x > 20f)
        {
            //beweeg naar de puck
            rb.MovePosition(Vector3.MoveTowards (aiPos, targetPos, speed * Time.fixedDeltaTime));
        }
        else
        {
            rb.MovePosition(Vector3.MoveTowards (aiPos, startPos, speed * Time.fixedDeltaTime));
        }
        
    }

}