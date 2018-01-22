using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour {

    enum gameState { MainMenu, Password, Win }; //Los estados de la escena1
    gameState currentState;

    const string menuHint = "You can type menu at any time"; //Text

    string[] passwordLevel1 = { "book", "class", "teacher" };//Passwords key codes
    string[] passwordLevel2 = { "apple", "orange", "banana" };
    string[] passwordLevel3 = { "tec", "itesm", "book" };
    int level;

    enum GameState { MainMenu, Password, Win };
    GameState currentScreen = GameState.MainMenu;
    string password;
    string input;

    void Start () {
        ShowMainMenu();
	}

    void ShowMainMenu()
        {
            currentScreen = GameState.MainMenu;
            Terminal.ClearScreen(); //Erase everything on display
            Terminal.WriteLine("What do you want to hack today?");//text
            Terminal.WriteLine("1. Town's College.");
            Terminal.WriteLine("2. City's Super Center.");
            Terminal.WriteLine("3. ITESM, Tampico's Campus.");
            Terminal.WriteLine("Waitting for answer...");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") //call the showMainMenu if menu is written
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        { //close the game if any of the previous options was written
            Terminal.WriteLine("Please, close the browser tab");
            Application.Quit();
        }
        else if (currentScreen == GameState.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == GameState.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValisInput = (input == "1" || input == "2" || input == "3");
        if (isValisInput)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "way")
        {
            Terminal.WriteLine("YOUDONUTNOUDAWEI!");
            Terminal.WriteLine("SPIT ON THE FAKE QUEEN!");
            Terminal.WriteLine("");
        }
        else { Terminal.WriteLine("Enter a valid level"); }
    }

    void AskForPassword()
    {
        currentScreen = GameState.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password.Hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch(level)
        {
            case 1:
                password = passwordLevel1[UnityEngine.Random.Range(0,passwordLevel1.Length)];
                break;
            case 2:
                password = passwordLevel2[UnityEngine.Random.Range(0, passwordLevel2.Length)];
                break;
            case 3:
                password = passwordLevel3[UnityEngine.Random.Range(0, passwordLevel3.Length)];
                break;
            default:
                Debug.LogError("Invalid Level. How did you manage that");
                break;
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        Terminal.ClearScreen();
        ShowLeveleReward();
        
    }

    void ShowLeveleReward()
    {
        currentScreen = GameState.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        ShowLevelReward();
    }
    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("School hacked, entering school archives");
                Terminal.WriteLine("");
                Terminal.WriteLine("Type menu to hack something else.");
                level = 0;
                break;
            case 2:
                Terminal.WriteLine("Prices of all electronic devices set to $0.00");
                Terminal.WriteLine("");

                level = 0;
                break;
            case 3:
                Terminal.WriteLine("Impossible to connect to the network ofthe ITESM, CAMPUS TAMPICO.");
                Terminal.WriteLine("");
                Terminal.WriteLine("ITESM NETWORK is unstable at this");
                Terminal.WriteLine("moment, try again later.");
                level = 0;
                break;
        }
    }
}
