using UnityEngine;

public class CameraManager : MonoBehaviour {


        private bool doMovement = true;
        public float panSpeed = 30f;
        public float panBorderThickness = 60f;
        public float scrollSpeed = 6f;
        public float minY = 10f;
        public float maxY = 80f;

        void Update ()
            {
            //Pan
            if (Input.GetKeyDown("c")) doMovement = !doMovement;
            if (!doMovement) return;

            if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) /*|| Input.mousePosition.y>=Screen.height - panBorderThickness*/)
                {
                    transform.Translate(Vector3.right*panSpeed*Time.deltaTime, Space.World);
                
                }
            if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) /*|| Input.mousePosition.y <=panBorderThickness*/) 
                {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

            }
            if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) /*|| Input.mousePosition.x >= Screen.width - panBorderThickness*/)
                {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

            }
            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) /*|| Input.mousePosition.x <= panBorderThickness*/)
                {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

            }
            //Scroll
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 pos = transform.position;
            pos.y -= scroll *1000* scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        
        }
}
