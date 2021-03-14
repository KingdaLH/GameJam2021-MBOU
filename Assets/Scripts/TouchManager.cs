using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    //public Text tCount;

    //Spelers toewijzen
    //   [SerializeField] private GameObject p1;
    //  [SerializeField] private GameObject p2;

    private GameObject g0bj = null;
    private Plane objPlane;
    private Vector3 m0;

    private GameObject selectedObject;

    private Vector3 touchedPos;

    private bool move = false;
    //  private float minX;
    // private float maxX;
    //  private float minY;
    //  private float maxY;

    // public float fingerIdPlayer1 = -1, fingerIdPlayer2 = -1;


    //public static Dictionary<int, objects> touchObjects = new Dictionary<int, objects>();
    Ray GenerateMouseRay(Vector3 touchPos)
    {
        Vector3 mousePosFar = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane);
        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;
    }

    // Update is called once per frame
    void Update()
    {
        //tCount.text = Input.touchCount.ToString();
       // Debug.Log(Input.touchCount.ToString());

        RaycastHit hit;

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray mouseRay = GenerateMouseRay(Input.GetTouch(0).position);

                if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Player") ||
                        (hit.collider.gameObject.CompareTag("Player2")))
                    {
                        move = true;
                       // Debug.Log("test");

                        g0bj = hit.transform.gameObject;
                        objPlane = new Plane(Camera.main.transform.forward * -1, g0bj.transform.position);

                        Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                        float rayDistance;
                        objPlane.Raycast(mRay, out rayDistance);
                        m0 = gameObject.transform.position - mRay.GetPoint(rayDistance);
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && g0bj)
            {
                Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                float rayDistance;

                if (objPlane.Raycast(mRay, out rayDistance))
                {
                    if (move)
                    {
                        g0bj.transform.position = mRay.GetPoint(rayDistance) + m0;

                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended && g0bj)
            {
                g0bj = null;
                move = false;
            }
        }
    }
}

/*foreach (Touch touch in Input.touches)
{
    float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
    Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));

    Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
    
    minX = bottomCorner.x + 0.2f;
    maxX = topCorner.x - 0.2f;
    
    if (!p2)
    {//PLAYER 1
        minY = bottomCorner.y + 0.2f;
        maxY = 0;
    } else
    {//PLAYER2
        minY = 0;
        maxY = topCorner.y - 0.2f;
    }
    print("raak mij niet aan!");
    touchedPos = Camera.main.ViewportToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0)) + new Vector3(0, 0, 10);
    print(touch.position.x); 
    //Player 2 Assigning
    if (touchedPos.x > 0 && touch.phase == TouchPhase.Began)
    {
        fingerIdPlayer2 = touch.fingerId;
    }
    else if (touch.phase == TouchPhase.Ended && touch.fingerId == fingerIdPlayer2)
    {
        fingerIdPlayer2 = - 1;
    }
    // Vinger aan rechterkant beweegt, en stuurt speler 2 aan
    if (touchedPos.x > 0 && touch.phase == TouchPhase.Moved)
    {
        Ray mRay = Camera.main.ScreenPointToRay(touch.position);
        float rayDistance;

        if (objPlane.Raycast(mRay, out rayDistance))
        {
            p2.transform.position = mRay.GetPoint(rayDistance) + m0;
        }
    }
    //Player1 Assigning
    if (touchedPos.x < 0 && touch.phase == TouchPhase.Began)
    {
        fingerIdPlayer1 = touch.fingerId;
    }
    else if (touch.phase == TouchPhase.Ended && touch.fingerId == fingerIdPlayer1)
    {
        fingerIdPlayer1 = -1;
    }
}*/
