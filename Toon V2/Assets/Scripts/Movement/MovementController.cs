using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    [SerializeField] GameObject self;
    [SerializeField] GameObject animatorSelf;

    private Animator animator;

    public void GoToTarget(int target)
    {
        animator = animatorSelf.GetComponent<Animator>();

        self.SetActive(true);
        self.transform.position = targets[target].transform.position;
    }

    public void LeaveShop()
    {
        GoToTarget(1);
        self.SetActive(false);
    }

    public void StartTalking()
    {
        animator.SetBool("IsTalking", true);
    }

    public void StopTalking()
    {
        animator.SetBool("IsTalking", false);
    }
}
