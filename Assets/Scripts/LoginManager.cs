using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class LoginManager : MonoBehaviour {
    public InputField userInputField;
    public InputField pwdInputField;
    public LevelManager levelManager;
    public Text errortext;
    public static string username;

    public void Login() {
        username = userInputField.text;
        if (string.IsNullOrEmpty(username)) {
            errortext.gameObject.SetActive(true);
            Debug.LogError("Nome utente non valido");
        }

        else {
            errortext.gameObject.SetActive(false);
            Debug.Log("user name: " + username);
            Analytics.CustomEvent("newUser", new Dictionary<string, object> { { "nome", username } });
            levelManager.LoadNextLevel();
        }

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
            Login();
    }
}
