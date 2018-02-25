using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    private Text _text;
    private int _score = 0;
    private int _level = 1;
    private int[] _levelStages; 

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

    private void Start() {
        _levelStages = new int[50];

        for (int i = 0; i < _levelStages.Length; i+=10) {
            _levelStages[i] = i * 2;
        }
    }

    public int SetScore(int value) {
        if (value == -1) {
            _score = 0;
            _level = 0;
        } else {
            _score += value;
        }

        if (_score > _levelStages[_level]) {
            ++_level;
        }
        _text.text = "Level: " + _level.ToString() + "\n\nScore: " + _score.ToString();

        return _score;
    }
}
