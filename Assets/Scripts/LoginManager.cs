using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class LoginManager : MonoBehaviour {
    public InputField userInputField;
    public InputField pwdInputField;
    public LevelManager levelManager;
    public static string name;

    public void Login() {
        name = userInputField.text;
        Debug.Log("user name: " + name);
        Analytics.CustomEvent("newUser", new Dictionary<string, object> { { "nome", name } });
        levelManager.LoadNextLevel();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
            Login();
    }
}
