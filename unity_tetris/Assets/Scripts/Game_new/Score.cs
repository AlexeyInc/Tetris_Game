using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    private Text _text;
    private int _score = 0;
    private int _level = 1; 

    private static Score _instance;

    public int CurScore {
        get {
            return _score;
        }
    }

    public static Score Singleton {
        get {
            return _instance;
        }
    }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        } 
    }

    private void Start() {
        _text = this.gameObject.GetComponent<Text>();
        _text.text = "Level: " + _level.ToString() + "\n\nScore: " + _score.ToString();
    }

    public int SetScore(int value, bool isUpLevel = false) {
        if (value == -1) {
            _score = 0;
            _level = 1;
        } else {
            _score += value;
        }

        if (isUpLevel) {
            ++_level;
        }
        _text.text = "Level: " + _level.ToString() + "\n\nScore: " + _score.ToString();

        return _score;
    }
}
