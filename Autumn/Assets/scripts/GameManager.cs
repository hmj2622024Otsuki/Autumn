using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject TimerText;

	float Timer = 30; // 制限時間の設定

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		Application.targetFrameRate = 60;
		TimerText.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
		// タイマー開始
		Timer -= Time.deltaTime;
		TimerText.GetComponent<TextMeshProUGUI>().text = "Time:" + Timer.ToString("F1");

		// タイマーが0になった場合、リザルトシーンへ遷移する
		if (Timer < 0f)
		{
			Timer = 0;
		}
	}
}
