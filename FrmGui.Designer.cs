using System.IO;
using AxMapWinGIS;

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
	public partial class FrmGui : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGui));
            this.TableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtEquilateralAngle = new System.Windows.Forms.TextBox();
            this.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.TableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtEllipseMinorAxisToStartEndDistanceRatio = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtEllipsMajorAxisToStartEndDistanceRatio = new System.Windows.Forms.TextBox();
            this.Label36 = new System.Windows.Forms.Label();
            this.TxtHexagonHeightRatio = new System.Windows.Forms.TextBox();
            this.RadioButtonFilterByESOVG = new System.Windows.Forms.RadioButton();
            this.RadioButtonFilterByECoVG = new System.Windows.Forms.RadioButton();
            this.RadioButtonFilterByDVGRectangle = new System.Windows.Forms.RadioButton();
            this.RadioButtonFilterbyHexagon = new System.Windows.Forms.RadioButton();
            this.Label17 = new System.Windows.Forms.Label();
            this.TableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtHexagonAngle = new System.Windows.Forms.TextBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.TxtRectangleHeightToStartEndDistanceRatio = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.TxtRectangleWidthExtensionToStartEndDistanceRatio = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.CheckBoxClearPreviousPathonEachIteration = new System.Windows.Forms.CheckBox();
            this.TableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.Label18 = new System.Windows.Forms.Label();
            this.CheckBoxApplyIterativeHexagon = new System.Windows.Forms.CheckBox();
            this.TxtHexagonHeightIncreasePercent = new System.Windows.Forms.TextBox();
            this.RadioButtonNoFilter = new System.Windows.Forms.RadioButton();
            this.TabPageObstacleFilterType = new System.Windows.Forms.TabPage();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.CheckBoxDrawOptimizedPath = new System.Windows.Forms.CheckBox();
            this.CheckBoxDrawWindowsNo = new System.Windows.Forms.CheckBox();
            this.Label34 = new System.Windows.Forms.Label();
            this.TxtInitialExpansionAngle = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.TxtSafteyMaxPathIncreaseRatio = new System.Windows.Forms.TextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label32 = new System.Windows.Forms.Label();
            this.CheckBoxSortObstacles = new System.Windows.Forms.CheckBox();
            this.CheckBoxApplyRoughMinPath = new System.Windows.Forms.CheckBox();
            this.CheckBoxApplyMinimumPointPath = new System.Windows.Forms.CheckBox();
            this.CheckBoxApplyMinimumPath = new System.Windows.Forms.CheckBox();
            this.TableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtStatMinimumPathLength = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.TxtMinimumPathLengthIncreaseStep = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.Label35 = new System.Windows.Forms.Label();
            this.BtnShowNodeToNodeVisbilty = new System.Windows.Forms.Button();
            this.CheckBoxShowNodeToNodeVisbilty = new System.Windows.Forms.CheckBox();
            this.DVGNodeToNodeVisbilty = new System.Windows.Forms.DataGridView();
            this.TabPageVisibilityMatrices = new System.Windows.Forms.TabPage();
            this.CheckBoxApplyInitialMinimumPath = new System.Windows.Forms.CheckBox();
            this.TabPagePathOptimize = new System.Windows.Forms.TabPage();
            this.TableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOptimizePath = new System.Windows.Forms.Button();
            this.TableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.ListBoxMazeSolutionLog = new System.Windows.Forms.ListBox();
            this.TabPageSolveMethod = new System.Windows.Forms.TabPage();
            this.TableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.RadioButtonDynamicHexagon = new System.Windows.Forms.RadioButton();
            this.RadioButtonHexagon = new System.Windows.Forms.RadioButton();
            this.RadioButtonArnaootFireLine = new System.Windows.Forms.RadioButton();
            this.RadioButtonUseDijkstra = new System.Windows.Forms.RadioButton();
            this.TableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.Label8 = new System.Windows.Forms.Label();
            this.TxtSafeDistance = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.TxtSafeDistanceToNodeExtensionDistance = new System.Windows.Forms.TextBox();
            this.CheckBoxDrawSplineOptimizedPath = new System.Windows.Forms.CheckBox();
            this.BtnLoadMaze = new System.Windows.Forms.Button();
            this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Label1 = new System.Windows.Forms.Label();
            this.ComboPathesFound = new System.Windows.Forms.ComboBox();
            this.CheckBoxShowSoultionsOnly = new System.Windows.Forms.CheckBox();
            this.LblCalculationTimeStopWatch = new System.Windows.Forms.Label();
            this.DGVOptimizedPath = new System.Windows.Forms.DataGridView();
            this.Label22 = new System.Windows.Forms.Label();
            this.LblPathTypes = new System.Windows.Forms.Label();
            this.LblCalculationTimeClock = new System.Windows.Forms.Label();
            this.TabPageMaze = new System.Windows.Forms.TabPage();
            this.TableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.Label20 = new System.Windows.Forms.Label();
            this.BtnSaveMaze = new System.Windows.Forms.Button();
            this.BtnNewMaze = new System.Windows.Forms.Button();
            this.BtnChangeMazeTarget = new System.Windows.Forms.Button();
            this.TableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.RadioButtonCreateRectangle = new System.Windows.Forms.RadioButton();
            this.Label24 = new System.Windows.Forms.Label();
            this.BtnCreateRndMaze = new System.Windows.Forms.Button();
            this.RadioButtonCreateLine = new System.Windows.Forms.RadioButton();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.TxtMazeHeight = new System.Windows.Forms.TextBox();
            this.TxtMazeWidth = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.TxtObstacleMaxLength = new System.Windows.Forms.TextBox();
            this.TxtObstacleNo = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.DGVPath = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDrawObstacles = new System.Windows.Forms.Button();
            this.BtnDrawWindows = new System.Windows.Forms.Button();
            this.CheckBoxDrawWindows = new System.Windows.Forms.CheckBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.CheckBoxDrawLine = new System.Windows.Forms.CheckBox();
            this.CheckBoxDrawObstacleNumber = new System.Windows.Forms.CheckBox();
            this.CheckBoxDrawSpline = new System.Windows.Forms.CheckBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.PictureBoxMAzeColorSelection = new System.Windows.Forms.PictureBox();
            this.ComboBoxElementsColor = new System.Windows.Forms.ComboBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.LblDisplayStatus = new System.Windows.Forms.Label();
            this.BTNTemp = new System.Windows.Forms.Button();
            this.BtnMapWinNormal = new System.Windows.Forms.Button();
            this.BtnMapWinPan = new System.Windows.Forms.Button();
            this.TableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.LblPathData = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.BtnFindPathes = new System.Windows.Forms.Button();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnClearData = new System.Windows.Forms.Button();
            this.BtnMapWinZoomExtent = new System.Windows.Forms.Button();
            this.BtnMapWinZoomOut = new System.Windows.Forms.Button();
            this.BtnMapWinZoomIn = new System.Windows.Forms.Button();
            this.AxMap1 = new AxMapWinGIS.AxMap();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPagePaths = new System.Windows.Forms.TabPage();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.TabPageDynamicObstacle = new System.Windows.Forms.TabPage();
            this.TableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            this.LblMyCourse = new System.Windows.Forms.Label();
            this.BtnEvaluateSolutionPathsDynamics = new System.Windows.Forms.Button();
            this.TxtMySpeed = new System.Windows.Forms.TextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.BtnStartSimulation = new System.Windows.Forms.Button();
            this.BtnStopSimulation = new System.Windows.Forms.Button();
            this.LblSimulationTime = new System.Windows.Forms.Label();
            this.DGVDynamicObstacles = new System.Windows.Forms.DataGridView();
            this.CheckBoxIncludeDynamicObstacles = new System.Windows.Forms.CheckBox();
            this.TabPageDraw = new System.Windows.Forms.TabPage();
            this.TabPageMultiSimulation = new System.Windows.Forms.TabPage();
            this.TableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.CreateRectangleRandomMaze = new System.Windows.Forms.RadioButton();
            this.Label26 = new System.Windows.Forms.Label();
            this.Label27 = new System.Windows.Forms.Label();
            this.TxtObsatcleNo_Step = new System.Windows.Forms.TextBox();
            this.TxtObsatcleNo_Start = new System.Windows.Forms.TextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.Label29 = new System.Windows.Forms.Label();
            this.TxtObsatcleNo_End = new System.Windows.Forms.TextBox();
            this.RadioBtnCreateLineRandomMaze = new System.Windows.Forms.RadioButton();
            this.BtnNewMultiSimulation = new System.Windows.Forms.Button();
            this.BtnContMultiSimulation = new System.Windows.Forms.Button();
            this.CheckBoxSaveMazeToFile = new System.Windows.Forms.CheckBox();
            this.CheckBoxCreateMazeSolutionImage = new System.Windows.Forms.CheckBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.TxtObsatcleMaxwidth = new System.Windows.Forms.TextBox();
            this.TableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SimulationTimer = new System.Windows.Forms.Timer(this.components);
            this.TableLayoutPanel18.SuspendLayout();
            this.TableLayoutPanel19.SuspendLayout();
            this.TableLayoutPanel7.SuspendLayout();
            this.TableLayoutPanel20.SuspendLayout();
            this.TableLayoutPanel14.SuspendLayout();
            this.TableLayoutPanel5.SuspendLayout();
            this.TabPageObstacleFilterType.SuspendLayout();
            this.TableLayoutPanel6.SuspendLayout();
            this.TableLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DVGNodeToNodeVisbilty)).BeginInit();
            this.TabPageVisibilityMatrices.SuspendLayout();
            this.TabPagePathOptimize.SuspendLayout();
            this.TableLayoutPanel16.SuspendLayout();
            this.TableLayoutPanel21.SuspendLayout();
            this.TabPageSolveMethod.SuspendLayout();
            this.TableLayoutPanel22.SuspendLayout();
            this.TableLayoutPanel15.SuspendLayout();
            this.TableLayoutPanel23.SuspendLayout();
            this.TableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOptimizedPath)).BeginInit();
            this.TabPageMaze.SuspendLayout();
            this.TableLayoutPanel9.SuspendLayout();
            this.TableLayoutPanel10.SuspendLayout();
            this.TableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPath)).BeginInit();
            this.TableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMAzeColorSelection)).BeginInit();
            this.TableLayoutPanel8.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxMap1)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.TabPagePaths.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            this.TabPageDynamicObstacle.SuspendLayout();
            this.TableLayoutPanel24.SuspendLayout();
            this.TableLayoutPanel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDynamicObstacles)).BeginInit();
            this.TabPageDraw.SuspendLayout();
            this.TabPageMultiSimulation.SuspendLayout();
            this.TableLayoutPanel12.SuspendLayout();
            this.TableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel18
            // 
            this.TableLayoutPanel18.ColumnCount = 4;
            this.TableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.94386F));
            this.TableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.89833F));
            this.TableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.10774F));
            this.TableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.89833F));
            this.TableLayoutPanel18.Controls.Add(this.TxtEquilateralAngle, 3, 0);
            this.TableLayoutPanel18.Controls.Add(this.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio, 1, 0);
            this.TableLayoutPanel18.Controls.Add(this.Label15, 0, 0);
            this.TableLayoutPanel18.Controls.Add(this.Label16, 2, 0);
            this.TableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel18.Location = new System.Drawing.Point(3, 111);
            this.TableLayoutPanel18.Name = "TableLayoutPanel18";
            this.TableLayoutPanel18.RowCount = 1;
            this.TableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel18.Size = new System.Drawing.Size(515, 48);
            this.TableLayoutPanel18.TabIndex = 415;
            // 
            // TxtEquilateralAngle
            // 
            this.TxtEquilateralAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEquilateralAngle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEquilateralAngle.Location = new System.Drawing.Point(450, 3);
            this.TxtEquilateralAngle.Name = "TxtEquilateralAngle";
            this.TxtEquilateralAngle.Size = new System.Drawing.Size(62, 30);
            this.TxtEquilateralAngle.TabIndex = 24;
            this.TxtEquilateralAngle.Text = "30";
            // 
            // TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio
            // 
            this.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio.Location = new System.Drawing.Point(224, 3);
            this.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio.Name = "TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio";
            this.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio.Size = new System.Drawing.Size(60, 30);
            this.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio.TabIndex = 22;
            this.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio.Text = "0";
            // 
            // Label15
            // 
            this.Label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label15.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(3, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(215, 48);
            this.Label15.TabIndex = 21;
            this.Label15.Text = "Equilateral Major Axis Ratio";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label16
            // 
            this.Label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label16.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(290, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(154, 48);
            this.Label16.TabIndex = 23;
            this.Label16.Text = "Equilateral Angle";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label19
            // 
            this.Label19.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(3, 0);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(72, 37);
            this.Label19.TabIndex = 391;
            this.Label19.Text = "Hexagon Height  Ratio";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TableLayoutPanel19
            // 
            this.TableLayoutPanel19.ColumnCount = 5;
            this.TableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.02198F));
            this.TableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.97802F));
            this.TableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.TableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.TableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.TableLayoutPanel19.Controls.Add(this.TxtEllipseMinorAxisToStartEndDistanceRatio, 4, 0);
            this.TableLayoutPanel19.Controls.Add(this.Label3, 0, 0);
            this.TableLayoutPanel19.Controls.Add(this.TxtEllipsMajorAxisToStartEndDistanceRatio, 1, 0);
            this.TableLayoutPanel19.Controls.Add(this.Label36, 3, 0);
            this.TableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel19.Location = new System.Drawing.Point(3, 219);
            this.TableLayoutPanel19.Name = "TableLayoutPanel19";
            this.TableLayoutPanel19.RowCount = 1;
            this.TableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel19.Size = new System.Drawing.Size(515, 48);
            this.TableLayoutPanel19.TabIndex = 420;
            // 
            // TxtEllipseMinorAxisToStartEndDistanceRatio
            // 
            this.TxtEllipseMinorAxisToStartEndDistanceRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEllipseMinorAxisToStartEndDistanceRatio.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEllipseMinorAxisToStartEndDistanceRatio.Location = new System.Drawing.Point(305, 3);
            this.TxtEllipseMinorAxisToStartEndDistanceRatio.Name = "TxtEllipseMinorAxisToStartEndDistanceRatio";
            this.TxtEllipseMinorAxisToStartEndDistanceRatio.Size = new System.Drawing.Size(207, 33);
            this.TxtEllipseMinorAxisToStartEndDistanceRatio.TabIndex = 16;
            this.TxtEllipseMinorAxisToStartEndDistanceRatio.Text = "0.44";
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(3, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 48);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Elliptical Major Axis Ratio";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtEllipsMajorAxisToStartEndDistanceRatio
            // 
            this.TxtEllipsMajorAxisToStartEndDistanceRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEllipsMajorAxisToStartEndDistanceRatio.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEllipsMajorAxisToStartEndDistanceRatio.Location = new System.Drawing.Point(75, 3);
            this.TxtEllipsMajorAxisToStartEndDistanceRatio.Name = "TxtEllipsMajorAxisToStartEndDistanceRatio";
            this.TxtEllipsMajorAxisToStartEndDistanceRatio.Size = new System.Drawing.Size(14, 33);
            this.TxtEllipsMajorAxisToStartEndDistanceRatio.TabIndex = 14;
            this.TxtEllipsMajorAxisToStartEndDistanceRatio.Text = "0.5";
            // 
            // Label36
            // 
            this.Label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label36.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label36.Location = new System.Drawing.Point(104, 0);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(195, 48);
            this.Label36.TabIndex = 23;
            this.Label36.Text = "Minor Axis Ratio";
            this.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtHexagonHeightRatio
            // 
            this.TxtHexagonHeightRatio.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHexagonHeightRatio.Location = new System.Drawing.Point(116, 3);
            this.TxtHexagonHeightRatio.Name = "TxtHexagonHeightRatio";
            this.TxtHexagonHeightRatio.Size = new System.Drawing.Size(107, 33);
            this.TxtHexagonHeightRatio.TabIndex = 392;
            this.TxtHexagonHeightRatio.Text = "0.1";
            // 
            // RadioButtonFilterByESOVG
            // 
            this.RadioButtonFilterByESOVG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonFilterByESOVG.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonFilterByESOVG.Location = new System.Drawing.Point(3, 57);
            this.RadioButtonFilterByESOVG.Name = "RadioButtonFilterByESOVG";
            this.RadioButtonFilterByESOVG.Size = new System.Drawing.Size(515, 48);
            this.RadioButtonFilterByESOVG.TabIndex = 382;
            this.RadioButtonFilterByESOVG.Text = "Filter Obstacle by Equilateral Spaces Oriented Visibility Graph (ESOVG)";
            this.RadioButtonFilterByESOVG.UseVisualStyleBackColor = true;
            // 
            // RadioButtonFilterByECoVG
            // 
            this.RadioButtonFilterByECoVG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonFilterByECoVG.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonFilterByECoVG.Location = new System.Drawing.Point(3, 165);
            this.RadioButtonFilterByECoVG.Name = "RadioButtonFilterByECoVG";
            this.RadioButtonFilterByECoVG.Size = new System.Drawing.Size(515, 48);
            this.RadioButtonFilterByECoVG.TabIndex = 383;
            this.RadioButtonFilterByECoVG.Text = "Filter Obstacle by Elliptical Concave Visibility Graph (ECoVG)";
            this.RadioButtonFilterByECoVG.UseVisualStyleBackColor = true;
            // 
            // RadioButtonFilterByDVGRectangle
            // 
            this.RadioButtonFilterByDVGRectangle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonFilterByDVGRectangle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonFilterByDVGRectangle.Location = new System.Drawing.Point(3, 273);
            this.RadioButtonFilterByDVGRectangle.Name = "RadioButtonFilterByDVGRectangle";
            this.RadioButtonFilterByDVGRectangle.Size = new System.Drawing.Size(515, 48);
            this.RadioButtonFilterByDVGRectangle.TabIndex = 385;
            this.RadioButtonFilterByDVGRectangle.Text = "Filter Obstacle by Dynamic Visibility Graph";
            this.RadioButtonFilterByDVGRectangle.UseVisualStyleBackColor = true;
            // 
            // RadioButtonFilterbyHexagon
            // 
            this.RadioButtonFilterbyHexagon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonFilterbyHexagon.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonFilterbyHexagon.Location = new System.Drawing.Point(3, 381);
            this.RadioButtonFilterbyHexagon.Name = "RadioButtonFilterbyHexagon";
            this.RadioButtonFilterbyHexagon.Size = new System.Drawing.Size(515, 48);
            this.RadioButtonFilterbyHexagon.TabIndex = 389;
            this.RadioButtonFilterbyHexagon.Text = "Filter Obstacle by Hexagon";
            this.RadioButtonFilterbyHexagon.UseVisualStyleBackColor = true;
            // 
            // Label17
            // 
            this.Label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label17.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(229, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(107, 37);
            this.Label17.TabIndex = 25;
            this.Label17.Text = "Hexagon Angle";
            this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label17.Visible = false;
            // 
            // TableLayoutPanel7
            // 
            this.TableLayoutPanel7.ColumnCount = 4;
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel7.Controls.Add(this.Label19, 0, 0);
            this.TableLayoutPanel7.Controls.Add(this.TxtHexagonHeightRatio, 1, 0);
            this.TableLayoutPanel7.Controls.Add(this.Label17, 2, 0);
            this.TableLayoutPanel7.Controls.Add(this.TxtHexagonAngle, 3, 0);
            this.TableLayoutPanel7.Location = new System.Drawing.Point(3, 435);
            this.TableLayoutPanel7.Name = "TableLayoutPanel7";
            this.TableLayoutPanel7.RowCount = 1;
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel7.Size = new System.Drawing.Size(453, 37);
            this.TableLayoutPanel7.TabIndex = 414;
            // 
            // TxtHexagonAngle
            // 
            this.TxtHexagonAngle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHexagonAngle.Location = new System.Drawing.Point(342, 3);
            this.TxtHexagonAngle.Name = "TxtHexagonAngle";
            this.TxtHexagonAngle.Size = new System.Drawing.Size(108, 33);
            this.TxtHexagonAngle.TabIndex = 26;
            this.TxtHexagonAngle.Text = "30";
            this.TxtHexagonAngle.Visible = false;
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label31.Location = new System.Drawing.Point(3, 0);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(253, 33);
            this.Label31.TabIndex = 20;
            this.Label31.Text = "Obstacle Filtering";
            this.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtRectangleHeightToStartEndDistanceRatio
            // 
            this.TxtRectangleHeightToStartEndDistanceRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtRectangleHeightToStartEndDistanceRatio.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRectangleHeightToStartEndDistanceRatio.Location = new System.Drawing.Point(430, 3);
            this.TxtRectangleHeightToStartEndDistanceRatio.Name = "TxtRectangleHeightToStartEndDistanceRatio";
            this.TxtRectangleHeightToStartEndDistanceRatio.Size = new System.Drawing.Size(82, 33);
            this.TxtRectangleHeightToStartEndDistanceRatio.TabIndex = 20;
            this.TxtRectangleHeightToStartEndDistanceRatio.Text = "0.17";
            // 
            // Label9
            // 
            this.Label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(259, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(165, 48);
            this.Label9.TabIndex = 19;
            this.Label9.Text = "Rectangle Height Ratio";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label10
            // 
            this.Label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(3, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(175, 48);
            this.Label10.TabIndex = 17;
            this.Label10.Text = "Rectangle Width Ratio";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtRectangleWidthExtensionToStartEndDistanceRatio
            // 
            this.TxtRectangleWidthExtensionToStartEndDistanceRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtRectangleWidthExtensionToStartEndDistanceRatio.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRectangleWidthExtensionToStartEndDistanceRatio.Location = new System.Drawing.Point(184, 3);
            this.TxtRectangleWidthExtensionToStartEndDistanceRatio.Name = "TxtRectangleWidthExtensionToStartEndDistanceRatio";
            this.TxtRectangleWidthExtensionToStartEndDistanceRatio.Size = new System.Drawing.Size(69, 33);
            this.TxtRectangleWidthExtensionToStartEndDistanceRatio.TabIndex = 18;
            this.TxtRectangleWidthExtensionToStartEndDistanceRatio.Text = "0.0";
            // 
            // TableLayoutPanel20
            // 
            this.TableLayoutPanel20.ColumnCount = 4;
            this.TableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.25741F));
            this.TableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.66459F));
            this.TableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.38533F));
            this.TableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.69267F));
            this.TableLayoutPanel20.Controls.Add(this.TxtRectangleHeightToStartEndDistanceRatio, 3, 0);
            this.TableLayoutPanel20.Controls.Add(this.Label9, 2, 0);
            this.TableLayoutPanel20.Controls.Add(this.Label10, 0, 0);
            this.TableLayoutPanel20.Controls.Add(this.TxtRectangleWidthExtensionToStartEndDistanceRatio, 1, 0);
            this.TableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel20.Location = new System.Drawing.Point(3, 327);
            this.TableLayoutPanel20.Name = "TableLayoutPanel20";
            this.TableLayoutPanel20.RowCount = 1;
            this.TableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel20.Size = new System.Drawing.Size(515, 48);
            this.TableLayoutPanel20.TabIndex = 415;
            // 
            // TableLayoutPanel14
            // 
            this.TableLayoutPanel14.ColumnCount = 1;
            this.TableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel14.Controls.Add(this.TableLayoutPanel20, 0, 6);
            this.TableLayoutPanel14.Controls.Add(this.TableLayoutPanel7, 0, 8);
            this.TableLayoutPanel14.Controls.Add(this.TableLayoutPanel18, 0, 2);
            this.TableLayoutPanel14.Controls.Add(this.TableLayoutPanel19, 0, 4);
            this.TableLayoutPanel14.Controls.Add(this.RadioButtonFilterByESOVG, 0, 1);
            this.TableLayoutPanel14.Controls.Add(this.RadioButtonFilterByECoVG, 0, 3);
            this.TableLayoutPanel14.Controls.Add(this.RadioButtonFilterByDVGRectangle, 0, 5);
            this.TableLayoutPanel14.Controls.Add(this.RadioButtonFilterbyHexagon, 0, 7);
            this.TableLayoutPanel14.Controls.Add(this.Label31, 0, 0);
            this.TableLayoutPanel14.Controls.Add(this.CheckBoxClearPreviousPathonEachIteration, 0, 11);
            this.TableLayoutPanel14.Controls.Add(this.TableLayoutPanel5, 0, 10);
            this.TableLayoutPanel14.Controls.Add(this.RadioButtonNoFilter, 0, 9);
            this.TableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel14.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel14.Name = "TableLayoutPanel14";
            this.TableLayoutPanel14.RowCount = 13;
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.69005F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.688628F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692169F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.688628F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692169F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.688628F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692169F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.688628F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692169F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692169F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.697171F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.697976F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.699439F));
            this.TableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel14.Size = new System.Drawing.Size(521, 708);
            this.TableLayoutPanel14.TabIndex = 400;
            // 
            // CheckBoxClearPreviousPathonEachIteration
            // 
            this.CheckBoxClearPreviousPathonEachIteration.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxClearPreviousPathonEachIteration.Location = new System.Drawing.Point(3, 597);
            this.CheckBoxClearPreviousPathonEachIteration.Name = "CheckBoxClearPreviousPathonEachIteration";
            this.CheckBoxClearPreviousPathonEachIteration.Size = new System.Drawing.Size(453, 37);
            this.CheckBoxClearPreviousPathonEachIteration.TabIndex = 390;
            this.CheckBoxClearPreviousPathonEachIteration.Text = "Clear Previous Path on Each Iteration";
            this.CheckBoxClearPreviousPathonEachIteration.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel5
            // 
            this.TableLayoutPanel5.ColumnCount = 3;
            this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.06829F));
            this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.83915F));
            this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.94082F));
            this.TableLayoutPanel5.Controls.Add(this.Label18, 1, 0);
            this.TableLayoutPanel5.Controls.Add(this.CheckBoxApplyIterativeHexagon, 0, 0);
            this.TableLayoutPanel5.Controls.Add(this.TxtHexagonHeightIncreasePercent, 2, 0);
            this.TableLayoutPanel5.Location = new System.Drawing.Point(3, 543);
            this.TableLayoutPanel5.Name = "TableLayoutPanel5";
            this.TableLayoutPanel5.RowCount = 1;
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel5.Size = new System.Drawing.Size(453, 37);
            this.TableLayoutPanel5.TabIndex = 412;
            // 
            // Label18
            // 
            this.Label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label18.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label18.Location = new System.Drawing.Point(207, 0);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(147, 37);
            this.Label18.TabIndex = 27;
            this.Label18.Text = "Iterative Increase Ratio";
            this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckBoxApplyIterativeHexagon
            // 
            this.CheckBoxApplyIterativeHexagon.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxApplyIterativeHexagon.Location = new System.Drawing.Point(3, 3);
            this.CheckBoxApplyIterativeHexagon.Name = "CheckBoxApplyIterativeHexagon";
            this.CheckBoxApplyIterativeHexagon.Size = new System.Drawing.Size(164, 24);
            this.CheckBoxApplyIterativeHexagon.TabIndex = 389;
            this.CheckBoxApplyIterativeHexagon.Text = "Apply Iterative Hexagon";
            this.CheckBoxApplyIterativeHexagon.UseVisualStyleBackColor = true;
            // 
            // TxtHexagonHeightIncreasePercent
            // 
            this.TxtHexagonHeightIncreasePercent.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHexagonHeightIncreasePercent.Location = new System.Drawing.Point(360, 3);
            this.TxtHexagonHeightIncreasePercent.Name = "TxtHexagonHeightIncreasePercent";
            this.TxtHexagonHeightIncreasePercent.Size = new System.Drawing.Size(90, 33);
            this.TxtHexagonHeightIncreasePercent.TabIndex = 28;
            this.TxtHexagonHeightIncreasePercent.Text = "0.1";
            // 
            // RadioButtonNoFilter
            // 
            this.RadioButtonNoFilter.Checked = true;
            this.RadioButtonNoFilter.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonNoFilter.Location = new System.Drawing.Point(3, 489);
            this.RadioButtonNoFilter.Name = "RadioButtonNoFilter";
            this.RadioButtonNoFilter.Size = new System.Drawing.Size(453, 37);
            this.RadioButtonNoFilter.TabIndex = 384;
            this.RadioButtonNoFilter.TabStop = true;
            this.RadioButtonNoFilter.Text = "Do Not Filter Obstacles";
            this.RadioButtonNoFilter.UseVisualStyleBackColor = true;
            // 
            // TabPageObstacleFilterType
            // 
            this.TabPageObstacleFilterType.Controls.Add(this.TableLayoutPanel14);
            this.TabPageObstacleFilterType.Location = new System.Drawing.Point(4, 25);
            this.TabPageObstacleFilterType.Name = "TabPageObstacleFilterType";
            this.TabPageObstacleFilterType.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageObstacleFilterType.Size = new System.Drawing.Size(527, 714);
            this.TabPageObstacleFilterType.TabIndex = 5;
            this.TabPageObstacleFilterType.Text = "ObstacleFilterType";
            this.TabPageObstacleFilterType.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDrawOptimizedPath
            // 
            this.CheckBoxDrawOptimizedPath.AutoSize = true;
            this.CheckBoxDrawOptimizedPath.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxDrawOptimizedPath.Location = new System.Drawing.Point(3, 515);
            this.CheckBoxDrawOptimizedPath.Name = "CheckBoxDrawOptimizedPath";
            this.CheckBoxDrawOptimizedPath.Size = new System.Drawing.Size(222, 28);
            this.CheckBoxDrawOptimizedPath.TabIndex = 376;
            this.CheckBoxDrawOptimizedPath.Text = "Draw Optimized Path";
            this.CheckBoxDrawOptimizedPath.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDrawWindowsNo
            // 
            this.CheckBoxDrawWindowsNo.AutoSize = true;
            this.CheckBoxDrawWindowsNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxDrawWindowsNo.Location = new System.Drawing.Point(319, 259);
            this.CheckBoxDrawWindowsNo.Name = "CheckBoxDrawWindowsNo";
            this.CheckBoxDrawWindowsNo.Size = new System.Drawing.Size(199, 28);
            this.CheckBoxDrawWindowsNo.TabIndex = 420;
            this.CheckBoxDrawWindowsNo.Text = "Draw Windows No.";
            this.CheckBoxDrawWindowsNo.UseVisualStyleBackColor = true;
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label34.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label34.Location = new System.Drawing.Point(3, 0);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(370, 50);
            this.Label34.TabIndex = 22;
            this.Label34.Text = "Path Optimize";
            this.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtInitialExpansionAngle
            // 
            this.TxtInitialExpansionAngle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInitialExpansionAngle.Location = new System.Drawing.Point(379, 153);
            this.TxtInitialExpansionAngle.Name = "TxtInitialExpansionAngle";
            this.TxtInitialExpansionAngle.Size = new System.Drawing.Size(92, 33);
            this.TxtInitialExpansionAngle.TabIndex = 375;
            this.TxtInitialExpansionAngle.Text = "30";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(3, 150);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(370, 50);
            this.Label5.TabIndex = 374;
            this.Label5.Text = "Expansion Angle";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtSafteyMaxPathIncreaseRatio
            // 
            this.TxtSafteyMaxPathIncreaseRatio.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSafteyMaxPathIncreaseRatio.Location = new System.Drawing.Point(379, 103);
            this.TxtSafteyMaxPathIncreaseRatio.Name = "TxtSafteyMaxPathIncreaseRatio";
            this.TxtSafteyMaxPathIncreaseRatio.Size = new System.Drawing.Size(92, 33);
            this.TxtSafteyMaxPathIncreaseRatio.TabIndex = 398;
            this.TxtSafteyMaxPathIncreaseRatio.Text = "0.1";
            // 
            // Label21
            // 
            this.Label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label21.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.Location = new System.Drawing.Point(3, 100);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(370, 50);
            this.Label21.TabIndex = 397;
            this.Label21.Text = "Allow Path Increase for Saftey";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label32.Location = new System.Drawing.Point(3, 0);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(194, 33);
            this.Label32.TabIndex = 399;
            this.Label32.Text = "Solve Setting";
            this.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckBoxSortObstacles
            // 
            this.CheckBoxSortObstacles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxSortObstacles.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxSortObstacles.Location = new System.Drawing.Point(3, 3);
            this.CheckBoxSortObstacles.Name = "CheckBoxSortObstacles";
            this.CheckBoxSortObstacles.Size = new System.Drawing.Size(509, 37);
            this.CheckBoxSortObstacles.TabIndex = 390;
            this.CheckBoxSortObstacles.Text = "Sort Obstacles by distance to start point";
            this.CheckBoxSortObstacles.UseVisualStyleBackColor = true;
            // 
            // CheckBoxApplyRoughMinPath
            // 
            this.CheckBoxApplyRoughMinPath.Checked = true;
            this.CheckBoxApplyRoughMinPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxApplyRoughMinPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxApplyRoughMinPath.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxApplyRoughMinPath.Location = new System.Drawing.Point(3, 132);
            this.CheckBoxApplyRoughMinPath.Name = "CheckBoxApplyRoughMinPath";
            this.CheckBoxApplyRoughMinPath.Size = new System.Drawing.Size(509, 37);
            this.CheckBoxApplyRoughMinPath.TabIndex = 391;
            this.CheckBoxApplyRoughMinPath.Text = "Apply Rough Minimum Path";
            this.CheckBoxApplyRoughMinPath.UseVisualStyleBackColor = true;
            // 
            // CheckBoxApplyMinimumPointPath
            // 
            this.CheckBoxApplyMinimumPointPath.Checked = true;
            this.CheckBoxApplyMinimumPointPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxApplyMinimumPointPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxApplyMinimumPointPath.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxApplyMinimumPointPath.Location = new System.Drawing.Point(3, 46);
            this.CheckBoxApplyMinimumPointPath.Name = "CheckBoxApplyMinimumPointPath";
            this.CheckBoxApplyMinimumPointPath.Size = new System.Drawing.Size(509, 37);
            this.CheckBoxApplyMinimumPointPath.TabIndex = 387;
            this.CheckBoxApplyMinimumPointPath.Text = "Apply Minimum Point Path Check";
            this.CheckBoxApplyMinimumPointPath.UseVisualStyleBackColor = true;
            // 
            // CheckBoxApplyMinimumPath
            // 
            this.CheckBoxApplyMinimumPath.Checked = true;
            this.CheckBoxApplyMinimumPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxApplyMinimumPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxApplyMinimumPath.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxApplyMinimumPath.Location = new System.Drawing.Point(3, 89);
            this.CheckBoxApplyMinimumPath.Name = "CheckBoxApplyMinimumPath";
            this.CheckBoxApplyMinimumPath.Size = new System.Drawing.Size(509, 37);
            this.CheckBoxApplyMinimumPath.TabIndex = 386;
            this.CheckBoxApplyMinimumPath.Text = "Apply Minimum Path Check";
            this.CheckBoxApplyMinimumPath.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel6
            // 
            this.TableLayoutPanel6.ColumnCount = 4;
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.66009F));
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.96055F));
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.71472F));
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.5129F));
            this.TableLayoutPanel6.Controls.Add(this.Label2, 0, 0);
            this.TableLayoutPanel6.Controls.Add(this.TxtStatMinimumPathLength, 1, 0);
            this.TableLayoutPanel6.Controls.Add(this.Label6, 2, 0);
            this.TableLayoutPanel6.Controls.Add(this.TxtMinimumPathLengthIncreaseStep, 3, 0);
            this.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel6.Location = new System.Drawing.Point(3, 218);
            this.TableLayoutPanel6.Name = "TableLayoutPanel6";
            this.TableLayoutPanel6.RowCount = 1;
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel6.Size = new System.Drawing.Size(509, 37);
            this.TableLayoutPanel6.TabIndex = 413;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(3, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(175, 37);
            this.Label2.TabIndex = 394;
            this.Label2.Text = "Start Minimum Path Length";
            // 
            // TxtStatMinimumPathLength
            // 
            this.TxtStatMinimumPathLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtStatMinimumPathLength.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStatMinimumPathLength.Location = new System.Drawing.Point(184, 3);
            this.TxtStatMinimumPathLength.Name = "TxtStatMinimumPathLength";
            this.TxtStatMinimumPathLength.Size = new System.Drawing.Size(65, 33);
            this.TxtStatMinimumPathLength.TabIndex = 395;
            this.TxtStatMinimumPathLength.Text = "1.05";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(255, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(155, 37);
            this.Label6.TabIndex = 396;
            this.Label6.Text = "Minimum Path Length increase step";
            // 
            // TxtMinimumPathLengthIncreaseStep
            // 
            this.TxtMinimumPathLengthIncreaseStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMinimumPathLengthIncreaseStep.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMinimumPathLengthIncreaseStep.Location = new System.Drawing.Point(416, 3);
            this.TxtMinimumPathLengthIncreaseStep.Name = "TxtMinimumPathLengthIncreaseStep";
            this.TxtMinimumPathLengthIncreaseStep.Size = new System.Drawing.Size(90, 33);
            this.TxtMinimumPathLengthIncreaseStep.TabIndex = 397;
            this.TxtMinimumPathLengthIncreaseStep.Text = "0.05";
            // 
            // TableLayoutPanel17
            // 
            this.TableLayoutPanel17.ColumnCount = 1;
            this.TableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel17.Controls.Add(this.Label35, 0, 0);
            this.TableLayoutPanel17.Controls.Add(this.BtnShowNodeToNodeVisbilty, 0, 1);
            this.TableLayoutPanel17.Controls.Add(this.CheckBoxShowNodeToNodeVisbilty, 0, 2);
            this.TableLayoutPanel17.Controls.Add(this.DVGNodeToNodeVisbilty, 0, 3);
            this.TableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel17.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel17.Name = "TableLayoutPanel17";
            this.TableLayoutPanel17.RowCount = 4;
            this.TableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel17.Size = new System.Drawing.Size(527, 714);
            this.TableLayoutPanel17.TabIndex = 398;
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label35.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(3, 0);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(521, 40);
            this.Label35.TabIndex = 23;
            this.Label35.Text = "Path Optimize";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnShowNodeToNodeVisbilty
            // 
            this.BtnShowNodeToNodeVisbilty.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowNodeToNodeVisbilty.Location = new System.Drawing.Point(3, 43);
            this.BtnShowNodeToNodeVisbilty.Name = "BtnShowNodeToNodeVisbilty";
            this.BtnShowNodeToNodeVisbilty.Size = new System.Drawing.Size(135, 32);
            this.BtnShowNodeToNodeVisbilty.TabIndex = 397;
            this.BtnShowNodeToNodeVisbilty.Text = "Show Visibility matirx";
            this.BtnShowNodeToNodeVisbilty.UseVisualStyleBackColor = true;
            this.BtnShowNodeToNodeVisbilty.Click += new System.EventHandler(this.BtnShowNodeToNodeVisbilty_Click);
            // 
            // CheckBoxShowNodeToNodeVisbilty
            // 
            this.CheckBoxShowNodeToNodeVisbilty.AutoSize = true;
            this.CheckBoxShowNodeToNodeVisbilty.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxShowNodeToNodeVisbilty.Location = new System.Drawing.Point(3, 83);
            this.CheckBoxShowNodeToNodeVisbilty.Name = "CheckBoxShowNodeToNodeVisbilty";
            this.CheckBoxShowNodeToNodeVisbilty.Size = new System.Drawing.Size(521, 28);
            this.CheckBoxShowNodeToNodeVisbilty.TabIndex = 394;
            this.CheckBoxShowNodeToNodeVisbilty.Text = "Show Node To Node Visbilty Status automatically after calculation";
            this.CheckBoxShowNodeToNodeVisbilty.UseVisualStyleBackColor = true;
            // 
            // DVGNodeToNodeVisbilty
            // 
            this.DVGNodeToNodeVisbilty.AllowUserToAddRows = false;
            this.DVGNodeToNodeVisbilty.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DVGNodeToNodeVisbilty.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DVGNodeToNodeVisbilty.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DVGNodeToNodeVisbilty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DVGNodeToNodeVisbilty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DVGNodeToNodeVisbilty.DefaultCellStyle = dataGridViewCellStyle3;
            this.DVGNodeToNodeVisbilty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DVGNodeToNodeVisbilty.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DVGNodeToNodeVisbilty.Location = new System.Drawing.Point(3, 123);
            this.DVGNodeToNodeVisbilty.MultiSelect = false;
            this.DVGNodeToNodeVisbilty.Name = "DVGNodeToNodeVisbilty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DVGNodeToNodeVisbilty.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DVGNodeToNodeVisbilty.RowHeadersVisible = false;
            this.DVGNodeToNodeVisbilty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DVGNodeToNodeVisbilty.Size = new System.Drawing.Size(521, 588);
            this.DVGNodeToNodeVisbilty.TabIndex = 393;
            this.DVGNodeToNodeVisbilty.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DVGNodeToNodeVisbilty_ColumnAdded);
            // 
            // TabPageVisibilityMatrices
            // 
            this.TabPageVisibilityMatrices.Controls.Add(this.TableLayoutPanel17);
            this.TabPageVisibilityMatrices.Location = new System.Drawing.Point(4, 25);
            this.TabPageVisibilityMatrices.Name = "TabPageVisibilityMatrices";
            this.TabPageVisibilityMatrices.Size = new System.Drawing.Size(527, 714);
            this.TabPageVisibilityMatrices.TabIndex = 12;
            this.TabPageVisibilityMatrices.Text = "Visibility Matrices";
            this.TabPageVisibilityMatrices.UseVisualStyleBackColor = true;
            // 
            // CheckBoxApplyInitialMinimumPath
            // 
            this.CheckBoxApplyInitialMinimumPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxApplyInitialMinimumPath.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxApplyInitialMinimumPath.Location = new System.Drawing.Point(3, 175);
            this.CheckBoxApplyInitialMinimumPath.Name = "CheckBoxApplyInitialMinimumPath";
            this.CheckBoxApplyInitialMinimumPath.Size = new System.Drawing.Size(509, 37);
            this.CheckBoxApplyInitialMinimumPath.TabIndex = 388;
            this.CheckBoxApplyInitialMinimumPath.Text = "Apply Initial Minimum Path";
            this.CheckBoxApplyInitialMinimumPath.UseVisualStyleBackColor = true;
            this.CheckBoxApplyInitialMinimumPath.CheckedChanged += new System.EventHandler(this.CheckBoxApplyInitialMinimumPath_CheckedChanged);
            // 
            // TabPagePathOptimize
            // 
            this.TabPagePathOptimize.Controls.Add(this.TableLayoutPanel16);
            this.TabPagePathOptimize.Location = new System.Drawing.Point(4, 25);
            this.TabPagePathOptimize.Name = "TabPagePathOptimize";
            this.TabPagePathOptimize.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePathOptimize.Size = new System.Drawing.Size(527, 714);
            this.TabPagePathOptimize.TabIndex = 2;
            this.TabPagePathOptimize.Text = "PathOptimize";
            this.TabPagePathOptimize.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel16
            // 
            this.TableLayoutPanel16.ColumnCount = 2;
            this.TableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.18045F));
            this.TableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.81955F));
            this.TableLayoutPanel16.Controls.Add(this.Label34, 0, 0);
            this.TableLayoutPanel16.Controls.Add(this.TxtInitialExpansionAngle, 1, 3);
            this.TableLayoutPanel16.Controls.Add(this.Label5, 0, 3);
            this.TableLayoutPanel16.Controls.Add(this.TxtSafteyMaxPathIncreaseRatio, 1, 2);
            this.TableLayoutPanel16.Controls.Add(this.Label21, 0, 2);
            this.TableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel16.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel16.Name = "TableLayoutPanel16";
            this.TableLayoutPanel16.RowCount = 5;
            this.TableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanel16.Size = new System.Drawing.Size(521, 253);
            this.TableLayoutPanel16.TabIndex = 399;
            // 
            // BtnOptimizePath
            // 
            this.BtnOptimizePath.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOptimizePath.Location = new System.Drawing.Point(3, 643);
            this.BtnOptimizePath.Name = "BtnOptimizePath";
            this.BtnOptimizePath.Size = new System.Drawing.Size(120, 38);
            this.BtnOptimizePath.TabIndex = 371;
            this.BtnOptimizePath.Text = "Optimize Path";
            this.BtnOptimizePath.UseVisualStyleBackColor = true;
            this.BtnOptimizePath.Click += new System.EventHandler(this.BtnOptimizePath_Click);
            // 
            // TableLayoutPanel21
            // 
            this.TableLayoutPanel21.ColumnCount = 1;
            this.TableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel21.Controls.Add(this.CheckBoxSortObstacles, 0, 0);
            this.TableLayoutPanel21.Controls.Add(this.CheckBoxApplyRoughMinPath, 0, 3);
            this.TableLayoutPanel21.Controls.Add(this.CheckBoxApplyMinimumPointPath, 0, 1);
            this.TableLayoutPanel21.Controls.Add(this.CheckBoxApplyMinimumPath, 0, 2);
            this.TableLayoutPanel21.Controls.Add(this.TableLayoutPanel6, 0, 5);
            this.TableLayoutPanel21.Controls.Add(this.CheckBoxApplyInitialMinimumPath, 0, 4);
            this.TableLayoutPanel21.Controls.Add(this.ListBoxMazeSolutionLog, 0, 6);
            this.TableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel21.Location = new System.Drawing.Point(3, 199);
            this.TableLayoutPanel21.Name = "TableLayoutPanel21";
            this.TableLayoutPanel21.RowCount = 7;
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel21.Size = new System.Drawing.Size(515, 506);
            this.TableLayoutPanel21.TabIndex = 0;
            // 
            // ListBoxMazeSolutionLog
            // 
            this.ListBoxMazeSolutionLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxMazeSolutionLog.FormattingEnabled = true;
            this.ListBoxMazeSolutionLog.HorizontalScrollbar = true;
            this.ListBoxMazeSolutionLog.ItemHeight = 16;
            this.ListBoxMazeSolutionLog.Location = new System.Drawing.Point(3, 261);
            this.ListBoxMazeSolutionLog.Name = "ListBoxMazeSolutionLog";
            this.ListBoxMazeSolutionLog.Size = new System.Drawing.Size(509, 242);
            this.ListBoxMazeSolutionLog.TabIndex = 414;
            // 
            // TabPageSolveMethod
            // 
            this.TabPageSolveMethod.Controls.Add(this.TableLayoutPanel22);
            this.TabPageSolveMethod.Location = new System.Drawing.Point(4, 25);
            this.TabPageSolveMethod.Name = "TabPageSolveMethod";
            this.TabPageSolveMethod.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSolveMethod.Size = new System.Drawing.Size(527, 714);
            this.TabPageSolveMethod.TabIndex = 14;
            this.TabPageSolveMethod.Text = "Solve Setting";
            this.TabPageSolveMethod.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel22
            // 
            this.TableLayoutPanel22.ColumnCount = 1;
            this.TableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel22.Controls.Add(this.TableLayoutPanel21, 0, 3);
            this.TableLayoutPanel22.Controls.Add(this.Label32, 0, 0);
            this.TableLayoutPanel22.Controls.Add(this.TableLayoutPanel15, 0, 2);
            this.TableLayoutPanel22.Controls.Add(this.TableLayoutPanel23, 0, 1);
            this.TableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel22.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel22.Name = "TableLayoutPanel22";
            this.TableLayoutPanel22.RowCount = 4;
            this.TableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.738476F));
            this.TableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.44068F));
            this.TableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.87571F));
            this.TableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.17514F));
            this.TableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel22.Size = new System.Drawing.Size(521, 708);
            this.TableLayoutPanel22.TabIndex = 1;
            // 
            // TableLayoutPanel15
            // 
            this.TableLayoutPanel15.ColumnCount = 4;
            this.TableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel15.Controls.Add(this.RadioButtonDynamicHexagon, 3, 0);
            this.TableLayoutPanel15.Controls.Add(this.RadioButtonHexagon, 0, 0);
            this.TableLayoutPanel15.Controls.Add(this.RadioButtonArnaootFireLine, 1, 0);
            this.TableLayoutPanel15.Controls.Add(this.RadioButtonUseDijkstra, 0, 0);
            this.TableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel15.Location = new System.Drawing.Point(3, 123);
            this.TableLayoutPanel15.Name = "TableLayoutPanel15";
            this.TableLayoutPanel15.RowCount = 1;
            this.TableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel15.Size = new System.Drawing.Size(515, 70);
            this.TableLayoutPanel15.TabIndex = 423;
            // 
            // RadioButtonDynamicHexagon
            // 
            this.RadioButtonDynamicHexagon.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioButtonDynamicHexagon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonDynamicHexagon.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonDynamicHexagon.Location = new System.Drawing.Point(387, 3);
            this.RadioButtonDynamicHexagon.Name = "RadioButtonDynamicHexagon";
            this.RadioButtonDynamicHexagon.Size = new System.Drawing.Size(125, 64);
            this.RadioButtonDynamicHexagon.TabIndex = 423;
            this.RadioButtonDynamicHexagon.Tag = "";
            this.RadioButtonDynamicHexagon.Text = "Dynamic Hexagon";
            this.RadioButtonDynamicHexagon.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHexagon
            // 
            this.RadioButtonHexagon.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioButtonHexagon.Checked = true;
            this.RadioButtonHexagon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonHexagon.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonHexagon.Location = new System.Drawing.Point(131, 3);
            this.RadioButtonHexagon.Name = "RadioButtonHexagon";
            this.RadioButtonHexagon.Size = new System.Drawing.Size(122, 64);
            this.RadioButtonHexagon.TabIndex = 422;
            this.RadioButtonHexagon.TabStop = true;
            this.RadioButtonHexagon.Tag = "";
            this.RadioButtonHexagon.Text = "Hexagon";
            this.RadioButtonHexagon.UseVisualStyleBackColor = true;
            // 
            // RadioButtonArnaootFireLine
            // 
            this.RadioButtonArnaootFireLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioButtonArnaootFireLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonArnaootFireLine.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonArnaootFireLine.Location = new System.Drawing.Point(259, 3);
            this.RadioButtonArnaootFireLine.Name = "RadioButtonArnaootFireLine";
            this.RadioButtonArnaootFireLine.Size = new System.Drawing.Size(122, 64);
            this.RadioButtonArnaootFireLine.TabIndex = 421;
            this.RadioButtonArnaootFireLine.Tag = "";
            this.RadioButtonArnaootFireLine.Text = "Fire Line";
            this.RadioButtonArnaootFireLine.UseVisualStyleBackColor = true;
            // 
            // RadioButtonUseDijkstra
            // 
            this.RadioButtonUseDijkstra.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioButtonUseDijkstra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonUseDijkstra.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonUseDijkstra.Location = new System.Drawing.Point(3, 3);
            this.RadioButtonUseDijkstra.Name = "RadioButtonUseDijkstra";
            this.RadioButtonUseDijkstra.Size = new System.Drawing.Size(122, 64);
            this.RadioButtonUseDijkstra.TabIndex = 420;
            this.RadioButtonUseDijkstra.Text = "Dijkstra ";
            this.RadioButtonUseDijkstra.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel23
            // 
            this.TableLayoutPanel23.ColumnCount = 2;
            this.TableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel23.Controls.Add(this.Label8, 0, 1);
            this.TableLayoutPanel23.Controls.Add(this.TxtSafeDistance, 1, 0);
            this.TableLayoutPanel23.Controls.Add(this.Label4, 0, 0);
            this.TableLayoutPanel23.Controls.Add(this.TxtSafeDistanceToNodeExtensionDistance, 1, 1);
            this.TableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel23.Location = new System.Drawing.Point(3, 43);
            this.TableLayoutPanel23.Name = "TableLayoutPanel23";
            this.TableLayoutPanel23.RowCount = 2;
            this.TableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.TableLayoutPanel23.Size = new System.Drawing.Size(515, 74);
            this.TableLayoutPanel23.TabIndex = 424;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(3, 36);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(222, 38);
            this.Label8.TabIndex = 16;
            this.Label8.Text = "Factor of the safe distance obstacle to";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtSafeDistance
            // 
            this.TxtSafeDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtSafeDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSafeDistance.Location = new System.Drawing.Point(260, 3);
            this.TxtSafeDistance.Name = "TxtSafeDistance";
            this.TxtSafeDistance.Size = new System.Drawing.Size(252, 33);
            this.TxtSafeDistance.TabIndex = 14;
            this.TxtSafeDistance.Text = "6";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(3, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(155, 25);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Safe Distance";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtSafeDistanceToNodeExtensionDistance
            // 
            this.TxtSafeDistanceToNodeExtensionDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtSafeDistanceToNodeExtensionDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSafeDistanceToNodeExtensionDistance.Location = new System.Drawing.Point(260, 39);
            this.TxtSafeDistanceToNodeExtensionDistance.Name = "TxtSafeDistanceToNodeExtensionDistance";
            this.TxtSafeDistanceToNodeExtensionDistance.Size = new System.Drawing.Size(252, 33);
            this.TxtSafeDistanceToNodeExtensionDistance.TabIndex = 15;
            this.TxtSafeDistanceToNodeExtensionDistance.Text = "0.5";
            // 
            // CheckBoxDrawSplineOptimizedPath
            // 
            this.CheckBoxDrawSplineOptimizedPath.AutoSize = true;
            this.CheckBoxDrawSplineOptimizedPath.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxDrawSplineOptimizedPath.Location = new System.Drawing.Point(3, 579);
            this.CheckBoxDrawSplineOptimizedPath.Name = "CheckBoxDrawSplineOptimizedPath";
            this.CheckBoxDrawSplineOptimizedPath.Size = new System.Drawing.Size(281, 28);
            this.CheckBoxDrawSplineOptimizedPath.TabIndex = 377;
            this.CheckBoxDrawSplineOptimizedPath.Text = "Draw Spline Optimized Path";
            this.CheckBoxDrawSplineOptimizedPath.UseVisualStyleBackColor = true;
            // 
            // BtnLoadMaze
            // 
            this.BtnLoadMaze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoadMaze.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoadMaze.Location = new System.Drawing.Point(259, 67);
            this.BtnLoadMaze.Name = "BtnLoadMaze";
            this.BtnLoadMaze.Size = new System.Drawing.Size(122, 58);
            this.BtnLoadMaze.TabIndex = 14;
            this.BtnLoadMaze.Text = "Load Maze";
            this.BtnLoadMaze.UseVisualStyleBackColor = true;
            this.BtnLoadMaze.Click += new System.EventHandler(this.BtnLoadTargets_Click);
            // 
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.ColumnCount = 2;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.72686F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.27314F));
            this.TableLayoutPanel4.Controls.Add(this.Label1, 0, 0);
            this.TableLayoutPanel4.Controls.Add(this.ComboPathesFound, 1, 0);
            this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel4.Location = new System.Drawing.Point(3, 143);
            this.TableLayoutPanel4.Name = "TableLayoutPanel4";
            this.TableLayoutPanel4.RowCount = 1;
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel4.Size = new System.Drawing.Size(515, 29);
            this.TableLayoutPanel4.TabIndex = 411;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(3, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(83, 25);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Path List";
            // 
            // ComboPathesFound
            // 
            this.ComboPathesFound.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPathesFound.FormattingEnabled = true;
            this.ComboPathesFound.Location = new System.Drawing.Point(104, 3);
            this.ComboPathesFound.Name = "ComboPathesFound";
            this.ComboPathesFound.Size = new System.Drawing.Size(408, 31);
            this.ComboPathesFound.TabIndex = 7;
            this.ComboPathesFound.SelectedIndexChanged += new System.EventHandler(this.ComboPathesFound_SelectedIndexChanged);
            // 
            // CheckBoxShowSoultionsOnly
            // 
            this.CheckBoxShowSoultionsOnly.AutoSize = true;
            this.CheckBoxShowSoultionsOnly.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxShowSoultionsOnly.Location = new System.Drawing.Point(3, 3);
            this.CheckBoxShowSoultionsOnly.Name = "CheckBoxShowSoultionsOnly";
            this.CheckBoxShowSoultionsOnly.Size = new System.Drawing.Size(274, 28);
            this.CheckBoxShowSoultionsOnly.TabIndex = 379;
            this.CheckBoxShowSoultionsOnly.Text = "Show Soultions pathes Only";
            this.CheckBoxShowSoultionsOnly.UseVisualStyleBackColor = true;
            // 
            // LblCalculationTimeStopWatch
            // 
            this.LblCalculationTimeStopWatch.AutoSize = true;
            this.LblCalculationTimeStopWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCalculationTimeStopWatch.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCalculationTimeStopWatch.Location = new System.Drawing.Point(3, 35);
            this.LblCalculationTimeStopWatch.Name = "LblCalculationTimeStopWatch";
            this.LblCalculationTimeStopWatch.Size = new System.Drawing.Size(515, 35);
            this.LblCalculationTimeStopWatch.TabIndex = 393;
            this.LblCalculationTimeStopWatch.Text = "CalculationTime";
            // 
            // DGVOptimizedPath
            // 
            this.DGVOptimizedPath.AllowUserToAddRows = false;
            this.DGVOptimizedPath.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGVOptimizedPath.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVOptimizedPath.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVOptimizedPath.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVOptimizedPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVOptimizedPath.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGVOptimizedPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVOptimizedPath.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVOptimizedPath.Location = new System.Drawing.Point(3, 479);
            this.DGVOptimizedPath.MultiSelect = false;
            this.DGVOptimizedPath.Name = "DGVOptimizedPath";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVOptimizedPath.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGVOptimizedPath.RowHeadersVisible = false;
            this.DGVOptimizedPath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVOptimizedPath.Size = new System.Drawing.Size(515, 226);
            this.DGVOptimizedPath.TabIndex = 394;
            // 
            // Label22
            // 
            this.Label22.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label22.Location = new System.Drawing.Point(3, 441);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(176, 25);
            this.Label22.TabIndex = 406;
            this.Label22.Text = "Selected Path Optimized Points";
            // 
            // LblPathTypes
            // 
            this.LblPathTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPathTypes.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPathTypes.Location = new System.Drawing.Point(3, 105);
            this.LblPathTypes.Name = "LblPathTypes";
            this.LblPathTypes.Size = new System.Drawing.Size(515, 35);
            this.LblPathTypes.TabIndex = 408;
            this.LblPathTypes.Text = "LblPathTypes";
            // 
            // LblCalculationTimeClock
            // 
            this.LblCalculationTimeClock.AutoSize = true;
            this.LblCalculationTimeClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCalculationTimeClock.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCalculationTimeClock.Location = new System.Drawing.Point(3, 70);
            this.LblCalculationTimeClock.Name = "LblCalculationTimeClock";
            this.LblCalculationTimeClock.Size = new System.Drawing.Size(515, 35);
            this.LblCalculationTimeClock.TabIndex = 405;
            this.LblCalculationTimeClock.Text = "CalculationTime";
            // 
            // TabPageMaze
            // 
            this.TabPageMaze.Controls.Add(this.TableLayoutPanel9);
            this.TabPageMaze.Location = new System.Drawing.Point(4, 25);
            this.TabPageMaze.Name = "TabPageMaze";
            this.TabPageMaze.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMaze.Size = new System.Drawing.Size(527, 714);
            this.TabPageMaze.TabIndex = 8;
            this.TabPageMaze.Text = "Maze";
            this.TabPageMaze.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel9
            // 
            this.TableLayoutPanel9.ColumnCount = 1;
            this.TableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel9.Controls.Add(this.TableLayoutPanel10, 0, 1);
            this.TableLayoutPanel9.Controls.Add(this.TableLayoutPanel11, 0, 3);
            this.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel9.Name = "TableLayoutPanel9";
            this.TableLayoutPanel9.RowCount = 4;
            this.TableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TableLayoutPanel9.Size = new System.Drawing.Size(521, 708);
            this.TableLayoutPanel9.TabIndex = 401;
            // 
            // TableLayoutPanel10
            // 
            this.TableLayoutPanel10.ColumnCount = 4;
            this.TableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel10.Controls.Add(this.Label20, 0, 0);
            this.TableLayoutPanel10.Controls.Add(this.BtnSaveMaze, 0, 1);
            this.TableLayoutPanel10.Controls.Add(this.BtnNewMaze, 0, 2);
            this.TableLayoutPanel10.Controls.Add(this.BtnLoadMaze, 2, 1);
            this.TableLayoutPanel10.Controls.Add(this.BtnChangeMazeTarget, 2, 2);
            this.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel10.Location = new System.Drawing.Point(3, 23);
            this.TableLayoutPanel10.Name = "TableLayoutPanel10";
            this.TableLayoutPanel10.RowCount = 3;
            this.TableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel10.Size = new System.Drawing.Size(515, 194);
            this.TableLayoutPanel10.TabIndex = 402;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label20.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.Location = new System.Drawing.Point(3, 0);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(122, 64);
            this.Label20.TabIndex = 14;
            this.Label20.Text = "File";
            // 
            // BtnSaveMaze
            // 
            this.BtnSaveMaze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSaveMaze.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveMaze.Location = new System.Drawing.Point(3, 67);
            this.BtnSaveMaze.Name = "BtnSaveMaze";
            this.BtnSaveMaze.Size = new System.Drawing.Size(122, 58);
            this.BtnSaveMaze.TabIndex = 13;
            this.BtnSaveMaze.Text = "Save Maze";
            this.BtnSaveMaze.UseVisualStyleBackColor = true;
            this.BtnSaveMaze.Click += new System.EventHandler(this.BtnSaveTargets_Click);
            // 
            // BtnNewMaze
            // 
            this.BtnNewMaze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNewMaze.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewMaze.Location = new System.Drawing.Point(3, 131);
            this.BtnNewMaze.Name = "BtnNewMaze";
            this.BtnNewMaze.Size = new System.Drawing.Size(122, 60);
            this.BtnNewMaze.TabIndex = 15;
            this.BtnNewMaze.Text = "New Maze";
            this.BtnNewMaze.UseVisualStyleBackColor = true;
            this.BtnNewMaze.Click += new System.EventHandler(this.BtnNewMaze_Click);
            // 
            // BtnChangeMazeTarget
            // 
            this.BtnChangeMazeTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnChangeMazeTarget.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChangeMazeTarget.Location = new System.Drawing.Point(259, 131);
            this.BtnChangeMazeTarget.Name = "BtnChangeMazeTarget";
            this.BtnChangeMazeTarget.Size = new System.Drawing.Size(122, 60);
            this.BtnChangeMazeTarget.TabIndex = 400;
            this.BtnChangeMazeTarget.Text = "Change MazeTarget";
            this.BtnChangeMazeTarget.UseVisualStyleBackColor = false;
            this.BtnChangeMazeTarget.Click += new System.EventHandler(this.BtnChangeMazeTarget_Click);
            // 
            // TableLayoutPanel11
            // 
            this.TableLayoutPanel11.ColumnCount = 3;
            this.TableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TableLayoutPanel11.Controls.Add(this.RadioButtonCreateRectangle, 0, 5);
            this.TableLayoutPanel11.Controls.Add(this.Label24, 0, 0);
            this.TableLayoutPanel11.Controls.Add(this.BtnCreateRndMaze, 1, 6);
            this.TableLayoutPanel11.Controls.Add(this.RadioButtonCreateLine, 0, 1);
            this.TableLayoutPanel11.Controls.Add(this.Label12, 1, 2);
            this.TableLayoutPanel11.Controls.Add(this.Label11, 1, 1);
            this.TableLayoutPanel11.Controls.Add(this.TxtMazeHeight, 2, 2);
            this.TableLayoutPanel11.Controls.Add(this.TxtMazeWidth, 2, 1);
            this.TableLayoutPanel11.Controls.Add(this.Label14, 1, 5);
            this.TableLayoutPanel11.Controls.Add(this.TxtObstacleMaxLength, 2, 5);
            this.TableLayoutPanel11.Controls.Add(this.TxtObstacleNo, 2, 4);
            this.TableLayoutPanel11.Controls.Add(this.Label13, 1, 4);
            this.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel11.Location = new System.Drawing.Point(3, 243);
            this.TableLayoutPanel11.Name = "TableLayoutPanel11";
            this.TableLayoutPanel11.RowCount = 7;
            this.TableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.TableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.TableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.TableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.TableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.TableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.TableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.TableLayoutPanel11.Size = new System.Drawing.Size(515, 462);
            this.TableLayoutPanel11.TabIndex = 403;
            // 
            // RadioButtonCreateRectangle
            // 
            this.RadioButtonCreateRectangle.AutoSize = true;
            this.RadioButtonCreateRectangle.Checked = true;
            this.RadioButtonCreateRectangle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonCreateRectangle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonCreateRectangle.Location = new System.Drawing.Point(3, 328);
            this.RadioButtonCreateRectangle.Name = "RadioButtonCreateRectangle";
            this.RadioButtonCreateRectangle.Size = new System.Drawing.Size(165, 59);
            this.RadioButtonCreateRectangle.TabIndex = 382;
            this.RadioButtonCreateRectangle.TabStop = true;
            this.RadioButtonCreateRectangle.Text = "Create Rectangle";
            this.RadioButtonCreateRectangle.UseVisualStyleBackColor = true;
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label24.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label24.Location = new System.Drawing.Point(3, 0);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(165, 65);
            this.Label24.TabIndex = 15;
            this.Label24.Text = "Random";
            // 
            // BtnCreateRndMaze
            // 
            this.BtnCreateRndMaze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCreateRndMaze.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateRndMaze.Location = new System.Drawing.Point(174, 393);
            this.BtnCreateRndMaze.Name = "BtnCreateRndMaze";
            this.BtnCreateRndMaze.Size = new System.Drawing.Size(165, 66);
            this.BtnCreateRndMaze.TabIndex = 380;
            this.BtnCreateRndMaze.Text = "Create Radom Maze";
            this.BtnCreateRndMaze.UseVisualStyleBackColor = true;
            this.BtnCreateRndMaze.Click += new System.EventHandler(this.BtnCreateRndMaze_Click);
            // 
            // RadioButtonCreateLine
            // 
            this.RadioButtonCreateLine.AutoSize = true;
            this.RadioButtonCreateLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonCreateLine.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonCreateLine.Location = new System.Drawing.Point(3, 68);
            this.RadioButtonCreateLine.Name = "RadioButtonCreateLine";
            this.RadioButtonCreateLine.Size = new System.Drawing.Size(165, 59);
            this.RadioButtonCreateLine.TabIndex = 381;
            this.RadioButtonCreateLine.Text = "Create Line";
            this.RadioButtonCreateLine.UseVisualStyleBackColor = true;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(174, 130);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(165, 65);
            this.Label12.TabIndex = 15;
            this.Label12.Text = "Maze Height";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(174, 65);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(165, 65);
            this.Label11.TabIndex = 13;
            this.Label11.Text = "Maze Width";
            // 
            // TxtMazeHeight
            // 
            this.TxtMazeHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMazeHeight.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMazeHeight.Location = new System.Drawing.Point(345, 133);
            this.TxtMazeHeight.Name = "TxtMazeHeight";
            this.TxtMazeHeight.Size = new System.Drawing.Size(167, 33);
            this.TxtMazeHeight.TabIndex = 16;
            this.TxtMazeHeight.Text = "300";
            // 
            // TxtMazeWidth
            // 
            this.TxtMazeWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMazeWidth.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMazeWidth.Location = new System.Drawing.Point(345, 68);
            this.TxtMazeWidth.Name = "TxtMazeWidth";
            this.TxtMazeWidth.Size = new System.Drawing.Size(167, 33);
            this.TxtMazeWidth.TabIndex = 14;
            this.TxtMazeWidth.Text = "600";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(174, 325);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(165, 65);
            this.Label14.TabIndex = 19;
            this.Label14.Text = "Obstacle Max. Length";
            // 
            // TxtObstacleMaxLength
            // 
            this.TxtObstacleMaxLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtObstacleMaxLength.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObstacleMaxLength.Location = new System.Drawing.Point(345, 328);
            this.TxtObstacleMaxLength.Name = "TxtObstacleMaxLength";
            this.TxtObstacleMaxLength.Size = new System.Drawing.Size(167, 33);
            this.TxtObstacleMaxLength.TabIndex = 20;
            this.TxtObstacleMaxLength.Text = "12";
            // 
            // TxtObstacleNo
            // 
            this.TxtObstacleNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtObstacleNo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObstacleNo.Location = new System.Drawing.Point(345, 263);
            this.TxtObstacleNo.Name = "TxtObstacleNo";
            this.TxtObstacleNo.Size = new System.Drawing.Size(167, 33);
            this.TxtObstacleNo.TabIndex = 18;
            this.TxtObstacleNo.Text = "200";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(174, 260);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(165, 65);
            this.Label13.TabIndex = 17;
            this.Label13.Text = "Obstacle Number";
            // 
            // DGVPath
            // 
            this.DGVPath.AllowUserToAddRows = false;
            this.DGVPath.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGVPath.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGVPath.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPath.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGVPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVPath.DefaultCellStyle = dataGridViewCellStyle11;
            this.DGVPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPath.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVPath.Location = new System.Drawing.Point(3, 213);
            this.DGVPath.MultiSelect = false;
            this.DGVPath.Name = "DGVPath";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPath.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DGVPath.RowHeadersVisible = false;
            this.DGVPath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPath.Size = new System.Drawing.Size(515, 225);
            this.DGVPath.TabIndex = 392;
            // 
            // TableLayoutPanel13
            // 
            this.TableLayoutPanel13.ColumnCount = 2;
            this.TableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.84453F));
            this.TableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.15547F));
            this.TableLayoutPanel13.Controls.Add(this.CheckBoxDrawWindowsNo, 1, 4);
            this.TableLayoutPanel13.Controls.Add(this.BtnOptimizePath, 0, 10);
            this.TableLayoutPanel13.Controls.Add(this.CheckBoxDrawOptimizedPath, 0, 8);
            this.TableLayoutPanel13.Controls.Add(this.CheckBoxDrawSplineOptimizedPath, 0, 9);
            this.TableLayoutPanel13.Controls.Add(this.BtnDrawObstacles, 1, 5);
            this.TableLayoutPanel13.Controls.Add(this.BtnDrawWindows, 0, 5);
            this.TableLayoutPanel13.Controls.Add(this.CheckBoxDrawWindows, 0, 4);
            this.TableLayoutPanel13.Controls.Add(this.Label28, 0, 0);
            this.TableLayoutPanel13.Controls.Add(this.CheckBoxDrawLine, 0, 1);
            this.TableLayoutPanel13.Controls.Add(this.CheckBoxDrawObstacleNumber, 0, 3);
            this.TableLayoutPanel13.Controls.Add(this.CheckBoxDrawSpline, 0, 2);
            this.TableLayoutPanel13.Controls.Add(this.Label30, 0, 7);
            this.TableLayoutPanel13.Controls.Add(this.PictureBoxMAzeColorSelection, 1, 6);
            this.TableLayoutPanel13.Controls.Add(this.ComboBoxElementsColor, 0, 6);
            this.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel13.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel13.Name = "TableLayoutPanel13";
            this.TableLayoutPanel13.RowCount = 11;
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel13.Size = new System.Drawing.Size(521, 708);
            this.TableLayoutPanel13.TabIndex = 399;
            // 
            // BtnDrawObstacles
            // 
            this.BtnDrawObstacles.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDrawObstacles.Location = new System.Drawing.Point(319, 323);
            this.BtnDrawObstacles.Name = "BtnDrawObstacles";
            this.BtnDrawObstacles.Size = new System.Drawing.Size(122, 33);
            this.BtnDrawObstacles.TabIndex = 378;
            this.BtnDrawObstacles.Text = "Draw Obstacles";
            this.BtnDrawObstacles.UseVisualStyleBackColor = true;
            this.BtnDrawObstacles.Click += new System.EventHandler(this.BtnDrawObstacles_Click);
            // 
            // BtnDrawWindows
            // 
            this.BtnDrawWindows.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDrawWindows.Location = new System.Drawing.Point(3, 323);
            this.BtnDrawWindows.Name = "BtnDrawWindows";
            this.BtnDrawWindows.Size = new System.Drawing.Size(122, 33);
            this.BtnDrawWindows.TabIndex = 397;
            this.BtnDrawWindows.Text = "Draw Windows";
            this.BtnDrawWindows.UseVisualStyleBackColor = true;
            this.BtnDrawWindows.Click += new System.EventHandler(this.BtnDrawWindows_Click);
            // 
            // CheckBoxDrawWindows
            // 
            this.CheckBoxDrawWindows.AutoSize = true;
            this.CheckBoxDrawWindows.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxDrawWindows.Location = new System.Drawing.Point(3, 259);
            this.CheckBoxDrawWindows.Name = "CheckBoxDrawWindows";
            this.CheckBoxDrawWindows.Size = new System.Drawing.Size(212, 28);
            this.CheckBoxDrawWindows.TabIndex = 398;
            this.CheckBoxDrawWindows.Text = "Draw WindowsLines";
            this.CheckBoxDrawWindows.UseVisualStyleBackColor = true;
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label28.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label28.Location = new System.Drawing.Point(3, 0);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(310, 64);
            this.Label28.TabIndex = 20;
            this.Label28.Text = "Path Draw";
            this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckBoxDrawLine
            // 
            this.CheckBoxDrawLine.AutoSize = true;
            this.CheckBoxDrawLine.Checked = true;
            this.CheckBoxDrawLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxDrawLine.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxDrawLine.Location = new System.Drawing.Point(3, 67);
            this.CheckBoxDrawLine.Name = "CheckBoxDrawLine";
            this.CheckBoxDrawLine.Size = new System.Drawing.Size(123, 28);
            this.CheckBoxDrawLine.TabIndex = 369;
            this.CheckBoxDrawLine.Text = "Draw Line";
            this.CheckBoxDrawLine.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDrawObstacleNumber
            // 
            this.CheckBoxDrawObstacleNumber.AutoSize = true;
            this.CheckBoxDrawObstacleNumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxDrawObstacleNumber.Location = new System.Drawing.Point(3, 195);
            this.CheckBoxDrawObstacleNumber.Name = "CheckBoxDrawObstacleNumber";
            this.CheckBoxDrawObstacleNumber.Size = new System.Drawing.Size(238, 28);
            this.CheckBoxDrawObstacleNumber.TabIndex = 396;
            this.CheckBoxDrawObstacleNumber.Text = "Draw Obstacle Number";
            this.CheckBoxDrawObstacleNumber.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDrawSpline
            // 
            this.CheckBoxDrawSpline.AutoSize = true;
            this.CheckBoxDrawSpline.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxDrawSpline.Location = new System.Drawing.Point(3, 131);
            this.CheckBoxDrawSpline.Name = "CheckBoxDrawSpline";
            this.CheckBoxDrawSpline.Size = new System.Drawing.Size(137, 28);
            this.CheckBoxDrawSpline.TabIndex = 368;
            this.CheckBoxDrawSpline.Text = "Draw Spline";
            this.CheckBoxDrawSpline.UseVisualStyleBackColor = true;
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label30.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label30.Location = new System.Drawing.Point(3, 448);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(310, 64);
            this.Label30.TabIndex = 399;
            this.Label30.Text = "Optimized Path Draw";
            this.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PictureBoxMAzeColorSelection
            // 
            this.PictureBoxMAzeColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBoxMAzeColorSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxMAzeColorSelection.Location = new System.Drawing.Point(319, 387);
            this.PictureBoxMAzeColorSelection.Name = "PictureBoxMAzeColorSelection";
            this.PictureBoxMAzeColorSelection.Size = new System.Drawing.Size(199, 58);
            this.PictureBoxMAzeColorSelection.TabIndex = 421;
            this.PictureBoxMAzeColorSelection.TabStop = false;
            this.PictureBoxMAzeColorSelection.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // ComboBoxElementsColor
            // 
            this.ComboBoxElementsColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxElementsColor.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxElementsColor.FormattingEnabled = true;
            this.ComboBoxElementsColor.Location = new System.Drawing.Point(3, 387);
            this.ComboBoxElementsColor.Name = "ComboBoxElementsColor";
            this.ComboBoxElementsColor.Size = new System.Drawing.Size(310, 31);
            this.ComboBoxElementsColor.TabIndex = 422;
            this.ComboBoxElementsColor.SelectedIndexChanged += new System.EventHandler(this.ComboBoxElementsColor_SelectedIndexChanged);
            // 
            // Label23
            // 
            this.Label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label23.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.Location = new System.Drawing.Point(3, 0);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(256, 29);
            this.Label23.TabIndex = 407;
            this.Label23.Text = "Selected Path Points and data";
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // LblDisplayStatus
            // 
            this.LblDisplayStatus.AutoSize = true;
            this.LblDisplayStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDisplayStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDisplayStatus.ForeColor = System.Drawing.Color.Red;
            this.LblDisplayStatus.Location = new System.Drawing.Point(3, 0);
            this.LblDisplayStatus.Name = "LblDisplayStatus";
            this.LblDisplayStatus.Size = new System.Drawing.Size(817, 40);
            this.LblDisplayStatus.TabIndex = 417;
            this.LblDisplayStatus.Text = "Maze Alone";
            this.LblDisplayStatus.Visible = false;
            // 
            // BTNTemp
            // 
            this.BTNTemp.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNTemp.Location = new System.Drawing.Point(207, 3);
            this.BTNTemp.Name = "BTNTemp";
            this.BTNTemp.Size = new System.Drawing.Size(84, 68);
            this.BTNTemp.TabIndex = 420;
            this.BTNTemp.Text = "tEMP";
            this.BTNTemp.UseVisualStyleBackColor = true;
            this.BTNTemp.Click += new System.EventHandler(this.BTNTemp_Click);
            // 
            // BtnMapWinNormal
            // 
            this.BtnMapWinNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMapWinNormal.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMapWinNormal.Location = new System.Drawing.Point(717, 3);
            this.BtnMapWinNormal.Name = "BtnMapWinNormal";
            this.BtnMapWinNormal.Size = new System.Drawing.Size(97, 68);
            this.BtnMapWinNormal.TabIndex = 415;
            this.BtnMapWinNormal.Text = "Normal";
            this.BtnMapWinNormal.UseVisualStyleBackColor = true;
            this.BtnMapWinNormal.Click += new System.EventHandler(this.BtnMapWinNormal_Click);
            // 
            // BtnMapWinPan
            // 
            this.BtnMapWinPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMapWinPan.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMapWinPan.Location = new System.Drawing.Point(615, 3);
            this.BtnMapWinPan.Name = "BtnMapWinPan";
            this.BtnMapWinPan.Size = new System.Drawing.Size(96, 68);
            this.BtnMapWinPan.TabIndex = 413;
            this.BtnMapWinPan.Text = "Pan";
            this.BtnMapWinPan.UseVisualStyleBackColor = true;
            this.BtnMapWinPan.Click += new System.EventHandler(this.BtnMapWinPan_Click);
            // 
            // TableLayoutPanel8
            // 
            this.TableLayoutPanel8.ColumnCount = 2;
            this.TableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.98634F));
            this.TableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.01366F));
            this.TableLayoutPanel8.Controls.Add(this.Label23, 0, 0);
            this.TableLayoutPanel8.Controls.Add(this.LblPathData, 1, 0);
            this.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel8.Location = new System.Drawing.Point(3, 178);
            this.TableLayoutPanel8.Name = "TableLayoutPanel8";
            this.TableLayoutPanel8.RowCount = 1;
            this.TableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel8.Size = new System.Drawing.Size(515, 29);
            this.TableLayoutPanel8.TabIndex = 415;
            // 
            // LblPathData
            // 
            this.LblPathData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPathData.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPathData.Location = new System.Drawing.Point(265, 0);
            this.LblPathData.Name = "LblPathData";
            this.LblPathData.Size = new System.Drawing.Size(247, 29);
            this.LblPathData.TabIndex = 409;
            this.LblPathData.Text = "CalculationTime";
            this.LblPathData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(1504, 711);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(95, 41);
            this.Button1.TabIndex = 420;
            this.Button1.Text = "pppp";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Visible = false;
            // 
            // BtnFindPathes
            // 
            this.BtnFindPathes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFindPathes.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFindPathes.Location = new System.Drawing.Point(3, 3);
            this.BtnFindPathes.Name = "BtnFindPathes";
            this.BtnFindPathes.Size = new System.Drawing.Size(96, 68);
            this.BtnFindPathes.TabIndex = 408;
            this.BtnFindPathes.Text = "Find Pathes";
            this.BtnFindPathes.UseVisualStyleBackColor = true;
            this.BtnFindPathes.Click += new System.EventHandler(this.BtnFindPathes_Click);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel2, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.LblDisplayStatus, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.AxMap1, 0, 2);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(544, 3);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(823, 743);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 8;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.Controls.Add(this.BTNTemp, 2, 0);
            this.TableLayoutPanel2.Controls.Add(this.BtnMapWinNormal, 7, 0);
            this.TableLayoutPanel2.Controls.Add(this.BtnMapWinPan, 6, 0);
            this.TableLayoutPanel2.Controls.Add(this.BtnFindPathes, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.BtnClearData, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.BtnMapWinZoomExtent, 5, 0);
            this.TableLayoutPanel2.Controls.Add(this.BtnMapWinZoomOut, 4, 0);
            this.TableLayoutPanel2.Controls.Add(this.BtnMapWinZoomIn, 3, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(3, 43);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 1;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(817, 74);
            this.TableLayoutPanel2.TabIndex = 419;
            // 
            // BtnClearData
            // 
            this.BtnClearData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnClearData.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearData.Location = new System.Drawing.Point(105, 3);
            this.BtnClearData.Name = "BtnClearData";
            this.BtnClearData.Size = new System.Drawing.Size(96, 68);
            this.BtnClearData.TabIndex = 416;
            this.BtnClearData.Text = "Data Clear";
            this.BtnClearData.UseVisualStyleBackColor = true;
            this.BtnClearData.Click += new System.EventHandler(this.BtnClearCalculationData_Click);
            // 
            // BtnMapWinZoomExtent
            // 
            this.BtnMapWinZoomExtent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMapWinZoomExtent.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMapWinZoomExtent.Location = new System.Drawing.Point(513, 3);
            this.BtnMapWinZoomExtent.Name = "BtnMapWinZoomExtent";
            this.BtnMapWinZoomExtent.Size = new System.Drawing.Size(96, 68);
            this.BtnMapWinZoomExtent.TabIndex = 414;
            this.BtnMapWinZoomExtent.Text = "Zoom Extent";
            this.BtnMapWinZoomExtent.UseVisualStyleBackColor = true;
            this.BtnMapWinZoomExtent.Click += new System.EventHandler(this.BtnMapWinZoomExtent_Click);
            // 
            // BtnMapWinZoomOut
            // 
            this.BtnMapWinZoomOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMapWinZoomOut.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMapWinZoomOut.Location = new System.Drawing.Point(411, 3);
            this.BtnMapWinZoomOut.Name = "BtnMapWinZoomOut";
            this.BtnMapWinZoomOut.Size = new System.Drawing.Size(96, 68);
            this.BtnMapWinZoomOut.TabIndex = 412;
            this.BtnMapWinZoomOut.Text = "Zoom Out";
            this.BtnMapWinZoomOut.UseVisualStyleBackColor = true;
            this.BtnMapWinZoomOut.Click += new System.EventHandler(this.BtnMapWinZoomOut_Click);
            // 
            // BtnMapWinZoomIn
            // 
            this.BtnMapWinZoomIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMapWinZoomIn.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMapWinZoomIn.Location = new System.Drawing.Point(309, 3);
            this.BtnMapWinZoomIn.Name = "BtnMapWinZoomIn";
            this.BtnMapWinZoomIn.Size = new System.Drawing.Size(96, 68);
            this.BtnMapWinZoomIn.TabIndex = 411;
            this.BtnMapWinZoomIn.Text = "Zoom In";
            this.BtnMapWinZoomIn.UseVisualStyleBackColor = true;
            this.BtnMapWinZoomIn.Click += new System.EventHandler(this.BtnMapWinZoomIn_Click);
            // 
            // AxMap1
            // 
            this.AxMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxMap1.Enabled = true;
            this.AxMap1.Location = new System.Drawing.Point(3, 123);
            this.AxMap1.Name = "AxMap1";
            this.AxMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxMap1.OcxState")));
            this.AxMap1.Size = new System.Drawing.Size(817, 617);
            this.AxMap1.TabIndex = 420;
            this.AxMap1.MouseDownEvent += new AxMapWinGIS._DMapEvents_MouseDownEventHandler(this.AxMap1_MouseDownEvent);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPagePaths);
            this.TabControl1.Controls.Add(this.TabPageSolveMethod);
            this.TabControl1.Controls.Add(this.TabPageDynamicObstacle);
            this.TabControl1.Controls.Add(this.TabPageDraw);
            this.TabControl1.Controls.Add(this.TabPageObstacleFilterType);
            this.TabControl1.Controls.Add(this.TabPagePathOptimize);
            this.TabControl1.Controls.Add(this.TabPageMaze);
            this.TabControl1.Controls.Add(this.TabPageMultiSimulation);
            this.TabControl1.Controls.Add(this.TabPageVisibilityMatrices);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(3, 3);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(535, 743);
            this.TabControl1.TabIndex = 409;
            // 
            // TabPagePaths
            // 
            this.TabPagePaths.Controls.Add(this.TableLayoutPanel3);
            this.TabPagePaths.Location = new System.Drawing.Point(4, 25);
            this.TabPagePaths.Name = "TabPagePaths";
            this.TabPagePaths.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePaths.Size = new System.Drawing.Size(527, 714);
            this.TabPagePaths.TabIndex = 1;
            this.TabPagePaths.Text = "Paths";
            this.TabPagePaths.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 1;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.Controls.Add(this.TableLayoutPanel8, 0, 5);
            this.TableLayoutPanel3.Controls.Add(this.CheckBoxShowSoultionsOnly, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.TableLayoutPanel4, 0, 4);
            this.TableLayoutPanel3.Controls.Add(this.LblCalculationTimeStopWatch, 0, 1);
            this.TableLayoutPanel3.Controls.Add(this.DGVOptimizedPath, 0, 8);
            this.TableLayoutPanel3.Controls.Add(this.Label22, 0, 7);
            this.TableLayoutPanel3.Controls.Add(this.LblPathTypes, 0, 3);
            this.TableLayoutPanel3.Controls.Add(this.LblCalculationTimeClock, 0, 2);
            this.TableLayoutPanel3.Controls.Add(this.DGVPath, 0, 6);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 9;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(521, 708);
            this.TableLayoutPanel3.TabIndex = 410;
            // 
            // TabPageDynamicObstacle
            // 
            this.TabPageDynamicObstacle.Controls.Add(this.TableLayoutPanel24);
            this.TabPageDynamicObstacle.Location = new System.Drawing.Point(4, 25);
            this.TabPageDynamicObstacle.Name = "TabPageDynamicObstacle";
            this.TabPageDynamicObstacle.Size = new System.Drawing.Size(527, 714);
            this.TabPageDynamicObstacle.TabIndex = 15;
            this.TabPageDynamicObstacle.Text = "DynamicObstacle";
            this.TabPageDynamicObstacle.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel24
            // 
            this.TableLayoutPanel24.ColumnCount = 1;
            this.TableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel24.Controls.Add(this.TableLayoutPanel25, 0, 0);
            this.TableLayoutPanel24.Controls.Add(this.DGVDynamicObstacles, 0, 2);
            this.TableLayoutPanel24.Controls.Add(this.CheckBoxIncludeDynamicObstacles, 0, 1);
            this.TableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel24.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel24.Name = "TableLayoutPanel24";
            this.TableLayoutPanel24.RowCount = 3;
            this.TableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.05042F));
            this.TableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.TableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.18768F));
            this.TableLayoutPanel24.Size = new System.Drawing.Size(527, 714);
            this.TableLayoutPanel24.TabIndex = 0;
            // 
            // TableLayoutPanel25
            // 
            this.TableLayoutPanel25.ColumnCount = 2;
            this.TableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel25.Controls.Add(this.LblMyCourse, 1, 1);
            this.TableLayoutPanel25.Controls.Add(this.BtnEvaluateSolutionPathsDynamics, 0, 2);
            this.TableLayoutPanel25.Controls.Add(this.TxtMySpeed, 1, 0);
            this.TableLayoutPanel25.Controls.Add(this.Label37, 0, 0);
            this.TableLayoutPanel25.Controls.Add(this.BtnStartSimulation, 0, 3);
            this.TableLayoutPanel25.Controls.Add(this.BtnStopSimulation, 1, 3);
            this.TableLayoutPanel25.Controls.Add(this.LblSimulationTime, 0, 1);
            this.TableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel25.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel25.Name = "TableLayoutPanel25";
            this.TableLayoutPanel25.RowCount = 4;
            this.TableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel25.Size = new System.Drawing.Size(521, 179);
            this.TableLayoutPanel25.TabIndex = 425;
            // 
            // LblMyCourse
            // 
            this.LblMyCourse.AutoSize = true;
            this.LblMyCourse.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMyCourse.Location = new System.Drawing.Point(263, 44);
            this.LblMyCourse.Name = "LblMyCourse";
            this.LblMyCourse.Size = new System.Drawing.Size(25, 25);
            this.LblMyCourse.TabIndex = 422;
            this.LblMyCourse.Text = "0";
            this.LblMyCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnEvaluateSolutionPathsDynamics
            // 
            this.BtnEvaluateSolutionPathsDynamics.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEvaluateSolutionPathsDynamics.Location = new System.Drawing.Point(3, 91);
            this.BtnEvaluateSolutionPathsDynamics.Name = "BtnEvaluateSolutionPathsDynamics";
            this.BtnEvaluateSolutionPathsDynamics.Size = new System.Drawing.Size(254, 35);
            this.BtnEvaluateSolutionPathsDynamics.TabIndex = 424;
            this.BtnEvaluateSolutionPathsDynamics.Text = "Evaluate Solution Paths Dynamics";
            this.BtnEvaluateSolutionPathsDynamics.UseVisualStyleBackColor = true;
            this.BtnEvaluateSolutionPathsDynamics.Click += new System.EventHandler(this.BtnEvaluateSolutionPathsDynamics_Click);
            // 
            // TxtMySpeed
            // 
            this.TxtMySpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMySpeed.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMySpeed.Location = new System.Drawing.Point(263, 3);
            this.TxtMySpeed.Name = "TxtMySpeed";
            this.TxtMySpeed.Size = new System.Drawing.Size(255, 33);
            this.TxtMySpeed.TabIndex = 14;
            this.TxtMySpeed.Text = "10";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label37.Location = new System.Drawing.Point(3, 0);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(112, 25);
            this.Label37.TabIndex = 13;
            this.Label37.Text = "My Speed";
            this.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnStartSimulation
            // 
            this.BtnStartSimulation.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStartSimulation.Location = new System.Drawing.Point(3, 135);
            this.BtnStartSimulation.Name = "BtnStartSimulation";
            this.BtnStartSimulation.Size = new System.Drawing.Size(254, 35);
            this.BtnStartSimulation.TabIndex = 409;
            this.BtnStartSimulation.Text = "Start Simulation";
            this.BtnStartSimulation.UseVisualStyleBackColor = true;
            this.BtnStartSimulation.Click += new System.EventHandler(this.BtnStartSimulation_Click);
            // 
            // BtnStopSimulation
            // 
            this.BtnStopSimulation.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStopSimulation.Location = new System.Drawing.Point(263, 135);
            this.BtnStopSimulation.Name = "BtnStopSimulation";
            this.BtnStopSimulation.Size = new System.Drawing.Size(255, 35);
            this.BtnStopSimulation.TabIndex = 410;
            this.BtnStopSimulation.Text = "Start/Pause Simulation";
            this.BtnStopSimulation.UseVisualStyleBackColor = true;
            this.BtnStopSimulation.Click += new System.EventHandler(this.BtnStopSimulation_Click);
            // 
            // LblSimulationTime
            // 
            this.LblSimulationTime.AutoSize = true;
            this.LblSimulationTime.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSimulationTime.Location = new System.Drawing.Point(3, 44);
            this.LblSimulationTime.Name = "LblSimulationTime";
            this.LblSimulationTime.Size = new System.Drawing.Size(25, 25);
            this.LblSimulationTime.TabIndex = 16;
            this.LblSimulationTime.Text = "0";
            this.LblSimulationTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DGVDynamicObstacles
            // 
            this.DGVDynamicObstacles.AllowUserToOrderColumns = true;
            this.DGVDynamicObstacles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDynamicObstacles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVDynamicObstacles.Location = new System.Drawing.Point(3, 222);
            this.DGVDynamicObstacles.Name = "DGVDynamicObstacles";
            this.DGVDynamicObstacles.Size = new System.Drawing.Size(521, 489);
            this.DGVDynamicObstacles.TabIndex = 0;
            // 
            // CheckBoxIncludeDynamicObstacles
            // 
            this.CheckBoxIncludeDynamicObstacles.AutoSize = true;
            this.CheckBoxIncludeDynamicObstacles.Checked = true;
            this.CheckBoxIncludeDynamicObstacles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxIncludeDynamicObstacles.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxIncludeDynamicObstacles.Location = new System.Drawing.Point(3, 188);
            this.CheckBoxIncludeDynamicObstacles.Name = "CheckBoxIncludeDynamicObstacles";
            this.CheckBoxIncludeDynamicObstacles.Size = new System.Drawing.Size(314, 28);
            this.CheckBoxIncludeDynamicObstacles.TabIndex = 1;
            this.CheckBoxIncludeDynamicObstacles.Text = "Include Dynamic Obstacles";
            this.CheckBoxIncludeDynamicObstacles.UseVisualStyleBackColor = true;
            this.CheckBoxIncludeDynamicObstacles.Visible = false;
            // 
            // TabPageDraw
            // 
            this.TabPageDraw.Controls.Add(this.TableLayoutPanel13);
            this.TabPageDraw.Location = new System.Drawing.Point(4, 25);
            this.TabPageDraw.Name = "TabPageDraw";
            this.TabPageDraw.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageDraw.Size = new System.Drawing.Size(527, 714);
            this.TabPageDraw.TabIndex = 0;
            this.TabPageDraw.Text = "Draw";
            this.TabPageDraw.UseVisualStyleBackColor = true;
            // 
            // TabPageMultiSimulation
            // 
            this.TabPageMultiSimulation.Controls.Add(this.TableLayoutPanel12);
            this.TabPageMultiSimulation.Location = new System.Drawing.Point(4, 25);
            this.TabPageMultiSimulation.Name = "TabPageMultiSimulation";
            this.TabPageMultiSimulation.Size = new System.Drawing.Size(527, 714);
            this.TabPageMultiSimulation.TabIndex = 13;
            this.TabPageMultiSimulation.Text = "Multi Sim.";
            this.TabPageMultiSimulation.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel12
            // 
            this.TableLayoutPanel12.ColumnCount = 2;
            this.TableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel12.Controls.Add(this.CreateRectangleRandomMaze, 1, 5);
            this.TableLayoutPanel12.Controls.Add(this.Label26, 0, 2);
            this.TableLayoutPanel12.Controls.Add(this.Label27, 0, 1);
            this.TableLayoutPanel12.Controls.Add(this.TxtObsatcleNo_Step, 1, 2);
            this.TableLayoutPanel12.Controls.Add(this.TxtObsatcleNo_Start, 1, 1);
            this.TableLayoutPanel12.Controls.Add(this.Label25, 0, 0);
            this.TableLayoutPanel12.Controls.Add(this.Label29, 0, 3);
            this.TableLayoutPanel12.Controls.Add(this.TxtObsatcleNo_End, 1, 3);
            this.TableLayoutPanel12.Controls.Add(this.RadioBtnCreateLineRandomMaze, 1, 6);
            this.TableLayoutPanel12.Controls.Add(this.BtnNewMultiSimulation, 0, 11);
            this.TableLayoutPanel12.Controls.Add(this.BtnContMultiSimulation, 1, 11);
            this.TableLayoutPanel12.Controls.Add(this.CheckBoxSaveMazeToFile, 0, 9);
            this.TableLayoutPanel12.Controls.Add(this.CheckBoxCreateMazeSolutionImage, 0, 8);
            this.TableLayoutPanel12.Controls.Add(this.Label7, 0, 4);
            this.TableLayoutPanel12.Controls.Add(this.TxtObsatcleMaxwidth, 1, 4);
            this.TableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel12.Name = "TableLayoutPanel12";
            this.TableLayoutPanel12.RowCount = 12;
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.332256F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.332256F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.332256F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.332256F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.332256F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.332256F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.33392F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.334992F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.334992F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.334992F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.334992F));
            this.TableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.332569F));
            this.TableLayoutPanel12.Size = new System.Drawing.Size(527, 714);
            this.TableLayoutPanel12.TabIndex = 404;
            // 
            // CreateRectangleRandomMaze
            // 
            this.CreateRectangleRandomMaze.AutoSize = true;
            this.CreateRectangleRandomMaze.Checked = true;
            this.CreateRectangleRandomMaze.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateRectangleRandomMaze.Location = new System.Drawing.Point(266, 298);
            this.CreateRectangleRandomMaze.Name = "CreateRectangleRandomMaze";
            this.CreateRectangleRandomMaze.Size = new System.Drawing.Size(258, 25);
            this.CreateRectangleRandomMaze.TabIndex = 421;
            this.CreateRectangleRandomMaze.TabStop = true;
            this.CreateRectangleRandomMaze.Text = "Create Rectangle Random Maze";
            this.CreateRectangleRandomMaze.UseVisualStyleBackColor = true;
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label26.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label26.Location = new System.Drawing.Point(3, 118);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(257, 59);
            this.Label26.TabIndex = 15;
            this.Label26.Text = "Obsatcle No. Step";
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label27.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label27.Location = new System.Drawing.Point(3, 59);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(257, 59);
            this.Label27.TabIndex = 13;
            this.Label27.Text = "Obsatcle No Start";
            // 
            // TxtObsatcleNo_Step
            // 
            this.TxtObsatcleNo_Step.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtObsatcleNo_Step.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObsatcleNo_Step.Location = new System.Drawing.Point(266, 121);
            this.TxtObsatcleNo_Step.Name = "TxtObsatcleNo_Step";
            this.TxtObsatcleNo_Step.Size = new System.Drawing.Size(258, 33);
            this.TxtObsatcleNo_Step.TabIndex = 16;
            this.TxtObsatcleNo_Step.Text = "1";
            // 
            // TxtObsatcleNo_Start
            // 
            this.TxtObsatcleNo_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtObsatcleNo_Start.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObsatcleNo_Start.Location = new System.Drawing.Point(266, 62);
            this.TxtObsatcleNo_Start.Name = "TxtObsatcleNo_Start";
            this.TxtObsatcleNo_Start.Size = new System.Drawing.Size(258, 33);
            this.TxtObsatcleNo_Start.TabIndex = 14;
            this.TxtObsatcleNo_Start.Text = "1";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label25.Location = new System.Drawing.Point(3, 0);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(236, 33);
            this.Label25.TabIndex = 19;
            this.Label25.Text = "Multi Simulation";
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label29.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label29.Location = new System.Drawing.Point(3, 177);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(257, 59);
            this.Label29.TabIndex = 17;
            this.Label29.Text = "Obsatcle No. End";
            // 
            // TxtObsatcleNo_End
            // 
            this.TxtObsatcleNo_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtObsatcleNo_End.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObsatcleNo_End.Location = new System.Drawing.Point(266, 180);
            this.TxtObsatcleNo_End.Name = "TxtObsatcleNo_End";
            this.TxtObsatcleNo_End.Size = new System.Drawing.Size(258, 33);
            this.TxtObsatcleNo_End.TabIndex = 18;
            this.TxtObsatcleNo_End.Text = "250";
            // 
            // RadioBtnCreateLineRandomMaze
            // 
            this.RadioBtnCreateLineRandomMaze.AutoSize = true;
            this.RadioBtnCreateLineRandomMaze.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBtnCreateLineRandomMaze.Location = new System.Drawing.Point(266, 357);
            this.RadioBtnCreateLineRandomMaze.Name = "RadioBtnCreateLineRandomMaze";
            this.RadioBtnCreateLineRandomMaze.Size = new System.Drawing.Size(249, 25);
            this.RadioBtnCreateLineRandomMaze.TabIndex = 420;
            this.RadioBtnCreateLineRandomMaze.Text = "Create Line Random Maze";
            this.RadioBtnCreateLineRandomMaze.UseVisualStyleBackColor = true;
            // 
            // BtnNewMultiSimulation
            // 
            this.BtnNewMultiSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNewMultiSimulation.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewMultiSimulation.Location = new System.Drawing.Point(3, 652);
            this.BtnNewMultiSimulation.Name = "BtnNewMultiSimulation";
            this.BtnNewMultiSimulation.Size = new System.Drawing.Size(257, 59);
            this.BtnNewMultiSimulation.TabIndex = 397;
            this.BtnNewMultiSimulation.Text = "New MultiTimes Simulation";
            this.BtnNewMultiSimulation.UseVisualStyleBackColor = true;
            this.BtnNewMultiSimulation.Click += new System.EventHandler(this.BtnNewMultiSimulation_Click);
            // 
            // BtnContMultiSimulation
            // 
            this.BtnContMultiSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnContMultiSimulation.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnContMultiSimulation.Location = new System.Drawing.Point(266, 652);
            this.BtnContMultiSimulation.Name = "BtnContMultiSimulation";
            this.BtnContMultiSimulation.Size = new System.Drawing.Size(258, 59);
            this.BtnContMultiSimulation.TabIndex = 398;
            this.BtnContMultiSimulation.Text = "Continue MultiTimes Simulation";
            this.BtnContMultiSimulation.UseVisualStyleBackColor = true;
            this.BtnContMultiSimulation.Click += new System.EventHandler(this.BtnContMultiSimulation_Click);
            // 
            // CheckBoxSaveMazeToFile
            // 
            this.CheckBoxSaveMazeToFile.AutoSize = true;
            this.CheckBoxSaveMazeToFile.Checked = true;
            this.CheckBoxSaveMazeToFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxSaveMazeToFile.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxSaveMazeToFile.Location = new System.Drawing.Point(3, 534);
            this.CheckBoxSaveMazeToFile.Name = "CheckBoxSaveMazeToFile";
            this.CheckBoxSaveMazeToFile.Size = new System.Drawing.Size(193, 28);
            this.CheckBoxSaveMazeToFile.TabIndex = 400;
            this.CheckBoxSaveMazeToFile.Text = "Save Maze To File";
            this.CheckBoxSaveMazeToFile.UseVisualStyleBackColor = true;
            // 
            // CheckBoxCreateMazeSolutionImage
            // 
            this.CheckBoxCreateMazeSolutionImage.AutoSize = true;
            this.CheckBoxCreateMazeSolutionImage.Checked = true;
            this.CheckBoxCreateMazeSolutionImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxCreateMazeSolutionImage.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxCreateMazeSolutionImage.Location = new System.Drawing.Point(3, 475);
            this.CheckBoxCreateMazeSolutionImage.Name = "CheckBoxCreateMazeSolutionImage";
            this.CheckBoxCreateMazeSolutionImage.Size = new System.Drawing.Size(257, 28);
            this.CheckBoxCreateMazeSolutionImage.TabIndex = 399;
            this.CheckBoxCreateMazeSolutionImage.Text = "Create Maze Solution Image";
            this.CheckBoxCreateMazeSolutionImage.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(3, 236);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(257, 59);
            this.Label7.TabIndex = 422;
            this.Label7.Text = "Obsatcle Max. width";
            // 
            // TxtObsatcleMaxwidth
            // 
            this.TxtObsatcleMaxwidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtObsatcleMaxwidth.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObsatcleMaxwidth.Location = new System.Drawing.Point(266, 239);
            this.TxtObsatcleMaxwidth.Name = "TxtObsatcleMaxwidth";
            this.TxtObsatcleMaxwidth.Size = new System.Drawing.Size(258, 33);
            this.TxtObsatcleMaxwidth.TabIndex = 423;
            this.TxtObsatcleMaxwidth.Text = "20";
            // 
            // TableLayoutPanelMain
            // 
            this.TableLayoutPanelMain.ColumnCount = 2;
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.56204F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.43796F));
            this.TableLayoutPanelMain.Controls.Add(this.TableLayoutPanel1, 1, 0);
            this.TableLayoutPanelMain.Controls.Add(this.TabControl1, 0, 0);
            this.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelMain.Name = "TableLayoutPanelMain";
            this.TableLayoutPanelMain.RowCount = 1;
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelMain.Size = new System.Drawing.Size(1370, 749);
            this.TableLayoutPanelMain.TabIndex = 421;
            // 
            // SimulationTimer
            // 
            this.SimulationTimer.Tick += new System.EventHandler(this.SimulationTimer_Tick);
            // 
            // FrmGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TableLayoutPanelMain);
            this.Name = "FrmGui";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGui_Load);
            this.TableLayoutPanel18.ResumeLayout(false);
            this.TableLayoutPanel18.PerformLayout();
            this.TableLayoutPanel19.ResumeLayout(false);
            this.TableLayoutPanel19.PerformLayout();
            this.TableLayoutPanel7.ResumeLayout(false);
            this.TableLayoutPanel7.PerformLayout();
            this.TableLayoutPanel20.ResumeLayout(false);
            this.TableLayoutPanel20.PerformLayout();
            this.TableLayoutPanel14.ResumeLayout(false);
            this.TableLayoutPanel14.PerformLayout();
            this.TableLayoutPanel5.ResumeLayout(false);
            this.TableLayoutPanel5.PerformLayout();
            this.TabPageObstacleFilterType.ResumeLayout(false);
            this.TableLayoutPanel6.ResumeLayout(false);
            this.TableLayoutPanel6.PerformLayout();
            this.TableLayoutPanel17.ResumeLayout(false);
            this.TableLayoutPanel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DVGNodeToNodeVisbilty)).EndInit();
            this.TabPageVisibilityMatrices.ResumeLayout(false);
            this.TabPagePathOptimize.ResumeLayout(false);
            this.TableLayoutPanel16.ResumeLayout(false);
            this.TableLayoutPanel16.PerformLayout();
            this.TableLayoutPanel21.ResumeLayout(false);
            this.TabPageSolveMethod.ResumeLayout(false);
            this.TableLayoutPanel22.ResumeLayout(false);
            this.TableLayoutPanel22.PerformLayout();
            this.TableLayoutPanel15.ResumeLayout(false);
            this.TableLayoutPanel23.ResumeLayout(false);
            this.TableLayoutPanel23.PerformLayout();
            this.TableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVOptimizedPath)).EndInit();
            this.TabPageMaze.ResumeLayout(false);
            this.TableLayoutPanel9.ResumeLayout(false);
            this.TableLayoutPanel10.ResumeLayout(false);
            this.TableLayoutPanel10.PerformLayout();
            this.TableLayoutPanel11.ResumeLayout(false);
            this.TableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPath)).EndInit();
            this.TableLayoutPanel13.ResumeLayout(false);
            this.TableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMAzeColorSelection)).EndInit();
            this.TableLayoutPanel8.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.TableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AxMap1)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.TabPagePaths.ResumeLayout(false);
            this.TableLayoutPanel3.ResumeLayout(false);
            this.TableLayoutPanel3.PerformLayout();
            this.TabPageDynamicObstacle.ResumeLayout(false);
            this.TableLayoutPanel24.ResumeLayout(false);
            this.TableLayoutPanel24.PerformLayout();
            this.TableLayoutPanel25.ResumeLayout(false);
            this.TableLayoutPanel25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDynamicObstacles)).EndInit();
            this.TabPageDraw.ResumeLayout(false);
            this.TabPageMultiSimulation.ResumeLayout(false);
            this.TableLayoutPanel12.ResumeLayout(false);
            this.TableLayoutPanel12.PerformLayout();
            this.TableLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		internal TableLayoutPanel TableLayoutPanel18;
		internal TextBox TxtEquilateralAngle;
		internal TextBox TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio;
		internal Label Label15;
		internal Label Label16;
		internal Label Label19;
		internal TableLayoutPanel TableLayoutPanel19;
		internal TextBox TxtEllipseMinorAxisToStartEndDistanceRatio;
		internal Label Label3;
		internal TextBox TxtEllipsMajorAxisToStartEndDistanceRatio;
		internal Label Label36;
		internal TextBox TxtHexagonHeightRatio;
		internal RadioButton RadioButtonFilterByESOVG;
		internal RadioButton RadioButtonFilterByECoVG;
		internal RadioButton RadioButtonFilterByDVGRectangle;
		internal RadioButton RadioButtonFilterbyHexagon;
		internal Label Label17;
		internal TableLayoutPanel TableLayoutPanel7;
		internal TextBox TxtHexagonAngle;
		internal Label Label31;
		internal TextBox TxtRectangleHeightToStartEndDistanceRatio;
		internal Label Label9;
		internal Label Label10;
		internal TextBox TxtRectangleWidthExtensionToStartEndDistanceRatio;
		internal TableLayoutPanel TableLayoutPanel20;
		internal TableLayoutPanel TableLayoutPanel14;
		internal CheckBox CheckBoxClearPreviousPathonEachIteration;
		internal TableLayoutPanel TableLayoutPanel5;
		internal Label Label18;
		internal CheckBox CheckBoxApplyIterativeHexagon;
		internal TextBox TxtHexagonHeightIncreasePercent;
		internal RadioButton RadioButtonNoFilter;
		internal TabPage TabPageObstacleFilterType;
		internal FolderBrowserDialog FolderBrowserDialog1;
		internal CheckBox CheckBoxDrawOptimizedPath;
		internal CheckBox CheckBoxDrawWindowsNo;
		internal Label Label34;
		internal TextBox TxtInitialExpansionAngle;
		internal Label Label5;
		internal TextBox TxtSafteyMaxPathIncreaseRatio;
		internal Label Label21;
		internal Label Label32;
		internal CheckBox CheckBoxSortObstacles;
		internal CheckBox CheckBoxApplyRoughMinPath;
		internal CheckBox CheckBoxApplyMinimumPointPath;
		internal CheckBox CheckBoxApplyMinimumPath;
		internal TableLayoutPanel TableLayoutPanel6;
		internal Label Label2;
		internal TextBox TxtStatMinimumPathLength;
		internal Label Label6;
		internal TextBox TxtMinimumPathLengthIncreaseStep;
		internal TableLayoutPanel TableLayoutPanel17;
		internal Label Label35;
		internal Button BtnShowNodeToNodeVisbilty;
		internal CheckBox CheckBoxShowNodeToNodeVisbilty;
		internal DataGridView DVGNodeToNodeVisbilty;
		internal TabPage TabPageVisibilityMatrices;
		internal CheckBox CheckBoxApplyInitialMinimumPath;
		internal TabPage TabPagePathOptimize;
		internal TableLayoutPanel TableLayoutPanel16;
		internal Button BtnOptimizePath;
		internal TableLayoutPanel TableLayoutPanel21;
		internal TabPage TabPageSolveMethod;
		internal CheckBox CheckBoxDrawSplineOptimizedPath;
		internal Button BtnLoadMaze;
		internal TableLayoutPanel TableLayoutPanel4;
		internal Label Label1;
		internal ComboBox ComboPathesFound;
		internal CheckBox CheckBoxShowSoultionsOnly;
		internal Label LblCalculationTimeStopWatch;
		internal DataGridView DGVOptimizedPath;
		internal Label Label22;
		internal Label LblPathTypes;
		internal Label LblCalculationTimeClock;
		internal TabPage TabPageMaze;
		internal TableLayoutPanel TableLayoutPanel9;
		internal TableLayoutPanel TableLayoutPanel10;
		internal Label Label20;
		internal Button BtnSaveMaze;
		internal Button BtnNewMaze;
		internal Button BtnChangeMazeTarget;
		internal TableLayoutPanel TableLayoutPanel11;
		internal RadioButton RadioButtonCreateRectangle;
		internal Label Label24;
		internal Button BtnCreateRndMaze;
		internal RadioButton RadioButtonCreateLine;
		internal Label Label12;
		internal Label Label11;
		internal TextBox TxtMazeHeight;
		internal TextBox TxtMazeWidth;
		internal Label Label14;
		internal TextBox TxtObstacleMaxLength;
		internal TextBox TxtObstacleNo;
		internal Label Label13;
		internal DataGridView DGVPath;
		internal TableLayoutPanel TableLayoutPanel13;
		internal Button BtnDrawObstacles;
		internal Button BtnDrawWindows;
		internal CheckBox CheckBoxDrawWindows;
		internal Label Label28;
		internal CheckBox CheckBoxDrawLine;
		internal CheckBox CheckBoxDrawObstacleNumber;
		internal CheckBox CheckBoxDrawSpline;
		internal Label Label30;
		internal Label Label23;
		internal OpenFileDialog OpenFileDialog1;
		internal SaveFileDialog SaveFileDialog1;
		internal Label LblDisplayStatus;
		internal Button BTNTemp;
		internal Button BtnMapWinNormal;
		internal Button BtnMapWinPan;
		internal TableLayoutPanel TableLayoutPanel8;
		internal Label LblPathData;
		internal Button Button1;
		internal Button BtnFindPathes;
		internal TableLayoutPanel TableLayoutPanel1;
		internal TableLayoutPanel TableLayoutPanel2;
		internal Button BtnClearData;
		internal Button BtnMapWinZoomExtent;
		internal Button BtnMapWinZoomOut;
		internal Button BtnMapWinZoomIn;
		internal TabControl TabControl1;
		internal TabPage TabPagePaths;
		internal TableLayoutPanel TableLayoutPanel3;
		internal TabPage TabPageMultiSimulation;
		internal TableLayoutPanel TableLayoutPanel12;
		internal RadioButton CreateRectangleRandomMaze;
		internal Label Label26;
		internal Label Label27;
		internal TextBox TxtObsatcleNo_Step;
		internal TextBox TxtObsatcleNo_Start;
		internal Label Label25;
		internal Label Label29;
		internal TextBox TxtObsatcleNo_End;
		internal RadioButton RadioBtnCreateLineRandomMaze;
		internal Button BtnNewMultiSimulation;
		internal Button BtnContMultiSimulation;
		internal CheckBox CheckBoxSaveMazeToFile;
		internal CheckBox CheckBoxCreateMazeSolutionImage;
		internal Label Label7;
		internal TextBox TxtObsatcleMaxwidth;
		internal TabPage TabPageDraw;
		internal TableLayoutPanel TableLayoutPanelMain;
		internal TabPage TabPageDynamicObstacle;
		internal DataGridView DGVDynamicObstacles;
		internal AxMapWinGIS.AxMap AxMap1;
		internal TableLayoutPanel TableLayoutPanel22;
		internal TableLayoutPanel TableLayoutPanel15;
		internal RadioButton RadioButtonArnaootFireLine;
		internal RadioButton RadioButtonUseDijkstra;
		internal RadioButton RadioButtonHexagon;
		internal TableLayoutPanel TableLayoutPanel23;
		internal TextBox TxtSafeDistance;
		internal Label Label4;
		internal Label Label8;
		internal TextBox TxtSafeDistanceToNodeExtensionDistance;
		internal ListBox ListBoxMazeSolutionLog;
		internal RadioButton RadioButtonDynamicHexagon;
		internal TableLayoutPanel TableLayoutPanel24;
		internal TableLayoutPanel TableLayoutPanel25;
		internal Label LblSimulationTime;
		internal TextBox TxtMySpeed;
		internal Label Label37;
		internal ColorDialog ColorDialog1;
		internal PictureBox PictureBoxMAzeColorSelection;
		internal ComboBox ComboBoxElementsColor;
		internal Timer SimulationTimer;
		internal Button BtnStartSimulation;
		internal Button BtnStopSimulation;
		internal Button BtnEvaluateSolutionPathsDynamics;
		internal CheckBox CheckBoxIncludeDynamicObstacles;
		internal Label LblMyCourse;
	}

}
