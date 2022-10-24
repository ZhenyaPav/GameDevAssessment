using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class MenuPanel : MonoBehaviour
{
    public UnityEvent OnClose, OnOpen;
    public bool IsOpen {get; private set;}
    [SerializeField] private float animationTime = .75f;
    [SerializeField] Vector3 openPositionOffset;

    private Tween tween;
    public void SetActive(bool active){
        tween?.Kill();
        Vector3 targetPosition = transform.localPosition 
        + openPositionOffset * (active ? 1f : -1f);
        tween = transform.DOLocalMove(targetPosition, animationTime);
        if(active) OnOpen?.Invoke();
        else OnClose?.Invoke();
        IsOpen = active;
    }
    void Update(){
        if(Input.GetButton("Cancel")) SetActive(!IsOpen);
    }
}
