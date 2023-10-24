using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    [SerializeField] GameObject self;

    public void GoToTarget(int target)
    {
        self.SetActive(true);
        self.transform.position = targets[target].transform.position;
    }

    public void LeaveShop()
    {
        GoToTarget(1);
        self.SetActive(false);
    }

    public void StopTalking()
    {

    }

    public void StartTalking()
    {

    }
}
