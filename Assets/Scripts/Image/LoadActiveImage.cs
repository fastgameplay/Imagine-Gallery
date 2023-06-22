using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RawImage))]
public class LoadActiveImage : MonoBehaviour
{
    RawImage _currentRawImage;
    void Awake(){
        _currentRawImage = GetComponent<RawImage>();
    }
    
    void Start(){
        int id = PlayerPrefs.GetInt(nameof(PlayerPrefKeys.ActiveImageID),-1);
        if(id == -1) {
            Debug.LogError($"PlayerPrefs isn't containing value of {nameof(PlayerPrefKeys.ActiveImageID)}");
            SceneLoader.Instance.LoadScene(1);
        }
        _currentRawImage.texture = ImageProxy.Instance.GetRawTexture(id);
    }
}