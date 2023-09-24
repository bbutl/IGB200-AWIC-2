using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGenericCharacter
{
    public void StartConversation();
}

public abstract class GenericCharacter : MonoBehaviour, IGenericCharacter
{
    public virtual void StartConversation()
    {

    }
}
