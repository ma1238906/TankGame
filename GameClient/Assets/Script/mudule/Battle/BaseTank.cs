using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTank : MonoBehaviour {
	//坦克模型
	private GameObject skin;

	//转向速度
	public float steer = 30;
	//移动速度
	public float speed = 6f;
	//炮塔旋转速度
	public float turretSpeed = 30f;
	//炮塔
	public Transform turret;
	//炮管
	public Transform gun;
	//发射点
	public Transform firePoint;
	//炮弹Cd时间
	public float fireCd = 0.5f;
	//上一次发射炮弹的时间
	public float lastFireTime = 0;
	//物理
	protected Rigidbody rigidBody;
	//生命值
	public float hp = 100;
	//属于哪一名玩家
	public string id = "";
	//阵营
	public int camp = 0;
	//炮管旋转
	public float minGunAngle = -20;
	public float maxGunAngle = 20;
	public float gunSpeed = 4f;
	//轮子和履带
	public Transform wheels;
	public Transform track;

	// Use this for initialization
	public void Start () {

	}

	//初始化
	public virtual void Init(string skinPath){
		//皮肤
		GameObject skinRes = ResManager.LoadPrefab(skinPath);
		skin = (GameObject)Instantiate(skinRes);
		skin.transform.parent = this.transform;
		skin.transform.localPosition = Vector3.zero;
		skin.transform.localEulerAngles = Vector3.zero;
		//物理
		rigidBody = gameObject.AddComponent<Rigidbody>();
		//BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>(); //改为预制体上自带
		//boxCollider.center = new Vector3(0, 2.5f, 1.47f);
		//boxCollider.size = new Vector3(7, 5, 12);
		//炮塔炮管
		turret = skin.transform.Find("Turret");
		gun = turret.transform.Find("Gun");
		firePoint = gun.transform.Find("FirePoint");
		//轮子履带
		wheels = skin.transform.Find("Wheels");
		//track = skin.transform.Find("Track");
	}

	//发射炮弹
	public Bullet Fire(){
		//已经死亡
		if(IsDie()){
			return null;
		}
		//产生炮弹
		GameObject bulletObj = new GameObject("bullet");
		bulletObj.layer = LayerMask.NameToLayer("Bullet");
		Bullet bullet = bulletObj.AddComponent<Bullet>();
		bullet.Init();
		bullet.tank = this;
		//位置
		bullet.transform.position = firePoint.position;
		bullet.transform.rotation = firePoint.rotation;
		//更新时间
		lastFireTime = Time.time;
		return bullet;
	}

	//是否死亡
	public bool IsDie(){
		return hp <= 0;
	}

	//被攻击
	public void Attacked(float att){
		//已经死亡
		if(IsDie()){
			return;
		}
		//扣血
		hp -= att;
		//死亡
		if(IsDie()){
			//显示焚烧效果
			GameObject obj = ResManager.LoadPrefab("explosion");
			GameObject explosion = Instantiate(obj, transform.position, transform.rotation);
			explosion.transform.SetParent(transform);
		}
	}


	// Update is called once per frame
	public void Update () {

	}

	//轮子旋转，履带滚动
	public void WheelUpdate(float axis){
		//计算速度
		float v = Time.deltaTime*speed*axis*100;
		//旋转每个轮子
		foreach (Transform wheel in wheels){
			wheel.Rotate(new Vector3(v,0,0),Space.Self);
		}
		//滚动履带
		//MeshRenderer mr = track.gameObject.GetComponent<MeshRenderer>();
		//if (mr == null) {
		//	return;
		//};
		//Material mtl = mr.material;
		//mtl.mainTextureOffset += new Vector2(0, v/256);

	}
}
