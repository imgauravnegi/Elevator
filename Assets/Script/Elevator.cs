using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Elevator : MonoBehaviour
{
    public int currentFloor = 0;
    public float speed = 1f;
    public TextMeshProUGUI floorDisplay;
    
    private List<int> requestQueue = new List<int>();
    private bool isMoving = false;
    private float[] floorYPositions = { -4.3f, -2.1875f, 1f, 4.45f }; 

    void Update()
    {
        if (requestQueue.Count > 0)
        {
            MoveToFloor(requestQueue[0]);
        }
    }

    public void AddToQueue(int floor)
    {
        if (!requestQueue.Contains(floor))
        {
            requestQueue.Add(floor);
        }
    }

    void MoveToFloor(int floorIndex)
    {
        isMoving = true;
        float targetY = floorYPositions[floorIndex];
        Vector3 targetPos = new Vector3(transform.position.x, targetY, 0);

        
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        
        UpdateFloorText();

       
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            currentFloor = floorIndex;
            requestQueue.RemoveAt(0);
            isMoving = requestQueue.Count > 0;
        }
    }

    void UpdateFloorText()
    {
        
        int displayFloor = Mathf.RoundToInt(transform.position.y / 3f);
        floorDisplay.text = "Floor: " + displayFloor;
    }

    public bool IsBusy() => isMoving;
}