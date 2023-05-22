using System;
using UnityEngine;

namespace Wsh.GridSystem {

    public class Grid {

        private const int DEBUG_LINE_DURATION = 1000;

        public event EventHandler<OnGridValueChangeEventArgs> onGridValueChanged;
        public class OnGridValueChangeEventArgs : EventArgs {
            public int x;
            public int y;
        }

        public int Width { get { return m_width; } }
        public int Height { get { return m_height; } }

        private int m_width;
        private int m_height;
        private float m_cellSize;
        private Vector3 m_originPosition;
        private int[,] m_gridArray;
        private TextMesh[,] m_debugTextArray;

        public Grid(int width, int height, float cellSize, Vector3 originPosition) {
            m_width = width;
            m_height = height;
            m_cellSize = cellSize;
            m_originPosition = originPosition;

            m_gridArray = new int[m_width, m_height];
            m_debugTextArray = new TextMesh[m_width, m_height];

            for(int x = 0; x < m_gridArray.GetLength(0); x++) {
                for(int y = 0; y < m_gridArray.GetLength(1); y++) {
                    m_debugTextArray[x, y] = ToolUtils.CreateWorldText(m_gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                    DebugDrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y+1));
                    DebugDrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y));
                }
            }
            DebugDrawLine(GetWorldPosition(0, m_height), GetWorldPosition(width, height));
            DebugDrawLine(GetWorldPosition(m_width, 0), GetWorldPosition(width, height));
        }
        
        private Vector3 GetWorldPosition(int x, int y) {
            return new Vector3(x, y) * m_cellSize + m_originPosition;
        }

        private bool CheckLimit(int x, int y) {
            return x >= 0 && y >= 0 && x < m_width && y < m_height;
        }

        private void GetXY(Vector3 worldPosition, out int x, out int y) {
            x = Mathf.FloorToInt((worldPosition - m_originPosition).x / m_cellSize);
            y = Mathf.FloorToInt((worldPosition - m_originPosition).y / m_cellSize);
        }

        private void DebugDrawLine(Vector3 from, Vector3 to) {
            Debug.DrawLine(from, to, Color.white, DEBUG_LINE_DURATION);
        }

        public void SetValue(int x, int y, int value) {
            if(CheckLimit(x, y)) {
                m_gridArray[x, y] = value;
                m_debugTextArray[x, y].text = m_gridArray[x, y].ToString();
                if(onGridValueChanged != null) {
                    onGridValueChanged(this, new OnGridValueChangeEventArgs{ x = x, y = y });
                }
            }
        }

        public void SetValue(Vector3 worldPosition, int value) {
            int x, y;
            GetXY(worldPosition, out x, out y);
            SetValue(x, y, value);
        }

        public int GetValue(int x, int y) {
            if(CheckLimit(x, y)) {
                return m_gridArray[x, y];
            } else {
                return -1;
            }
        }

        public int GetValue(Vector3 worldPosition) {
            int x, y;
            GetXY(worldPosition, out x, out y);
            return GetValue(x, y);
        }
    }
}