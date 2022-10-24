using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class QuitButton : MonoBehaviour
{
    void Awake(){
        Button button = GetComponent<Button>();
        button.onClick.AddListener(QuitApplication);
    }
    private void QuitApplication(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }
}
