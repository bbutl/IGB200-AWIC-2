using UnityEngine;

public class QueueController : MonoBehaviour
{
    [SerializeField] MovementController[] characters;
    [SerializeField] Sarah sarah;
    [SerializeField] Lucy lucy;
    [SerializeField] Kate kate;
    [SerializeField] Lily lily;
    
    private int currentCharacter = -1;

    void Start()
    {
        StartNextCharacter(0);
    }

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            Next();
        }
    }

    public void Next()
    {
        currentCharacter += 1;
        if (currentCharacter < characters.Length)
        {
            StartNextCharacter(currentCharacter);
        }
        characters[currentCharacter - 1].LeaveShop();
    }

    public void StartNextCharacter(int next)
    {
        characters[next].GoToTarget(0);
        switch (next)
        {
            case 0:
                lucy.StartConversation();
                break;
            case 1:
                sarah.StartConversation();
                break;
            case 2:
                kate.StartConversation();
                break;
            case 3:
                lily.StartConversation();
                break;
            default:
                Debug.Log("Oopsie!");
                break;
        }
            
    }
}
