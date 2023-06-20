using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/GalleryData")]
public class Scr_GalleryData : ScriptableObject
{
    public Dictionary<int,Texture> gallery;
    private void Awake() {
        Reset();
        Debug.Log("Sr_GalleryData AWOKEN!");
    }

    public bool HasTexture(int id){
        if(gallery == null) Reset();
        return gallery.ContainsKey(id);
    }
    public Texture GetTexture(int id){
        return gallery[id];
    }
    public void AddTexture(Texture texture, int id){
        gallery.Add(id, texture);
        Debug.Log($"Size{gallery.Count}");
    }
    public void Reset(){
        gallery = new Dictionary<int, Texture>();
        Debug.Log("Resset Galery");
    }



    public void Size(){
        Debug.Log(gallery.Count);
    }
}
