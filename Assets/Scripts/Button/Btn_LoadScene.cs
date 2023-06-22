using UnityEngine;
public class Btn_LoadScene : ButtonListener
{
    [SerializeField] int _sceneToOpen;
    public override void OnClick(){
        SceneLoader.Instance.LoadScene(_sceneToOpen);
    }
}
