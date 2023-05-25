using UnityEngine;

namespace Wsh.GridSystem {

    public class IntClass : IGridObject{
        private int m_x;
        private int m_y;
        private int m_value;

        public IntClass() : this(0) {
            
        }

        public IntClass(int value) {
            m_value = value;
        }

        public int GetX() {
            return m_x;
        }

        public int GetY() {
            return m_y;
        }
        
        public override string ToString() {
            return m_value.ToString();
        }
    }
    
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

        private GridSystem.Grid<IntClass> grid;

        void Start() {
            grid = new GridSystem.Grid<IntClass>(width, height, cellSize, new Vector3(offsetX, offsetY), (GridSystem.Grid<IntClass> g, int x, int y) => { return new IntClass();});
            grid.onGridValueChanged += OnChangedGrid;
        }

        private void OnChangedGrid(object sender, System.EventArgs e) {
            Grid<IntClass>.OnGridValueChangeEventArgs ge = e as Grid<IntClass>.OnGridValueChangeEventArgs;
            Debug.Log(ge.x + "_" + ge.y);
        }

        void Update() {
            if(Input.GetMouseButtonDown(0)) {
                grid.SetGridObject(ToolUtils.GetMouseWorldPosition(), new IntClass(99));
            }
        
            if(Input.GetMouseButtonDown(1)) {
                Debug.Log(grid.GetGridObject(ToolUtils.GetMouseWorldPosition()));
            }
        }

    }

    public class HeatMapVisual {

        private GridSystem.Grid<IntClass> m_grid;

        public HeatMapVisual(Grid<IntClass> grid) {
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