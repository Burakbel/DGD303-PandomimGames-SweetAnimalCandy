using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float dragSpeed = 0.3f;    
    public float inertia = 5f;        

    public float maxX = 20f;

    public float minX = -20f;

    private Vector3 lastMousePos;
    private float currentVelocity = 0f;
    private bool isDragging = false;

    void Update()
    {
  
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePos = Input.mousePosition;
            currentVelocity = 0f; 
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePos;

            float moveX = -delta.x * dragSpeed * Time.deltaTime;

            currentVelocity = moveX * 60f; 

            Vector3 newPos = transform.position + new Vector3(moveX, 0, 0);
            newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
            transform.position = newPos;

            lastMousePos = Input.mousePosition;
        }
        else
        {
            if (Mathf.Abs(currentVelocity) > 0.01f)
            {
                Vector3 newPos = transform.position + new Vector3(currentVelocity * Time.deltaTime, 0, 0);

                newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
                transform.position = newPos;

                currentVelocity = Mathf.Lerp(currentVelocity, 0f, Time.deltaTime * inertia);
            }
        }
    }
}
