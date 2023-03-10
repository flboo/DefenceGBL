using UnityEngine;
using System.Collections;

public class NarHandleShake
{
    /*
    <uses-permission android:name="android.permission.BLUETOOTH_ADMIN"/>
    <uses-permission android:name="android.permission.BLUETOOTH"/>
    <uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />
    */

#if UNITY_ANDROID && !UNITY_EDITOR
    static class GetAndroid
    {
        public static AndroidJavaClass usbClass;
        public static AndroidJavaObject usbContext;

        static GetAndroid()
        {
            usbClass = new AndroidJavaClass("ruiyue.newgame.sdk.NewgameUnity");///参数为安卓包名，根据不同包具体设置

            AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");///unity主类名，固定，不需要修改
            usbContext = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }

    protected static AndroidJavaClass GetAndroidClass
    {
        get
        {
            return GetAndroid.usbClass;
        }
    }

    protected static AndroidJavaObject GetAndroidContext
    {
        get 
        {
            return GetAndroid.usbContext;
        }
    }
#endif

    public static void init(){
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(GetAndroidClass != null){
			GetAndroidClass.CallStatic("init", GetAndroidContext);
		}
		#endif
	}

	public static void startVibrate(int left,int right){
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(GetAndroidClass != null){
			GetAndroidClass.CallStatic("startVibrate", new object[] {left,right});
		}
		#endif
	}

	public static void cancelVibrate(){
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(GetAndroidClass != null){
			GetAndroidClass.CallStatic("cancelVibrate");
		}
		#endif
	}

	public static void destroy(){
        #if UNITY_ANDROID && !UNITY_EDITOR
		if(GetAndroidClass != null){
			GetAndroidClass.CallStatic("destroy");
		}
#endif
    }
}
