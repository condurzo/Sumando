using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShareManager
{
    public const string shareText = "I've scored {0} points in " + ProjectConfig.projectName + "! Can you beat it?"; //Use with string.Format(shareText, <scoreValue>)

    public static void ShareImage(string imagePath, string message, SingleButton.CallbackDelegate callback)//subject, string title, string message)
    {

#if UNITY_ANDROID || UNITY_EDITOR
        message += "\n" + ProjectConfig.googlePlayLink;
#elif UNITY_IOS
        message += "\n" + ProjectConfig.appStoreLink;
#endif

#if UNITY_ANDROID

        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        intentObject.Call<AndroidJavaObject>("setType", "image/*");
        //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
        //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), title);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), message);

        AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject fileObject = new AndroidJavaObject("java.io.File", imagePath);
        AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("fromFile", fileObject);

        bool fileExist = fileObject.Call<bool>("exists");
        Debug.Log("File exist : " + fileExist);
        // Attach image to intent
        if (fileExist)
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("startActivity", intentObject);

#endif

        if (callback != null)
        {
            callback();
        }
    }
}

//    public static IEnumerator ShareScreenshot(int bestScore, SingleButton.CallbackDelegate callback = null)
//    {
//        string message = "My best score in " + ProjectConfig.projectName + " is " +
//                         bestScore.ToString() +
//#if UNITY_ANDROID || UNITY_EDITOR
//                         "\nGet it on Google Play and try to beat my record!\n" + ProjectConfig.googlePlayLink;
//#elif UNITY_IOS
//                         "\nGet it on AppStore and try to beat my record!\n" + ProjectConfig.appStoreLink;
//#endif

//        yield return new WaitForEndOfFrame();
//        string name = "scr_" + System.DateTime.Now.ToString("MM_dd_yyyy") + "_" + System.DateTime.Now.ToString("hh_mm_ss") + ".png";
//        string path = Application.persistentDataPath + "/" + name;
//        Application.CaptureScreenshot(name);
//        while (!System.IO.File.Exists(path))
//        {
//            yield return null;
//        }

//        ShareImage(path, message, callback);// "subject", "title", "message");
//    }

