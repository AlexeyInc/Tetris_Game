using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    private Text _text;
    private int _score;

    private static Score _instance;

    public static Score Singleton {
        get {
            return _instance;
        }
    }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        }

        _text = this.gameObject.GetComponent<Text>(); 
    }
    
    public int SetScore(int value) {
        if (value != -1) {
            _score += value; 
        } else {
            _score = 0; 
        }
        _text.text = "Score: " + _score.ToString();

        return _score;
    }
}
