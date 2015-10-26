﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int multi;
    public int currentStep;
    int life = 3;

	public bool firstRun;
	Vector2 pos;

    GameObject escape;
    GameObject grid;

	//A*



	float speed = 5;
	
	public Vector2[] path;

	// Use this for initialization
	void Start () {

        escape = GameObject.FindGameObjectWithTag("End");
		grid = GameObject.FindGameObjectWithTag("Grid");

        currentStep = 1;
		firstRun = true;

		pos = grid.GetComponent<TowerDefGrid>().startPos;

		path = new Vector2[10];
		

    }
	
	// Update is called once per frame
	void Update () {


		Move();
		transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);




        if (transform.position == escape.transform.position)
        {
            Escape();
        }

        if (life == 0)
        {
            Dead();
        }

		





      

    }




	void Move()
    {
        


		if(multi == 2) {

		


			if(path[0] == (Vector2)transform.position) {
				pos = path[1];
			}

			if(path[1] == (Vector2)transform.position) {
				pos = path[2];
			}



		}

		if(multi == 3) {
			
			
			
			
			if(path[0] == (Vector2)transform.position) {
				pos = path[1];
			}
			
			if(path[1] == (Vector2)transform.position) {
				pos = path[2];
			}

			if(path[2] == (Vector2)transform.position) {
				pos = path[3];
			}
			
			
			
		}


		if(multi == 4) {
			
			
			
			
			if(path[0] == (Vector2)transform.position) {
				pos = path[1];
			}
			
			if(path[1] == (Vector2)transform.position) {
				pos = path[2];
			}

			if(path[2] == (Vector2)transform.position) {
				pos = path[3];
			}

			if(path[3] == (Vector2)transform.position) {
				pos = path[4];
			}
			
			
		}


		if(multi == 5) {
			
			
			
			
			if(path[0] == (Vector2)transform.position) {
				pos = path[1];
			}
			
			if(path[1] == (Vector2)transform.position) {
				pos = path[2];
			}

			if(path[2] == (Vector2)transform.position) {
				pos = path[3];
			}

			if(path[3] == (Vector2)transform.position) {
				pos = path[4];
			}

			if(path[4] == (Vector2)transform.position) {
				pos = path[5];
			}
			
			
			
		}


		if(multi == 6) {
			
			
			
			
			if(path[0] == (Vector2)transform.position) {
				pos = path[1];
			}
			
			if(path[1] == (Vector2)transform.position) {
				pos = path[2];
			}

			if(path[2] == (Vector2)transform.position) {
				pos = path[3];
			}

			if(path[3] == (Vector2)transform.position) {
				pos = path[4];
			}

			if(path[4] == (Vector2)transform.position) {
				pos = path[5];
			}

			if(path[5] == (Vector2)transform.position) {
				pos = path[6];
			}
			
			
			
		}


		if(multi == 7) {
			
			
			
			
			if(path[0] == (Vector2)transform.position) {
				pos = path[1];
			}
			
			if(path[1] == (Vector2)transform.position) {
				pos = path[2];
			}

			if(path[2] == (Vector2)transform.position) {
				pos = path[3];
			}

			if(path[3] == (Vector2)transform.position) {
				pos = path[4];
			}

			if(path[4] == (Vector2)transform.position) {
				pos = path[5];
			}

			if(path[5] == (Vector2)transform.position) {
				pos = path[6];
			}

			if(path[6] == (Vector2)transform.position) {
				pos = path[7];
			}
			
			
			
		}


		if(multi == 8) {
			
			
			
			
			if(path[0] == (Vector2)transform.position) {
				pos = path[1];
			}
			
			if(path[1] == (Vector2)transform.position) {
				pos = path[2];
			}

			if(path[2] == (Vector2)transform.position) {
				pos = path[3];
			}

			if(path[3] == (Vector2)transform.position) {
				pos = path[4];
			}

			if(path[4] == (Vector2)transform.position) {
				pos = path[5];
			}

			if(path[5] == (Vector2)transform.position) {
				pos = path[6];
			}

			if(path[6] == (Vector2)transform.position) {
				pos = path[7];
			}

			if(path[7] == (Vector2)transform.position) {
				pos = path[8];
			}
			
			
			
		}


		if(multi == 9) {
			
			
			
			
			if(path[0] == (Vector2)transform.position) {
				pos = path[1];
			}
			
			if(path[1] == (Vector2)transform.position) {
				pos = path[2];
			}

			if(path[2] == (Vector2)transform.position) {
				pos = path[3];
			}

			if(path[3] == (Vector2)transform.position) {
				pos = path[4];
			}

			if(path[4] == (Vector2)transform.position) {
				pos = path[5];
			}

			if(path[5] == (Vector2)transform.position) {
				pos = path[6];
			}

			if(path[6] == (Vector2)transform.position) {
				pos = path[7];
			}

			if(path[7] == (Vector2)transform.position) {
				pos = path[8];
			}

			if(path[8] == (Vector2)transform.position) {
				pos = path[9];
			}
			
			
			
		}


		if(multi == 10) {
			
			
			
			
			if(path[0] == (Vector2)transform.position) {
				pos = path[1];
			}
			
			if(path[1] == (Vector2)transform.position) {
				pos = path[2];
			}

			if(path[2] == (Vector2)transform.position) {
				pos = path[3];
			}

			if(path[3] == (Vector2)transform.position) {
				pos = path[4];
			}

			if(path[4] == (Vector2)transform.position) {
				pos = path[5];
			}

			if(path[5] == (Vector2)transform.position) {
				pos = path[6];
			}

			if(path[6] == (Vector2)transform.position) {
				pos = path[7];
			}

			if(path[7] == (Vector2)transform.position) {
				pos = path[8];
			}

			if(path[8] == (Vector2)transform.position) {
				pos = path[9];
			}

			if(path[9] == (Vector2)transform.position) {
				pos = path[10];
			}
			
			
			
		}



    }


	void MoveEnemy() {




	}




    public void Escape()
    {
        --grid.GetComponent<TowerDefGrid>().life;
        Destroy(gameObject);
    }


    public void Damage()
    {
        --life;
    }

    public void Dead()
    {
        Destroy(gameObject);
    }


}
