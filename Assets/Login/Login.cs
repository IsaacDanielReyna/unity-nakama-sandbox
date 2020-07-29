using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Nakama;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;
    public Button loginButton;
    public TMP_Text status;

    public Button startButton;

    // Initialize the client
    private readonly IClient client = new Client("http", "127.0.0.1", 7350, "defaultkey");

    private string username = "none";

    // Start is called before the first frame update
    void Start()
    {
        Button buttonLogin = loginButton.GetComponent<Button>();
        buttonLogin.onClick.AddListener(StartSession);

        Button buttonStart = startButton.GetComponent<Button>();
        buttonStart.onClick.AddListener(LoadLobby);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void StartSession()
    {
        status.text = "connecting";
        try
        {
            var session = await client.AuthenticateEmailAsync(email.text, password.text, null, false);
            status.text = "Logged in as " + session.Username;
            username = session.Username;
            Debug.Log(session);
        } catch (ApiResponseException e)
        {
            status.text = e.Message;
            Debug.LogError(e);
        }
    }

    void LoadLobby()
    {
        PlayerPrefs.SetString("USERNAME", username);
        //DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}
