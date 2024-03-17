using Wsh.Mathematics;

namespace Wsh.GridSystem {
    
    public class GridInfo {
        
        public int Row => m_row;
        public int Column => m_column;
        public float CellSize => m_cellSize;
        public Vect2 OriginPosition => m_originPosition;

        private int m_row;
        private int m_column;
        private float m_cellSize;
        private Vect2 m_originPosition;

        public GridInfo(int row, int column, float cellSize, float posX, float posY) {
            m_row = row;
            m_column = column;
            m_cellSize = cellSize;
            m_originPosition = new Vect2(posX, posY);
        }

    }

}
