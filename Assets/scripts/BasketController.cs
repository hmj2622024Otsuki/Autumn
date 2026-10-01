using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class BasketController : MonoBehaviour
{
	float speed = 0.2f; // 籠の通常速度

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {

	}

	// Update is called once per frame
	void Update()
	{
		float posX = transform.position.x;

		// 左移動
		if (Keyboard.current.leftArrowKey.isPressed)
		{
			// 端に触れた時は、これ以上移動できないようにする
			if (posX < -7.5f)
			{

			}
			else
			{
				transform.Translate(-speed, 0, 0);
			}
		}

		// 右移動
		if (Keyboard.current.rightArrowKey.isPressed)
		{
			// 端に触れた時は、これ以上移動できないようにする
			if (posX > 7.5f)
			{

			}
			else
			{
				transform.Translate(speed, 0, 0);
			}
		}

		// 加速
		if (Keyboard.current.shiftKey.isPressed)
		{
			speed = 0.4f;
		}
		else
		{
			speed = 0.2f;
		}
	}

	// 落ちものに触れた時、そのタグがついているオブジェクトを削除する
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Fallen"))
		{
			Destroy(collision.gameObject);
			FindObjectOfType<GameManager>().AddScore();
		}

		if (collision.CompareTag("RareFallen"))
		{
			Destroy(collision.gameObject);
			FindObjectOfType<GameManager>().AddScorePlus();
		}

		if (collision.CompareTag("Refuse"))
		{
			Destroy(collision.gameObject);
			FindObjectOfType<GameManager>().RemoveScore();
		}
	}
}
