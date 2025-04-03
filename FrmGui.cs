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

using System.IO;
using AxMapWinGIS;

namespace WindowsApp2
{
	public partial class FrmGui
	{
		public FrmGui()
		{
			InitializeComponent();
		}

#region Variable Declare
		private ClassPathPlan A = new ClassPathPlan();
		//
		private int MazeCreatingStatus;
		private Point TempMazePoint;
		private partial struct MazeCreatingStatusTypes
		{
			public const int NotActive = 0;
			public const int SelectingStart = 1;
			public const int SelectingTarget = 2;
			public const int SelectingObstacleStart = 3;
			public const int SelectingObstacleEnd = 4;
		}
		private partial struct MazeSolveParameter
		{
			public int SoultionTime;
			public int TotalObstaclesNo;
			public int ActiveObstaclesNo;
			public float PathLength;
			public int FoundSolutionPathNo;
			public int FoundBlockedPathNo;
			public int FoundTooLongPathNo;
			public string FileName;
			public string SolutionPointsNo;
		}
#region Simulation Part
		private ClassPathPlan.MovingUnitData MySimulatedVehicle;
		//Dim SimulationTime As Integer
		//Dim SimulatedSolutionPathIndex As Integer
		//Dim SimulatedSolutionPathCurrentTargetNode As Integer
#endregion
#endregion
#region DRaw Variable Declare
		private int ObstacleDrawLayer = 0;
		private int SolutionPathLayer = 0;
		private int SolutionOptimizedPathLayer = 0;
		private int FilterLayer = 0;
		private int MazeStartEndLayer = 0;
		private int TempObstacleLineLayer = 0; //the layer used to draw the temperorary line when adding a new obstacle line
		private int PathSafetyLayer = 0; //the layer used to draw the temperorary line when adding a new obstacle line
		private int WindowLayer = 0; //the layer used to draw the temperorary line when adding a new obstacle line
		public int SimualtionLayer = 0; //the layer used to draw the Simualtion
		//
		//Private MazeWallColor As UInteger = System.Convert.ToUInt32(RGB(255, 255, 0))
		//Private MazeWallNotSelectedColor As UInteger = System.Convert.ToUInt32(RGB(0, 255, 0))
		//Private MazeWallTempLineColor As UInteger = System.Convert.ToUInt32(RGB(30, 40, 50))
		//'
		//Private MazeStartPointColor As UInteger = System.Convert.ToUInt32(RGB(0, 0, 255))
		//Private MazeEndPointColor As UInteger = System.Convert.ToUInt32(RGB(0, 255, 255))
		//'
		//Private MazeSolutionColor As UInteger = System.Convert.ToUInt32(RGB(0, 0, 255))
		//Private MazeOptimizedSolutionColor As UInteger = System.Convert.ToUInt32(RGB(0, 255, 125))
		//Private ObstacleFilterColor As UInteger = System.Convert.ToUInt32(RGB(125, 125, 125))
		//Private DangerObstacleColor As UInteger = System.Convert.ToUInt32(RGB(255, 0, 0))
		//Private WindowsColor As UInteger = System.Convert.ToUInt32(RGB(180, 5, 12))
		public class Wrapper
		{
			public uint Color;
		}
		private List<Wrapper> k = new List<Wrapper>();

		private Wrapper MazeWallColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(255, 255, 0))};
		private Wrapper MazeWallNotSelectedColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(0, 255, 0))};
		private Wrapper MazeWallTempLineColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(30, 40, 50))};
		//
		private Wrapper MazeStartPointColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(0, 0, 255))};
		private Wrapper MazeEndPointColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(0, 255, 255))};
		//
		private Wrapper MazeSolutionColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(0, 0, 255))};
		private Wrapper MazeOptimizedSolutionColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(0, 255, 125))};
		private Wrapper ObstacleFilterColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(125, 125, 125))};
		private Wrapper DangerObstacleColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(255, 0, 0))};
		private Wrapper WindowsColor = new Wrapper {Color = Convert.ToUInt32(Microsoft.VisualBasic.Information.RGB(180, 5, 12))};
		//'






		//
		//
		// Private Const MultiSimulationResultFolderName = "Maze_"
#endregion
#region Form Start up subs
		private void FrmGui_Load(object sender, EventArgs e)
		{
			int S = 0;
			AddAllColors();
			//
			TableLayoutPanelMain.Dock = DockStyle.Fill;
			//MyControl.Width = WidthFull
			//MyControl.Left = Left_Shift
			//MyControl.Height = HeightFull '* 0.97
			//MyControl.Top = Top_Shift
			//
			DGVPath.ColumnCount = 7;
			S = 0;
			ModGeneral.SetDGVColHeaderWidth(ref DGVPath, ref S, "Point#", 70, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVPath, ref S, "Point.X", 70, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVPath, ref S, "Point.Y", 70, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVPath, ref S, "Distance", 80, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVPath, ref S, "Obs. Dist.", 80, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVPath, ref S, "Obs. No", 80, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVPath, ref S, "Obs. Pnt. Type", 80, true);
			//
			//
			DGVOptimizedPath.ColumnCount = 4;
			S = 0;
			ModGeneral.SetDGVColHeaderWidth(ref DGVOptimizedPath, ref S, "Point#", 70, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVOptimizedPath, ref S, "Point.X", 70, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVOptimizedPath, ref S, "Point.Y", 70, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVOptimizedPath, ref S, "Distance", 80, true);
			//
			DGVDynamicObstacles.ColumnCount = 7;
			S = 0;
			ModGeneral.SetDGVColHeaderWidth(ref DGVDynamicObstacles, ref S, "Name", 120, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVDynamicObstacles, ref S, "Speed", 120, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVDynamicObstacles, ref S, "Course", 120, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVDynamicObstacles, ref S, "LocationX", 120, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVDynamicObstacles, ref S, "LocationY", 120, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVDynamicObstacles, ref S, "Width", 120, true);
			ModGeneral.SetDGVColHeaderWidth(ref DGVDynamicObstacles, ref S, "Length", 120, true);
			//
			//DGVDynamicObstacles.Columns.Add("Name", "Name")
			//DGVDynamicObstacles.Columns.Add("Speed", "Speed")
			//DGVDynamicObstacles.Columns.Add("Course", "Course")
			//DGVDynamicObstacles.Columns.Add("LocationX", "LocationX")
			//DGVDynamicObstacles.Columns.Add("LocationY", "LocationY")
			//DGVDynamicObstacles.Columns.Add("Width", "Width")
			//DGVDynamicObstacles.Columns.Add("Height", "Height")  
			//   
			SetMap();
			//
			LoadMazeFromFile(Application.StartupPath + "\\b.CSV");
			//
			TabControl1.SelectedIndex = 2;
			//'
			//BtnFindPathes.PerformClick()
			//ComboPathesFound.SelectedIndex = 0
			//' BtnStartSimulation.PerformClick()
		}
#endregion
#region GUI Subs
#region Obstacle Draw
		private void BtnDrawObstacles_Click(object sender, EventArgs e)
		{
			DrawObstacle();
			//
			DrawFilterShape();
		}
		private void BtnDrawWindows_Click(object sender, EventArgs e)
		{
			DrawWindows(CheckBoxDrawWindowsNo.Checked ? -1 : 0);
		}
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			int ColorIndex = ComboBoxElementsColor.SelectedIndex;
			if (ColorIndex > -1)
			{
				ColorDialog1.Color = ColorTranslator.FromWin32((System.Int32)(k[ColorIndex].Color));
				if (ColorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					k[ColorIndex].Color = (uint)System.Drawing.ColorTranslator.ToWin32(ColorDialog1.Color);
					PictureBoxMAzeColorSelection.BackColor = ColorDialog1.Color;
				}
			}
		}

		private void ComboBoxElementsColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			int ColorIndex = ComboBoxElementsColor.SelectedIndex;
			if (ColorIndex > -1)
			{
				PictureBoxMAzeColorSelection.BackColor = ColorTranslator.FromWin32((System.Int32)(k[ColorIndex].Color));
			}
		}
#endregion

#region Maze change Btns (Save ,Load ,new)
		private void BtnSaveTargets_Click(System.Object sender, System.EventArgs e)
		{
			SaveMazeToFile(ShowSaveFileDialog("CSV"));
			//
			//SaveFileDialog1.Filter = "CSV Files (*.CSV*)|*.CSV"
			//SaveFileDialog1.InitialDirectory = Application.StartupPath()
			//If SaveFileDialog1.ShowDialog = DialogResult.OK Then
			//    SaveMazeToFile(SaveFileDialog1.FileName)
			//End If
		}
		private string ShowSaveFileDialog(string ExtentiosinFilterText)
		{
			SaveFileDialog1.Filter = ExtentiosinFilterText + " Files (*." + ExtentiosinFilterText + "*)|*." + ExtentiosinFilterText;
			SaveFileDialog1.InitialDirectory = Application.StartupPath;
			if (SaveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				return SaveFileDialog1.FileName;
			}
			return null;
		}
		private void BtnLoadTargets_Click(System.Object sender, System.EventArgs e)
		{
			string Myfile = null;
			OpenFileDialog1.Filter = "CSV Files (*.CSV*)|*.CSV";
			OpenFileDialog1.InitialDirectory = Application.StartupPath;
			if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Myfile = OpenFileDialog1.FileName;
				LoadMazeFromFile(OpenFileDialog1.FileName);
			}
			else
			{
				return;
			}
		}
		private void BtnNewMaze_Click(object sender, EventArgs e)
		{

			//
			ClearAllLayers();
			MapWinGIS.Extents myExtents = new MapWinGIS.Extents();
			myExtents.SetBounds(0, 0, 0, 1000, 1000, 0);
			AxMap1.Extents = myExtents;
			//
			MazeCreatingStatus = MazeCreatingStatusTypes.SelectingStart;
			LblDisplayStatus.Visible = true;
			LblDisplayStatus.Text = "Selecting Maze Start Point";
			A.Obstacles.Clear();
			A.NodeToNodeVisibility = new byte[0, 0];
			//
		}

