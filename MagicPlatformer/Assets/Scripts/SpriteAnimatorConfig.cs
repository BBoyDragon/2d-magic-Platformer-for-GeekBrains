using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu (fileName = "SpriteAnimationCfg",menuName ="Configs",order =1)]
public class SpriteAnimatorConfig : ScriptableObject
{
    [Serializable]
    public sealed class SpriteSequence
    {
        public AnimState Track;
        public List<Sprite> Sprites = new List<Sprite>();

    }

    public List<SpriteSequence> Seqence = new List<SpriteSequence>();
}
