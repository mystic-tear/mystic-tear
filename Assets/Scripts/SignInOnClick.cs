using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class SignInOnClick : MonoBehaviour
{
    void Start()
    {
    // Initialize Play Games Configuration and Activate it.
    PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().RequestServerAuthCode(false /*forceRefresh*/).Build();
    PlayGamesPlatform.InitializeInstance(config);
    PlayGamesPlatform.Activate();
    Debug.LogFormat("SignInOnClick: Play Games Configuration initialized");
    }

    string authCode;

    public void SignInWithPlayGames(string sceneName)
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                authCode = PlayGamesPlatform.Instance.GetServerAuthCode();
            }
        });

        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Firebase.Auth.Credential credential =
            Firebase.Auth.PlayGamesAuthProvider.GetCredential(authCode);
        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            SceneManager.LoadScene(sceneName);
        });
    }
}


//// Initialize Firebase Auth 
//Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance; // Sign In and Get a server auth code. 
//UnityEngine.Social.localUser.Authenticate((bool success) =>
//{
//    if (!success)
//    {
//        Debug.LogError("SignInOnClick: Failed to Sign into Play Games Services.");
//        return;
//    }
//    string authCode = PlayGamesPlatform.Instance.GetServerAuthCode();
//    if (string.IsNullOrEmpty(authCode))
//    {
//        Debug.LogError("SignInOnClick: Signed into Play Games Services but failed to get the server auth code.");
//        return;
//    }
//    Debug.LogFormat("SignInOnClick: Auth code is: {0}", authCode); // Use Server Auth Code to make a credential 
//    Firebase.Auth.Credential credential = Firebase.Auth.PlayGamesAuthProvider.GetCredential(authCode); // Sign In to Firebase with the credential
//    auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
//        if (task.IsCanceled)
//        {
//            Debug.LogError("SignInOnClick was canceled.");
//            return;
//        }
//        if (task.IsFaulted)
//        {
//            Debug.LogError("SignInOnClick encountered an error: " + task.Exception);
//            return;
//        }
//        Firebase.Auth.FirebaseUser newUser = task.Result;
//        Debug.LogFormat("SignInOnClick: User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
//        SceneManager.LoadScene(sceneName);
//    });
//});