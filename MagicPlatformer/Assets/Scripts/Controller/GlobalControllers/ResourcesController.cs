using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesController 
{

    private SpriteAnimatorConfig  _PlayerAnimationConfig;
    private ViewLevelObject _PlayerView;

    public SpriteAnimatorConfig PlayerAnimationConfig
    {
        get
        {
            if (_PlayerAnimationConfig == null)
            {
                _PlayerAnimationConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            }
            return _PlayerAnimationConfig;
        }
    }
    public ViewLevelObject  PlayerView
    {
        get
        {
            if (_PlayerView == null)
            {
                var gameobject = Resources.Load<ViewLevelObject>("PlayerView");
                _PlayerView = GameObject.Instantiate(gameobject);
            }
            return _PlayerView;
        }
    }
}
