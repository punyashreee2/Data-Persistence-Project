//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using System.IO;

//public class MainManager : MonoBehaviour
//{
//    public static MainManager Instance;

//    public Brick BrickPrefab;
//    public int LineCount = 6;
//    public Rigidbody Ball;

//    public Text ScoreText;
//    public Text HighScoreText;
//    public GameObject GameOverText;

//    private bool m_Started = false;
//    private int m_Points;
//    private bool m_GameOver = false;

//    public string PlayerName;
//    public string HighScorePlayer;
//    public int HighScore;

//    private void Awake()
//    {
//        if (Instance != null)
//        {
//            Destroy(gameObject);
//            return;
//        }

//        Instance = this;
//        DontDestroyOnLoad(gameObject);

//        LoadHighScore();
//    }

//    void Start()
//    {
//        // Load player name from StartMenu
//        PlayerName = PlayerPrefs.GetString("PlayerName", "Player");

//        const float step = 0.6f;
//        int perLine = Mathf.FloorToInt(4.0f / step);

//        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };

//        for (int i = 0; i < LineCount; ++i)
//        {
//            for (int x = 0; x < perLine; ++x)
//            {
//                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
//                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
//                brick.PointValue = pointCountArray[i];
//                brick.onDestroyed.AddListener(AddPoint);
//            }
//        }

//        ScoreText.text = "Score : " + m_Points;
//        HighScoreText.text = "Best Score : " + HighScorePlayer + " : " + HighScore;

//        GameOverText.SetActive(false);
//    }

//    private void Update()
//    {
//        if (!m_Started)
//        {
//            if (Input.GetKeyDown(KeyCode.Space))
//            {
//                m_Started = true;
//                float randomDirection = Random.Range(-1.0f, 1.0f);
//                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
//                forceDir.Normalize();

//                Ball.transform.SetParent(null);
//                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
//            }
//        }
//        else if (m_GameOver)
//        {
//            if (Input.GetKeyDown(KeyCode.Space))
//            {
//                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//            }
//        }
//    }

//    void AddPoint(int point)
//    {
//        m_Points += point;
//        ScoreText.text = "Score : " + m_Points;

//        if (m_Points > HighScore)
//        {
//            SaveHighScore(m_Points, PlayerName);
//            HighScoreText.text = "Best Score : " + HighScorePlayer + " : " + HighScore;
//        }
//    }

//    public void GameOver()
//    {
//        m_GameOver = true;
//        GameOverText.SetActive(true);
//    }

//    [System.Serializable]
//    class SaveData
//    {
//        public string HighScorePlayer;
//        public int HighScore;
//    }

//    public void SaveHighScore(int score, string player)
//    {
//        HighScore = score;
//        HighScorePlayer = player;

//        // Save for StartMenu display
//        PlayerPrefs.SetInt("HighScore", score);
//        PlayerPrefs.SetString("HighScorePlayer", player);

//        SaveData data = new SaveData();
//        data.HighScorePlayer = player;
//        data.HighScore = score;

//        string json = JsonUtility.ToJson(data);
//        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
//    }

//    public void LoadHighScore()
//    {
//        string path = Application.persistentDataPath + "/savefile.json";

//        if (File.Exists(path))
//        {
//            string json = File.ReadAllText(path);
//            SaveData data = JsonUtility.FromJson<SaveData>(json);

//            HighScorePlayer = data.HighScorePlayer;
//            HighScore = data.HighScore;
//        }
//    }
//}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;
    private bool m_GameOver = false;

    public string PlayerName;
    public string HighScorePlayer;
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    void Start()
    {
        // Load player name from PlayerPrefs (set in MenuUIHandler)
        PlayerName = PlayerPrefs.GetString("PlayerName", "Player");

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };

        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        ScoreText.text = "Score : " + m_Points;
        HighScoreText.text = "Best Score : " + HighScorePlayer + " : " + HighScore;

        GameOverText.SetActive(false);
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = "Score : " + m_Points;

        if (m_Points > HighScore)
        {
            SaveHighScore(m_Points, PlayerName);
            HighScoreText.text = "Best Score : " + HighScorePlayer + " : " + HighScore;
        }
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    [System.Serializable]
    class SaveData
    {
        public string HighScorePlayer;
        public int HighScore;
    }

    public void SaveHighScore(int score, string player)
    {
        HighScore = score;
        HighScorePlayer = player;

        // Save for StartMenu display
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.SetString("HighScorePlayer", player);

        SaveData data = new SaveData();
        data.HighScorePlayer = player;
        data.HighScore = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayer = data.HighScorePlayer;
            HighScore = data.HighScore;
        }
    }
}
