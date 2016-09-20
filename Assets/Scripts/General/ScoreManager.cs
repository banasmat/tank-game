using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour, IListener {

    private Text scoreText;
    private int score = 0;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find(NameContainer.SCORE).GetComponent<Text>();
        setScoreText();
        EventManager.Instance.AddListener(EVENT_TYPE.BULLET_HITS_ENEMY, this);
    }

    public void OnEvent(GameEvent gameEvent)
    {
        switch (gameEvent.eventType)
        {
            case EVENT_TYPE.BULLET_HITS_ENEMY:
                PlayerKillsEnemy((Enemy)gameEvent.component);
                break;
        }
    }

    private void PlayerKillsEnemy(Enemy enemy)
    {
        score += enemy.Points;
        setScoreText();
    }

    private void setScoreText()
    {
        scoreText.text = score.ToString();
    }
}
