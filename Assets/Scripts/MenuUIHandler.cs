//using UnityEngine;
//using UnityEngine.SceneManagement;
//using TMPro;

//public class MenuUIHandler : MonoBehaviour
//{
//    public TMP_InputField nameInputField;
//    public TMP_Text bestScoreText;

//    private void Start()
//    {
//        // Load high score from PlayerPrefs
//        string player = PlayerPrefs.GetString("HighScorePlayer", "None");
//        int score = PlayerPrefs.GetInt("HighScore", 0);

//        bestScoreText.text = "Best Score : " + player + " : " + score;
//    }

//    public void StartGame()
//    {
//        // Save player name before loading scene
//        PlayerPrefs.SetString("PlayerName", nameInputField.text);

//        // Load main scene
//        SceneManager.LoadScene("main");
//    }

//    public void Exit()
//    {
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.ExitPlaymode();
//#else
//        Application.Quit();
//#endif
//    }
//}


using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text bestScoreText;

    private void Start()
    {
        // Load high score from PlayerPrefs
        string player = PlayerPrefs.GetString("HighScorePlayer", "None");
        int score = PlayerPrefs.GetInt("HighScore", 0);

        bestScoreText.text = "Best Score : " + player + " : " + score;
    }

    public void StartGame()
    {
        // Save player name before loading scene
        PlayerPrefs.SetString("PlayerName", nameInputField.text);

        // Load main scene
        SceneManager.LoadScene("main"); // Ensure your scene name matches exactly
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
