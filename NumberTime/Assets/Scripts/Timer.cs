using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro {

    public class Timer : MonoBehaviour
    {


        [SerializeField] private TMP_Text _text;
        [SerializeField] private int time;

        // Start is called before the first frame update
        void Start()
        {
            //_text = gameObject.GetComponent<Canvas>();
            time = 333;

            _text.text = "" + time;
        }

        // Update is called once per frame
        void Update()
        {
            if (time > 0)
            {
                time = (int)((time - Time.deltaTime * 100f));
                _text.text = "" + time;
            }
            else
            {
                
            }
        }


        public int getTime()
        {
            return time;
        }

        public void setTime(int time)
        {
            if (time > 0)
            this.time = time;
        }

    }
}
