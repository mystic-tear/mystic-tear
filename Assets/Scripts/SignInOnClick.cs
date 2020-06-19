using System.Threading.Tasks;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;
using Firebase.Extensions;
public class SignInOnClick : MonoBehaviour
{
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .RequestServerAuthCode(false /* Don't force refresh */)
        .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Debug.LogFormat("SignInOnClick: Play Games Configuration initialized");
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            string playerName = user.DisplayName;
            Debug.LogFormat("Current Login User is ", playerName);
            SceneManager.LoadScene("GalleryScene");
        }
    }
    string authCode;
    void SignInWithPlayGames(string sceneName)
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
        auth.SignInWithCredentialAsync(credential).ContinueWithOnMainThread(task =>
        { 
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
            WaitFiveSeconds(sceneName);
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
    async void WaitFiveSeconds(string sceneName)
    {
        await Task.Delay(5000);
        SceneManager.LoadScene(sceneName);
    }
}
