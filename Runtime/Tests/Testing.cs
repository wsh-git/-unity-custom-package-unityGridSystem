using UnityEngine;

namespace Wsh.GridSystem {

    public class Testing : MonoBehaviour {

        [SerializeField]
        private int offsetX;
        [SerializeField]
        private int offsetY;
        [SerializeField]
        private float cellSize;
        [SerializeField]
        private int width;
        [SerializeField]
        private int height;

        private Grid grid;

        void Start() {
            grid = new Grid(width, height, cellSize, new Vector3(offsetX, offsetY));
            grid.onGridValueChanged += OnChangedGrid;
        }

        private void OnChangedGrid(object sender, System.EventArgs e) {
            Grid.OnGridValueChangeEventArgs ge = e as Grid.OnGridValueChangeEventArgs;
            Debug.Log(ge.x + "_" + ge.y);
        }

        void Update() {
            if(Input.GetMouseButtonDown(0)) {
                grid.SetValue(ToolUtils.GetMouseWorldPosition(), 99);
            }
        
            if(Input.GetMouseButtonDown(1)) {
                Debug.Log(grid.GetValue(ToolUtils.GetMouseWorldPosition()));
            }
        }

    }

    public class HeatMapVisual {

        private Grid m_grid;

        public HeatMapVisual(Grid grid) {
            m_grid = grid;
            Vector3[] vertices;
            Vector2[] uvs;
            int[] triangles;
            ToolUtils.CreateEmptyMeshArrays(m_grid.Width * m_grid.Height, out vertices, out uvs, out triangles);
            for(int x = 0; x < m_grid.Width; x++) {
                for(int y = 0; y < m_grid.Height; y++) {

                }
            }
            
        }
    }
}