using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class ButtonHandler : MonoBehaviour
{
    private const string CLASS_PHONE = "com.example.androidphonestate.TelephonyManagerHelperClass";
    [UsedImplicitly]
    private const string RESTART_FUNCTION_NAME = "restartApp";
    [UsedImplicitly]
    private static readonly AndroidJavaClass _phone = new(CLASS_PHONE);
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _phone.CallStatic(RESTART_FUNCTION_NAME);
#endif
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Clicked);
    }
}
