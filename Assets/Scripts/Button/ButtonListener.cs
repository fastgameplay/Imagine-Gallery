using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public abstract class ButtonListener : MonoBehaviour{
    protected Button _currentButton;
    public abstract void OnClick();
    protected virtual void OnEnableInternal(){
        //DoNothing
    }
    protected virtual void OnDisableInternal(){
        //DoNothing
    }
    protected void CheckCache(){
        if(_currentButton == null) _currentButton = GetComponent<Button>();
    }

    private void OnEnable() {
        CheckCache();
        _currentButton.onClick.AddListener(OnButtonPress);
        OnEnableInternal();
    }
    private void OnDisable() {
        _currentButton.onClick.RemoveListener(OnButtonPress);
        OnDisableInternal();
    }
    private void OnButtonPress(){
        OnClick();
    }
    

}
