using UnityEngine;

[System.Serializable]
public class AudioGroup
{
    public string Audio_Group_Name;
    public string Audio_Group_Type;
    public AudioData[] Audio_Clips;

    public AudioClip AudioPicker(bool randomn,int pick){
        if (randomn){
            return this.Audio_Clips[Random.Range(0,Audio_Clips.Length)].Audio_Clip;
        }else 
            return this.Audio_Clips[pick].Audio_Clip;
    }
}
