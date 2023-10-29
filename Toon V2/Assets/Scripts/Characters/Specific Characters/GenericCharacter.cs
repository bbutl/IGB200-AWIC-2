using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGenericCharacter
{
    public void StartConversation();
    public void Day2Start();

    public void Day3Start();
}

public abstract class GenericCharacter : MonoBehaviour, IGenericCharacter
{
    public virtual void StartConversation()
    {

    }
    public virtual void Day2Start()
    {

    }
    public virtual void Day3Start()
    {

    }
    public virtual void Day4Start()
    {

    }
    public virtual void Day5Start()
    {

    }
}
