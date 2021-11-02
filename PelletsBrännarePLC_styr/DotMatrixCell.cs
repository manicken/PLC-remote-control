/*
 * Created by SharpDevelop.
 * User: Bandula
 * Date: 10/28/2012
 * Time: 10:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit St&&ard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DotMatrix
{
	/// <summary>
	/// Description of UserControl1.
	/// </summary>
	public class DotMatrixCell : UserControl
	{
		#region Private Properties and fields

		private int charPixelHeight = 3;
		private int charPixelWidth = 3;

        private byte charHeightPixels = 8;
        private byte charWidthPixels = 5;

        private int textColumnCount = 3;
        private int textRowCount = 2;

        private int charHorizontalDistance = 3;
        private int charVerticalDistance = 3;

        private int borderMargin = 10;

        private Pixel[,,] pixels;
        private bool pixelBorderVisible = false;
        private bool pixelBorderAsRectangle = false;
        private float pixelBorderSize = 0.01f;
        private Color pixelTurnONColor = Color.Black;
        private Color pixelTurnOFFColor = Color.GreenYellow;

        
		private CGROM CG_ROM = new CGROM();
        private bool printCGROM = false;
        private int printCGROM_rows = 8;
        private int printCGROM_cols = 32;


        private int lcdLineOffsetHorizontal;		//offset for next character
		private int lcdLineOffsetVertical;

		private int RowIndex;
		
		private int LCDWidth;
		private int LCDHeight;
		
		private Brush PixelTurnONBrush;
		private Brush PixelTurnOFFBrush;
		private Pen PixelBorderPen;
		private Brush LCDBorderBrush;
		private Pen LCDBorderPen;
        private Color pixelBorderColor = Color.AliceBlue;

		private bool PrintPixels = false;
        
        private string[] textLines;

        

        #endregion

        #region Public Properties and fields

        public int ColIndex;

        //[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string[] TextLines
        {
            get { if (textLines == null) textLines = new string[] { "" };  return textLines; }
            set { textLines = value; PrintCGROM = false; UpdateTextView(); }
        }
        public void TextSetAll(string text)
        {
            PrintCGROM = false;

            int numOfLines = text.Length / textColumnCount;
            int lastRowCharCount = (numOfLines * TextColumnCount) - text.Length;

            if (lastRowCharCount > 0)
                textLines = new string[numOfLines + 1];
            else
                textLines = new string[numOfLines];

            for (int li = 0; li < numOfLines; li++)
            {
                textLines[li] = text.Substring(li * textColumnCount, textColumnCount);
            }
            if (lastRowCharCount > 0)
                textLines[numOfLines] = text.Substring(numOfLines * textColumnCount, lastRowCharCount);

            UpdateTextView();
        }
        public void TextSetLine(int row, string text)
        {
            PrintCGROM = false;

            if (row > textLines.Length)
                row = textLines.Length - 1;
            else if (row < 0)
                row = 0;
            textLines[row] = text;

            UpdateTextView();
        }

        public bool PrintCGROM
        {
            get { return printCGROM;  }
            set { PrintPixels = false; printCGROM = value; UpdateTextView(); }
        }
        public int PixelHeight
        {
            get { return charPixelHeight; }
            set { charPixelHeight = value; charVerticalDistance = value; UpdateTextView(); }
        }

        public int PixelWidth
        {
            get { return charPixelWidth; }
            set { charPixelWidth = value; charHorizontalDistance = value; UpdateTextView(); }
        }

        public int BorderMargin
        {
            get { return borderMargin; }
            set { borderMargin = value; UpdateTextView(); }
        }

        
        public int TextColumnCount
        {
            get { return textColumnCount; }
            set { textColumnCount = value; UpdateTextView(); }
        }

        public int CharacterHorizontalDistance { get { return charHorizontalDistance; } set { charHorizontalDistance = value; UpdateTextView(); } }
        public int CharacterVerticalDistance { get { return charVerticalDistance; } set { charVerticalDistance = value; UpdateTextView(); } }


        public int TextRowCount { get => textRowCount; set => textRowCount = value; }

        
        public Color PixelBorderColor { get { return pixelBorderColor; } set { pixelBorderColor = value; this.Refresh(); } }

        public bool PixelBorderVisible { get => pixelBorderVisible; set { pixelBorderVisible = value; this.Refresh(); } }

        public float PixelBorderSize { get => pixelBorderSize; set { pixelBorderSize = value; this.Refresh(); } }

        public bool PixelBorderAsRectangle { get => pixelBorderAsRectangle; set { pixelBorderAsRectangle = value; this.Refresh(); } }

        public Color PixelTurnONColor { get => pixelTurnONColor; set { pixelTurnONColor = value; this.Refresh(); } }
        public Color PixelTurnOFFColor { get => pixelTurnOFFColor; set { pixelTurnOFFColor = value; this.Refresh(); } }


        #endregion


        #region Constructor
        public DotMatrixCell() : base()
		{
			//this.BackColor = Color.GreenYellow;//.YellowGreen;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
			
			//initialize graphic variables
			PixelTurnONBrush = new SolidBrush(pixelTurnONColor);
			PixelTurnOFFBrush = new SolidBrush(pixelTurnOFFColor);
			PixelBorderPen = new Pen(PixelTurnONBrush);
            PixelBorderPen.Width = pixelBorderSize;
            PixelBorderPen.Color = pixelBorderColor;
			
			LCDBorderBrush = new SolidBrush(Color.Silver);
			LCDBorderPen = new Pen(LCDBorderBrush);
			LCDBorderPen.Width = 2;
			
			
		}
		#endregion
		
		#region Private Methods

		private void ResizeLCD()
		{
            if (!this.AutoSize)
                return;

            int numOfLines, numOfCols;

            if (!printCGROM)
            {
                numOfLines = TextRowCount;
                numOfCols = textColumnCount;
            }
            else
            {
                numOfLines = printCGROM_rows;
                numOfCols = printCGROM_cols;
            }

            LCDWidth = (2 * borderMargin) + (charPixelWidth * charWidthPixels * numOfCols) + ((numOfCols - 1) * charHorizontalDistance) ;
			LCDHeight = (2 * borderMargin) + (charPixelHeight * charHeightPixels * numOfLines) + ((numOfLines - 1) * charVerticalDistance);

            this.Width = LCDWidth;
			this.Height = LCDHeight;
		}
		
		private void DrawLCDBorders(Graphics gr)
		{
            LCDBorderPen.Color = Color.Chocolate;

            gr.DrawRectangle(LCDBorderPen,2,2,this.Width,this.Height);
			LCDBorderPen.Color = pixelBorderColor;
			gr.DrawRectangle(LCDBorderPen,0,0,this.Width-2,this.Height-2);
			
		}
		
		
		private void UpdateTextPixels()
		{
            int numOfLines, numOfCols;

            if (!printCGROM)
            {
                numOfLines = TextLines.Length;
            }
            else
            {
                numOfLines = printCGROM_rows;
            }

            for (RowIndex = 0; RowIndex < numOfLines; RowIndex++)
			{
                if (!printCGROM) numOfCols = Math.Min(textColumnCount, textLines[RowIndex].Length);
                else numOfCols = printCGROM_cols;

                for (ColIndex = 0; ColIndex < numOfCols; ColIndex++)
				{
					for( byte Row = 0 ; Row < charHeightPixels; Row++)
					{
                        byte[] RowVals;

                        if (!printCGROM) RowVals = CG_ROM.Standard[(byte)textLines[RowIndex][ColIndex]];
                        else RowVals = CG_ROM.Standard[(byte)(RowIndex* printCGROM_cols + ColIndex)];

                        int bit;
						
						for(int Col = 0; Col < charWidthPixels; Col++)
						{
							bit = (charWidthPixels -1) - Col;
							if(((byte.Parse(Math.Pow( 2, (bit) ).ToString()) & RowVals[Row])/(byte.Parse(Math.Pow( 2, bit ).ToString()))) == 1)
							{
								pixels[Row * charWidthPixels + Col,ColIndex, RowIndex ].Enabled = true  ;
							}
							else
							{
								pixels[Row * charWidthPixels + Col,ColIndex, RowIndex].Enabled = false;
							}
						}
					}
				}
			}
            PrintPixels = true;
		}
		
		private void FillPixelArray()
		{
            int numOfLines, numOfCols;

            if (!printCGROM)
            {
                numOfLines = TextLines.Length;
                numOfCols = textColumnCount;
            }
            else
            {
                numOfLines = printCGROM_rows;
                numOfCols = printCGROM_cols;
            }
            int Row = 0;
			int Col = 0;
			
			pixels = new Pixel[charWidthPixels * charHeightPixels, numOfCols, numOfLines];

            int charHeight = charHeightPixels * charPixelHeight;
            int charWidth = charWidthPixels * charPixelWidth;
            int X, Y;

            for (RowIndex = 0; RowIndex < numOfLines; RowIndex++)
			{
                lcdLineOffsetVertical = borderMargin + (RowIndex * charHeight) + (RowIndex * charVerticalDistance);

				for(ColIndex = 0; ColIndex < numOfCols; ColIndex++)
				{
					lcdLineOffsetHorizontal = borderMargin + (ColIndex * charWidth) + (ColIndex * charHorizontalDistance);
					
					for (int i = 0; i < (charHeightPixels * charWidthPixels); i++)
					{
						pixels[i,ColIndex, RowIndex] = new Pixel();
						pixels[i,ColIndex, RowIndex].Id = i;
						
						if ((i % charWidthPixels == 0) && (i != 0))
						{
							Col = 0;
							Row++;
						}
						pixels[i,ColIndex, RowIndex].Column = Col++;
						pixels[i,ColIndex, RowIndex].Row = Row;
						pixels[i,ColIndex, RowIndex].BinaryValue = (charWidthPixels - 1) - pixels[i,ColIndex, RowIndex].Column;

						X = lcdLineOffsetHorizontal + charPixelWidth * pixels[i,ColIndex, RowIndex].Column;

						Y = lcdLineOffsetVertical + charPixelHeight * pixels[i,ColIndex, RowIndex].Row;

						pixels[i,ColIndex, RowIndex].Rect = new Rectangle(X, Y, charPixelWidth, charPixelHeight);
					}
					
					Row = 0;
					Col = 0;
					
				}
			}
			
		}
        
		private void PaintPixels(Graphics gr)
		{
            Rectangle rtmp;
            int numOfLines, numOfCols;

            if (!printCGROM)
            {
                numOfLines = TextLines.Length;
                numOfCols = textColumnCount;
            }
            else
            {
                numOfLines = printCGROM_rows;
                numOfCols = printCGROM_cols;
            }

            PixelBorderPen.Color = pixelBorderColor;
            PixelBorderPen.Width = pixelBorderSize;

            PixelTurnONBrush = new SolidBrush(pixelTurnONColor);
            PixelTurnOFFBrush = new SolidBrush(pixelTurnOFFColor);

            if (!PrintPixels)
                return;
                
            for (RowIndex =  0; RowIndex < numOfLines; RowIndex++)
			{
				for(ColIndex = 0; ColIndex < numOfCols; ColIndex++)
				{
					for (int i = 0; i < (charWidthPixels * charHeightPixels); i++)
					{
						rtmp = pixels[i,ColIndex, RowIndex].Rect;
							
						if (pixels[i,ColIndex, RowIndex].Enabled)
						{
							//PixelArray[i,ColIndex, RowIndex].Color = PixelTurnONColor;
							gr.FillRectangle(PixelTurnONBrush, rtmp);

                            if (pixelBorderVisible)
                            {
                                    
                                if (pixelBorderAsRectangle)
                                    gr.DrawRectangle(PixelBorderPen, rtmp);
                                else
                                {
                                    gr.DrawLine(PixelBorderPen, rtmp.Left, rtmp.Bottom - 1, rtmp.Right-1, rtmp.Bottom - 1);
                                    gr.DrawLine(PixelBorderPen, rtmp.Right - 1, rtmp.Top, rtmp.Right - 1, rtmp.Bottom - 1);
                                }
                                    
                            }
						}
						else
						{
                            //PixelArray[i,ColIndex, RowIndex].Color = PixelTurnOFFColor;
                            //if (pixelBorderVisible)
                            //    gr.FillRectangle(PixelTurnOFFBrush, rtmp);

                            gr.FillRectangle(PixelTurnOFFBrush, rtmp);

                            if (pixelBorderVisible)
                            {

                                if (pixelBorderAsRectangle)
                                    gr.DrawRectangle(PixelBorderPen, rtmp);
                                else
                                {
                                    gr.DrawLine(PixelBorderPen, rtmp.Left, rtmp.Bottom - 1, rtmp.Right - 1, rtmp.Bottom - 1);
                                    gr.DrawLine(PixelBorderPen, rtmp.Right - 1, rtmp.Top, rtmp.Right - 1, rtmp.Bottom - 1);
                                }
                            }
                        }
					}
				}
			}
		}
		
		#endregion
		
		#region Override Methods
		
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphic = e.Graphics;	
		
			this.SuspendLayout();
			
            PaintPixels(graphic);
			ResizeLCD();
			//DrawLCDBorders(graphic);
            base.OnPaint(e);

            this.ResumeLayout();
		}


        #endregion

        #region Public Methods
        
        public void UpdateTextView()
		{
			FillPixelArray();

            UpdateTextPixels();

            PrintPixels = true;

            this.Refresh();
            //System.Diagnostics.Debug.WriteLine("updated");
            //this.Invalidate();
           // this.Update();
        }
      
		
		#endregion
		
	}
}