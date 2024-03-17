using UnityEngine;

namespace Wsh.GridSystem {

    public class DebugUtils {

        public static TextMesh CreateWorldText(string text, Transform parent=null, Vector3 localPosition=default(Vector3), int fontSize=40, Color? color=null, TextAnchor textAnchor=TextAnchor.UpperLeft, TextAlignment textAlignment=TextAlignment.Left, int sortingOrder=5000) {
            if(color == null) {
                color = Color.white;
            }
            return CreateWorldText(text, parent, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
        }
        
        public static TextMesh CreateWorldText(string text, Transform parent, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment alignment, int sortingOrder) {
            GameObject go = new GameObject("World_Text", typeof(TextMesh));
            Transform tf = go.transform;
            tf.SetParent(parent, false);
            tf.localPosition = localPosition;
            TextMesh textMesh = go.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = alignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }

        // Get Mouse Position in world with z = 0f
        public static Vector3 GetMouseWorldPosition() {
            var vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0;
            return vec;
        }

        public static Vector3 GetMouseWorldPositionWithZ() {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }

        public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }

        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        public static void CreateEmptyMeshArrays(int quadCount, out Vector3[] vertices, out Vector2[] uvs, out int[] triangles) {
            vertices = new Vector3[4 * quadCount];
            uvs = new Vector2[4 * quadCount];
            triangles = new int[6 * quadCount];
        }

    }
}