using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPermissions : MonoBehaviour
{
#if UNITY_ANDROID && !UNITY_EDITOR
    void Awake()
    {
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.Camera))
        {
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.Camera);

        }

        using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (var rsContext = new AndroidJavaClass("com.intel.realsense.librealsense.RsContext"))
        {
            Debug.Log(rsContext);
            rsContext.CallStatic("init", currentActivity);
        }
    }
#endif
}