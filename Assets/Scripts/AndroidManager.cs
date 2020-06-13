using UnityEngine;

public class AndroidManager : MonoBehaviour
{
    private class HapticFeedbackManager
    {
    #if UNITY_ANDROID && !UNITY_EDITOR
        private int HapticFeedbackConstantsKey;
        private AndroidJavaObject UnityPlayer;
    #endif

        public HapticFeedbackManager(){
            #if UNITY_ANDROID && !UNITY_EDITOR
            HapticFeedbackConstantsKey=new AndroidJavaClass("android.view.HapticFeedbackConstants").GetStatic<int>("VIRTUAL_KEY");
            UnityPlayer=new AndroidJavaClass ("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer");
            //Alternative way to get the UnityPlayer:
            //int content=new AndroidJavaClass("android.R$id").GetStatic<int>("content");
            //new AndroidJavaClass ("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("findViewById",content).Call<AndroidJavaObject>("getChildAt",0);
            #endif
        }

        public bool Execute(){
            #if UNITY_ANDROID && !UNITY_EDITOR
            return UnityPlayer.Call<bool> ("performHapticFeedback",HapticFeedbackConstantsKey);
            #endif
            return false;
        }
    }

    //Cache the Manager for performance
    private static HapticFeedbackManager mHapticFeedbackManager;

    public static bool HapticFeedback(){
        if (mHapticFeedbackManager == null) {
            mHapticFeedbackManager = new HapticFeedbackManager ();
        }
        return mHapticFeedbackManager.Execute ();
    }
}
