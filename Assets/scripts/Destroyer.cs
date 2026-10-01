using UnityEngine;

public class Destroyer : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Fallen"))
		{
			Destroy(collision.gameObject);
		}

		if (collision.CompareTag("RareFallen"))
		{
			Destroy(collision.gameObject);
		}

		if (collision.CompareTag("Refuse"))
		{
			Destroy(collision.gameObject);
		}
	}
}
