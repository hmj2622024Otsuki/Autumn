using UnityEngine;

public class RefuseFallenGenerator : MonoBehaviour
{
	[SerializeField] GameObject RefuseFallenPrefab;
	float span = 0.7f;
	float delta = 0;
	int m_ratio = 2;

	Rigidbody2D rigid2D;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (FindObjectOfType<GameManager>().currentScene == GameManager.scene.GAME)
		{
			this.delta += Time.deltaTime;

			// span秒ごとに落ち物を生成する
			if (this.delta > this.span)
			{
				this.delta = 0;

				int dice = Random.Range(1, 11);
				if (dice <= m_ratio)
				{
					// クローンを生成する位置(x座標)をランダム化
					int px = Random.Range(-8, 9);

					// 向きをランダム化
					float z = Random.Range(0f, 360f);

					RefuseFallenPrefab.transform.position = new Vector3(px, 7, 0);
					RefuseFallenPrefab.transform.Rotate(0, 0, z * Time.deltaTime);

					// プレハブを生成
					GameObject newObj = Instantiate(RefuseFallenPrefab);
					rigid2D = newObj.GetComponent<Rigidbody2D>();

					// Rigidbody2DにあるGravity Scaleの値をスクリプトから変えられるようにする
					rigid2D.gravityScale = Random.Range(0.15f, 1.2f);
				}
				else
				{
					// 何も処理をしない
				}
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
