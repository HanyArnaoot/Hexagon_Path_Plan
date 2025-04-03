// INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace WindowsApp2
{
	internal static class ModGeneral
	{
		public static void SetDGVColHeaderWidth(ref DataGridView MyGrid, ref int ColNo, string ColHeader, int ColWidth, bool IncreaseColCount)
		{
			if (ColNo < MyGrid.Columns.Count)
			{
				MyGrid.Columns[ColNo].Width = ColWidth;
				MyGrid.Columns[ColNo].HeaderText = ColHeader;
				if (IncreaseColCount == true)
				{
					ColNo = ColNo + 1;
				}
			}
			else
			{
				System.Diagnostics.Debugger.Break();
			}
		}
		public static object ReadDGVCell(ref DataGridView DGView, int ColNo, int RowNo)
		{
			if (ColNo < 0 || RowNo < 0)
			{
				System.Diagnostics.Debugger.Break();
				return Microsoft.VisualBasic.Constants.vbNull;
			}

			if (ColNo < DGView.ColumnCount && RowNo < DGView.RowCount)
			{
				if (Convert.IsDBNull(DGView[ColNo, RowNo].Value))
				{
					return null;
				}
				else
				{
					return DGView[ColNo, RowNo].Value;
				}
			}
			return Microsoft.VisualBasic.Constants.vbNull;
		}
		//
		public static void SetDGVCell(ref DataGridView DGView, int ColNo, int RowNo, object NewVal)
		{
			if (ColNo < DGView.ColumnCount && RowNo < DGView.RowCount)
			{
				DGView[ColNo, RowNo].Value = NewVal;
			}
		}
	}

}
