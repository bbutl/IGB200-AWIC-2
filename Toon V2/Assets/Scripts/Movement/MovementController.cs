using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    [SerializeField] GameObject self;

    public void GoToTarget(int target)
    {
        self.transform.position = targets[target].transform.position;
    }

    public void LeaveShop()
    {
        self.SetActive(false);
    }
}
