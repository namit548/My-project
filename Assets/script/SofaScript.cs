using Newtonsoft.Json.Bson;
using UnityEngine;

public class SofaScript : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    // Define movement boundaries
    private float minX = 3.0001f, maxX = 9f;
    private float minZ = -1.55f ,maxZ = 1.8f;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        //urrent position of the sofa - position in the 3D world that corresponds to mouse is currently located.
    }

    void OnMouseUp()
    {
        isDragging = false;
        //ResetToAlignedPosition();  // Reset position when the user releases the mouse
    }
    void Update()
    {
        if (isDragging)
        {
            Vector3 newPos = GetMouseWorldPosition() + offset;//moves the sofa smoothly as you drag it

            // Clamp position within boundaries
            newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
            newPos.z = Mathf.Clamp(newPos.z, minZ, maxZ);

            transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
        }

        Quaternion targetRotation = transform.rotation;

        if (transform.position.x >= 8.82f)
        {
            transform.position = new Vector3(8.777f, transform.position.y, transform.position.z);
            targetRotation = Quaternion.Euler(0, -90, 0);
        }
        else if (transform.position.x <= 3.8f)
        {
            transform.position = new Vector3(3.636f, transform.position.y, transform.position.z);
            targetRotation = Quaternion.Euler(0, 90, 0);
        }

        if (transform.position.z >= 1.647f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.63f);
            targetRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.z <= -1.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.60f);
            targetRotation = Quaternion.Euler(0, 0, 0);
        }

        // Smooth rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 15f);
    }


    //void ResetToAlignedPosition()  ////this code works for if user release  left mouse then position set //// remove if else condition form update for to use this code
    //{
    //    Vector3 currentPosition = transform.position;

    //    // Adjust only X or Z when snapping
    //    if (currentPosition.x >= 8.82f)
    //    {
    //        transform.position = new Vector3(8.777f, transform.position.y, currentPosition.z);
    //        transform.rotation = Quaternion.Euler(0, -90, 0);
    //    }
    //    else if (currentPosition.x <= 3.8f)
    //    {
    //        transform.position = new Vector3(3.636f, transform.position.y, currentPosition.z);
    //        transform.rotation = Quaternion.Euler(0, 90, 0);
    //    }

    //    if (currentPosition.z >= 1.647f)
    //    {
    //        transform.position = new Vector3(currentPosition.x, transform.position.y, 1.63f);
    //        transform.rotation = Quaternion.Euler(0, 180, 0);
    //    }
    //    else if (currentPosition.z <= -1.6f)
    //    {
    //        transform.position = new Vector3(currentPosition.x, transform.position.y, -1.577f);
    //        transform.rotation = Quaternion.Euler(0, 0, 0);
    //    }
    //}

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        return transform.position;
    }

    //public void 
}

















