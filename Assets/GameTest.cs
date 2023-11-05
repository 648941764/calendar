using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTest : MonoBehaviour
{
    
}
public class player : MonoBehaviour
{
    public delegate void DeathDelegate();
    public event DeathDelegate DeathEvent;
    private void Die()
    {
        if(DeathEvent != null)
        DeathEvent();
        Debug.Log("ÕÊº“À¿Õˆ");
        
    }
}

public class Achievements : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<player>().DeathEvent += OnPlayerDeath;
    }
    private void OnPlayerDeath()
    {

    }
}

public class UserInterface : MonoBehaviour
{
    private void OnPlayerDeath()
    {

    }
}
