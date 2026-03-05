using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public Elevator[] elevators; 

    public void OnFloorButtonClick(int requestedFloor)
    {
        Elevator bestElevator = null;
        float shortestDistance = float.MaxValue;

        foreach (var e in elevators)
        {
           
            if (e.currentFloor == requestedFloor && !e.IsBusy()) return;
        }

        
        foreach (var e in elevators)
        {
            float distance = Mathf.Abs(e.currentFloor - requestedFloor);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                bestElevator = e;
            }
        }

        if (bestElevator != null)
        {
            bestElevator.AddToQueue(requestedFloor);
        }
    }
}