using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class ImageProxy : MonoBehaviour
{
    private const int TRIES_PER_REQUEST = 3;

    public static ImageProxy Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ImageProxy>(); // Eewww
            }
            return _instance;
        }
    }
    private static ImageProxy _instance;

    public event Action<int> OnTextureUpdate;
    public event Action<int> OnTextureNotFound;
    
    [SerializeField] private Texture _defaultTexture;
    
    [Header("Link")]
    [SerializeField] Scr_UrlData _urlData;
    
    private Queue<int> _idsToLoad;
    private bool _isActive;


    void Awake(){
        if(ImageProxy.Instance != null && ImageProxy.Instance != this){
            Destroy(gameObject);
        } else{
            _instance = this;
        }


        _idsToLoad = new Queue<int>();


        DontDestroyOnLoad(gameObject);
    }
    public Texture GetRawTexture(int id){
        if(TextureSaveManager.CheckTextureByID(id)) {
            return TextureSaveManager.GetTexture(id);
        }

        if(_idsToLoad.Contains(id) == false) _idsToLoad.Enqueue(id);

        if(_isActive == false) StartCoroutine(LoadImagesFromQueue());
        
        return _defaultTexture;
    }

    IEnumerator LoadImagesFromQueue(){
        _isActive = true;
        while(_idsToLoad.Count > 0){
            yield return DownloadAndCacheTexture(_idsToLoad.Dequeue());
        }
        _isActive = false;
    }

    private IEnumerator DownloadAndCacheTexture(int id){
            for(int i = 0; i < TRIES_PER_REQUEST; i++){
                using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(_urlData.Url + id + _urlData.Suffix)){
                    yield return request.SendWebRequest();
                    if (request.result == UnityWebRequest.Result.ConnectionError){
                        //Try TRIES_PER_REQUEST times if 
                        Debug.LogWarning("ConnectionError");
                        continue;
                    }
                    if(request.result == UnityWebRequest.Result.ProtocolError){
                        OnTextureNotFound?.Invoke(id);
                        break;
                    }

                    TextureSaveManager.SaveTextureAsPNG(request.downloadHandler.data,id);

                    OnTextureUpdate?.Invoke(id);
                }            
            }

    }

}
