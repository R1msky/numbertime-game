using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity;

namespace TMPro
{
    public class GameControl : MonoBehaviour
    {
        private Timer timer;
        private int timeSize = 333;
        private int count = 0;
        private int _score = 0;
        private int numberOfObjects = 1;
        private float width;
        private float height;

        [SerializeField] private float offsetX = 0.2f;
        private float scaleRatio = 0.75f;
        [SerializeField] private GameObject prefCube;
        [SerializeField] private GameObject newCube;
        [SerializeField] private List<float> xOffsets = new List<float>() {1f, 0f, 2f};
        [SerializeField] private List<float> yOffsets = new List<float>() {1f, 1f, 1f};
        [SerializeField] private List<GameObject> cubes;
       // [SerializeField] private List<Vector3> positions = {new Vector3() };
        Animation animation;
        
        void Start()
        {
            width = Camera.main.pixelWidth;
            height = Camera.main.pixelHeight;
            timer = gameObject.GetComponent<Timer>();
            animation = gameObject.GetComponent<Animation>();
           
        }

        void Update()
        {

        }
        
        void OnMouseDown()
        {
            if (timer.getTime() < 100 && timer.getTime() > 0)
            {
                rightAction();
                
            }

            
            else
            {
                wrongAction();
            }
        }

        private void rightAction()
        {
            count++;
            timer.setTime(timeSize);
            _score = timer.getTime();
            animation.Play("Rotation");
            if (count > 2)
            {
                timeSize += 150;
                count = 0;
                timer.setTime(timeSize);
                spawnCube();

            }
            Debug.Log("+");
        }

        private void wrongAction()
        {
            Time.timeScale = 0;
            Debug.Log("-");
        }

        private int i = 0; 

        private void spawnCube()
        {
            newCube = (Instantiate(prefCube as GameObject));
           // cubes.Add(Instantiate(prefCube as GameObject));
           // cubes[i].transform.position = new Vector3(xOffsets[i], yOffsets[i], transform.position.z);
           
            //transform.position = new Vector3(-xOffsets[i], yOffsets[i]);
          
            newCube.transform.position = transform.position;
          
            //cubes[i].transform.localScale *= scaleRatio;
            transform.localScale *= scaleRatio;
            newCube.transform.localScale *= scaleRatio;
           // if (i == 2)
           // {
           //     scaleRatio -= 0.25f;
           // }
          //  i++;
           transform.Translate(new Vector3(transform.position.x - offsetX, 0));
           newCube.transform.Translate(new Vector3(newCube.transform.position.x + offsetX, 0)); 
        }
    }
}
