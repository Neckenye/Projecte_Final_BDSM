using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Movement : MonoBehaviour
{
    public GameObject followObject;
    public Vector2 followOffset;
    [SerializeField] public float speed;
    private Vector2 threshold;
    // Start is called before the first frame update
    void Start()
    {
        threshold = CalculateTreshold();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        
        if (Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime); 

    }

    private Vector2 CalculateTreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.y -= followOffset.y;
        return t;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = CalculateTreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
