﻿using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
		public GameObject[] obj;
		public GameObject startPlatform, clone;
		public float y0 = -0.7f, y = 1f, t1, x0 = 0, x; //squareEquation
		public int switchcase = 1;
		public bool counter = true;
		bool flag = true;

		float SquareEquation (float y0, float y)
		{
				float t2;
				t1 = (-12f + Mathf.Sqrt (12f * 12f + 4f * 15f * (y0 - y-0.12f))) / (-30f);
				t2 = (-12f - Mathf.Sqrt (12f * 12f + 4f * 15f * (y0 - y-0.12f))) / (-30f);
				if (t1 > t2)
						return t1;
				else {
						t1 = t2;
						return t1;
				}
		}

		void Start ()
		{
				/*while (startPlatform.rigidbody2D.position.x>-3f)
					{
						t1 = SquareEquation (y0, y);
						clone=Instantiate (obj [2], new Vector2 (5f * t1, y - 0.7f), Quaternion.identity) as GameObject;
						y0 = y - 0.3f;//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
						y = Random.Range (-1f, 5f); 
						while (y-y0>2.3F)//область в которой функция будет иметь вещественные корни
							y = Random.Range (-1F, 5F);
				//y0 = 1.5f;
					}*/
				t1 = SquareEquation (y0, y);
				//x = x0 + 5f * t1;
		}

		void Update ()
		{
				/*if (flag) {
			            clone=Instantiate (obj [2], new Vector2 (5f, 1.5f), Quaternion.identity) as GameObject;
						flag = false;
				}*/
				//rigidbody2D.position = new Vector2 (2, -1);
				if (flag)	
			    
				if (startPlatform.rigidbody2D.position.x < 0f) {
						t1 = SquareEquation (y0, y);
						clone = Instantiate (obj [2], new Vector2 (x + 5f * t1, y - 0.4f), Quaternion.identity) as GameObject;
						x = x + 5f;
						y0 = y - 0.3f;//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
						y = Random.Range (-1f, 5f); 
						while (y-y0>2.3F)//область в которой функция будет иметь вещественные корни
								y = Random.Range (-1F, 5F);
						flag = false;
				y0 = 0f;
				}

					
				if (!flag) {
						t1 = SquareEquation (y0, y-0.8f);
						if (Input.GetButtonDown ("Fire1"))//ГЕНЕРИРУЕМ ДО ТОГО КАК ОН БУДЕТ В УКАЗАННОЙ ТОЧКЕ 
						clone = Instantiate (obj [2], new Vector2 (5f * t1, y-0.8f), Quaternion.identity) as GameObject; //ставит платформу относительно её середины
						y0 = y-0.8f;//ОШИБКА!!!//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
						y = Random.Range (-1f, 5f); 
							while (y-y0>2.3F)//область в которой функция будет иметь вещественные корни
									y = Random.Range (-1F, 5F);
						//y = Random.Range (y0-2.2f, y0+2f); 
				}
				//print(t1);//учесть положение пацана
						
					

				
			
				//Invoke ("Spawn", Random.Range (SpawnMin,SpawnMax));
				//если количество spawn элементов становится большим, то нужно прекратить генерацию
				//нужно генерировать такие платформы, дельта, которых по x и y была бы от [
				/*if (rnd.Next (0, 2) == 1)
						x = x + 1f;
				else
						x = x + 2f;
		if ((y<=-4) || counter)
		{
			y =y+2;
			counter=false;
		}
		else
		{
			y =y-rnd.Next (2,4);
			counter=true;
		}*/
		}

}
