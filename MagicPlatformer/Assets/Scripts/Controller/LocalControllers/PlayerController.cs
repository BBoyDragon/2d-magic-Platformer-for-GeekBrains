using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IExecute
{
    private int _animationSpeed=20;
    private SpriteAnimatorController _playerAnimator;
    private SpriteAnimatorConfig _playerAnimationConfig;
    private ViewLevelObject _playerView;
    public PlayerController(SpriteAnimatorConfig playerCfg,ViewLevelObject playerView)
    {
        _playerView = playerView;
        _playerAnimationConfig = playerCfg;
        _playerAnimator = new SpriteAnimatorController(_playerAnimationConfig);
    }
    public void Execute()
    {
        _playerAnimator.Execute();

    }
    public void StartRun()//пока нет контекста для включения анимации бега, пусть будет в отдельном методе
    {
        _playerAnimator.StartAnimation(_playerView._SpriteRanderer, AnimState.Run, true, _animationSpeed);
    }
    //будет прописана реализыция умений персонажа...
}
