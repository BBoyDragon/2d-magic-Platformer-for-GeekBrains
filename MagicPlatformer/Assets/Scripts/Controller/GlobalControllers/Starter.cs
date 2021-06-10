using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    private ResourcesController _ResourcesControl;

    private PlayerController Player;
    private void Awake()
    {
        _ResourcesControl = new ResourcesController();
        Player = new PlayerController(_ResourcesControl.PlayerAnimationConfig,_ResourcesControl.PlayerView);
        Player.StartRun();
    }
    private void Start()
    { 
    }

    private void Update()
    {
        Player.Execute();
    }

    private void FixedUpdate()
    {

    }

    private void OnDestroy()
    {

    }
}