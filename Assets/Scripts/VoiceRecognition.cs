using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour {

    [SerializeField]
    private Text m_Hypotheses;

    [SerializeField]
    private Text m_Recognitions;

    public List<string> leftWords;
    public List<Sprite> leftSprites;
    public List<string> rightWords;
    public List<Sprite> rightSprites;
    public Image leftImage;
    public Image rightImage;
    public Text leftText;
    public Text rigthText;

    private System.Random rand;
    private DictationRecognizer m_DictationRecognizer;
    private int next = 0;

    void Start()
    {
        //inicjalizacja pierwszych słów
        rand = new System.Random();
        ChooseNewLeftWord();
        ChooseNewRightWord();


        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            m_Recognitions.text = text + "\n";
			MoveByHypotheses(text);
        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
           // Debug.LogFormat("Dictation hypothesis: {0}", text);
            m_Hypotheses.text = text;
           // MoveByHypotheses(text);
        };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        };

        m_DictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };

        m_DictationRecognizer.Start();
    }

    void MoveByHypotheses(string text)
    {
        if (rightWords.Contains(text.ToLower()))
        {
            this.GetComponent<player_controller>().MoveRight();
            ChooseNewRightWord();
        }
        else if (leftWords.Contains(text.ToLower()))
        {
            this.GetComponent<player_controller>().MoveLeft();
            ChooseNewLeftWord();
        }
    }

    public void ChooseNewRightWord()
    {
        next = rand.Next(0, rightWords.Count);
        rigthText.text = rightWords[next].ToString();
        rightImage.sprite = rightSprites[next];
    }

    public void ChooseNewLeftWord()
    {
        next = rand.Next(0, leftWords.Count);
        leftText.text = leftWords[next].ToString();
        leftImage.sprite = leftSprites[next];

    }
}
