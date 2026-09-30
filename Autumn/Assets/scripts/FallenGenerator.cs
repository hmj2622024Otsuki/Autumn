using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.U2D;
using static Unity.Burst.Intrinsics.Arm;

public class FallenGenerator : MonoBehaviour
{
	[SerializeField] GameObject FallenPrefab;
	[SerializeField] Sprite[] Fallen;
	float span = 0.3f;
	float delta = 0;
	Rigidbody2D rigid2D;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		this.delta += Time.deltaTime;

		// span秒ごとに落ちものを生成する
		if (this.delta > this.span)
		{
			this.delta = 0;
			int px = Random.Range(-8, 9);
			float pz = Random.Range(0f, 360f);
			FallenPrefab.transform.position = new Vector3(px, 7, 0);
			FallenPrefab.transform.Rotate(0, 0, pz);

			// プレハブを生成
			GameObject newObj = Instantiate(FallenPrefab);
			rigid2D = newObj.GetComponent<Rigidbody2D>();

			// Rigidbody2DにあるGravity Scaleの値をスクリプトから変えられるようにする
			rigid2D.gravityScale = Random.Range(0.15f, 1.2f);

			// スプライトをランダムに切り替える
			if (Fallen.Length > 0)
			{
				int index = Random.Range(0, Fallen.Length);


				SpriteRenderer sr = newObj.GetComponent<SpriteRenderer>();
				if (sr != null)
				{
					sr.sprite = Fallen[index];
				}
			}
		}
	}
}
