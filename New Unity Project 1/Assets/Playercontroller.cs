using UnityEngine;
using System.Collections;

public class Playercontroller : MonoBehaviour 
{
	public const float SPEED = 3.0f;
	// ジャンプ中ならtrue
	public bool jump = false;
	// ジャンプする力
	public float force = 30.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	private void FixedUpdate()
	{
		// ジャンプ中でないときにマウス左ボタンが押されたらジャンプする
		if (!jump && Input.GetKeyDown("up"))
		{
			jump = true;
			// オブジェクトの上方向に力を瞬間的に与える
			GetComponent<Rigidbody>().AddForce(transform.up * force *2, ForceMode.Impulse);
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		// 床オブジェクトと衝突したらジャンプ中ではないのでjump = falseにする
		if (collision.gameObject.tag == "Floor")
		{
			jump = false;
		}
		switch (collision.gameObject.name) 
		{
			case"Goal":
					Time.timeScale = 0;
				break;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		float axisHorizontal = Input.GetAxisRaw("Horizontal");
		
		if (axisHorizontal == -1 || axisHorizontal == 1 ) 
		{
			Vector3 move = new Vector3(axisHorizontal, 0, 0);
			GetComponent<Rigidbody>().velocity = move * SPEED;
		}
	}
    /*void Jump() 
	{
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		velocity.y = jump;
		GetComponent<Rigidbody>().velocity = velocity;
	}*/

}
