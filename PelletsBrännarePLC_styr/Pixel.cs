/*
 * Created by SharpDevelop.
 * User: Bandula
 * Date: 10/29/2012
 * Time: 10:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
namespace DotMatrix
{
	/// <summary>
	/// Description of Pixel.
	/// </summary>
	 class Pixel
    {
        public Pixel()
        {

        }

        private Rectangle _rect;
        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        private int _row;
        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        private int _col;
        public int Column
        {
            get { return _col; }
            set { _col = value; }
        }

        private int _binVal;
        public int BinaryValue
        {
            get { return _binVal; }
            set { _binVal = value; }
        }

        private Color _color;
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }


    }
}
