using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public enum SE
{
    EatFood,
    Dead,
    Knife,
    RadioLight,
    Gloves,
    SNS,
    DeadLineJob,
    BrokenThing
    
}
    
public enum Bgm
{
    Take1,
    Take2,
    Take4
}
    
[CreateAssetMenu(fileName = "Music Data", menuName = "Music Data")]
public class MusicData : SerializedScriptableObject
{
        
    public Dictionary<SE, AudioClip> seDict;

    [Title("BGM")]
    public AudioClip titleBGM;
    public AudioClip[] gameBGMs;

}