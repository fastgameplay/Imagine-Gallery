using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class TextureSaveManager
{
    const string cachingDirectory = "/Resources/CachingDirectory/Image";
    const string suffix = ".jpg";
    public static void SaveTextureAsPNG(byte[] bytes, int id){
        File.WriteAllBytes(Application.dataPath + cachingDirectory + id + suffix, bytes);
        Debug.Log( $"{bytes.Length / 1024} KB was saved as Image{id}");
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
    public static bool CheckTextureByID(int id){
        return File.Exists(Application.dataPath + cachingDirectory + id + suffix);
    }
    public static Texture2D GetTexture(int id){
        Texture2D currentTexture = new Texture2D(2, 2);
        string path = Application.dataPath + cachingDirectory + id + suffix;

        if (CheckTextureByID(id) == false) {
            Debug.LogError($"Texture Not Found at location: {path}");
            return currentTexture;
        }
        byte[] bytes = File.ReadAllBytes(path);
        currentTexture.LoadImage(bytes);
        return currentTexture;
    }
}
