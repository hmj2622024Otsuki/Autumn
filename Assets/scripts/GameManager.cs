using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject TimerText;
	[SerializeField] GameObject ScoreText;
	[SerializeField] GameObject ScoreText2;
	[SerializeField] GameObject GuideText;
	[SerializeField] GameObject ResultText;
	[SerializeField] GameObject Youhishi;
	[SerializeField] GameObject Basket;

	float timer = 60;       // 制限時間の設定
	static int score = 0;   // スコア

	public enum scene { GAME, RESULT };		// シーンを分ける列挙定数
	public scene currentScene = scene.GAME; // シーンを設定

	public void AddScore() { score += 100; }		// スコアの加点を別のスクリプトから行うための関数
	public void AddScorePlus() { score += 300; }    // スコアの加点(+)を別のスクリプトから行うための関数
	public void RemoveScore() { score -= 500; }     // スコアの減点を別のスクリプトから行うための関数

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		Application.targetFrameRate = 60;

		score = 0; // スコアのリセット

		Basket.SetActive(true);
		TimerText.SetActive(true);
		ScoreText.SetActive(true);
		ResultText.SetActive(false);
		ScoreText2.SetActive(false);
		GuideText.SetActive(false);
		Youhishi.SetActive(false);
	}

    // Update is called once per frame
    async void Update()
    {
		// 現在のシーンがゲームシーンの時の処理
		if (currentScene == scene.GAME)
		{
			// スコア表示
			ScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString("F0");

			// タイマー開始
			timer -= Time.deltaTime;
			TimerText.GetComponent<TextMeshProUGUI>().text = "Time: " + timer.ToString("F1");

			// タイマーが0になった場合、リザルトシーンへ遷移する
			if (timer < 0f)
			{
				timer = 0;
				currentScene = scene.RESULT;
			}
		}

		// 現在のシーンがリザルトシーンの時の処理
		if (currentScene == scene.RESULT)
		{
			await Task.Delay(3000); // 3000ミリ秒(3秒)待つ

			Basket.SetActive(false);
			TimerText.SetActive(false);
			ScoreText.SetActive(false);
			ScoreText2.SetActive(true);
			ResultText.SetActive(true);
			GuideText.SetActive(true);
			Youhishi.SetActive(true);

			// リザルト用スコア表示
			ScoreText2.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString("F0");

			// キー入力を受け付ける
			if (Keyboard.current.rKey.wasPressedThisFrame)
			{
				SceneManager.LoadScene("GameScene");
			}
			else if (Keyboard.current.tKey.wasPressedThisFrame)
			{
				SceneManager.LoadScene("TitleScene");
			}
		}
	}
}