#endregion
#region Calculation
		private void BtnClearCalculationData_Click(object sender, EventArgs e)
		{
			ComboPathesFound.Items.Clear();
			//
			//A.FoundPath.Clear()
			//A.PreCalculationDone = False
			//'
			//A.Clear_Obsatcle_IsMakingPathCritical()
			A.ClearAllData();
			//
			ClearLayer(SolutionPathLayer);
			ClearLayer(SolutionOptimizedPathLayer);
			ClearLayer(FilterLayer);
			ClearLayer(PathSafetyLayer);
			ClearLayer(TempObstacleLineLayer);
			ClearLayer(ObstacleDrawLayer);
			ClearLayer(MazeStartEndLayer);
			ClearLayer(WindowLayer);
			ClearLayer(SimualtionLayer);
		}

		private void SetMazeSoultionParameter()
		{
			///////////////////////////////////////////
			//Setting main parameters
			A.SafeDistance = (float)NumericHelper.Val(TxtSafeDistance.Text);
			A.SafeDistanceToNodeExtensionDistanceRatio = (float)NumericHelper.Val(TxtSafeDistanceToNodeExtensionDistance.Text);
			//'
			A.MySpeed = Convert.ToSingle(TxtMySpeed.Text);
			//'A.IncludeDynamicObstacles = CheckBoxIncludeDynamicObstacles.Checked
			//Optimazation variables
			A.SafetyMaxPathLengthIncreaseRatio = (float)NumericHelper.Val(TxtSafteyMaxPathIncreaseRatio.Text);
			A.InitialExpansionAngle = (float)A.Deg2Rad(NumericHelper.Val(TxtInitialExpansionAngle.Text));
			//
			A.SortObstaclesByDistanceToStartPoint = CheckBoxSortObstacles.Checked;
			A.ApplyMinimumPath = CheckBoxApplyMinimumPath.Checked;
			A.ApplyMinimumPointPath = CheckBoxApplyMinimumPointPath.Checked;
			//A.ApplyIterariveMinimumPath = CheckBoxApplyInitialMinimumPath.Checked
			A.ApplyRoughMinPath = CheckBoxApplyRoughMinPath.Checked;
			//
			//A.IterariveMinimumPathIncreaseStepRatio = Val(TxtMinimumPathLengthIncreaseStep.Text)
			// A.IterariveMinimumPathStartPercent = Val(TxtStatMinimumPathLength.Text)
			//
			A.EllipseMajorAxisToStartEndDistanceRatio = (float)NumericHelper.Val(TxtEllipsMajorAxisToStartEndDistanceRatio.Text);
			A.EllipseMinorAxisToStartEndDistanceRatio = (float)NumericHelper.Val(TxtEllipseMinorAxisToStartEndDistanceRatio.Text);
			//
			A.HexagonHeightRatio = (float)NumericHelper.Val(TxtHexagonHeightRatio.Text);
			//A.HexagonAngle = Val(TxtHexagonAngle.Text)
			A.ApplyIterativeHexagon = CheckBoxApplyIterativeHexagon.Checked;
			//A.ApplyFireLine = RadioButtonUseHanyLine.Checked
			//
			A.IterativeHexagonHeightStepRatio = (float)NumericHelper.Val(TxtHexagonHeightIncreasePercent.Text);
			A.ClearPreviousPathonEachIteration = CheckBoxClearPreviousPathonEachIteration.Checked;
			//
			A.EquilateralMajorAxisExtensionToStartEndDistanceRatio = (float)NumericHelper.Val(TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio.Text);
			A.EquilateralAngle = (float)A.Deg2Rad(NumericHelper.Val(TxtEquilateralAngle.Text));
			//
			A.RectangleWidthExtensionToStartEndDistanceRatio = (float)NumericHelper.Val(TxtRectangleWidthExtensionToStartEndDistanceRatio.Text);
			A.RectangleHeightToStartEndDistanceRatio = (float)NumericHelper.Val(TxtRectangleHeightToStartEndDistanceRatio.Text);
			///////////////////////////////////////////

			//LblCalculationTimeClock.Text = "Calculation Start Time  :" + Now.ToShortTimeString
			// Debug.Print(CalculationStartTime.ToString)
			//
			//reading user Obstacle filtering preference
			if (RadioButtonFilterByDVGRectangle.Checked == true)
			{
				A.ObstacleFilterMethod = ClassPathPlan.ObstacleFilteringMethods.DVG;
			}
			if (RadioButtonFilterByECoVG.Checked == true)
			{
				A.ObstacleFilterMethod = ClassPathPlan.ObstacleFilteringMethods.ECoVG;
			}
			if (RadioButtonFilterByESOVG.Checked == true)
			{
				A.ObstacleFilterMethod = ClassPathPlan.ObstacleFilteringMethods.ESOVG;
			}
			if (RadioButtonFilterbyHexagon.Checked == true)
			{
				A.ObstacleFilterMethod = ClassPathPlan.ObstacleFilteringMethods.Hexagon;
			}
			if (RadioButtonNoFilter.Checked == true)
			{
				A.ObstacleFilterMethod = ClassPathPlan.ObstacleFilteringMethods.NoFilter;
			}
			//If RadioButtonFireLine.Checked = True Then A.ObstacleFilterMethod = ClassPathPlan.ObstacleFilteringMethods.FireLine
			//
			//Maze solve Method     
			if (RadioButtonUseDijkstra.Checked == true)
			{
				A.MazeSolveMethod = ClassPathPlan.SolutionMethods.Dijkstra;
			}
			if (RadioButtonHexagon.Checked == true)
			{
				A.MazeSolveMethod = ClassPathPlan.SolutionMethods.Hexagon;
			}
			if (RadioButtonArnaootFireLine.Checked == true)
			{
				A.MazeSolveMethod = ClassPathPlan.SolutionMethods.ArnaootFireLine;
			}
			if (RadioButtonDynamicHexagon.Checked == true)
			{
				A.MazeSolveMethod = ClassPathPlan.SolutionMethods.HexagonDynamic;
			}
		}
		private void BtnFindPathes_Click(object sender, EventArgs e)
		{
			int S = 0;
			int PathPointNo = 0;
			float Distance = 0F;
			//Dim MinPathDistance  As Single
			//Dim MinPathNo As Integer
			string PathSatus = "";
			int AvailableSoultions = 0;
			TimeSpan CalculationTime = new TimeSpan();
			DateTime CalculationStartTime = default(DateTime);
			int SolPathNo = 0;
			int BlockedPathNo = 0;
			int TooLongPathNo = 0;
			int SearchingPathNo = 0;
			//
			//clear all previous data
			A.ClearData(false, true);
			//
			if (CheckBoxIncludeDynamicObstacles.Checked == true)
			{
				//
				S = DGVDynamicObstacles.Rows.Count - 2;
				A.MovingObstacles = new WindowsApp2.ClassPathPlan.MovingUnitData[S + 1];
				for (S = 0; S <= DGVDynamicObstacles.Rows.Count - 2; S++)
				{
					ClassPathPlan.MovingUnitData MyDynamicObstacle = new ClassPathPlan.MovingUnitData();
					MyDynamicObstacle.Name = Convert.ToString(ModGeneral.ReadDGVCell(ref DGVDynamicObstacles, 0, S));
					MyDynamicObstacle.Speed = (float)NumericHelper.Val(ModGeneral.ReadDGVCell(ref DGVDynamicObstacles, 1, S));
					MyDynamicObstacle.Course = ClassPathPlan.CourseToAngle((float)A.Deg2Rad(NumericHelper.Val(ModGeneral.ReadDGVCell(ref DGVDynamicObstacles, 2, S)))); //'to turn navigational Direction into geometrical dimension
					MyDynamicObstacle.Position.X = Convert.ToInt32(NumericHelper.Val(ModGeneral.ReadDGVCell(ref DGVDynamicObstacles, 3, S)));
					MyDynamicObstacle.Position.Y = Convert.ToInt32(NumericHelper.Val(ModGeneral.ReadDGVCell(ref DGVDynamicObstacles, 4, S)));
					MyDynamicObstacle.Width = (float)NumericHelper.Val(ModGeneral.ReadDGVCell(ref DGVDynamicObstacles, 5, S));
					MyDynamicObstacle.Length = (float)NumericHelper.Val(ModGeneral.ReadDGVCell(ref DGVDynamicObstacles, 6, S));
					//'
					A.MovingObstacles[S] = MyDynamicObstacle;
				}
			}
			//
			///////////////////////////////////////////
			//Setting main parameters
			//Optimazation variables
			SetMazeSoultionParameter();
			///////////////////////////////////////////
			//Calculation Time estimating
			CalculationStartTime = DateTime.Now;
			//Time Calculation
			Stopwatch ProcessStopwatch = Stopwatch.StartNew();
			//
			A.SolveMaze();
			//
			//ProcessStopwatch.Stop()
			CalculationTime = DateTime.Now.Subtract(CalculationStartTime);
			// Debug.Print(Now.ToString)
			//
			LblCalculationTimeStopWatch.Text = "Calculation Time  :" + (ProcessStopwatch.ElapsedMilliseconds / 1000.0).ToString() + " seconds";
			// LblCalculationTimeClock.Text = "Calculation Time  :" + (CalculationTime.Milliseconds / 1000).ToString + " seconds"
			Microsoft.VisualBasic.Interaction.Beep();
			//
			//Exit Sub
			//
			ComboPathesFound.Items.Clear();
			//
			//Remove the blocked pathes upon user choice
			if (CheckBoxShowSoultionsOnly.Checked == true)
			{
				for (S = A.FoundPaths.Count - 1; S >= 0; S--)
				{
					PathPointNo = A.FoundPaths[S].PathNode.Count - 1;
					if (A.FoundPaths[S].PathNode[PathPointNo].NodePoint == A.MazeEndNode.NodePoint)
					{
						// A.FoundPath(S).CalPathLength()
						AvailableSoultions = AvailableSoultions + 1;
					}
					else
					{
						A.FoundPaths.RemoveAt(S);
					}
				}
			}
			else
			{
				// A.FoundPath.RemoveAt(0)
				for (S = A.FoundPaths.Count - 1; S >= 0; S--)
				{
					PathPointNo = A.FoundPaths[S].PathNode.Count - 1;
					if (A.FoundPaths[S].PathNode[PathPointNo].NodePoint == A.MazeEndNode.NodePoint)
					{
						AvailableSoultions = AvailableSoultions + 1;
					}
				}
			}
			//
			if (AvailableSoultions == 0)
			{
				MessageBox.Show("no solution was found", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
				//Exit Sub
			}
			//
			//adding path with number and distance to the combo
			if (A.FoundPaths.Count == 0)
			{
				return;
			}
			//
			ComboPathesFound.Items.Clear();
			//
			for (S = 0; S < A.FoundPaths.Count; S++)
			{
				Distance = (float)(Convert.ToInt32(Math.Floor(Convert.ToDouble(A.FoundPaths[S].PathLength * 100))) / 100.0);
				switch (A.FoundPaths[S].CurrentPathStatus)
				{
					case ClassPathPlan.PathStatusTypes.Searching:
						PathSatus = "Searching";
						SearchingPathNo = SearchingPathNo + 1;
						break;
					case ClassPathPlan.PathStatusTypes.Blocked:
						PathSatus = "Blocked";
						BlockedPathNo = BlockedPathNo + 1;
						break;
					case ClassPathPlan.PathStatusTypes.Solution:
						PathSatus = "Solution";
						SolPathNo = SolPathNo + 1;
						break;
					case ClassPathPlan.PathStatusTypes.TooLong:
						PathSatus = "Toolong";
						TooLongPathNo = TooLongPathNo + 1;
						break;
				}
				// A.FoundPath(S).PathLength = Distance
				//If Distance < MinPathDistance Then
				//    MinPathDistance = Distance
				//    MinPathNo = S
				//End If
				ComboPathesFound.Items.Add("Path#" + (S + 1).ToString() + "/ distance=" + (Distance.ToString()) + " / " + PathSatus);
			}
			//
			// Dim SolPathNo, BlockedPathNo, TooLongPathNo, SearchingPathNo As Integer
			LblPathTypes.Text = "paths: " + SolPathNo.ToString() + " Solutions, " + BlockedPathNo.ToString() + " Blocked, " + TooLongPathNo.ToString() + " TooLong, " + SearchingPathNo.ToString() + " Searching.";
			ListBoxMazeSolutionLog.Items.Insert(0, A.MazeSolveMethod.ToString() + " : " + LblPathTypes.Text + "" + LblCalculationTimeStopWatch.Text);
			//'
			ClearAllLayers();
			//'
			DrawObstacle();
			//
			//
			DrawFilterShape();

			//
			if (CheckBoxDrawWindows.Checked == true)
			{
				DrawWindows(CheckBoxDrawWindowsNo.Checked ? -1 : 0);
			}
			//
			if (CheckBoxShowNodeToNodeVisbilty.Checked)
			{
				ShowNodeToNodeVisbilty(ref DVGNodeToNodeVisbilty);
			}
			//
			//If CheckBoxDrawWindowsNo.Checked Then

			//End If
			LblCalculationTimeClock.Text = "Total Processing and Calculation Time  :" + (ProcessStopwatch.ElapsedMilliseconds / 1000.0).ToString() + " seconds";
		}
		private void ComboPathesFound_SelectedIndexChanged(object sender, EventArgs e)
		{
			int SelectedPath = ComboPathesFound.SelectedIndex;
			int S1 = 0;
			ClassPathPlan.Node[] PathPoints = null;
			float PathLength = 0F;
			float OptimizedPathLength = 0F;
			float LineLength = 0F;
			//
			if (SelectedPath < 0 || ComboPathesFound.Items.Count == 0 || A.FoundPaths.Count == 0)
			{
				return;
			}
			int SelectedPathPointsNo = A.FoundPaths[SelectedPath].PathNode.Count + 1;
			//If A.FoundPath(S).CurrentPathStatus = 2 Then
			//
			switch (A.FoundPaths[SelectedPath].CurrentPathStatus)
			{
				case ClassPathPlan.PathStatusTypes.Searching:
					LblPathData.Text = "PathNo :" + SelectedPath.ToString() + "  Searching";
					break;
				case ClassPathPlan.PathStatusTypes.Blocked:
					LblPathData.Text = "PathNo :" + SelectedPath.ToString() + "  Blocked!!!";
					break;
				case ClassPathPlan.PathStatusTypes.Solution:
					LblPathData.Text = "PathNo :" + SelectedPath.ToString() + "  Solution";
					break;
				case ClassPathPlan.PathStatusTypes.TooLong:
					LblPathData.Text = "PathNo :" + SelectedPath.ToString() + "  Too long";
					break;
			}
			//
			DGVPath.RowCount = 1;
			DGVPath.RowCount = SelectedPathPointsNo + 1;
			//
			DGVPath[0, 0].Value = 1;
			DGVPath[1, 0].Value = A.FoundPaths[SelectedPath].PathNode[0].NodePoint.X;
			DGVPath[2, 0].Value = A.FoundPaths[SelectedPath].PathNode[0].NodePoint.Y;
			//
			int ClosestObstacleNo = 0;
			float ClosestLineToObstacleDistance = 0F;
			int ClosestObstaclePointType = 0;
			A.Clear_Obsatcle_IsMakingPathCritical();
			//
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of A.FoundPaths(SelectedPath).PathNode.Count for every iteration:
			int tempVar = A.FoundPaths[SelectedPath].PathNode.Count;
			for (S1 = 1; S1 < tempVar; S1++)
			{
				DGVPath[0, S1].Value = S1 + 1;
				DGVPath[1, S1].Value = A.FoundPaths[SelectedPath].PathNode[S1].NodePoint.X;
				DGVPath[2, S1].Value = A.FoundPaths[SelectedPath].PathNode[S1].NodePoint.Y;
				LineLength = A.CalNodeDis(A.FoundPaths[SelectedPath].PathNode[S1], A.FoundPaths[SelectedPath].PathNode[S1 - 1]);
				PathLength = PathLength + LineLength;
				DGVPath[3, S1].Value = LineLength.ToString();
			}
			DGVPath[0, S1].Value = "Total";
			DGVPath[1, S1].Value = "Path";
			DGVPath[2, S1].Value = "Distance";
			DGVPath[3, S1].Value = PathLength.ToString();
			//Path drawing
			PathPoints = A.FoundPaths[SelectedPath].PathNode.ToArray();
			// Draw Line to screen.
			if (CheckBoxDrawLine.Checked == true && PathPoints.Count() > 1)
			{
				DrawNodeArray(SolutionPathLayer, PathPoints, true, false, MazeSolutionColor.Color, true);
			}
			// Draw curve to screen.
			if (CheckBoxDrawSpline.Checked == true && PathPoints.Count() > 2)
			{
				//  PictureBoxMazeSolution.CreateGraphics.DrawCurve(penSplinePath, PathPoints, 0.2)
			}
			//###########################
			//critical path data extraction
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of A.FoundPaths(SelectedPath).PathNode.Count for every iteration:
			int tempVar2 = A.FoundPaths[SelectedPath].PathNode.Count;
			for (S1 = 1; S1 < tempVar2; S1++)
			{
				A.CheckObstacleToLineSafety(A.FoundPaths[SelectedPath].PathNode[S1 - 1].NodePoint, A.FoundPaths[SelectedPath].PathNode[S1].NodePoint, ref ClosestObstacleNo, ref ClosestLineToObstacleDistance, ref ClosestObstaclePointType);
				DGVPath[4, S1].Value = ClosestLineToObstacleDistance.ToString();
				DGVPath[5, S1].Value = ClosestObstacleNo.ToString();
				DGVPath[6, S1].Value = ClosestObstaclePointType.ToString();
			}
			//critical path osbtacles drawing
			ClearLayer(PathSafetyLayer);
			//
			//For S = 0 To A.FoundPath(SelectedPath).PathPoint.Count - 2
			//    AxMap1.DrawLineEx(PathSafetyLayer, A.FoundPath(SelectedPath).PathPoint(S).X, A.FoundPath(SelectedPath).PathPoint(S).Y, A.FoundPath(SelectedPath).PathPoint(S + 1).X, A.FoundPath(SelectedPath).PathPoint(S + 1).Y, 2, 1)
			//Next
			for (var S = 0; S < A.Obstacles.Count - 1; S++)
			{
				if (A.Obstacles[S].IsMakingPathCritical == true)
				{
					AxMap1.DrawLineEx(PathSafetyLayer, A.Obstacles[S].Points[ClassPathPlan.ObstaclePointTypeStart].X, A.Obstacles[S].Points[ClassPathPlan.ObstaclePointTypeStart].Y, A.Obstacles[S].Points[ClassPathPlan.ObstaclePointLastTypeIndex].X, A.Obstacles[S].Points[ClassPathPlan.ObstaclePointLastTypeIndex].Y, 2, DangerObstacleColor.Color);
				}
				else
				{
					// AxMap1.DrawLineEx(PathSafetyLayer, A.Obstacles(S).StartPoint.X, A.Obstacles(S).StartPoint.Y, A.Obstacles(S).EndPoint.X, A.Obstacles(S).EndPoint.Y, 2, MazeWallNotSelectedColor)
				}
			}

			//PictureBox1.CreateGraphics.DrawLine(penStartTarget, A.MazeStartPoint, A.MazeEndPoint)
			//DrawObstacle()
			//**************************************************************
			Point[] OptimizedPathPoints;
			//
			OptimizedPathPoints = A.OptimizePath(SelectedPath);
			if (OptimizedPathPoints == null)
			{
				return;
			}
			//
			if (CheckBoxDrawOptimizedPath.Checked == true && OptimizedPathPoints != null)
			{
				DrawPointArray(SolutionOptimizedPathLayer, OptimizedPathPoints, true, false, MazeOptimizedSolutionColor.Color, true);
			}
			if (CheckBoxDrawSplineOptimizedPath.Checked == true && OptimizedPathPoints != null)
			{
				//PictureBoxMazeSolution.CreateGraphics.DrawCurve(penSplineOptimizedPath, OptimizedPathPoints, 0.5)
			}
			//
			DGVOptimizedPath.RowCount = 1;
			DGVOptimizedPath.RowCount = SelectedPathPointsNo + 1;
			//
			DGVOptimizedPath[0, 0].Value = 1;
			DGVOptimizedPath[1, 0].Value = OptimizedPathPoints[0].X;
			DGVOptimizedPath[2, 0].Value = OptimizedPathPoints[0].Y;
			//
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of A.FoundPaths(SelectedPath).PathNode.Count for every iteration:
			int tempVar3 = A.FoundPaths[SelectedPath].PathNode.Count;
			for (S1 = 1; S1 < tempVar3; S1++)
			{
				//
				DGVOptimizedPath[0, S1].Value = S1 + 1;
				DGVOptimizedPath[1, S1].Value = OptimizedPathPoints[S1].X;
				DGVOptimizedPath[2, S1].Value = OptimizedPathPoints[S1].Y;
				LineLength = A.CalPointDis(OptimizedPathPoints[S1], OptimizedPathPoints[S1 - 1]);
				OptimizedPathLength = OptimizedPathLength + LineLength;
				DGVOptimizedPath[3, S1].Value = LineLength.ToString();
				//
			}
			//
			DGVOptimizedPath[0, S1].Value = "Total";
			DGVOptimizedPath[1, S1].Value = "Path";
			DGVOptimizedPath[2, S1].Value = "Distance";
			DGVOptimizedPath[3, S1].Value = OptimizedPathLength.ToString();
			//
			//DrawObstacle()
			//A.CalculateRectangleData()
			// A.checkPathSaftey(A.FoundPath(SelectedPath))
			//
			//Dim ClosestObstacleNo As Integer, ClosestLineToObstacleDistance As Single, ClosestObstaclePointType As Integer
			//For S = 0 To A.FoundPath(SelectedPath).PathPoint.Count - 2
			//    If A.CheckObstacleToLineSafety(A.FoundPath(SelectedPath).PathPoint(S), A.FoundPath(SelectedPath).PathPoint(S + 1), ClosestObstacleNo, ClosestLineToObstacleDistance, ClosestObstaclePointType) = False Then
			//        'Debug.Print(S, ClosestObstacleNo, ClosestLineToObstacleDistance, ClosestObstaclePointType)
			//        ' Obstacles(ClosestObstacleNo).IsMakingPathCritical = True
			//        'SetDGVColHeaderWidth(DGVPath, S, "Obs. Dist.", 80, True)
			//        'SetDGVColHeaderWidth(DGVPath, S, "Obs. No", 80, True)
			//        'SetDGVColHeaderWidth(DGVPath, S, "Obs. Pnt. Type", 80, True)

			//    End If
			//Next


		}

#endregion
#region Draw
		public void AddAllColors()
		{
			//'create a nested sub to add the wrappers
			Action<string, Wrapper> AddColors = (string ColorName, Wrapper ColorValue) =>
			{
														  ComboBoxElementsColor.Items.Add(ColorName);
														  k.Add(ColorValue);
			};
			//'
			ComboBoxElementsColor.Items.Clear();
			AddColors("Maze Wall Color", MazeWallColor);
			AddColors("Maze Wall Not Selected Color", MazeWallNotSelectedColor);
			AddColors("Maze Wall Temp Line Color", MazeWallTempLineColor);
			AddColors("Maze Start Point Color", MazeStartPointColor);
			AddColors("Maze End Point Color", MazeEndPointColor);
			AddColors("Maze Solution Color", MazeSolutionColor);
			AddColors("Maze Optimized Solution Color", MazeOptimizedSolutionColor);
			AddColors("Obstacle Filter Color", ObstacleFilterColor);
			AddColors("Danger Obstacle Color", DangerObstacleColor);
			AddColors("Windows Color", WindowsColor);
			//AddColors("",  )
			//AddColors("",  )
			//AddColors("",  )
			//AddColors("",  )
		}

		private void DrawFilterShape()
		{
			switch (A.ObstacleFilterMethod)
			{
				case ClassPathPlan.ObstacleFilteringMethods.ESOVG:
					DrawPointArray(FilterLayer, A.EquilateralPoints, true, true, ObstacleFilterColor.Color, false);
					break;
				case ClassPathPlan.ObstacleFilteringMethods.Hexagon:
					DrawPointArray(FilterLayer, A.HexagonPoints, false, true, ObstacleFilterColor.Color, false);
					break;
				case ClassPathPlan.ObstacleFilteringMethods.DVG:
					DrawPointArray(FilterLayer, A.RectanglePoints, true, true, ObstacleFilterColor.Color, false);
					break;
				case ClassPathPlan.ObstacleFilteringMethods.ECoVG:
					DrawEllipse(A.EllipseCenterPoint, A.EllipseMajorAxisLength, A.EllipseMinorAxisLength, A.EllipseAngle, FilterLayer);
					break;
			}
		}

#endregion

#region Optimize
		private void BtnOptimizePath_Click(object sender, EventArgs e)
		{
			int SelectedPath = ComboPathesFound.SelectedIndex;
			//Dim S As Integer
			//
			Point[] OptimizedPathPoints = null;
			if (A.FoundPaths.Count > 0)
			{
				if (A.FoundPaths[SelectedPath].CurrentPathStatus == ClassPathPlan.PathStatusTypes.Solution)
				{
					OptimizedPathPoints = A.OptimizePath(SelectedPath);
					DrawPointArray(SolutionOptimizedPathLayer, OptimizedPathPoints, true, false, MazeOptimizedSolutionColor.Color, false);
				}
			}
		}

#endregion

#endregion

#region Maze Save ,Load ,Create Random Subs
		private void BtnCreateRndMaze_Click(object sender, EventArgs e)
		{
			float MazeWidth = (float)NumericHelper.Val(TxtMazeWidth.Text); //PictureBoxMazeOnly.Width * 0.9
			float MazeHeight = (float)NumericHelper.Val(TxtMazeHeight.Text); //PictureBoxMazeOnly.Height * 0.9
			int ObstacleNo = Convert.ToInt32(NumericHelper.Val(TxtObstacleNo.Text)); //90
			float ObstacleMaxLength = (float)NumericHelper.Val(TxtObstacleMaxLength.Text); // 20
			int MazeType = 0;
			//
			if (MazeWidth == 0 || MazeHeight == 0 || ObstacleNo == 0 || ObstacleMaxLength == 0)
			{
				MessageBox.Show("Values Can not be Zeros", "Data Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			//
			A.ClearAllData();
			A.Obstacles.Clear();
			//
			if (RadioButtonCreateLine.Checked)
			{
				MazeType = ClassPathPlan.RandomMazeTypes.Lines;
			}
			//
			if (RadioButtonCreateRectangle.Checked)
			{
				MazeType = ClassPathPlan.RandomMazeTypes.Rectangles;
			}
			//
			A.CreateRandomMaze(MazeType, MazeWidth, MazeHeight, ObstacleNo, ObstacleMaxLength);
			//A.CalculateWindowData()
			ClearAllLayers();
			DrawObstacle();
		}
		public void SaveMazeToFile(string Myfile)
		{
			System.IO.StreamWriter objWriter = null;
			int S = 0;
			string NodeData = "";
			string ObstacleData = "";
			float PathLength = 0F;
			float LineLength = 0F;
			int X = 0;
			int Y = 0;
			int DynamicObstaclesCount = 0;
			//
			objWriter = new System.IO.StreamWriter(Myfile, false, System.Text.Encoding.UTF8); //FILE_NAME
			//
			objWriter.Write("Line Extension Distacne=," + A.SafeDistance.ToString() + "\r\n");
			objWriter.Write("Obstacles Count=," + A.Obstacles.Count.ToString() + "\r\n");
			//
			objWriter.Write("\r\n");
			objWriter.Write("Node Name,Start Node X,Start Node Y,End Node X,End Node Y" + "\r\n");
			//
			objWriter.Write("Maze Start&End," + A.MazeStartNode.NodePoint.X.ToString() + "," + A.MazeStartNode.NodePoint.Y.ToString() + "," + A.MazeEndNode.NodePoint.X.ToString() + "," + A.MazeEndNode.NodePoint.Y.ToString() + "\r\n");
			//
			//Maze Obstacles Detail
			int ObstaclePointType = 0;
			for (S = 0; S < A.Obstacles.Count; S++)
			{
				if (A.Obstacles[S].ObstacleType == ClassPathPlan.ObstacleTypes.StaticObsatcle)
				{
					NodeData = "Obstacle No. " + (S + 1).ToString();
					for (ObstaclePointType = ClassPathPlan.ObstaclePointTypeStart; ObstaclePointType <= ClassPathPlan.ObstaclePointLastTypeIndex; ObstaclePointType++)
					{
						NodeData = NodeData + "," + A.Obstacles[S].Points[ObstaclePointType].X.ToString() + "," + A.Obstacles[S].Points[ObstaclePointType].Y.ToString();
					}
					objWriter.Write(NodeData + "\r\n");
				}
			}
			//
			DynamicObstaclesCount = DGVDynamicObstacles.Rows.Count - 1;
			objWriter.Write("Dynamic Obstacles Count=," + (DynamicObstaclesCount).ToString() + "\r\n");
			//objWriter.Write("Obstacles Properties Count=," + (DGVDynamicObstacles.Columns.Count).ToString + vbCrLf)
			//
			if (DynamicObstaclesCount > 0)
			{
				for (Y = 0; Y < DynamicObstaclesCount; Y++)
				{
					for (X = 0; X < DGVDynamicObstacles.Columns.Count; X++)
					{
						ObstacleData = ObstacleData + Convert.ToString(ModGeneral.ReadDGVCell(ref DGVDynamicObstacles, X, Y)) + ",";
					}
					objWriter.Write(ObstacleData + "\r\n");
					ObstacleData = "";
				}
			}

			if (A.FoundPaths.Count > 0)
			{
				//Shortest Solution Details
				objWriter.Write("\r\n");
				objWriter.Write("Shortest Solution" + "\r\n");
				objWriter.Write("Node Name, Node X, Node Y,Distance to Previous,Path Length So Far" + "\r\n");
				NodeData = "Node No. 0" + "," + A.FoundPaths[0].PathNode[0].NodePoint.X.ToString() + "," + A.FoundPaths[0].PathNode[0].NodePoint.Y.ToString();
				objWriter.Write(NodeData + "\r\n");
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of A.FoundPaths(0).PathNode.Count for every iteration:
				int tempVar = A.FoundPaths[0].PathNode.Count;
				for (S = 1; S < tempVar; S++)
				{
					LineLength = A.CalNodeDis(A.FoundPaths[0].PathNode[S], A.FoundPaths[0].PathNode[S - 1]);
					PathLength = PathLength + LineLength;
					NodeData = "Node No. " + (S + 1).ToString() + "," + A.FoundPaths[0].PathNode[S].NodePoint.X.ToString() + "," + A.FoundPaths[0].PathNode[S].NodePoint.Y.ToString() + "," + LineLength.ToString() + "," + PathLength.ToString();
					objWriter.Write(NodeData + "\r\n");
				}
				//
				objWriter.Write("Path Length" + PathLength.ToString() + "\r\n");
			}

			objWriter.Close();
			objWriter = null;
		}
		private string Trim2String(ref string TrimmedString, string StrTrimMarkString)
		{
			//this function removes the character till , to get next value
			int FirstTrimMark = 0;
			int NextTrimMark = 0;
			int DataLength = 0;
			string D = null;
			FirstTrimMark = TrimmedString.IndexOf(StrTrimMarkString) + 1;
			NextTrimMark = TrimmedString.IndexOf(StrTrimMarkString, FirstTrimMark) + 1;
			//
			//Return Mid(TrimmedString, S + Len(StrTrimMarkString), Len(TrimmedString) - S - Len(StrTrimMarkString) + 1)
			if (NextTrimMark > 0)
			{
				DataLength = NextTrimMark - FirstTrimMark - StrTrimMarkString.Length;
			}
			else
			{
				DataLength = TrimmedString.Length - FirstTrimMark - StrTrimMarkString.Length + 1;
			}
			//
			D = TrimmedString.Substring((FirstTrimMark + StrTrimMarkString.Length) - 1, DataLength);
			TrimmedString = TrimmedString.Substring((FirstTrimMark + StrTrimMarkString.Length) - 1, TrimmedString.Length - FirstTrimMark - StrTrimMarkString.Length + 1);
			return D;
		}
		public bool LoadMazeFromFile(string Myfile)
		{
			int S = 0;
            int FixedObstacleCount = 0;

            string Textline = null;
			//
			//A = New ClassPathPlan
			A.ClearAllData();
			//
			//checks if the exists , to prevent error
			if (System.IO.File.Exists(Myfile) == false)
			{
				return false;
			}
			//
			//reading file content
			using (StreamReader sr = new StreamReader(Myfile))
			{
                //Loading the settings
                 Textline = sr.ReadLine();
                A.SafeDistance = (float)NumericHelper.Val(Trim2String(ref Textline, ","));
                //
                Textline = sr.ReadLine();
                FixedObstacleCount = Convert.ToInt32( Trim2String(ref  Textline , ",") );
                //
				Textline = sr.ReadLine(); //to skip the empty line
				Textline = sr.ReadLine(); //to skip the header line
				//
				Textline = sr.ReadLine();
				//T = Trim2String(sr.ReadLine, ",")
				A.MazeStartNode.NodePoint.X = Convert.ToInt32(NumericHelper.Val(Trim2String(ref Textline, ",")));
				// T = Trim2String(T, ",")
				A.MazeStartNode.NodePoint.Y = Convert.ToInt32(NumericHelper.Val(Trim2String(ref Textline, ",")));
				//T = Trim2String(T, ",")
				A.MazeEndNode.NodePoint.X = Convert.ToInt32(NumericHelper.Val(Trim2String(ref Textline, ",")));
				//T = Trim2String(T, ",")
				A.MazeEndNode.NodePoint.Y = Convert.ToInt32(NumericHelper.Val(Trim2String(ref Textline, ",")));
				//            '
				//Loading the  Obstacles Data
				for (S = 0; S < FixedObstacleCount; S++)
				{
					ClassPathPlan.ObstacleLine NewObstacle = new ClassPathPlan.ObstacleLine();
					Textline = sr.ReadLine(); //"Obstacle No. 1,86,18,86,50"
					//Trim2String(T, ",")
					for (var ObstaclePointType = ClassPathPlan.ObstaclePointTypeStart; ObstaclePointType <= ClassPathPlan.ObstaclePointLastTypeIndex; ObstaclePointType++)
					{
						NewObstacle.Points[ObstaclePointType].X = Convert.ToInt32(NumericHelper.Val(Trim2String(ref Textline, ","))); // Val(T)
						NewObstacle.Points[ObstaclePointType].Y = Convert.ToInt32(NumericHelper.Val(Trim2String(ref Textline, ","))); //Val(T)
					}
					A.Obstacles.Add(NewObstacle);
				}
				//Loading the Dynamic Obstacles
				int X = 0;
				int Y = 0;
				int DynamicObstaclesCount;
                Textline = sr.ReadLine();
                DynamicObstaclesCount = Convert.ToInt32( Trim2String(ref Textline, ","));
				DGVDynamicObstacles.RowCount = DynamicObstaclesCount + 1;
				if (DynamicObstaclesCount > 0)
				{
					for (Y = 0; Y < DynamicObstaclesCount; Y++)
					{
						Textline = "," + sr.ReadLine();
						for (X = 0; X < DGVDynamicObstacles.Columns.Count; X++)
						{
							// T = Trim2String(T, ",")
							ModGeneral.SetDGVCell(ref DGVDynamicObstacles, X, Y, Trim2String(ref Textline, ","));
						}
					}
				}
			}
			//
			// Debug.Print(A.Obstacles.Count)
			A.PreCalculationDone = false;
			//
			ClearAllLayers();
			//A.CalculateWindowData()
			DrawObstacle();
			//AxMap1.ZoomToMaxExtents()
			//CenterOnMaze()
			return true;
		}



#endregion
#region Draw
		//
		private void SetMap()
		{
			bool State = false;
			// AxMap1 setting
			AxMap1.SendMouseDown = true;
			AxMap1.SendMouseMove = true;
			AxMap1.SendMouseUp = true;
			// AxMap1.r = True
			//
			AxMap1.Projection = MapWinGIS.tkMapProjection.PROJECTION_NONE; //'Projection.PROJECTION_NONE
			AxMap1.MapUnits = MapWinGIS.tkUnitsOfMeasure.umMeters;
			//
			AxMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
			AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
			//
			var sfWorld = new MapWinGIS.Shapefile();
			State = sfWorld.CreateNewWithShapeID("", MapWinGIS.ShpfileType.SHP_POLYGON);
			//
			FilterLayer = AxMap1.AddLayer(sfWorld, true);
			ObstacleDrawLayer = AxMap1.AddLayer(sfWorld, true);
			SolutionPathLayer = AxMap1.AddLayer(sfWorld, true);
			SolutionOptimizedPathLayer = AxMap1.AddLayer(sfWorld, true);
			MazeStartEndLayer = AxMap1.AddLayer(sfWorld, true);
			TempObstacleLineLayer = AxMap1.AddLayer(sfWorld, true);
			PathSafetyLayer = AxMap1.AddLayer(sfWorld, true);
			WindowLayer = AxMap1.AddLayer(sfWorld, true);
			SimualtionLayer = AxMap1.AddLayer(sfWorld, true);
			//
			//'ClearAllLayers()
			//Dim myExtents As MapWinGIS.Extents = New MapWinGIS.Extents
			//myExtents.SetBounds(0, 0, 0, 1000, 1000, 0)
			//AxMap1.Extents = myExtents
		}
		//Private Sub SetLayer(ByVal LayerNo As Integer)
		//    AxMap1.ClearDrawing(LayerNo) 'clear the layer before drawing new targets
		//    AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
		//End Sub
		private void CenterOnMaze()
		{
			MapWinGIS.Extents myExtents = new MapWinGIS.Extents();
			float xmin = 0F;
			float xmax = 0F;
			float ymin = 0F;
			float ymax = 0F;
			//
			if (A.PreCalculationDone == false)
			{
				xmin = Math.Min(A.MazeStartNode.NodePoint.X, A.MazeEndNode.NodePoint.X);
				ymin = Math.Min(A.MazeStartNode.NodePoint.Y, A.MazeEndNode.NodePoint.Y);
				xmax = Math.Max(A.MazeStartNode.NodePoint.X, A.MazeEndNode.NodePoint.X);
				ymax = Math.Max(A.MazeStartNode.NodePoint.Y, A.MazeEndNode.NodePoint.Y);
				myExtents.SetBounds(xmin, ymin, 0, xmax, ymax, 0);
			}
			else
			{
				myExtents.SetBounds(A.MazeMinPoint.X, A.MazeMinPoint.Y, 0, A.MazeMaxPoint.X, A.MazeMaxPoint.Y, 0);
			}
			AxMap1.Extents = myExtents;
			//myExtents.SetBounds(A.MazeMinPoint.X, A.MazeMinPoint.Y, 0, A.MazeMaxPoint.X, A.MazeMaxPoint.Y, 0)
			//AxMap1.Extents = myExtents
		}
		private void ClearAllLayers()
		{
			AxMap1.ClearDrawing(MazeStartEndLayer); //clear the layer before drawing new targets
			//'AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			//       
			AxMap1.ClearDrawing(ObstacleDrawLayer); //clear the layer before drawing new targets
			//'AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			//
			AxMap1.ClearDrawing(SolutionPathLayer); //clear the layer before drawing new targets
			//'AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			//       
			AxMap1.ClearDrawing(SolutionOptimizedPathLayer); //clear the layer before drawing new targets
			//'AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			//
			AxMap1.ClearDrawing(FilterLayer); //clear the layer before drawing new targets
			//'AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			//
			AxMap1.ClearDrawing(TempObstacleLineLayer);
			//'AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			AxMap1.ClearDrawing(WindowLayer);
			//'AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			AxMap1.ClearDrawing(SimualtionLayer);
			//'AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			//
			AxMap1.ClearDrawing(PathSafetyLayer);
			//ClearLayer(MazeStartEndLayer)
			//ClearLayer(ObstacleDrawLayer)
			//ClearLayer(SolutionLayer)
			//ClearLayer(FilterLayer)
			//ClearLayer(TempObstacleLineLayer)
			AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
		}
		private void ClearLayer(int LayerNo)
		{
			AxMap1.ClearDrawing(LayerNo); //clear the layer before drawing new targets
			AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
		}
		private void DrawWindows(int DrawWindowNo)
		{
			float X = 0F;
			float Xmax = 0F;
			float Y = 0F;
			float Ymax = 0F;
			int WindowX = 0;
			int WindowY = 0;
			//
			if (A.PreCalculationDone == false)
			{
				A.CalculateWindowData();
				A.CreateWindoWObstalcesMatrix();
				// Exit Sub
			}
			//
			ClearLayer(WindowLayer);
			// 
			Xmax = A.MazeMinPoint.X + (A.WindowWidth * A.WindowsNoHorizontal);
			Ymax = A.MazeMinPoint.Y + (A.WindowHeight * A.WindowsNoVertical);
			//
// INSTANT C# WARNING: The step increment was not confirmed to be either positive or negative - confirm that the stopping condition is appropriate:
// ORIGINAL LINE: For X = A.MazeMinPoint.X To Xmax Step A.WindowWidth
			for (X = A.MazeMinPoint.X; X <= Xmax; X += A.WindowWidth)
			{
				AxMap1.DrawLineEx(WindowLayer, X, A.MazeMinPoint.Y, X, Ymax, 2, WindowsColor.Color);
			}
			//
// INSTANT C# WARNING: The step increment was not confirmed to be either positive or negative - confirm that the stopping condition is appropriate:
// ORIGINAL LINE: For Y = A.MazeMinPoint.Y To Ymax Step A.WindowHeight
			for (Y = A.MazeMinPoint.Y; Y <= Ymax; Y += A.WindowHeight)
			{
				AxMap1.DrawLineEx(WindowLayer, A.MazeMinPoint.X, Y, Xmax, Y, 2, WindowsColor.Color);
			}
			//
			// ClearLayer(ObstacleDrawLayer) '
			if (DrawWindowNo == -1)
			{
// INSTANT C# WARNING: The step increment was not confirmed to be either positive or negative - confirm that the stopping condition is appropriate:
// ORIGINAL LINE: For X = A.MazeMinPoint.X + (A.WindowWidth / 2) To Xmax Step A.WindowWidth
				for (X = A.MazeMinPoint.X + (A.WindowWidth / 2); X <= Xmax; X += A.WindowWidth)
				{
// INSTANT C# WARNING: The step increment was not confirmed to be either positive or negative - confirm that the stopping condition is appropriate:
// ORIGINAL LINE: For Y = A.MazeMinPoint.Y + (A.WindowHeight / 2) To Ymax Step A.WindowHeight
					for (Y = A.MazeMinPoint.Y + (A.WindowHeight / 2); Y <= Ymax; Y += A.WindowHeight)
					{
						WindowX = Convert.ToInt32(Convert.ToSingle(Math.Floor((X - A.MazeMinPoint.X) / (A.WindowWidth))));
						WindowY = Convert.ToInt32(Convert.ToSingle(Math.Floor((Y - A.MazeMinPoint.Y) / (A.WindowHeight))));
						//
						AxMap1.DrawLabelEx(ObstacleDrawLayer, "W" + WindowX.ToString() + "," + WindowY.ToString() + "," + A.ObstacleWindowSort[WindowX, WindowY].Count.ToString(), X, Y, 0);
					}
				}
			}
		}
		private void DrawObstacle()
		{
			int S = 0;
			int X = 0;
			int Y = 0;
			//
			ClearLayer(ObstacleDrawLayer);
			//
			try
			{
				AxMap1.DrawCircleEx(MazeStartEndLayer, A.MazeStartNode.NodePoint.X, A.MazeStartNode.NodePoint.Y, A.SafeDistance * 4, MazeStartPointColor.Color, true);
				AxMap1.DrawCircleEx(MazeStartEndLayer, A.MazeEndNode.NodePoint.X, A.MazeEndNode.NodePoint.Y, A.SafeDistance * 4, MazeEndPointColor.Color, true);
				//
				if (CheckBoxDrawObstacleNumber.Checked == true)
				{
					for (S = 0; S < A.Obstacles.Count; S++)
					{
						X = (A.Obstacles[S].Points[ClassPathPlan.ObstaclePointTypeStart].X + A.Obstacles[S].Points[ClassPathPlan.ObstaclePointLastTypeIndex].X) / 2;
						Y = (A.Obstacles[S].Points[ClassPathPlan.ObstaclePointTypeStart].Y + A.Obstacles[S].Points[ClassPathPlan.ObstaclePointLastTypeIndex].Y) / 2;
						//AxMap1.DrawLabelEx(ObstacleDrawLayer, A.Obstacles(S).HexagonNumber.ToString + "," + A.Obstacles(S).DistanceToStartPoint.ToString, X, Y, 0)
						AxMap1.DrawLabelEx(ObstacleDrawLayer, (S + 1).ToString(), X, Y, 0);
						//AxMap1.DrawLabelEx(ObstacleDrawLayer, A.Obstacles(S).ObstacleWindowX.ToString + "," + A.Obstacles(S).ObstacleWindowY.ToString, X, Y, 0)
						//If A.Obstacles(S).InsideSearchRegion = True Then
						//    AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles(S).Points(A.ObstaclePointTypeStart).X, A.Obstacles(S).Points(A.ObstaclePointTypeStart).Y, A.Obstacles(S).Points(A.ObstaclePointTypeEnd).X, A.Obstacles(S).Points(A.ObstaclePointTypeEnd).Y, 2, MazeWallColor)
						//Else
						//    AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles(S).Points(A.ObstaclePointTypeStart).X, A.Obstacles(S).Points(A.ObstaclePointTypeStart).Y, A.Obstacles(S).Points(A.ObstaclePointTypeEnd).X, A.Obstacles(S).Points(A.ObstaclePointTypeEnd).Y, 2, MazeWallNotSelectedColor)
						//End If
					}
				}
				else
				{
					//For S = 0 To A.Obstacles.Count - 1
					//    If A.Obstacles(S).InsideSearchRegion = True Then
					//        AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles(S).Points(A.ObstaclePointTypeStart).X, A.Obstacles(S).Points(A.ObstaclePointTypeStart).Y, A.Obstacles(S).Points(A.ObstaclePointTypeEnd).X, A.Obstacles(S).Points(A.ObstaclePointTypeEnd).Y, 2, MazeWallColor)
					//    Else
					//        AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles(S).Points(A.ObstaclePointTypeStart).X, A.Obstacles(S).Points(A.ObstaclePointTypeStart).Y, A.Obstacles(S).Points(A.ObstaclePointTypeEnd).X, A.Obstacles(S).Points(A.ObstaclePointTypeEnd).Y, 2, MazeWallNotSelectedColor)
					//    End If
					//Next
				}
				//
				uint ObstacleDrawColor = 0;
				for (S = 0; S < A.Obstacles.Count; S++)
				{
					if (A.Obstacles[S].ObstacleType == ClassPathPlan.ObstacleTypes.DynamicObsatcle)
					{
						ObstacleDrawColor = 0;
					}
					else
					{
						//If A.Obstacles(S).InsideSearchRegion = True Then
						//    AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles(S).Points(ClassPathPlan.ObstaclePointTypeStart).X, A.Obstacles(S).Points(ClassPathPlan.ObstaclePointTypeStart).Y, A.Obstacles(S).Points(ClassPathPlan.ObstaclePointLastTypeIndex).X, A.Obstacles(S).Points(ClassPathPlan.ObstaclePointLastTypeIndex).Y, 2, MazeWallColor)
						//    'AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles(S).PointsExtentended(A.ObstaclePointTypeStart).X, A.Obstacles(S).PointsExtentended(A.ObstaclePointTypeStart).Y, A.Obstacles(S).PointsExtentended(A.ObstaclePointTypeEnd).X, A.Obstacles(S).PointsExtentended(A.ObstaclePointTypeEnd).Y, 2, MazeWallColor)
						//Else
						//    AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles(S).Points(ClassPathPlan.ObstaclePointTypeStart).X, A.Obstacles(S).Points(ClassPathPlan.ObstaclePointTypeStart).Y, A.Obstacles(S).Points(ClassPathPlan.ObstaclePointLastTypeIndex).X, A.Obstacles(S).Points(ClassPathPlan.ObstaclePointLastTypeIndex).Y, 2, MazeWallNotSelectedColor)
						//    'AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles(S).PointsExtentended(A.ObstaclePointTypeStart).X, A.Obstacles(S).PointsExtentended(A.ObstaclePointTypeStart).Y, A.Obstacles(S).PointsExtentended(A.ObstaclePointTypeEnd).X, A.Obstacles(S).PointsExtentended(A.ObstaclePointTypeEnd).Y, 2, MazeWallNotSelectedColor)
						//End If
						if (A.Obstacles[S].InsideSearchRegion == true)
						{
							ObstacleDrawColor = MazeWallColor.Color;
						}
						else
						{
							ObstacleDrawColor = MazeWallNotSelectedColor.Color;
						}

					}
					AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles[S].Points[ClassPathPlan.ObstaclePointTypeStart].X, A.Obstacles[S].Points[ClassPathPlan.ObstaclePointTypeStart].Y, A.Obstacles[S].Points[ClassPathPlan.ObstaclePointLastTypeIndex].X, A.Obstacles[S].Points[ClassPathPlan.ObstaclePointLastTypeIndex].Y, 2, ObstacleDrawColor);
				}
				//
				ObstacleDrawColor = 45554545;
				if (A.MovingObstacles != null)
				{
					for (S = 0; S < A.MovingObstacles.Count(); S++)
					{
						if (A.MovingObstacles[S].BodyDefiningPoints != null)
						{
							for (var N = 0; N <= 3; N++)
							{
								AxMap1.DrawLineEx(ObstacleDrawLayer, A.MovingObstacles[S].BodyDefiningPoints[N].X, A.MovingObstacles[S].BodyDefiningPoints[N].Y, A.MovingObstacles[S].BodyDefiningPoints[N + 1].X, A.MovingObstacles[S].BodyDefiningPoints[N + 1].Y, 2, ObstacleDrawColor);
							}
						}
					}
				}

				CenterOnMaze();
			}
			catch (Exception ex)
			{
                Debug.Print(ex.Message);
				System.Diagnostics.Debugger.Break();
			}
		}


		private void DrawNodeArray(int LayerNo, ClassPathPlan.Node[] DrawnNodes, bool ClearTheLayer, bool ClosePolygon, uint DrawColor, bool DrawJoints)
		{
			int S = 0;
			int PointCount = DrawnNodes.GetUpperBound(0);
			//
			Point[] PointArray = new Point[PointCount + 1];
			for (S = 0; S <= PointCount; S++)
			{
				PointArray[S] = DrawnNodes[S].NodePoint;
			}
			//'
			DrawPointArray(LayerNo, PointArray, ClearTheLayer, ClosePolygon, DrawColor, DrawJoints);

		}
		private void DrawPointArray(int LayerNo, Point[] DrawnPoint, bool ClearTheLayer, bool ClosePolygon, uint DrawColor, bool DrawJoints)
		{
			int S = 0;
			int PointCount = DrawnPoint.GetLength(0);
			//
			if (ClearTheLayer == true)
			{
				ClearLayer(LayerNo);
				//AxMap1.ClearDrawing(LayerNo) 'clear the layer before drawing new targets
				//AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			}
			//'ClearAllLayers()
			//
			if (DrawJoints == true)
			{
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of PointCount - 3 for every iteration:
				int tempVar = PointCount - 3;
				for (S = 0; S <= tempVar; S++)
				{
					AxMap1.DrawLineEx(LayerNo, DrawnPoint[S].X, DrawnPoint[S].Y, DrawnPoint[S + 1].X, DrawnPoint[S + 1].Y, 2, DrawColor);
					AxMap1.DrawWideCircleEx(LayerNo, DrawnPoint[S + 1].X, DrawnPoint[S + 1].Y, 2, DrawColor, true, 1);
				}
				AxMap1.DrawLineEx(LayerNo, DrawnPoint[S].X, DrawnPoint[S].Y, DrawnPoint[S + 1].X, DrawnPoint[S + 1].Y, 2, DrawColor);
			}
			else
			{
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of PointCount - 2 for every iteration:
				int tempVar2 = PointCount - 2;
				for (S = 0; S <= tempVar2; S++)
				{
					AxMap1.DrawLineEx(LayerNo, DrawnPoint[S].X, DrawnPoint[S].Y, DrawnPoint[S + 1].X, DrawnPoint[S + 1].Y, 2, 234);
				}
			}
			//
			if (ClosePolygon == true)
			{
				AxMap1.DrawLineEx(LayerNo, DrawnPoint[0].X, DrawnPoint[0].Y, DrawnPoint[PointCount - 1].X, DrawnPoint[PointCount - 1].Y, 2, DrawColor);
			}
		}

		private void DrawEllipse(Point EllipseCenter, float MajorAxisLength, float MinorAxisLength, float angle, int LayerNo)
		{
			float sin_angle = 0F;
			float cos_angle = 0F;
			float theta = 0F;
			float dtheta = 0F;
			float X = 0F; // A point on the ellipse.
			float Y = 0F;
			float RX = 0F; // The point rotated.
			float RY = 0F;
			//
			Point OldPoint = new Point();
			Point Newpoint = new Point();
			//
			//'angle = A.Deg2Rad(angle) ' angle * PI / 180
			sin_angle = (float)Math.Sin(angle);
			cos_angle = (float)Math.Cos(angle);
			//
			theta = 0;
			dtheta = (float)(2 * Math.PI / 50);
			//
			// Find the first point.
			X = (float)(MajorAxisLength * Math.Cos(theta));
			Y = (float)(MinorAxisLength * Math.Sin(theta));
			//
			RX = EllipseCenter.X + X * cos_angle + Y * sin_angle;
			RY = EllipseCenter.Y - X * sin_angle + Y * cos_angle;
			OldPoint.X = Convert.ToInt32(RX);
			OldPoint.Y = Convert.ToInt32(RY);
			//
			//AxMap1.ClearDrawing(LayerNo) 'clear the layer before drawing new targets
			//AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
			ClearLayer(LayerNo);
			//
			while (theta < (float)(2 * Math.PI))
			{
				theta = theta + dtheta;
				X = (float)(MajorAxisLength * Math.Cos(theta));
				Y = (float)(MinorAxisLength * Math.Sin(theta));
				//
				Newpoint.X = Convert.ToInt32(EllipseCenter.X + X * cos_angle + Y * sin_angle);
				Newpoint.Y = Convert.ToInt32(EllipseCenter.Y - X * sin_angle + Y * cos_angle);
				//
				AxMap1.DrawLineEx(LayerNo, OldPoint.X, OldPoint.Y, Newpoint.X, Newpoint.Y, 2, ObstacleFilterColor.Color);
				OldPoint = Newpoint;
			}
		}
		private void BtnChangeMazeTarget_Click(object sender, EventArgs e)
		{
			MazeCreatingStatus = MazeCreatingStatusTypes.SelectingTarget;
			A.PathWasFound = false;
			A.FoundPaths.Clear();
		}
		public Point ConvertMapWinGisPixelToCart(_DMapEvents_MouseMoveEvent e)
		{
			double Myx = 0D;
			double Myy = 0D;
			Point TempPoint = new Point();
			AxMap1.PixelToProj(e.x, e.y, ref Myx, ref Myy);
			TempPoint.X = Convert.ToInt32(Myx);
			TempPoint.Y = Convert.ToInt32(Myy);
			return TempPoint;
		}
		public Point ConvertMapWinGisPixelToCart(AxMapWinGIS._DMapEvents_MouseDownEvent e)
		{
			double Myx = 0D;
			double Myy = 0D;
			Point TempPoint = new Point();
			//
			AxMap1.PixelToProj(e.x, e.y, ref Myx, ref Myy);
			TempPoint.X = Convert.ToInt32(Myx);
			TempPoint.Y = Convert.ToInt32(Myy);
			return TempPoint;
		}
		private void AxMap1_MouseMove(object sender, MouseEventArgs e) //'Handles AxMap1.MouseMove
		{
			Point CurrentPoint = new Point(e.X, e.Y); //' ConvertMapWinGisPixelToCart(e)
			//
			if (MazeCreatingStatus == MazeCreatingStatusTypes.SelectingObstacleEnd)
			{
				// ClearLayer(TempObstacleLineLayer)

				AxMap1.ClearDrawing(TempObstacleLineLayer); //clear the layer before drawing new targets
				//AxMap1.RemoveLayer(TempObstacleLineLayer)
				AxMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
				//'
				AxMap1.DrawLineEx(TempObstacleLineLayer, TempMazePoint.X, TempMazePoint.Y, CurrentPoint.X, CurrentPoint.Y, 2, MazeWallColor.Color);
			}
		}
#endregion
#region Mapwin Draw control

		private void AxMap1_MouseDownEvent(object sender, AxMapWinGIS._DMapEvents_MouseDownEvent e)
		{
			int ObstacleNo = A.Obstacles.Count;
			//
			//If A.InEllipse(  e.Location) = True Then
			//    Label6.Text = "inside"
			//    PictureBoxMazeOnly.CreateGraphics.FillRectangle(Brushes.Red, e.Location.X, e.Location.Y, 2, 2)
			//Else
			//    Label6.Text = "outside"
			//    PictureBoxMazeOnly.CreateGraphics.FillRectangle(Brushes.Blue, e.Location.X, e.Location.Y, 2, 2)
			//End If

			//If A.InsideRectangle(e.Location) = True Then
			//    Label6.Text = "inside"
			//    PictureBoxMazeOnly.CreateGraphics.FillRectangle(Brushes.Red, e.Location.X, e.Location.Y, 2, 2)
			//Else
			//    Label6.Text = "outside"
			//    PictureBoxMazeOnly.CreateGraphics.FillRectangle(Brushes.Blue, e.Location.X, e.Location.Y, 2, 2)
			//End If
			//If A.InsideEquilateral(e.Location) = True Then
			//    Label6.Text = "inside"
			//    PictureBoxMazeOnly.CreateGraphics.FillRectangle(Brushes.Red, e.Location.X, e.Location.Y, 2, 2)
			//Else
			//    Label6.Text = "outside"
			//    PictureBoxMazeOnly.CreateGraphics.FillRectangle(Brushes.Blue, e.Location.X, e.Location.Y, 2, 2)
			//End If
			//AxMap1.DrawCircleEx(MazeStartEndLayer, A.MazeStartPoint.X, A.MazeStartPoint.Y, 20, MazeStartPointColor, True)
			//AxMap1.DrawCircleEx(MazeStartEndLayer, A.MazeEndPoint.X, A.MazeEndPoint.Y, 20, MazeEndPointColor, True)


			if (e.button == 2 && MazeCreatingStatus == MazeCreatingStatusTypes.SelectingObstacleEnd) //right mouse button
			{
				MazeCreatingStatus = MazeCreatingStatusTypes.NotActive;
				LblDisplayStatus.Visible = false;
				return;
			}
			switch (MazeCreatingStatus)
			{
				case MazeCreatingStatusTypes.SelectingStart:
					//ClearAllLayers()
					A.MazeStartNode.NodePoint = ConvertMapWinGisPixelToCart(e);
					MazeCreatingStatus = MazeCreatingStatusTypes.SelectingTarget;
					LblDisplayStatus.Text = "Selecting Maze Target Point";
					//       
					AxMap1.DrawCircleEx(MazeStartEndLayer, A.MazeStartNode.NodePoint.X, A.MazeStartNode.NodePoint.Y, 20, MazeStartPointColor.Color, true);
					break;
				case MazeCreatingStatusTypes.SelectingTarget:
					A.FoundPaths.Clear();
					A.MazeEndNode.NodePoint = ConvertMapWinGisPixelToCart(e);
					MazeCreatingStatus = MazeCreatingStatusTypes.SelectingObstacleStart;
					LblDisplayStatus.Text = "Selecting Obstacle Start Point";
					AxMap1.DrawCircleEx(MazeStartEndLayer, A.MazeEndNode.NodePoint.X, A.MazeEndNode.NodePoint.Y, 20, MazeEndPointColor.Color, true);
					break;
				case MazeCreatingStatusTypes.SelectingObstacleStart:
					TempMazePoint = ConvertMapWinGisPixelToCart(e);
					MazeCreatingStatus = MazeCreatingStatusTypes.SelectingObstacleEnd;
					LblDisplayStatus.Text = "Selecting Obstacle End Point";
					break;
				case MazeCreatingStatusTypes.SelectingObstacleEnd:
					//Dim VisibiltyArraySize As Integer = A.ObstacleNoToArray(ObstacleNo, A.ObstaclePointTypeEnd)
					//ReDim A.NodeToNodeVisbilty(VisibiltyArraySize, VisibiltyArraySize)
					A.PreCalculationDone = false; //this to make the program recalcualtes every thing again , since an obstacke was added
					// A.PreCalculationDone = False
					ClassPathPlan.ObstacleLine NewObstacle = new ClassPathPlan.ObstacleLine();
					//
					MazeCreatingStatus = MazeCreatingStatusTypes.SelectingObstacleStart;
					LblDisplayStatus.Text = "Selecting Obstacle Start Point";
					NewObstacle.Points[ClassPathPlan.ObstaclePointTypeStart] = TempMazePoint;
					NewObstacle.Points[ClassPathPlan.ObstaclePointLastTypeIndex] = ConvertMapWinGisPixelToCart(e);
					A.Obstacles.Add(NewObstacle);
					AxMap1.DrawLineEx(ObstacleDrawLayer, A.Obstacles[ObstacleNo].Points[ClassPathPlan.ObstaclePointTypeStart].X, A.Obstacles[ObstacleNo].Points[ClassPathPlan.ObstaclePointTypeStart].Y, A.Obstacles[ObstacleNo].Points[ClassPathPlan.ObstaclePointLastTypeIndex].X, A.Obstacles[ObstacleNo].Points[ClassPathPlan.ObstaclePointLastTypeIndex].Y, 2, MazeWallColor.Color);
					break;

			}
		}
		private void BtnMapWinZoomIn_Click(object sender, EventArgs e)
		{
			AxMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn;
		}

		private void BtnMapWinZoomOut_Click(object sender, EventArgs e)
		{
			AxMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut;
		}

		private void BtnMapWinZoomExtent_Click(object sender, EventArgs e)
		{
			AxMap1.ZoomToMaxExtents();
		}

		private void BtnMapWinPan_Click(object sender, EventArgs e)
		{
			AxMap1.CursorMode = MapWinGIS.tkCursorMode.cmPan;
		}
		private void BtnMapWinNormal_Click(object sender, EventArgs e)
		{
			AxMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
		}
		private void CheckBoxApplyInitialMinimumPath_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckBoxApplyInitialMinimumPath.Checked == true)
			{
				CheckBoxApplyMinimumPath.Checked = true;
				CheckBoxApplyMinimumPointPath.Checked = true;
			}

		}
#endregion
#region Node To Node Visbilty
		public void ShowNodeToNodeVisbilty(ref DataGridView DVG)
		{
			//showing the visibilty to a grid , by creating a datatbale then assign this table as a datasource to a grid to reduce execution time  
			//
			int VisibiltyArraySize = 0; //= A.NodeToNodeVisbilty.GetLength(0)
			int x = 0;
			int y = 0;
			DataTable DatatTableNodeToNodeVisbilty = new DataTable();
			//'
			try
			{
				VisibiltyArraySize = A.NodeToNodeVisibility.GetLength(0);
			}
			catch (Exception ex)
			{
                Debug.Print(ex.Message);
                System.Diagnostics.Debugger.Break();
                return;
			}
			//
			//create the datatable coulmns
			DatatTableNodeToNodeVisbilty.Columns.Add("Node Name", Type.GetType("System.String"));
			DatatTableNodeToNodeVisbilty.Columns.Add("Maze Start", Type.GetType("System.String"));
			DatatTableNodeToNodeVisbilty.Columns.Add("Maze End  ", Type.GetType("System.String"));
			//
			for (x = 1; x <= A.Obstacles.Count; x++)
			{
				DatatTableNodeToNodeVisbilty.Columns.Add("Obs" + (x).ToString() + " St ", Type.GetType("System.String"));
				DatatTableNodeToNodeVisbilty.Columns.Add("Obs" + (x).ToString() + " nd ", Type.GetType("System.String"));
			}
			//
			//'
			for (x = 0; x < VisibiltyArraySize; x++)
			{
				DataRow NewDataRow = DatatTableNodeToNodeVisbilty.NewRow(); // DatatTableNodeToNodeVisbilty.Rows.
				//
				for (y = 1; y <= VisibiltyArraySize; y++)
				{
					switch (A.NodeToNodeVisibility[x, y - 1])
					{
						case ClassPathPlan.NodeToNodeVisibilityType.NotTested:
							NewDataRow[y] = "not tested";
							break;
							//DVG(x + 1, y).Value = "not tested"
						case ClassPathPlan.NodeToNodeVisibilityType.Visible:
							NewDataRow[y] = "visible";
							break;
						case ClassPathPlan.NodeToNodeVisibilityType.blocked:
							NewDataRow[y] = "blocked";
							break;
					}
				}
				DatatTableNodeToNodeVisbilty.Rows.Add(NewDataRow);
			}
			//
			//fill the node name column data
			DatatTableNodeToNodeVisbilty.Rows[0][0] = "Maze Start";
			DatatTableNodeToNodeVisbilty.Rows[1][0] = "Maze End";
			//
			for (x = 1; x <= A.Obstacles.Count; x++)
			{
				DatatTableNodeToNodeVisbilty.Rows[x * ClassPathPlan.ObstaclePointCount][0] = "Obs" + (x).ToString() + " St ";
				DatatTableNodeToNodeVisbilty.Rows[x * ClassPathPlan.ObstaclePointCount + 1][0] = "Obs" + (x).ToString() + " nd ";
			}
			//
			DVG.DataSource = DatatTableNodeToNodeVisbilty;
			DVG.Columns[0].Frozen = true;
		}
		private void BtnShowNodeToNodeVisbilty_Click(object sender, EventArgs e)
		{
			ShowNodeToNodeVisbilty(ref DVGNodeToNodeVisbilty);
		}
		private void DVGNodeToNodeVisbilty_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
		{
			e.Column.FillWeight = 1;
		}
#endregion


#region Multi Simualtion
		private void BtnNewMultiSimulation_Click(object sender, EventArgs e)
		{
			string ResultCSVFileName = ShowSaveFileDialog("CSV");
			if (string.IsNullOrEmpty(ResultCSVFileName))
			{
				return;
			}
			System.IO.FileInfo fi = new System.IO.FileInfo(ResultCSVFileName);
			string SimulationName = fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);
			string ResultDirectory = fi.DirectoryName;
			//
			int S  ;
			Stopwatch ProcessStopwatch = null;
			//
			int ObsatcleNo_Start = Convert.ToInt32(NumericHelper.Val(TxtObsatcleNo_Start.Text));
			int ObsatcleNo_Step = Convert.ToInt32(NumericHelper.Val(TxtObsatcleNo_Step.Text));
			int ObsatcleNo_End = Convert.ToInt32(NumericHelper.Val(TxtObsatcleNo_End.Text));
			//bool CreateImageFile = true;
			//bool CreateCSVFile = true;
			//
			int SelectedPathNuMber = 0;
			float Mazewidth = 0F;
			// 
			List<MazeSolveParameter> MultiSimlationSolutionResults = new List<MazeSolveParameter>();
			string FileName = null;
			string ResultPath = null;
			//
			int MazeType = 0;
			int ObsatcleMaxwidth = 0;
			int MazeFixedwidth = 0;
			int MAzewidthIncrease = 0;

			SetMazeSoultionParameter();
			//
			if (ObsatcleNo_Start < 1)
			{
				ObsatcleNo_Start = 1;
			}
			if (ObsatcleNo_Step < 1)
			{
				ObsatcleNo_Step = 1;
			}
			if (ObsatcleNo_End < 1)
			{
				ObsatcleNo_End = 5;
			}
			//
			if (string.IsNullOrEmpty(ResultCSVFileName))
			{
				return;
			}
			//
			MultiSimlationSolutionResults.Clear();
			//
			ObsatcleMaxwidth = Convert.ToInt32(NumericHelper.Val(TxtObsatcleMaxwidth.Text));
			//
			if (RadioBtnCreateLineRandomMaze.Checked == true)
			{
				MazeType = ClassPathPlan.RandomMazeTypes.Lines;
				MazeFixedwidth = 50;
				MAzewidthIncrease = Convert.ToInt32(1.5);
			}
			if (CreateRectangleRandomMaze.Checked == true)
			{
				MazeType = ClassPathPlan.RandomMazeTypes.Rectangles;
				MazeFixedwidth = 50;
				MAzewidthIncrease = 4;
			}
			//
			for (S = ObsatcleNo_Start; S <= ObsatcleNo_End; S += ObsatcleNo_Step)
			{
				//
				LblDisplayStatus.Text = "Creating New Maze with " + S.ToString() + " Obstacles";
				A.ClearAllData();
				Mazewidth = MazeFixedwidth + Convert.ToInt32(Math.Floor((double)(S * MAzewidthIncrease)));
				//
				A.CreateRandomMaze(MazeType, Mazewidth * 2, Mazewidth, S, ObsatcleMaxwidth);
				ProcessStopwatch = Stopwatch.StartNew();
				A.SolveMaze();
				ProcessStopwatch.Stop();
				//
				//check if maze is path  between MazeStartNode and MazeEndNode is clear / find another maze
				if (A.CheckNodeToNodeVisible(A.MazeStartNode, A.MazeEndNode) == true || A.PathWasFound == false)
				{
					while (A.CheckNodeToNodeVisible(A.MazeStartNode, A.MazeEndNode) == true || A.PathWasFound == false)
					{
						LblDisplayStatus.Text = "Found Maze with " + S.ToString() + " Obstacles has no solution , Creating another";
						//
						A.ClearAllData();
						A.CreateRandomMaze(MazeType, Mazewidth * 2, Mazewidth, S, ObsatcleMaxwidth);
						ProcessStopwatch = Stopwatch.StartNew();
						A.SolveMaze();
						ProcessStopwatch.Stop();
					}
				}
				//
				if (A.FoundPaths.Count < 1)
				{
					System.Diagnostics.Debugger.Break();
				}
				SelectedPathNuMber = 0;
				if (SelectedPathNuMber == -1)
				{
					System.Diagnostics.Debugger.Break();
				}
				//
				ResultPath = ResultDirectory + "\\Mazes\\" + S.ToString();
				//

				FileName = ResultPath + "\\" + SimulationName + "_" + "Obs_" + S.ToString();
				if (CheckBoxCreateMazeSolutionImage.Checked == true)
				{
					System.IO.Directory.CreateDirectory(ResultPath);
					SaveMazeImagetoFile(FileName + ".jpg", SelectedPathNuMber);
				}
				//
				if (CheckBoxSaveMazeToFile.Checked == true)
				{
					System.IO.Directory.CreateDirectory(ResultPath);
					SaveMazeToFile(FileName + ".csv");
				}
				//
				MultiSimlationSolutionResults.Add(GetMazeParameter((int)ProcessStopwatch.ElapsedMilliseconds, FileName, SelectedPathNuMber));
			}
			//
			System.IO.StreamWriter objWriter;
			objWriter = new System.IO.StreamWriter(ResultCSVFileName, false, System.Text.Encoding.UTF8);
			//
			objWriter.Write("No.,Obstacles No.,Active Obstacles No,Solution Time,PathLength,FoundSolutionPathNo,FoundBlockedPathNo,FoundTooLongPathNo,No of points" + "\r\n");
			for (S = 0; S < MultiSimlationSolutionResults.Count; S++)
			{
				objWriter.Write((S + 1).ToString() + "," + MultiSimlationSolutionResults[S].TotalObstaclesNo.ToString() + "," + MultiSimlationSolutionResults[S].ActiveObstaclesNo.ToString() + "," + MultiSimlationSolutionResults[S].SoultionTime.ToString() + "," + MultiSimlationSolutionResults[S].PathLength.ToString() + "," + MultiSimlationSolutionResults[S].FoundSolutionPathNo.ToString() + "," + MultiSimlationSolutionResults[S].FoundBlockedPathNo.ToString() + "," + MultiSimlationSolutionResults[S].FoundTooLongPathNo.ToString() + "," + MultiSimlationSolutionResults[S].SolutionPointsNo + "," + MultiSimlationSolutionResults[S].FileName + "\r\n");
			}
			//
			objWriter.Close();
			//
			Microsoft.VisualBasic.Interaction.Beep();
			MessageBox.Show("mulitple maze solving done successfully");
		}
		private MazeSolveParameter GetMazeParameter(int MazeSolveTime, string SavedMazeFileName, int SelectedPathNuMber)
		{
			MazeSolveParameter CurrentMazeparameter = new MazeSolveParameter();
			int ActiveObsatclesNo = 0;
			//
			//ActiveObsatclesNo = 0
			for (var S1 = 0; S1 < A.Obstacles.Count; S1++)
			{
				if (A.Obstacles[S1].InsideSearchRegion == true)
				{
					ActiveObsatclesNo = ActiveObsatclesNo + 1;
				}
			}

			CurrentMazeparameter.TotalObstaclesNo = A.Obstacles.Count;
			CurrentMazeparameter.ActiveObstaclesNo = ActiveObsatclesNo;
			CurrentMazeparameter.SoultionTime = MazeSolveTime + 1;
			CurrentMazeparameter.FoundSolutionPathNo = A.SolPathNo;
			CurrentMazeparameter.FoundBlockedPathNo = A.BlockedPathNo;
			CurrentMazeparameter.FoundTooLongPathNo = A.TooLongPathNo;
			CurrentMazeparameter.PathLength = A.FoundPaths[SelectedPathNuMber].PathLength;
			CurrentMazeparameter.FileName = SavedMazeFileName;
			CurrentMazeparameter.SolutionPointsNo = (A.FoundPaths[SelectedPathNuMber].PathNode.Count).ToString();
			//
			return CurrentMazeparameter;
		}
		private void SaveMazeImagetoFile(string ImageFileName, int SelectedPath)
		{
			MapWinGIS.Image image = new MapWinGIS.Image();
			MapWinGIS.Extents ex = null;
			ClassPathPlan.Node[] PathPoints;
			PathPoints = A.FoundPaths[SelectedPath].PathNode.ToArray();
			//
			ClearAllLayers();
			DrawObstacle();
			DrawFilterShape();
			//
			// Draw solution Line to screen.
			if (PathPoints.Count() > 1)
			{
				DrawNodeArray(SolutionPathLayer, PathPoints, true, false, MazeSolutionColor.Color, true);
			}

			try
			{
				//Set extents to be the extents of the map
				ex = (MapWinGIS.Extents)AxMap1.Extents;
				//Take a picture of what is being displayed in map1 and store it in image
				image = (MapWinGIS.Image)AxMap1.SnapShot(ex);
				image.Save(ImageFileName);
			}
			catch (System.Exception exc)
			{
                MessageBox.Show("Maze Image Save Error " + System.Environment.NewLine+ exc.Message);  
			}

		}
		private void BtnContMultiSimulation_Click(object sender, EventArgs e)
		{
			string ResultCSVFileName = ShowSaveFileDialog("CSV");
			//
			Stopwatch ProcessStopwatch = null;
            //
            // MazeSolveParameter CurrentMazeparameter = new MazeSolveParameter();
			List<MazeSolveParameter> MultiSimlationSolutionResults = new List<MazeSolveParameter>();
			List<MazeSolveParameter> SortedMultiSimlationSolutionResults = new List<MazeSolveParameter>();
			//
			if (string.IsNullOrEmpty(ResultCSVFileName))
			{
				return;
			}
			//
			System.IO.FileInfo fi = new System.IO.FileInfo(ResultCSVFileName);
			string SimulationName = fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length); // New FileInfo(ResultCSVFileName).Name
			string ResultFileName = null;

			//
			try
			{
				//
				FolderBrowserDialog1.SelectedPath = Application.StartupPath;
				if (FolderBrowserDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				{
					return;
				}
				//
				string[] dirs = Directory.GetDirectories(FolderBrowserDialog1.SelectedPath, "*", SearchOption.TopDirectoryOnly);
				//
				foreach (string dir in dirs)
				{
					System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dir);
					System.IO.FileInfo[] FilesArray = di.GetFiles("*.csv");
					int ObsNo = Convert.ToInt32(NumericHelper.Val(dir.Substring(FolderBrowserDialog1.SelectedPath.Length + 1)));
					//
					if (LoadMazeFromFile(FilesArray[0].FullName) == false)
					{
						System.Diagnostics.Debugger.Break();
					}
					LblDisplayStatus.Text = "solve Maze with " + ObsNo.ToString() + " Obstacles";

					SetMazeSoultionParameter();
					//
					ProcessStopwatch = Stopwatch.StartNew();
					A.SolveMaze();
					ProcessStopwatch.Stop();
					// 
					A.SortPaths();
					MultiSimlationSolutionResults.Add(GetMazeParameter((int)ProcessStopwatch.ElapsedMilliseconds, dir, 0));
					//
					ResultFileName = dir + "\\" + SimulationName + "_" + "Obs_" + ObsNo.ToString();
					//
					if (CheckBoxSaveMazeToFile.Checked == true)
					{
						SaveMazeToFile(ResultFileName + ".csv");
					}
					//
					if (CheckBoxCreateMazeSolutionImage.Checked == true)
					{
						if (A.FoundPaths.Count < 1)
						{
							System.Diagnostics.Debugger.Break();
						}
						SaveMazeImagetoFile(ResultFileName + ".jpg", 0);
					}
				}
				//
				MultiSimlationSolutionResults = MultiSimlationSolutionResults.OrderBy((x) => x.TotalObstaclesNo).ToList();
				//
				System.IO.StreamWriter objWriter;
				objWriter = new System.IO.StreamWriter(ResultCSVFileName, false, System.Text.Encoding.UTF8);
				//
				objWriter.Write("No.,Obstacles No.,Active Obstacles No,Solution Time,PathLength,FoundSolutionPathNo,FoundBlockedPathNo,FoundTooLongPathNo" + "\r\n");
				for (var S = 0; S < MultiSimlationSolutionResults.Count; S++)
				{
					objWriter.Write((S + 1).ToString() + "," + MultiSimlationSolutionResults[S].TotalObstaclesNo.ToString() + "," + MultiSimlationSolutionResults[S].ActiveObstaclesNo.ToString() + "," + MultiSimlationSolutionResults[S].SoultionTime.ToString() + "," + MultiSimlationSolutionResults[S].PathLength.ToString() + "," + MultiSimlationSolutionResults[S].FoundSolutionPathNo.ToString() + "," + MultiSimlationSolutionResults[S].FoundBlockedPathNo.ToString() + "," + MultiSimlationSolutionResults[S].FoundTooLongPathNo.ToString() + "," + MultiSimlationSolutionResults[S].SolutionPointsNo + "," + MultiSimlationSolutionResults[S].FileName + "\r\n");
				}
				//
				objWriter.Close();

			}
			catch (Exception f)
			{
				Console.WriteLine("Multi Simulation process failed", f.ToString());
				return;
			}
			//
			Microsoft.VisualBasic.Interaction.Beep();
			MessageBox.Show("mulitple maze solving done successfully");
		}

		private void BTNTemp_Click(object sender, EventArgs e)
		{
			//A.CalculateWindowData()
			//A.SortObstacles()
			//DrawObstacle()

			//Dim Angle, X1, Y1, X2, Y2 As Integer
			//Dim Origin As Point = New Point(100, 100)
			//ClearLayer(WindowLayer)
			//For Angle = 0 To 359
			//    X1 = 100 * (1 + Math.Cos((Angle) * 3.14159265358979 / 180))
			//    Y1 = 100 * (1 + Math.Sin((Angle) * 3.14159265358979 / 180))
			//    '
			//    X2 = 100 * (1 + 1.3 * Math.Cos((Angle) * 3.14159265358979 / 180))
			//    Y2 = 100 * (1 + 1.3 * Math.Sin((Angle) * 3.14159265358979 / 180))

			//    'AxMap1.DrawLineEx(WindowLayer, 100, 100, X, Y, 2, WindowsColor)
			//    Dim Point1 As Point = New Point(X1, Y1)
			//    Dim Point2 As Point = New Point(X2, Y2)
			//    'Dim point2, point3 As Point
			//    A.ExtendLine(Point1, Point2, 20, Point1, Point2)
			//    AxMap1.DrawLineEx(WindowLayer, Point1.X, Point1.Y, Point2.X, Point2.Y, 2, WindowsColor)

			//Next


		}











