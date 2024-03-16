using UnityEngine;
using Wsh.Mathematics;

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

        private Vect2 m_tempPosition;
        
        void Start() {
            GridInfo gridInfo = new GridInfo(width, height, cellSize, offsetX, offsetY);
            grid = new GridSystem.Grid<IntClass>(gridInfo, true, (GridSystem.Grid<IntClass> g, int x, int y, float cellSize) => { return new IntClass();});
            grid.onGridValueChanged += OnChangedGrid;
        }

        private void OnChangedGrid(object sender, System.EventArgs e) {
            Grid<IntClass>.OnGridValueChangeEventArgs ge = e as Grid<IntClass>.OnGridValueChangeEventArgs;
            Debug.Log(ge.x + "_" + ge.y);
        }

        private void ConvertWorldPosition(Vect2 worldPosition, Vector3 position) {
            worldPosition.Set(position.x, position.y);
        }

        void Update() {
            if(Input.GetMouseButtonDown(0)) {
                ConvertWorldPosition(m_tempPosition, ToolUtils.GetMouseWorldPosition());
                grid.SetGridObject(m_tempPosition, new IntClass(99));
            }
        
            if(Input.GetMouseButtonDown(1)) {
                ConvertWorldPosition(m_tempPosition, ToolUtils.GetMouseWorldPosition());
                Debug.Log(grid.GetGridObject(m_tempPosition));
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