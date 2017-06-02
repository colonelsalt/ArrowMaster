using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class SpeechControl : MonoBehaviour {

    public string fireCommand = "fire";
    public string resetCommand = "reset";

    private KeywordRecognizer keywordRecognizer;

    void Start()
    {
        // Set up Keyword Recognizer to register our assigned voice commands
        keywordRecognizer = new KeywordRecognizer(new[] { fireCommand, resetCommand });
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    // Called whenever a voice command is recognised
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        string cmd = args.text;

        // If user said "fire", shoot arrow from Bow
        if (cmd == fireCommand)
        {
            GetComponent<Bow>().Shoot();
        }

        // If user said "reset", reload the Unity scene to start from the beginning
        else if (cmd == resetCommand)
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
    }
}
