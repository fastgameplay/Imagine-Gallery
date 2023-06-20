using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class ImageProxy : MonoBehaviour
{
    private const int TRIES_PER_REQUEST = 3;

    public static ImageProxy Instance {get; private set;}

    public event Action<int> OnTextureUpdate;
    public event Action<int> OnTextureNotFound;
    
    [SerializeField] private Texture _defaultTexture;
    [SerializeField] private Scr_GalleryData _galleryData;
    
    [Header("Link")]
    [SerializeField] Scr_UrlData _urlData;
    
    private Queue<int> _idsToLoad;
    private bool _isActive;


    void Awake(){
        if(ImageProxy.Instance != null && ImageProxy.Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }

        _idsToLoad = new Queue<int>();
        DontDestroyOnLoad(gameObject);
    }
    public Texture GetRawTexture(int id){
        if(_galleryData.HasTexture(id)) return _galleryData.GetTexture(id);
        if(_idsToLoad.Contains(id) == true) return _defaultTexture;
        
        _idsToLoad.Enqueue(id);

        if(_isActive == false) StartCoroutine(LoadImagesFromQueue());
        
        return _defaultTexture;
    }

    IEnumerator LoadImagesFromQueue(){
        _isActive = true;
        while(_idsToLoad.Count > 0){
            yield return LoadImageWithID(_idsToLoad.Dequeue());
        }
        _isActive = false;
    }

    IEnumerator LoadImageWithID(int id) {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(_urlData.Url + id + _urlData.Suffix);

        for (int i = 0; i < TRIES_PER_REQUEST; i++){
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError){
                //Try 3 times if 
                continue;
            }
            if(request.result == UnityWebRequest.Result.ProtocolError){
                OnTextureNotFound?.Invoke(id);
            }
            else{
                _galleryData.AddTexture(((DownloadHandlerTexture)request.downloadHandler).texture, id);
                OnTextureUpdate?.Invoke(id);
            }
            break;
        }
        
    }


}
