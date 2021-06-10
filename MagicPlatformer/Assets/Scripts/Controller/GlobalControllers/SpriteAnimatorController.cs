using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteAnimatorController:IDisposable
{
    private sealed class Animation
    {
        public AnimState Track;
        public List<Sprite> Sprites;
        public bool Loop = true;
        public float Speed = 10;
        public float Counter = 0;
        public bool Sleep = false;

        public void Execute()
        {
            if (Sleep) return;
            Counter += Time.deltaTime * Speed;
            if(Loop)
            {
                while (Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                }
            }
            else if(Counter >Sprites.Count)
            {
                Counter = Sprites.Count;
                Sleep = true;
            }
        }
    }
    private SpriteAnimatorConfig _Config;
    private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();

    public SpriteAnimatorController (SpriteAnimatorConfig _config)
    {
        _Config = _config;
    }

    public void StartAnimation(SpriteRenderer spriteRenderer,AnimState track,bool loop,float speed)
    {
        if(_activeAnimations.TryGetValue(spriteRenderer,out var animation))
        {
            animation.Loop = loop;
            animation.Speed = speed;
            animation.Sleep = false;
            if (animation.Track != track)
            {
                animation.Track = track;
                animation.Sprites = _Config.Seqence.Find(seqence => seqence.Track == track).Sprites;

                animation.Counter = 0;
            }
        }
        else
        {
            _activeAnimations.Add(spriteRenderer, new Animation()
            {
                Track = track,
                Sprites = _Config.Seqence.Find(seqence => seqence.Track == track).Sprites,
                Loop = loop,
                Speed = speed
            });
        }
    }

    public void StopAnimation(SpriteRenderer sprite)
    {
        if(_activeAnimations.ContainsKey(sprite))
        {
            _activeAnimations.Remove(sprite);
        }
    }
    public void Execute()
    {
        foreach(var animation in _activeAnimations)
        {
            animation.Value.Execute();
            if(animation.Value.Counter < animation.Value.Sprites.Count)
            {
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
            }
        }
    }

    public void Dispose()
    {
        _activeAnimations.Clear();
    }
}
