using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool Master_Volume_On;
    public bool Music_Volume_On;
    public bool SFX_Volume_On;

    public float Master_Volume_Level;
    public float Music_Volume_Level;
    public float SFX_Volume_Level;

    public AudioGroup[] Music_Audio_Groups;
    public AudioGroup[] SFX_Audio_Groups;

    public AudioGroup AudioGroupPicker(string AudioGroupName,AudioGroup[] AudioGroupType){
        for (int i =0; i < AudioGroupType.Length; i++){
            if (AudioGroupType[i].Audio_Group_Name == AudioGroupName) return AudioGroupType[i];
        } 
        return null;
    }

}
