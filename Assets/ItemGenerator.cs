using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //ヒエラルキーにあるユニティちゃんのゲームオブジェクトを入れる
    [SerializeField]
    private GameObject UnityChan;

    //ユニティちゃんの位置情報を格納
    private int UnityChanPos = 0;

    //アイテムの生成を開始した地点
    private int ItemGeneratePos;

    // Use this for initialization
    void Start()
    {

        //最初の50メートルにアイテムを生成
        for (int i = startPos; i < (startPos + 50); i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
        ItemGeneratePos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        UnityChanPos = (int)UnityChan.transform.position.z;
        //UnityChanの現在位置が定められたStartPosを通り越したら
        if (UnityChanPos > startPos)
        {
            //ユニティちゃんが前回のアイテム生成を始めた場所から15メートル進みかつユニティちゃんの50メートル先ががゴール地点を超えないならば
            if (Mathf.Abs(UnityChanPos - ItemGeneratePos) > 15 && (UnityChanPos + 50) < goalPos)
            {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(0, 10);
                if (num <= 1)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, UnityChanPos + 50);
                    }
                }
                else
                {

                    //レーンごとにアイテムを生成
                    for (int j = -1; j < 2; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, UnityChanPos + 50 + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, UnityChanPos + 50 + offsetZ);
                        }
                    }
                }
                ItemGeneratePos = UnityChanPos;
            }
        }
    }
}