#endregion
#region 
		private void BtnStartSimulation_Click(object sender, EventArgs e)
		{
			int SimulatedSolutionPathIndex = ComboPathesFound.SelectedIndex;
			if (A.FoundPaths.Count == 0)
			{
				MessageBox.Show("Solve the maze first to get a suitable path from the solutions");
				return;
			}
			if (SimulatedSolutionPathIndex < 0)
			{
				ComboPathesFound.SelectedIndex = 0;
				SimulatedSolutionPathIndex = 0;
			}
			//'
			float tempVar =  A.SimulationTime ;
			A.StartSimulation(ref MySimulatedVehicle, A.FoundPaths[SimulatedSolutionPathIndex], ref A.SimulatedSolutionPathCurrentTargetNode, ref tempVar);
				A.SimulationTime = tempVar;
			//'
			SimulationTimer.Enabled = true;
		}

		private void SimulationTimer_Tick(object sender, EventArgs e)
		{
			int SimulatedSolutionPathIndex = ComboPathesFound.SelectedIndex;
			SimulationTimer.Enabled = A.OneStepSimulation(ref MySimulatedVehicle, A.FoundPaths[SimulatedSolutionPathIndex], ref A.SimulatedSolutionPathCurrentTargetNode, ref A.SimulationTime, 1);
			LblSimulationTime.Text = "Simulation Time : " + A.SimulationTime.ToString() + " s ";
			LblMyCourse.Text = " My Course :" + Math.Floor(MySimulatedVehicle.Course * 180 / Math.PI).ToString();
			//'
			ClearLayer(SimualtionLayer);
			//'
			AxMap1.DrawCircleEx(SimualtionLayer, MySimulatedVehicle.PositionSimulatedX, MySimulatedVehicle.PositionSimulatedY, 10, 54864, true);
			AxMap1.DrawLabelEx(SimualtionLayer, "Ship", MySimulatedVehicle.PositionSimulatedX + 20, MySimulatedVehicle.PositionSimulatedY, 0);
			//'
			for (var s = 0; s < A.MovingObstacles.Count(); s++)
			{
				AxMap1.DrawCircleEx(SimualtionLayer, A.MovingObstacles[s].PositionSimulatedX, A.MovingObstacles[s].PositionSimulatedY, 10, 1864, true);
				AxMap1.DrawLabelEx(SimualtionLayer, A.MovingObstacles[s].Name, A.MovingObstacles[s].PositionSimulatedX, A.MovingObstacles[s].PositionSimulatedY + 20, 0);
				AxMap1.DrawLineEx(SimualtionLayer, A.MovingObstacles[s].FuturePosition.X, A.MovingObstacles[s].FuturePosition.Y, A.MovingObstacles[s].Position.X, A.MovingObstacles[s].Position.Y, 2, 666);
			}
			//AxMap1.DrawCircleEx(SimualtionLayer, A.TempPathintersectionPoint.X, A.TempPathintersectionPoint.Y, 5, 666, True)
			AxMap1.DrawLineEx(SimualtionLayer, A.MazeStartNode.NodePoint.X, A.MazeStartNode.NodePoint.Y, A.MazeEndNode.NodePoint.X, A.MazeEndNode.NodePoint.Y, 2, 234);
		}

		private void BtnStopSimulation_Click(object sender, EventArgs e)
		{
			SimulationTimer.Enabled = !SimulationTimer.Enabled;
		}

		private void BtnEvaluateSolutionPathsDynamics_Click(object sender, EventArgs e)
		{
			if (A.FoundPaths.Count == 0)
			{
				MessageBox.Show("Solve the maze first to get a suitable path from the solutions");
				return;
			}
			int s = A.EvaluateSolutionPathsDynamics();
			ComboPathesFound.SelectedIndex = s;
		}




#endregion
	}

}
