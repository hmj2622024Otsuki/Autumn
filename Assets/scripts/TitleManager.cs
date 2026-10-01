using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
		// スペースキーが押されたら、ゲームシーンに遷移する
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			SceneManager.LoadScene("GameScene");
		}

	}
}
