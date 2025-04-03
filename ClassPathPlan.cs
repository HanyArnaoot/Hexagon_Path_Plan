 using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace WindowsApp2
{
    //the path plan class, the core of the code
    public class ClassPathPlan
	{
#region Classes and Structures
#region Obstacle
		public const int ObstaclePointTypeStart = 1; // the index of the first Obstacle Point type
		public const int ObstaclePointLastTypeIndex = 2; // the index of the last Obstacle Point type
		public const int ObstaclePointCount = 2; // the count of the Obstacle Point types (start,End)
		public struct ObstaclePointTypes
		{
			public const int ObsStart = 1;
			public const int ObsEnd = 2;
		}
		// the array order are 
		//      0                 1                   2                 3                 4                   5                6
		//maze start point  maze end point , obstacle1 start ,  obstacle1 end , , obstacle2 start ,  obstacle2 end ,   obstacle3 start ,  obstacle3 end , ...
		public int ObstacleNoToArray(int ObstacleNo, int ObstacleEndPointType)
		{
			return (ObstacleNo * 2) + 1 + ObstacleEndPointType;
		}
		public class ObstacleLine
		{
			//
			public Point[] Points = new Point[ObstaclePointLastTypeIndex + 1]; // the orginal obstacle points co-ordinates
			public Point[] PointsExtended_lineIntersection = new Point[ObstaclePointLastTypeIndex + 1]; // the extended obstacle points co-ordinates (obstacle intersection , path clear check)
			public Point[] PointsExtended = new Point[ObstaclePointLastTypeIndex + 1]; // the orginal obstacle points co-ordinates
			//
			public double[] MinDistanceMazeStart = new double[ObstaclePointLastTypeIndex + 1]; //the shortest path distance between that node in the obstacle and start point
			//
			//the sorting parameters
			public Point ObstacleMiddlePoint; // the middle point of the obstacle , mainly used as a single point to determine which window should contain the obstacle
			public float CenterDistanceToStartPoint; //the direct distance between the obstacle center and start point (not a path)
			public int HexagonNumber; //for sorting the obstacles as multiple hexagon with same base and diffirent heights
			//
			public bool InsideSearchRegion; //is this obstacle inside search region, so will be considered as possible visited nodes or not
			public bool IsMakingPathCritical; //after solution is found , obstacles are checked to know if it too close to path
			//
			public bool TestedForPathStart; //has this obstacle been checked as a possible path may start from maze start point to its nodes or not
			//
			public int ObstacleWindowX; //the Window X coordiantes of this obstacles , use in checking for intersection
			public int ObstacleWindowY; //the Window y coordiantes of this obstacles , use in checking for intersection
			//
			//fire line calculATIONS
			public int ObstacleIndex; //the orginal index of the obstacle , for fire line calculATIONS
			public double[] MazeEndDirectDistance = new double[ObstaclePointLastTypeIndex + 1]; //the Direct distance between that node in the obstacle and End point assume no obstacles in the way
			//ObstacleType  DynamicObsatcle or StaticObsatcle
			public ObstacleTypes ObstacleType = ObstacleTypes.StaticObsatcle;
		}
		public enum ObstacleTypes
		{
			DynamicObsatcle,
			StaticObsatcle
		}
#endregion
#region Path
		public class Path
		{
			public int CurrentPathStatus;
			public List<Node> PathNode = new List<Node>();
			public float PathLength;
			public bool PathChecked;
		}
		public struct PathStatusTypes
		{
			public const int Searching = 0;
			public const int TooLong = 1;
			public const int Blocked = 2;
			public const int Solution = 3;
		}
#endregion
#region Node
		public class Node
		{
			public Point NodePoint;
			public Point OptimizedPoint;
			public int NodeObstacleNumber;
			public int NodeObstaclePointType;
 		}
		public struct NodeToNodeVisibilityType
		{
			public const int NotTested = 0;
			public const int Visible = 1;
			public const int blocked = 2;
		}
 #endregion
#region Maze / solution 
		public enum SolutionMethods
		{
			Hexagon,
			ArnaootFireLine,
			Dijkstra,
			HexagonDynamic
		}
		public struct ObstacleFilteringMethods
		{
			public const int NoFilter = 0;
			public const int Hexagon = 1;
			public const int ESOVG = 2;
			public const int ECoVG = 3;
			public const int DVG = 4;
 		}
		public struct RandomMazeTypes
		{
			public const int Lines = 1;
			public const int Rectangles = 2;
		}
#endregion
#region Dynamic
		public struct MovingUnitData
		{
			public float Speed;
			public double Course;
			public Point Position; //'MyPoint 'the real position
			public float PositionSimulatedX; //the position during simulation , changes during plotting To the screen
			public float PositionSimulatedY; //the position during simulation , changes during plotting To the screen
			public float Width;
			public float Length;
			public string Name;
			public Point[] BodyDefiningPoints; //' the array of point drawing rectangle representing the obstacle ship, rotated by course
			public Point[] DangerZonePoint; //' the array of point drawing parallelogram representing the obstacle ship DangerZone , rotated by course
			public int SafeDynamicObstacleToMyVehicleDistance;
			public Point FuturePosition; //'the obstacle ship Predicted Position when my ship reachs its destination
			public Point UpdateMylocation(float SimulationStepTime)
			{
				PositionSimulatedX = (float)(PositionSimulatedX + (Speed * SimulationStepTime * Math.Cos(Course)));
				PositionSimulatedY = (float)(PositionSimulatedY + (Speed * SimulationStepTime * Math.Sin(Course)));
				// 
				if (Math.Abs(PositionSimulatedX) > 100000)
				{
					System.Diagnostics.Debugger.Break();
				}
				// 
				return GetPositionSimulatedPoint();
			}
			public Point GetPositionSimulatedPoint()
			{
				return new Point(Convert.ToInt32(PositionSimulatedX), Convert.ToInt32(PositionSimulatedY));
			}
			public void UpdatePositionSimulatedPoint(Point PositionSimulatedPoint)
			{
				PositionSimulatedX = PositionSimulatedPoint.X;
				PositionSimulatedY = PositionSimulatedPoint.Y;
			}
		}

		//Public Structure MyPoint
		//    Public X As Double
		//    Public Y As Double
		//    Public Function ToPoint() As Point
		//        Return New Point(Int(X), Int(Y))
		//    End Function
		//    Public Sub New(x As Single, y As Single)
		//        Me.X = x
		//        Me.Y = y
		//    End Sub
		//End Structure

#endregion
#endregion
#region Variables

#region General Variables
		//'Public StopSimulation As Boolean = False
		public const double Angle90Rad = Math.PI / 2;
		//
		public Node MazeStartNode = new Node();
		public Node MazeEndNode = new Node();
		//
		public List<ObstacleLine> Obstacles = new List<ObstacleLine>();
		//Public FireLineObstacles As New List(Of ObstacleLine)
		public List<ObstacleLine> ObstaclesFireLine = new List<ObstacleLine>();
		public List<Path> FoundPaths = new List<Path>();
		public float SafeDistance = 10;
		public float SafeDistanceToNodeExtensionDistanceRatio = 0.5F;
		//'Public IncludeDynamicObstacles As Boolean = False
		//
		public float MinimumPathLengthFound;
		public bool PathWasFound;
		public bool ApplyMinimumPath;
		public bool ApplyMinimumPointPath;
		//
		public bool ApplyRoughMinPath;
		//
		//Public ApplyIterariveMinimumPath As Boolean
		//'Public ApplyFireLine As Boolean
		//Public IterariveMinimumPathStartPercent As Single
		//Public IterariveMinimumPathIncreaseStepRatio As Single
		//
		public bool PreCalculationDone;
		//
		public float MazeStartToEndDistance;
		//
		public bool SortObstaclesByDistanceToStartPoint = false;
		//
		public int ObstacleFilterMethod;
		public SolutionMethods MazeSolveMethod; //'Integer
		//
		public byte[,] NodeToNodeVisibility;
		public float[,] NodeToNodeDistance;
		//
		public int SolPathNo; //the resultant Paths types Number
		public int BlockedPathNo;
		public int TooLongPathNo;
		public int SearchingPathNo;
		private int MazeStartWindowX; //the location of maze start node and maze end node as window x,y
		private int MazeStartWindowY;
		private int MazeEndWindowX;
		private int MazeEndWindowY;
#endregion
#region Dynamic
		public MovingUnitData[] MovingObstacles; //the array of Dynamic obstacles
		//'Public MovingObstacles As New List(Of MovingUnitData) 'the list of Dynamic obstacles
		public float MySpeed; //'= 10 ''m/s
		public int SimulatedSolutionPathCurrentTargetNode;
		public float SimulationTime;
		//'Public MyCurrentLocation As Point = New Point(0, 0)
#endregion
#region Dynamic Obstacle Simulation
		//Public MySimulatedVehicle As MovingUnitData
		//Public SimulatedSolutionPathIndex As Integer
		//Public SimulatedSolutionPathCurrentTargetNode As Integer
		//'Public DynamicDangerZoneSafetyFactor As Integer = 10
		//' Public SimulationTime As Single
		//'Public SimulationStepTime As Single
		//Public TempPathintersectionPoint As Point
		//Public TempDynamicObstacleMaxFuturePosition As Point '' Public TempPathintersectionPoint As Point

#endregion
#region Path Optimaization Variables
		public float InitialExpansionAngle = 30;
		public Point MazeMinPoint;
		public Point MazeMaxPoint;
		public float SafetyMaxPathLengthIncreaseRatio;
#endregion


#region Filteration Methods
		public delegate bool FilterFunction(Point ObstaclePoint);

#region Elliptical Concave Visibility Graph (ECoVG)
		public float EllipseMajorAxisToStartEndDistanceRatio = 0.7F;
		public float EllipseMinorAxisToStartEndDistanceRatio = 0.3F;
		public float EllipseMajorAxisLength; //= CalDis( StartNode.NodePoint, MazeEndNode.NodePoint) * MajorAxisToStartEndDiatnceRatio
		public float EllipseMinorAxisLength; // = EllipseMajorAxisLength * MinorAxisToStartEndDiatnceRatio
		public float EllipseAngle; //= CalAnglePoint( StartNode.NodePoint, MazeEndNode.NodePoint)
		public Point EllipseCenterPoint;
#endregion
#region Equilateral Spaces Oriented Visibility Graph (ESOVG)
		public Point[] EquilateralPoints = new Point[4];
		public float EquilateralAngle; //= 1 '0.2
		public float EquilateralMajorAxisExtensionToStartEndDistanceRatio; //= 1 ' 0.1
		// Public RectangleMiddlePoint As Point
		//Public EquilateralArea As Single
#endregion
#region Dynamic Visibility Graph (Rectangle)
		public Point[] RectanglePoints = new Point[4];
		public float RectangleWidth;
		public float RectangleHeight;
		public float RectangleWidthExtensionToStartEndDistanceRatio = 1; // 0.1
		public float RectangleHeightToStartEndDistanceRatio = 1; //0.2
		// Public RectangleMiddlePoint As Point
		public float RectangleArea;
#endregion
#region Hexagon
		public Point[] HexagonPoints = new Point[6];
		// Public HexagonAngle As Single
		public float HexagonHeightRatio;
		public float IterativeHexagonHeightStepRatio; // = 0.1
		public bool ApplyIterativeHexagon;
		public bool ClearPreviousPathonEachIteration;
#endregion

#endregion

#region Window
		public int WindowsNoVertical; //= 10
		public int WindowsNoHorizontal; // = 20
		public float WindowWidth;
		public float WindowHeight;
		//
		public List<int>[,] ObstacleWindowSort;
#endregion
#endregion
#region Obsatcles
		public void ExtendObstacleLine(ref ObstacleLine MyObstacle, double ExtendDistance)
		{
			//'PointsExtended_lineIntersection
			ExtendLine(MyObstacle.Points[ObstaclePointTypeStart], MyObstacle.Points[ObstaclePointLastTypeIndex], (float)(ExtendDistance * SafeDistanceToNodeExtensionDistanceRatio), ref MyObstacle.PointsExtended_lineIntersection[ObstaclePointTypeStart], ref MyObstacle.PointsExtended_lineIntersection[ObstaclePointLastTypeIndex]);
			//'PointsExtendedNodes
			ExtendLine(MyObstacle.Points[ObstaclePointTypeStart], MyObstacle.Points[ObstaclePointLastTypeIndex], (float)ExtendDistance, ref MyObstacle.PointsExtended[ObstaclePointTypeStart], ref MyObstacle.PointsExtended[ObstaclePointLastTypeIndex]);
		}
		public void PrepareNewObsatcle(ref ObstacleLine MyObstacle, int ObstacleNo)
		{
			int ObsStartID = 0;
			int ObsEndID = 0;
			//'
			//the obstacle list is zero based 
			ExtendObstacleLine(ref MyObstacle, SafeDistance);
			//
			MyObstacle.ObstacleMiddlePoint = CalMiddlePoint(MyObstacle.Points[ObstaclePointTypes.ObsStart], MyObstacle.Points[ObstaclePointTypes.ObsEnd]);
			//
			MyObstacle.InsideSearchRegion = false;
			//
			MyObstacle.ObstacleIndex = ObstacleNo;
			//
			//set a very high initial value (ten times the direcrt distance between maze start and maze end nodes)
			MyObstacle.MinDistanceMazeStart[ObstaclePointTypes.ObsStart] = MazeStartToEndDistance * 10;
			MyObstacle.MinDistanceMazeStart[ObstaclePointTypes.ObsEnd] = MazeStartToEndDistance * 10;
			//
			for (var NodeNo = ObstaclePointTypeStart; NodeNo <= ObstaclePointLastTypeIndex; NodeNo++)
			{
				MyObstacle.MazeEndDirectDistance[NodeNo] = CalPointDis(MazeEndNode.NodePoint, MyObstacle.PointsExtended[NodeNo]);
			}
			//
			//get the IDs by which obstacles is identified
			ObsStartID = ObstacleNoToArray(ObstacleNo, ObstaclePointTypes.ObsStart);
			ObsEndID = ObstacleNoToArray(ObstacleNo, ObstaclePointTypes.ObsEnd);
			//the obstacle is not visible to itself(it will not go to itself)
			NodeToNodeVisibility[ObsStartID, ObsStartID] = (byte)NodeToNodeVisibilityType.blocked;
			NodeToNodeVisibility[ObsEndID, ObsEndID] = (byte)NodeToNodeVisibilityType.blocked;
			//the two side of the obstacle are not visible to each other
			NodeToNodeVisibility[ObsStartID, ObsEndID] = (byte)NodeToNodeVisibilityType.blocked;
			NodeToNodeVisibility[ObsEndID, ObsStartID] = (byte)NodeToNodeVisibilityType.blocked;
			//
			MyObstacle.CenterDistanceToStartPoint = CalPointDis(MyObstacle.ObstacleMiddlePoint, MazeStartNode.NodePoint);
		}
#region Obstacle Sort
		//Pathes sorting by path length
		//
		public void SortObstacles()
		{
			int ObstaclesNo = Obstacles.Count;
			int S = 0;
			List<ObstacleLine> Sorted = new List<ObstacleLine>();
			//
			Point HexagonMiddlePoint = new Point();
			Point HexagonMiddleNearStartPoint = new Point();
			Point HexagonNearEndMiddlePoint = new Point();
			float HexagonMiddleLength = 0F;
			float MazeStartToEndAngle = (float)CalAnglePointRad(MazeStartNode.NodePoint, MazeEndNode.NodePoint);
			float TempHexagonHeightRatio = 0F;
			int HexagonNumber = 1000;
			Point[] TempHexagonPoints = new Point[6];
			//
			//
			TempHexagonPoints[0] = MazeStartNode.NodePoint;
			TempHexagonPoints[3] = MazeEndNode.NodePoint;
			//
			HexagonMiddlePoint = CalMiddlePoint(MazeStartNode.NodePoint, MazeEndNode.NodePoint);
			HexagonMiddleNearStartPoint = CalMiddlePoint(MazeStartNode.NodePoint, HexagonMiddlePoint);
			HexagonNearEndMiddlePoint = CalMiddlePoint(HexagonMiddlePoint, MazeEndNode.NodePoint);
			//
// INSTANT C# WARNING: The step increment was not confirmed to be either positive or negative - confirm that the stopping condition is appropriate:
// ORIGINAL LINE: For TempHexagonHeightRatio = 0.15 To 2 Step 0.2
			for (TempHexagonHeightRatio = 0.15F; TempHexagonHeightRatio <= 2; TempHexagonHeightRatio += 0.2F)
			{
				//
				HexagonMiddleLength = MazeStartToEndDistance * HexagonHeightRatio;
				ExtendPointPerPendicular(HexagonMiddleNearStartPoint, MazeStartToEndAngle, HexagonMiddleLength / 2, ref TempHexagonPoints[1], ref TempHexagonPoints[5]);
				ExtendPointPerPendicular(HexagonNearEndMiddlePoint, MazeStartToEndAngle, HexagonMiddleLength / 2, ref TempHexagonPoints[2], ref TempHexagonPoints[4]);
				//
				for (S = 0; S < ObstaclesNo; S++)
				{
					if (Obstacles[S].HexagonNumber == 0)
					{
						//For ObstaclePointType = ObstaclePointTypeStart To ObstaclePointTypeEnd
						//Next
						if (PointInPolygon(Obstacles[S].ObstacleMiddlePoint, TempHexagonPoints))
						{
							Obstacles[S].HexagonNumber = HexagonNumber;
						}
					}
				}
				HexagonNumber = HexagonNumber - 1;
			}
			//
			//sorted = Obstacles.OrderBy(Function(x) x.DistanceToStartPoint).ToList()
			Sorted = Obstacles.OrderBy((x) => -x.HexagonNumber).ThenBy((y) => -y.CenterDistanceToStartPoint).ToList();
			//sorted = Obstacles.OrderBy(Function(x) -x.HexagonNumber).ToList()
			Obstacles = Sorted;
			//Array.Sort(Obstacles, Function(Obstacle1 As ObstacleLine, Obstacle2 As ObstacleLine)
			//                          Return Obstacle2.DistanceToStartPoint.CompareTo(Obstacle1.DistanceToStartPoint)
			//                      End Function)

		}

		//Public Sub SortObstacleswindow()
		//    Dim ObstaclesNo As Integer = Obstacles.Count
		//    Dim S As Integer
		//    ' Dim sorted As New List(Of ObstacleLine)
		//    Dim AddDepth As Integer '= 1
		//    Dim WindowAdded As Boolean '= False
		//    Dim WindowsAddedStatus(WindowsNoHorizontal, WindowsNoVertical) As Boolean
		//    '
		//    '
		//    'Dim 
		//    '#####################################################################3
		//    Dim StartNodeWindowX, StartNodeWindowY, EndNodeWindowX, EndNodeWindowY As Integer
		//    Dim WindowX, WindowY As Integer
		//    Dim LineRasteraizaionList As New List(Of Point)
		//    Dim NewObstacles As New List(Of ObstacleLine)
		//    Dim MoveX As Boolean
		//    Dim MazeStartToEndSlope As Single '= CalAnglePoint(MazeStartNode.NodePoint, MazeEndNode.NodePoint)
		//    '
		//    GetPointWindow(MazeStartNode.NodePoint, StartNodeWindowX, StartNodeWindowY)
		//    GetPointWindow(MazeEndNode.NodePoint, EndNodeWindowX, EndNodeWindowY)
		//    '
		//    'deciding wethear to move with the rasertized points in vertical or horizontal direction aacording to kine slope
		//    If EndNodeWindowX = StartNodeWindowX Then
		//        MoveX = False
		//    Else
		//        MazeStartToEndSlope = (EndNodeWindowX - StartNodeWindowX) / (EndNodeWindowY - StartNodeWindowY)
		//        If Math.Abs(MazeStartToEndSlope) > 1 Then
		//            MoveX = True
		//        Else
		//            MoveX = False
		//        End If
		//    End If
		//    '
		//    LineRasteraizaionList = DDA(StartNodeWindowX, StartNodeWindowY, EndNodeWindowX, EndNodeWindowY)
		//    'FrmGUI.DataGridView1.ColumnCount = WindowsNoHorizontal
		//    'FrmGUI.DataGridView1.RowCount = WindowsNoVertical
		//    'For S = 0 To LineRasteraizaionList.Count - 1
		//    '    FrmGUI.DataGridView1.Item(LineRasteraizaionList(S).X, LineRasteraizaionList(S).Y).Value = S
		//    'Next



		//    'If StartNodeWindowX > EndNodeWindowX Then
		//    '    LineRasteraizaionList = DDA(EndNodeWindowX, EndNodeWindowY, StartNodeWindowX, StartNodeWindowY)
		//    'Else
		//    '    LineRasteraizaionList = DDA(StartNodeWindowX, StartNodeWindowY, EndNodeWindowX, EndNodeWindowY)
		//    'End If
		//    '
		//    'For S = 0 To LineRasteraizaionList.Count - 1
		//    '    AddObstacleinWindow(NewObstacles, LineRasteraizaionList(S).X, LineRasteraizaionList(S).Y)
		//    '    WindowsAddedStatus(LineRasteraizaionList(S).X, LineRasteraizaionList(S).Y) = True
		//    'Next
		//    '
		//    WindowAdded = True
		//    '
		//    If MoveX = True Then
		//        Do While WindowAdded = True
		//            WindowAdded = False
		//            For S = 0 To LineRasteraizaionList.Count - 1
		//                WindowY = LineRasteraizaionList(S).Y
		//                WindowX = LineRasteraizaionList(S).X + AddDepth
		//                '
		//                If CheckWindowNumber(WindowX, WindowY) = True Then
		//                    If WindowsAddedStatus(WindowX, WindowY) = False Then
		//                        AddAllObstacleinWindow(NewObstacles, WindowX, WindowY)
		//                        ' If WindowsAddedStatus(LineRasteraizaionList(S).X, LineRasteraizaionList(S).Y) = True Then Stop
		//                        WindowsAddedStatus(WindowX, WindowY) = True
		//                        WindowAdded = True
		//                        Debug.Print("added window" + WindowX.ToString + "," + WindowY.ToString + vbCrLf)
		//                    End If
		//                Else
		//                    ' Stop
		//                End If
		//                '
		//                WindowX = LineRasteraizaionList(S).X - AddDepth
		//                '
		//                If CheckWindowNumber(WindowX, WindowY) = True Then
		//                    If WindowsAddedStatus(WindowX, WindowY) = False Then
		//                        AddAllObstacleinWindow(NewObstacles, WindowX, WindowY)
		//                        '  If WindowsAddedStatus(LineRasteraizaionList(S).X, LineRasteraizaionList(S).Y) = True Then Stop
		//                        WindowsAddedStatus(WindowX, WindowY) = True
		//                        WindowAdded = True
		//                        Debug.Print("added window" + WindowX.ToString + "," + WindowY.ToString + vbCrLf)
		//                    End If
		//                Else
		//                    '   Stop
		//                End If
		//            Next
		//            AddDepth = AddDepth + 1
		//        Loop
		//    Else
		//        Do While WindowAdded = True
		//            WindowAdded = False
		//            For S = 0 To LineRasteraizaionList.Count - 1
		//                WindowY = LineRasteraizaionList(S).Y + AddDepth
		//                WindowX = LineRasteraizaionList(S).X
		//                '
		//                If CheckWindowNumber(WindowX, WindowY) = True Then
		//                    If WindowsAddedStatus(WindowX, WindowY) = False Then
		//                        AddAllObstacleinWindow(NewObstacles, WindowX, WindowY)
		//                        ' If WindowsAddedStatus(LineRasteraizaionList(S).X, LineRasteraizaionList(S).Y) = True Then Stop
		//                        WindowsAddedStatus(WindowX, WindowY) = True
		//                        WindowAdded = True
		//                        Debug.Print("added window" + WindowX.ToString + "," + WindowY.ToString + vbCrLf)
		//                    End If
		//                Else
		//                    ' Stop
		//                End If
		//                '
		//                WindowY = LineRasteraizaionList(S).Y - AddDepth
		//                '
		//                If CheckWindowNumber(WindowX, WindowY) = True Then
		//                    If WindowsAddedStatus(WindowX, WindowY) = False Then
		//                        AddAllObstacleinWindow(NewObstacles, WindowX, WindowY)
		//                        '  If WindowsAddedStatus(LineRasteraizaionList(S).X, LineRasteraizaionList(S).Y) = True Then Stop
		//                        WindowsAddedStatus(WindowX, WindowY) = True
		//                        WindowAdded = True
		//                        Debug.Print("added window" + WindowX.ToString + "," + WindowY.ToString + vbCrLf)
		//                    End If
		//                Else
		//                    '   Stop
		//                End If
		//            Next
		//            AddDepth = AddDepth + 1
		//        Loop
		//    End If
		//    '
		//    'Dim x, y As Integer
		//    ''
		//    'FrmGUI.DataGridView1.ColumnCount = WindowsNoHorizontal
		//    'FrmGUI.DataGridView1.RowCount = WindowsNoVertical
		//    'For x = 0 To WindowsNoHorizontal - 1
		//    '    For y = 0 To WindowsNoVertical - 1
		//    '        FrmGUI.DataGridView1.Item(x, y).Value = WindowsAddedStatus(x, y)
		//    '    Next
		//    'Next
		//    'NewObstacles = NewObstacles
		//    'Stop
		//    '
		//    Obstacles = NewObstacles
		//End Sub
		//Private Function CheckWindowNumber(ByVal WindowX As Integer, ByVal WindowY As Integer) As Boolean
		//    If WindowX < 0 Or WindowX >= WindowsNoHorizontal Then Return False
		//    If WindowY < 0 Or WindowY >= WindowsNoVertical Then Return False
		//    Return True
		//End Function
		//Private Sub AddAllObstacleinWindow(ByRef ObstacleList As List(Of ObstacleLine), ByVal WindowX As Integer, ByVal WindowY As Integer)
		//    Dim S As Integer
		//    Dim ObstacleNo As Integer
		//    '
		//    For S = 0 To ObstacleWindowSort(WindowX, WindowY).Count - 1
		//        ObstacleNo = ObstacleWindowSort(WindowX, WindowY)(S)
		//        ObstacleList.Add(Obstacles(ObstacleNo))
		//    Next
		//End Sub

		//Private Function DDA(ByVal X0 As Integer, ByVal Y0 As Integer, ByVal X1 As Integer, ByVal Y1 As Integer) As List(Of Point)
		//    Dim dx As Integer = X1 - X0
		//    Dim dy As Integer = Y1 - Y0
		//    Dim steps As Integer = (If(Math.Abs(dx) > Math.Abs(dy), Math.Abs(dx), Math.Abs(dy)))
		//    Dim Xinc As Single = dx / CSng(steps)
		//    Dim Yinc As Single = dy / CSng(steps)
		//    Dim X As Single = X0
		//    Dim Y As Single = Y0
		//    '
		//    Dim LineRasteraizaionList As New List(Of Point)
		//    '
		//    For i As Integer = 0 To steps
		//        'Debug.Print(Int(X).ToString + " , " + Int(Y).ToString + vbCrLf)
		//        LineRasteraizaionList.Add(New Point(Int(X), Int(Y)))
		//        '
		//        X += Xinc
		//        Y += Yinc
		//    Next
		//    Return LineRasteraizaionList
		//End Function



		//Private Function midPoint(ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As List(Of Point)
		//    Dim dx As Integer = X2 - X1
		//    Dim dy As Integer = Y2 - Y1
		//    Dim d As Integer = dy - (dx / 2)
		//    Dim x As Integer = X1, y As Integer = Y1
		//    Dim LineRasteraizaionList As New List(Of Point)
		//    '  Console.Write(x & "," & y & vbLf)

		//    LineRasteraizaionList.Add(New Point(X1, Y1))

		//    While x < X2
		//        x += 1

		//        If d < 0 Then
		//            d = d + dy
		//        Else
		//            d = d + (dy - dx)
		//            y = y + 1
		//        End If
		//        LineRasteraizaionList.Add(New Point(x, y))
		//        ' Console.Write(x & "," & y & vbLf)
		//    End While
		//    Return LineRasteraizaionList
		//End Function

		//Public Shared Sub Main()
		//    Dim X1 As Integer = 2, Y1 As Integer = 2, X2 As Integer = 8, Y2 As Integer = 5
		//    midPoint(X1, Y1, X2, Y2)
		//End Sub
#endregion
#endregion
#region path general data
		public void ClearData(bool ClearObstacles, bool ReCalculate)
		{
			FoundPaths.Clear();
			//'
			MazeMinPoint.X = 1000000; //an extreme value to be updated by the numbers
			MazeMinPoint.Y = 1000000; //an extreme value to be updated by the numbers
			MazeMaxPoint.X = -1000000; //an extreme value to be updated by the numbers
			MazeMaxPoint.Y = -1000000; //an extreme value to be updated by the numbers
			//'
			//ObstaclesFireLine.Clear() ''already cleared in the solvebyarnaootfireline()
			//'
			if (ReCalculate == true)
			{
				PreCalculationDone = false;
				MinimumPathLengthFound = 0;
				PathWasFound = false;
				//'
			}
			//'
			//'If Not IsNothing(MovingObstacles) Then MovingObstacles.Clear()
			//'
			if (ClearObstacles == true)
			{
				//deletes all obstacles
				Obstacles.Clear();
				//'
				MovingObstacles = null; //'MovingObstacles.Clear()
			}
			else
			{

				int VisibiltyArraySize = ObstacleNoToArray(Obstacles.Count - 1, ObstaclePointLastTypeIndex);
				NodeToNodeVisibility = new byte[VisibiltyArraySize + 1, VisibiltyArraySize + 1];
				NodeToNodeDistance = new float[VisibiltyArraySize + 1, VisibiltyArraySize + 1];
				//'
				CalculateWindowData();
				//'
				CreateWindoWObstalcesMatrix();
				//'
				//Clears all obstacles Data
				for (var N = (Obstacles.Count - 1); N >= 0; N--)
				{
					//If Obstacles(N).ObstacleType = ObstacleTypes.DynamicObsatcle Then
					//    Obstacles.RemoveAt(N)
					//Else
					for (var s = 0; s < ObstaclePointCount; s++) //'obstacle.MinDistanceMazeStart.GetUpperBound(0)
					{
						Obstacles[N].TestedForPathStart = false;
						Obstacles[N].MinDistanceMazeStart[s] = 0;
						Obstacles[N].MazeEndDirectDistance[s] = 0;
					}
					//End If
				}
			}
			//Clear_Obsatcle_IsMakingPathCritical()
			//'
			//Clear_Obsatcle_MinDistanceMazeStartObstaclePoint()
			//
		}
		public void ClearAllData()
		{
			//
			FoundPaths.Clear();
			PreCalculationDone = false;
			//
			Obstacles.Clear();
			ObstaclesFireLine.Clear();
			//Clear_Obsatcle_IsMakingPathCritical()
			//'
			//Clear_Obsatcle_MinDistanceMazeStartObstaclePoint()
			//
		}
		public int SolveMaze()
		{
			Path InitialPath = CreateInitialPath();
			int S = 0;
			Node NewNode = new Node();
			int VisibiltyArraySize = 0;
			//
			// the array order are 
			//      0                 1                   2                 3                 4                   5                6
			//maze start point  maze end point , obstacle1 start ,  obstacle1 end , , obstacle2 start ,  obstacle2 end ,   obstacle3 start ,  obstacle3 end , ...
			//'so setting maze start and  end nodes as one obstacle , with index =-1 to be  before the first obstacle
			MazeStartNode.NodeObstacleNumber = -1;
			MazeStartNode.NodeObstaclePointType = ObstaclePointTypes.ObsStart;
			//
			MazeEndNode.NodeObstacleNumber = -1;
			MazeEndNode.NodeObstaclePointType = ObstaclePointTypes.ObsEnd;
			//'
			if (PreCalculationDone == false)
			{
				//this line must be before dynamic obstalce because the later depen on it
				MazeStartToEndDistance = CalPointDis(MazeStartNode.NodePoint, MazeEndNode.NodePoint);
				//'
				//If IncludeDynamicObstacles = True Then
				//    SetupDynamicObstacles()
				//End If
				//'
				VisibiltyArraySize = ObstacleNoToArray(Obstacles.Count - 1, ObstaclePointLastTypeIndex);
				NodeToNodeVisibility = new byte[VisibiltyArraySize + 1, VisibiltyArraySize + 1];
				NodeToNodeDistance = new float[VisibiltyArraySize + 1, VisibiltyArraySize + 1];
				//
				for (S = 0; S < Obstacles.Count; S++)
				{
					WindowsApp2.ClassPathPlan.ObstacleLine tempVar = Obstacles[S];
					PrepareNewObsatcle(ref tempVar, S);
						Obstacles[S] = tempVar;
				}
				// 
				CalculateWindowData();
				//'
				if (SortObstaclesByDistanceToStartPoint == true)
				{
					SortObstacles();
				}
				//      
				CreateWindoWObstalcesMatrix();
				//
				//those are maze start and end points, I do not want to block them
				NodeToNodeVisibility[0, 1] = (byte)NodeToNodeVisibilityType.NotTested;
				NodeToNodeVisibility[1, 0] = (byte)NodeToNodeVisibilityType.NotTested;
				//
				PreCalculationDone = true;
			}
			//
			//'check if maze start node is visible to end node, no need to do more calculation
			if (CheckNodeToNodeVisible(MazeStartNode, MazeEndNode) == true)
			{
				//no obstacle blocking the path
				InitialPath.PathNode.Add(MazeEndNode);
				InitialPath.CurrentPathStatus = PathStatusTypes.Solution;
				InitialPath.PathLength = MazeStartToEndDistance; //CalDis(MazeStartNode.NodePoint, MazeEndNode.NodePoint)
				FoundPaths.Add(InitialPath);
				return 1;
			}
			//
			MinimumPathLengthFound = 0;
			PathWasFound = false;
			// 
			//############################################################################################################
			//Obstalce filtering part
			FilterObstacles();
			//*************************************************************************
			int FoundPathesCount = 0;
			//
			switch (MazeSolveMethod)
			{
				case SolutionMethods.Dijkstra:
					SolveMazeDijkstra();
					FoundPathesCount = 1;
					break;
				case SolutionMethods.Hexagon:
					FoundPathesCount = Convert.ToInt32(SolveByArnaoot(ref Obstacles));
					break;
				case SolutionMethods.ArnaootFireLine:
					SolveByArnaootFirLine();
					break;
				case SolutionMethods.HexagonDynamic:
					FindPath_DynamicObstacles();
					break;
			}
			//
			//############################################################################################################
			//'solution done , counting resulting paths , still searching for soultion (this should be zero) because all path were searched, blocked , solution  , too long
			SearchingPathNo = 0;
			BlockedPathNo = 0;
			SolPathNo = 0;
			TooLongPathNo = 0;
			//
			for (S = 0; S < FoundPaths.Count; S++)
			{
				switch (FoundPaths[S].CurrentPathStatus)
				{
					case PathStatusTypes.Searching:
						SearchingPathNo = SearchingPathNo + 1;
						break;
					case PathStatusTypes.Blocked:
						BlockedPathNo = BlockedPathNo + 1;
						break;
					case PathStatusTypes.Solution:
						SolPathNo = SolPathNo + 1;
						break;
					case PathStatusTypes.TooLong:
						TooLongPathNo = TooLongPathNo + 1;
						break;
				}
			}
			//'
			return FoundPathesCount;
			//
		}
#endregion

#region Path Find
#region Hexagon , arnaoot fire line general Path Find
#region Create Path
		private Path CreateInitialPath()
		{
			Path InitialPath = new Path();
			Node StartNode = new Node();
			//
			InitialPath.PathNode = new List<Node>();
			StartNode = MazeStartNode;
			InitialPath.PathNode.Add(StartNode);
			//
			return InitialPath;
		}
		//
		private void CreateAllStartPaths(ref List<ObstacleLine> LocalUsedObstaclesList)  
		{
			Path InitialPath = CreateInitialPath();
			int S = 0;
			int ObstaclePointType = 0;
 //
			for (S = 0; S < LocalUsedObstaclesList.Count; S++)
			{
				if (LocalUsedObstaclesList[S].InsideSearchRegion == true && LocalUsedObstaclesList[S].TestedForPathStart == false)
				{

					for (ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType <= ObstaclePointLastTypeIndex; ObstaclePointType++)
					{
						Node TempNode = new Node();
						TempNode.NodeObstacleNumber = LocalUsedObstaclesList[S].ObstacleIndex; //S
						TempNode.NodeObstaclePointType = ObstaclePointType;
						TempNode.NodePoint = LocalUsedObstaclesList[S].PointsExtended[ObstaclePointType];
						//
						if (CheckNodeToNodeVisible(MazeStartNode, TempNode) == true)
						{
							CreateNewPath(InitialPath, TempNode);
						}
						LocalUsedObstaclesList[S].TestedForPathStart = true;
					}
				}
			}
		}
		//
		private int CreateNewPath(Path OldPath, Node NewNode)
		{
			Path TempPath = new Path();
			float LineLength = 0F;
			Node PathLastNode = OldPath.PathNode[OldPath.PathNode.Count - 1];
			Node tempNode = new Node();
			//
			if (OldPath.PathNode.Contains(NewNode))
			{
				return 0;
			}
			//
			LineLength = CalNodeDis(NewNode, PathLastNode);
			TempPath.PathLength = OldPath.PathLength + LineLength;
			//
			if (PathWasFound == true)
			{
				if (OldPath.PathLength > MinimumPathLengthFound && ApplyMinimumPath == true) //And FrmGUI.CheckBoxApplyMinimumPath.Checked = True Then
				{
					return 0;
				}
			}
			//
			tempNode = NewNode;
			TempPath.PathNode = new List<Node>();
			TempPath.PathNode.AddRange(OldPath.PathNode);
			TempPath.PathNode.Add(tempNode);
			TempPath.CurrentPathStatus = PathStatusTypes.Searching;
			//
			//TempPath.CurrentPathStatus = PathStatusTypes.Searching
			if (FoundPaths.Contains(TempPath))
			{
				return FoundPaths.Count - 1;
			}
			else
			{
				FoundPaths.Add(TempPath);
				//CheckPath(FoundPath(FoundPath.Count - 1))
				// CheckPath(TempPath)
				return FoundPaths.Count - 1;
			}
		}
#endregion
#region path processing
		public void SortPaths()
		{
			//   FoundPath.Sort(Function(x, y) x.PathLength.CompareTo(y.PathLength))
			//
			List<Path> Sorted = new List<Path>();
			Sorted = FoundPaths.OrderBy((X) => -X.CurrentPathStatus).ThenBy((X) => X.PathLength).ToList();
			FoundPaths = Sorted;
		}
		private void CheckPath(ref Path CheckedPath, ref List<ObstacleLine> LocalUsedObstaclesList) // ByVal UseFireLineObstacles As Boolean)
		{
			int ObstacleNumber = 0;
			var PathNodesNo = CheckedPath.PathNode.Count;
			Node PathCurrentNode = new Node(); //= CheckedPath.PathNode(PathNodesNo - 1)
			//
			List<Node> PossiblePathNodes = new List<Node>();
			float LineLength = 0F;
			//
			int CurrentNodeWindowX = 0;
			int CurrentNodeWindowY = 0;
			int NextNodeWindowX = 0;
			int NexttNodeWindowY = 0;
			//
			//Dim LocalUsedObstaclesList As List(Of ObstacleLine) '= Obstacles
			//'Dim LocalUsedObstaclesList As List(Of ObstacleLine) = Obstacles
			//'
			//If UseFireLineObstacles = True Then
			//    LocalUsedObstaclesList = FireLineObstacles
			//Else
			//    LocalUsedObstaclesList = Obstacles
			//End If

			//Debug.Print("PathNo:" + PathNo.ToString)
			//Debug.Print("PathPointNo:" + PathPointNo.ToString)
			//Debug.Print("__________________________")
			//If PathNo > 300 Then
			//    'Stop
			//    Exit Sub
			//End If
			//bool Initial = true;
			//  Do While PossiblePathNodes.Count > 0 Or Initial = True  'CheckedPath.CurrentPathStatus = PathStatusTypes.Searching
			//Initial = false;
			PathCurrentNode = CheckedPath.PathNode[CheckedPath.PathNode.Count - 1];
			PossiblePathNodes.Clear();
			//
			if (CheckNodeToNodeVisible(PathCurrentNode, MazeEndNode) == true)
			{
				CheckedPath.CurrentPathStatus = PathStatusTypes.Solution;
				CheckedPath.PathNode.Add(MazeEndNode);
				LineLength = CalNodeDis(PathCurrentNode, MazeEndNode);
				CheckedPath.PathLength = CheckedPath.PathLength + LineLength;
				if (PathWasFound == true && ApplyMinimumPath == true)
				{
					if (MinimumPathLengthFound > CheckedPath.PathLength)
					{
						MinimumPathLengthFound = CheckedPath.PathLength;
					}
				}
				else
				{
					PathWasFound = true;
					MinimumPathLengthFound = CheckedPath.PathLength;
				}
				return;
				//Stop
			}
			else
			{
				if (PathWasFound == true && ApplyRoughMinPath == true)
				{
					if ((CalNodeDis(PathCurrentNode, MazeEndNode) + CheckedPath.PathLength) > MinimumPathLengthFound)
					{
						//the new path will be greatr than the already found path, it is too far !!!!1 
						CheckedPath.CurrentPathStatus = PathStatusTypes.TooLong;
						//FoundPath.Remove(CheckedPath)
						//CheckedPath = Nothing
						return;
					}
				}
				//
				//the following part checks the obsatcles in the  next window in the direction of the solution first to speed up calculations
				if (PathCurrentNode.NodeObstacleNumber == -1)
				{
					//this is maze start
					CurrentNodeWindowX = MazeStartWindowX;
					CurrentNodeWindowY = MazeStartWindowY;
				}
				else
				{
					CurrentNodeWindowX = Obstacles[PathCurrentNode.NodeObstacleNumber].ObstacleWindowX;
					CurrentNodeWindowY = Obstacles[PathCurrentNode.NodeObstacleNumber].ObstacleWindowY;
				}
				//getting the next window id 
				int Xmotion = 0;
				int Ymotion = 0;
				//
				if (CurrentNodeWindowX < MazeEndWindowX)
				{
					Xmotion = 1;
				}
				else
				{
					if (CurrentNodeWindowX > MazeEndWindowX)
					{
						Xmotion = -1;
					}
					else
					{
						Xmotion = 0;
					}
				}
				//
				if (CurrentNodeWindowY < MazeEndWindowY)
				{
					Ymotion = 1;
				}
				else
				{
					if (CurrentNodeWindowY > MazeEndWindowY)
					{
						Ymotion = -1;
					}
					else
					{
						Ymotion = 0;
					}
				}
				//
				NextNodeWindowX = CurrentNodeWindowX + Xmotion;
				NexttNodeWindowY = CurrentNodeWindowY + Ymotion;
				//
				//For s = 0 To ObstacleWindowSort(NextNodeWindowX, NexttNodeWindowY).Count - 1
				//    For ObstaclePointType = ObstaclePointTypeStart To ObstaclePointTypeEnd
				//        Dim TempCurrentNode As Node = New Node
				//        Dim TempObstacleNode As Node = New Node
				//        TempObstacleNode.NodeObstacleNumber = ObstacleWindowSort(NextNodeWindowX, NexttNodeWindowY)(s)
				//        TempObstacleNode.NodeObstaclePointType = ObstaclePointType
				//        TempObstacleNode.NodePoint = LocalUsedObstaclesList(TempObstacleNode.NodeObstacleNumber).PointsExtentended(ObstaclePointType)
				//        TempCurrentNode = CheckedPath.PathNode(CheckedPath.PathNode.Count - 1)
				//    Next
				//Next
				//For s = 0 To ObstacleWindowSort(CurrentNodeWindowX, CurrentNodeWindowY).Count - 1
				//    For ObstaclePointType = ObstaclePointTypeStart To ObstaclePointTypeEnd
				//        Dim TempCurrentNode As Node = New Node
				//        Dim TempObstacleNode As Node = New Node
				//        TempObstacleNode.NodeObstacleNumber = ObstacleWindowSort(CurrentNodeWindowX, CurrentNodeWindowY)(s)
				//        TempObstacleNode.NodeObstaclePointType = ObstaclePointType
				//        TempObstacleNode.NodePoint = Obstacles(TempObstacleNode.NodeObstacleNumber).PointsExtentended(ObstaclePointType)
				//        TempCurrentNode = CheckedPath.PathNode(CheckedPath.PathNode.Count - 1)
				//        AddPointToPossiblePointsList(PossiblePathNodes, CheckedPath, TempCurrentNode, TempObstacleNode)
				//    Next
				//Next
				for (ObstacleNumber = 0; ObstacleNumber < LocalUsedObstaclesList.Count; ObstacleNumber++)
				{
					for (var ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType <= ObstaclePointLastTypeIndex; ObstaclePointType++)
					{
						Node TempCurrentNode = new Node();
						Node TempObstacleNode = new Node();
						TempObstacleNode.NodeObstacleNumber = LocalUsedObstaclesList[ObstacleNumber].ObstacleIndex; // ObstacleNumber
						TempObstacleNode.NodeObstaclePointType = ObstaclePointType;
						TempObstacleNode.NodePoint = LocalUsedObstaclesList[ObstacleNumber].PointsExtended[ObstaclePointType];
						TempCurrentNode = CheckedPath.PathNode[CheckedPath.PathNode.Count - 1];
						AddPointToPossiblePointsList(ref PossiblePathNodes, ref CheckedPath, TempCurrentNode, TempObstacleNode);
					}
				}
				if (PossiblePathNodes.Count == 0)
				{
					//no new points i.e. path is blocked
					CheckedPath.CurrentPathStatus = PathStatusTypes.Blocked;
					// FoundPath.Remove(CheckedPath)
					return;
				}
				else
				{
					if (PossiblePathNodes.Count > 1)
					{
						CheckPathTooLong(ref CheckedPath);

						//if there is more than one possible points create new pathes based on cureent point then add a point to current path
						for (ObstacleNumber = 1; ObstacleNumber < PossiblePathNodes.Count; ObstacleNumber++)
						{
							CreateNewPath(CheckedPath, PossiblePathNodes[ObstacleNumber]);
						}
					}
					//
					CheckedPath.PathNode.Add(PossiblePathNodes[0]);
					LineLength = CalNodeDis(PathCurrentNode, PossiblePathNodes[0]);
					CheckedPath.PathLength = CheckedPath.PathLength + LineLength;
					//
					if (PathWasFound == true && ApplyMinimumPath == true) //And FrmGUI.CheckBoxApplyMinimumPath.Checked = True Then
					{
						if (CheckedPath.PathLength > MinimumPathLengthFound)
						{
							CheckedPath.CurrentPathStatus = PathStatusTypes.TooLong;
							// FoundPath.Remove(CheckedPath)
							//CheckedPath = Nothing
							return;
						}
					}
				}
			}
			//Loop
			//
		}
		private bool CheckPathTooLong(ref Path CheckedPath)
		{
			int ObsNo = 0;
			int ObsType = 0;
			float PathLength = 0F;
			int S = CheckedPath.PathNode.Count - 1;
			//Dim PreviousNodeNo, CurrentNodeNumber As Integer
			//
			if (S == 0) //no need to check as that is only the start point
			{
				return false;
			}
			//ObsNo = CheckedPath.PathNode(CheckedPath.PathNode.Count - 1).NodeObstacleNumber
			//If ObsNo = -1 Then Return False 'no need to check as the path is a solution 
			//
			for (S = 1; S < CheckedPath.PathNode.Count; S++)
			{
				ObsNo = CheckedPath.PathNode[S].NodeObstacleNumber;
				ObsType = CheckedPath.PathNode[S].NodeObstaclePointType;
				PathLength = PathLength + CalNodeDis(CheckedPath.PathNode[S - 1], CheckedPath.PathNode[S]);
				//
				//  If (PathLength - Obstacles(ObsNo).MinDistanceMazeStart(ObsType)) > 0.1 Then
				if (PathLength > (float)(Obstacles[ObsNo].MinDistanceMazeStart[ObsType]))
				{
					CheckedPath.CurrentPathStatus = PathStatusTypes.TooLong;
					return true;
				}
				else
				{
					Obstacles[ObsNo].MinDistanceMazeStart[ObsType] = PathLength;
				}
			}
			//
			return false;
		}
		private void AddPointToPossiblePointsList(ref List<Node> PossiblePointsList, ref Path currentPath, Node PathCurrentNode, Node CheckedNode)
		{
			Point tempPoint = new Point();
			float CurrenttoNewDistance = 0F;
			int S1 = 0;
			bool AddPoint = true;
			//
			//
			if (Obstacles[CheckedNode.NodeObstacleNumber].InsideSearchRegion == false)
			{
				return;
			}
			//
			if (currentPath.PathNode.Contains(CheckedNode) == true)
			{
				return; //do not add the same point twice
			}
			//
			//check if new path line is clear from obsatcles
			if (CheckNodeToNodeVisible(PathCurrentNode, CheckedNode) == false)
			{
				return;
			}
			//
			//check that path does not intersect itself 
			S1 = currentPath.PathNode.Count;
			if (S1 > 2)
			{
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of S1 - 3 for every iteration:
				int tempVar = S1 - 3;
				for (S1 = 0; S1 <= tempVar; S1++)
				{
					if (CheckTwoLineIntersect(PathCurrentNode.NodePoint, CheckedNode.NodePoint, currentPath.PathNode[S1].NodePoint, currentPath.PathNode[S1 + 1].NodePoint, ref tempPoint) == true)
					{
						return;
					}
				}
			}
			//
			CurrenttoNewDistance = CalNodeDis(PathCurrentNode, CheckedNode); //* 0.5
			//
			if (ApplyMinimumPointPath == true)
			{
				//the part that calculates each obstacle end distance to start point to prevent adding a point with a long path
				if (Obstacles[CheckedNode.NodeObstacleNumber].MinDistanceMazeStart[CheckedNode.NodeObstaclePointType] == 0)
				{
					Obstacles[CheckedNode.NodeObstacleNumber].MinDistanceMazeStart[CheckedNode.NodeObstaclePointType] = currentPath.PathLength + CurrenttoNewDistance;
					//Obstacles(CheckedNode.NodeObstacleNumber).MinDistanceMazeStart(CheckedNode.NodeObstaclePointType) = Int(currentPath.PathLength) + Int(CurrenttoNewDistance)
					//AddPoint = True
				}
				else
				{
					//If (currentPath.PathLength + Int(CurrenttoNewDistance)) - Int(Obstacles(CheckedNode.NodeObstacleNumber).MinDistanceMazeStart(CheckedNode.NodeObstaclePointType)) < 0.9 Then
					if ((currentPath.PathLength + CurrenttoNewDistance) - Obstacles[CheckedNode.NodeObstacleNumber].MinDistanceMazeStart[CheckedNode.NodeObstaclePointType] < 0.001)
					{
						//MinimumPointPath condition is valid leave AddPoint as it is
						//Obstacles(CheckedNode.NodeObstacleNumber).MinDistanceMazeStart(CheckedNode.NodeObstaclePointType) = Int(currentPath.PathLength) + Int(CurrenttoNewDistance)
						Obstacles[CheckedNode.NodeObstacleNumber].MinDistanceMazeStart[CheckedNode.NodeObstaclePointType] = currentPath.PathLength + CurrenttoNewDistance;
						//AddPoint = True
					}
					else
					{
						//MinimumPointPath condition is not valid !!!!,  exit sub without adding the point
						AddPoint = false;
						return;
					}
				}

			}
			//
			if (AddPoint == true)
			{
				PossiblePointsList.Add(CheckedNode);
			}
		}
#endregion
#region Solve Methods
#region  Dynamic Obstacles
#region Dynamic Obstacle  solve
		public static float CourseToAngle(float Course)
		{
			if (Course <= (float)Angle90Rad)
			{
				return (float)(Angle90Rad - Course);
			}
			if (Course <= (float)Math.PI)
			{
				return (float)(Math.PI * 2 - Course);
			}
			if (Course <= (float)(3 * Math.PI / 2))
			{
				return (float)(3 * Math.PI / 2 - Course);
			}
			if (Course > (float)(3 * Math.PI / 2)) //'- (Angle90Rad)
			{
				return (float)(5 * Math.PI / 2 - Course);
			}
			//'
			System.Diagnostics.Debugger.Break();
			return 100000000;
		}
		public int EvaluateSolutionPathsDynamics()
		{
			//'
			SetupDynamicObstacles();
			//'
			for (var s = 0; s < FoundPaths.Count; s++)
			{
				if (FoundPaths[s].CurrentPathStatus == PathStatusTypes.Solution)
				{
					if (CheckPathSafeDynamic(FoundPaths[s]) == true)
					{
						return s;
					}
				}
			}
			return -1;
		}
		public bool FindPath_DynamicObstacles()
		{
			SetupDynamicObstacles();
			//'
			if (Convert.ToInt32(SolveByArnaoot(ref Obstacles)) > 0 && PathWasFound == true)
			{
				for (var s = 1; s <= 10; s++) //'number of search trials before stop to not search for ever
				{
					if (IterateDynamicPath(FoundPaths[0]) == true)
					{
						return true;
					}
				}
			}
			//'
			return false;
		}
		public bool CheckPathSafeDynamic(Path Mypath)
		{
			MovingUnitData MySimulatedVehicle = new MovingUnitData();
			int TempObstacleAdded = 0;
			//       
			int SimulatedSolutionPathCurrentTargetNode = 0;
			float SimulationTime = 0;
			//'
			//' set the parameters to start the simulation
			StartSimulation(ref MySimulatedVehicle, Mypath, ref SimulatedSolutionPathCurrentTargetNode, ref SimulationTime);
			//'run the simulation to the end
			while (OneStepSimulation(ref MySimulatedVehicle, Mypath, ref SimulatedSolutionPathCurrentTargetNode, ref SimulationTime, 1) == true)
			{
				for (var v = 0; v < MovingObstacles.Count(); v++)
				{

					if (CalPointDis(MovingObstacles[v].GetPositionSimulatedPoint(), MySimulatedVehicle.GetPositionSimulatedPoint()) < MovingObstacles[v].SafeDynamicObstacleToMyVehicleDistance)
					{
						TempObstacleAdded += 1;
						//'
						float EquilateralMinorAxis = (float)(((MySpeed + MovingObstacles[v].Speed) + (MazeStartToEndDistance * 0.05)) / 2);
						//'
						CreateEquilateralfromPointAngle(ref MovingObstacles[v].DangerZonePoint, MovingObstacles[v].GetPositionSimulatedPoint(), (float)(Angle90Rad - MovingObstacles[v].Course), EquilateralMinorAxis, EquilateralMinorAxis * 2);
						MovingObstacles[v].DangerZonePoint[4] = MovingObstacles[v].DangerZonePoint[0]; //add the first point again to close the rectangle
						//
						for (var gg = 0; gg <= 3; gg++)
						{
							ObstacleLine myObstacle = new ObstacleLine();
							myObstacle.Points[ObstaclePointTypeStart] = MovingObstacles[v].DangerZonePoint[gg];
							myObstacle.Points[ObstaclePointLastTypeIndex] = MovingObstacles[v].DangerZonePoint[gg + 1];
							//
							//'myObstacle.ObstacleMiddlePoint = CalMiddlePoint(MovingObstacles(v).DangerZonePoint(gg), MovingObstacles(v).DangerZonePoint(gg + 1))
							Obstacles.Add(myObstacle);
						}
					}
				}
			}
			//'
			if (TempObstacleAdded == 0)
			{
				return true;
			}
			//'
			return false;
		}
		public bool IterateDynamicPath(Path Mypath)
		{
			//MovingUnitData MySimulatedVehicle = new MovingUnitData();
			int ObstaclesOldCount = Obstacles.Count;
			//'
			//'
			if (CheckPathSafeDynamic(Mypath) == true)
			{
				return true; //'solution found
			}
			else
			{
				ClearData(false, true);
				//'
				for (var s = ObstaclesOldCount; s < Obstacles.Count; s++)
				{
					WindowsApp2.ClassPathPlan.ObstacleLine tempVar = Obstacles[s];
					PrepareNewObsatcle(ref tempVar, s);
						Obstacles[s] = tempVar;
					Obstacles[s].ObstacleType = ObstacleTypes.DynamicObsatcle;
				}
				//'
				SolveByArnaoot(ref Obstacles);
				//'Mypath = FoundPaths(0)
				//remove all previously added obstacles to prepare for new simulation
				//For k = Obstacles.Count - 1 To 0 Step -1
				//    If Obstacles(k).ObstacleType = ObstacleTypes.DynamicObsatcle Then
				//        Obstacles.RemoveAt(k)
				//    End If
				//Next
				//'
			}
			return false;
		}
#region dynamic obstacle Simulation
		public void StartSimulation(ref MovingUnitData MySimulatedVehicle, Path Mypath, ref int MySimulatedSolutionPathCurrentTargetNode, ref float MySimulationTime)
		{
			MySimulatedVehicle = new MovingUnitData();
			//'
			MySimulatedVehicle.UpdatePositionSimulatedPoint(MazeStartNode.NodePoint);
			MySimulatedVehicle.Speed = MySpeed;
			MySimulatedVehicle.Course = CalAnglePointRad(MazeStartNode.NodePoint, Mypath.PathNode[1].NodePoint);
			//'
			MySimulatedSolutionPathCurrentTargetNode = 1;
			//'
			MySimulationTime = 0;
			//'
			for (var s = 0; s < MovingObstacles.Count(); s++)
			{
				MovingObstacles[s].UpdatePositionSimulatedPoint(MovingObstacles[s].Position);
			}
		}
		public bool OneStepSimulation(ref MovingUnitData MySimulatedVehicle, Path MyPath, ref int MySimulatedSolutionPathCurrentTargetNode, ref float MySimulationTime, float SimulationStepTime)
		{
			MySimulationTime += SimulationStepTime;
			//'Update myVehicle Poisiton
			//MySimulatedVehicle.PositionSimulated = UpdateLocation(MySimulatedVehicle.PositionSimulated, MySimulatedVehicle.Course, MySimulatedVehicle.Speed, SimulationStepTime)
			MySimulatedVehicle.UpdateMylocation(SimulationStepTime);
			//
			//'update all dynamic obstacles position..
			for (var s = 0; s < MovingObstacles.Count(); s++)
			{
				//MovingObstacles(s).PositionSimulated = UpdateLocation(MovingObstacles(s).PositionSimulated, Math.PI - MovingObstacles(s).Course, MovingObstacles(s).Speed, SimulationStepTime)
				MovingObstacles[s].UpdateMylocation(SimulationStepTime);
			}
			//'the distacne between my vehicle current position and next node is less than or equal to what i cover with MySpeed in SimulationStepTime second with safety factor 1.5
			//'Debug.Print(MySimulatedVehicle.PositionSimulated.X.ToString + "  .  " + MySimulatedVehicle.PositionSimulated.Y.ToString)
			if (CalPointDis(MyPath.PathNode[MySimulatedSolutionPathCurrentTargetNode].NodePoint, MySimulatedVehicle.GetPositionSimulatedPoint()) < MySpeed * SimulationStepTime)
			{
				//'node reached
				MySimulatedSolutionPathCurrentTargetNode += 1;
				if (MyPath.PathNode.Count <= MySimulatedSolutionPathCurrentTargetNode)
				{
					//'simulation End
					return false;
				}
				else
				{
					MySimulatedVehicle.UpdatePositionSimulatedPoint(MyPath.PathNode[MySimulatedSolutionPathCurrentTargetNode - 1].NodePoint);
					//MySimulatedVehicle.PositionSimulatedX = MyPath.PathNode(MySimulatedSolutionPathCurrentTargetNode - 1).NodePoint.X
					//MySimulatedVehicle.PositionSimulatedY = MyPath.PathNode(MySimulatedSolutionPathCurrentTargetNode - 1).NodePoint.Y
					MySimulatedVehicle.Course = CalAnglePointRad(MySimulatedVehicle.GetPositionSimulatedPoint(), MyPath.PathNode[MySimulatedSolutionPathCurrentTargetNode].NodePoint);
				}
			}
			//
			return true;
		}
		//Private Function UpdateLocation(ByVal CurrentLocation As Point, ByVal Course As Single, ByVal Speed As Single, ByVal SimulationStepTime As Single) As Point
		//    Return CalLineSecondPoint(CurrentLocation, Course - Angle90Rad, Speed * SimulationStepTime)
		//End Function
#endregion

#endregion
		public Point[] CreateRectanglefromPointAngle(ref Point[] RectanglePoints, Point Location, float AngleDegree, float Width, float Length)
		{
			//'Dim RectanglePoints(4) As Point
			RectanglePoints = new Point[5];
			//'
			//'90- angle because navigational angles are measured clock wise , and the reference is north 0 equals to 90
			Point CourseExtension1 = CalLineSecondPoint(Location, (float)(Angle90Rad - AngleDegree), Length / 2);
			Point CourseExtension2 = CalLineSecondPoint(Location, (float)(Angle90Rad - AngleDegree), -Length / 2);
			//'
			ExtendPointPerPendicular(CourseExtension1, -AngleDegree, Width / 2, ref RectanglePoints[0], ref RectanglePoints[3]); //'90-90-AngleDegree=-AngleDegree
			ExtendPointPerPendicular(CourseExtension2, -AngleDegree, Width / 2, ref RectanglePoints[1], ref RectanglePoints[2]); //'90-90-AngleDegree=-AngleDegree
			//'
			RectanglePoints[4] = RectanglePoints[0];
			return RectanglePoints;
		}

		public Point[] CreateEquilateralfromPointAngle(ref Point[] MyEquilateralPoints, Point CenterLocation, float AngleDegree, float MajorAxisLength, float MinorAxisLength)
		{
			//'90- angle because navigational angles are measured clock wise , and the reference is north 0 equals to 90
			MyEquilateralPoints[0] = CalLineSecondPoint(CenterLocation, (float)(Angle90Rad - AngleDegree), MajorAxisLength / 2);
			MyEquilateralPoints[2] = CalLineSecondPoint(CenterLocation, (float)(Angle90Rad - AngleDegree), -MajorAxisLength / 2);
			//
			ExtendPointPerPendicular(CenterLocation, AngleDegree, MinorAxisLength / 2, ref MyEquilateralPoints[1], ref MyEquilateralPoints[3]);
			//
			return MyEquilateralPoints;
		}

		private bool CreateObstacleDangerZone(ref MovingUnitData DynamicObstacle)
		{
			//'
			float TimeToFinishTheMaze = (float)(MazeStartToEndDistance / MySpeed * 1.0); //'1.5 is the safety margin
			float DynamicObstaclerange = TimeToFinishTheMaze * DynamicObstacle.Speed;
			DynamicObstacle.FuturePosition = CalLineSecondPoint(DynamicObstacle.Position, (float)DynamicObstacle.Course, DynamicObstaclerange);
			//'
			Point PathintersectionPoint = new Point();
			//create obstacle  initial postion   points
			CreateRectanglefromPointAngle(ref DynamicObstacle.BodyDefiningPoints, DynamicObstacle.Position, (float)DynamicObstacle.Course, DynamicObstacle.Width, DynamicObstacle.Length);
			DynamicObstacle.DangerZonePoint = new Point[5];
			//'
			double T1 = 0D; //'T varaibles of bezier line intersection , when t<0 intersection before line segment, 0<t<1 on line segment, t>1 after line segemnt
			double T2 = 0D;
			CheckTwoLineIntersectGetT1T2(MazeStartNode.NodePoint, MazeEndNode.NodePoint, DynamicObstacle.Position, DynamicObstacle.FuturePosition, ref PathintersectionPoint, ref T1, ref T2);

			//TempPathintersectionPoint = PathintersectionPoint


			//T1 = 1
			//T2 = 1
			//' PathintersectionPoint = CalculatePerpendicularPointToLine(MazeStartNode.NodePoint, MazeEndNode.NodePoint, DynamicObstacle.Position)
			//'
			//If T1 > -0.1 And T2 > -0.1 Then ''to make sure that the intersection point is on the forward path not the back path 
			//'create 4 lines And add them as an obstacle
			//'Dim ObstacleToCollisionPointTime As Single = CalPointDis(DynamicObstacle.Position, PathintersectionPoint) / DynamicObstacle.Speed
			float MyVechileToCollisionPointTime = CalPointDis(MazeStartNode.NodePoint, PathintersectionPoint) / MySpeed;
			//'Dim DangerZonePoint(4) As Point
			//'
			//' If Math.Abs(ObstacleToCollisionPointTime - MyVechileToCollisionPointTime) * FastedSpeed < (SafeDistance + Math.Max(DynamicObstacle.Width, DynamicObstacle.Length)) * 1.5 Then '' the 1.5 factor is a safety margin
			//'DynamicObstacle.PositionPredicted = CalLineSecondPoint(DynamicObstacle.Position, DynamicObstacle.Course, MyVechileToCollisionPointTime * DynamicObstacle.Speed)
			//'calculate the start   and end distance of danger zone , the location the obstacle will be in when my vehilce reachs the PathintersectionPoint
			//' it is DynamicDangerZoneSafetyFactor% before the location and DynamicDangerZoneSafetyFactor% after the location
			//Dim ObsatcledangerLocationDistanceStart As Single = (MyVechileToCollisionPointTime * (100 - DynamicDangerZoneSafetyFactor) / 100 * DynamicObstacle.Speed) - DynamicObstacle.Length / 2 ''with 0.2 safety factor
			//Dim ObsatcledangerLocationDistanceEnd As Single = (MyVechileToCollisionPointTime * (100 + DynamicDangerZoneSafetyFactor) / 100 * DynamicObstacle.Speed) + DynamicObstacle.Length / 2 ''with 0.2 safety factor
			//Dim ObsatcledangerLocationStart As Point = CalLineSecondPoint(DynamicObstacle.Position, Angle90Rad - DynamicObstacle.Course, ObsatcledangerLocationDistanceStart)
			//Dim ObsatcledangerLocationEnd As Point = CalLineSecondPoint(DynamicObstacle.Position, Angle90Rad - DynamicObstacle.Course, ObsatcledangerLocationDistanceEnd)
			//'create the danger zone rectangle with the calcuated points  
			//ExtendPointPerPendicular(ObsatcledangerLocationStart, -DynamicObstacle.Course, DynamicObstacle.Width / 2, DynamicObstacle.DangerZonePoint(0), DynamicObstacle.DangerZonePoint(3))
			//ExtendPointPerPendicular(ObsatcledangerLocationEnd, -DynamicObstacle.Course, DynamicObstacle.Width / 2, DynamicObstacle.DangerZonePoint(1), DynamicObstacle.DangerZonePoint(2))
			//'DynamicObstacle.DangerZonePoint

			float EquilateralMinorAxis = (float)(((MySpeed + DynamicObstacle.Speed) + (MazeStartToEndDistance * 0.05)) / 4);
			CreateEquilateralfromPointAngle(ref DynamicObstacle.DangerZonePoint, PathintersectionPoint, (float)(Angle90Rad - DynamicObstacle.Course), EquilateralMinorAxis, EquilateralMinorAxis * 2);
			DynamicObstacle.DangerZonePoint[4] = DynamicObstacle.DangerZonePoint[0]; //add the first point again to close the rectangle
			//
			//
			//'check if the danger zone inside the MazeMinPoint to MazeMaxPoint rectangle
			//'this is done by checking the four points coordiantes of the obstacle danger zone ,
			//'If one Or more Then points are In the maze start to maze end rectangle (maze minimum to maze maximum) 
			//'then it Is added else rejected
			//'If CheckDangerZoneInsideSearch(DynamicObstacle.DangerZonePoint) = True Then
			for (var s = 0; s <= 3; s++)
			{
				ObstacleLine myObstacle = new ObstacleLine();
				myObstacle.ObstacleType = ObstacleTypes.DynamicObsatcle;
				myObstacle.Points[ObstaclePointTypeStart] = DynamicObstacle.DangerZonePoint[s];
				myObstacle.Points[ObstaclePointLastTypeIndex] = DynamicObstacle.DangerZonePoint[s + 1];
				Obstacles.Add(myObstacle);
			}
			return true;
			//' End If
			//'End If
			//End If
			//return false;
		}
		public bool CheckDangerZoneInsideSearch(Point[] ObsaclePoint)
		{
			int code1 = 0; //'= computeCode(x1, y1)
			for (var s = 0; s <= ObsaclePoint.GetUpperBound(0); s++)
			{
				code1 = computeCode(ObsaclePoint[s]);
				if (code1 == 0)
				{
					return true;
				}
			}
			return false;
		}
		private object SetupDynamicObstacles()
		{
			//'update the maze min max points to be the role to know wether the obstacle in the maze active area or not  
			UpdateMazeWindow(MazeStartNode.NodePoint);
			UpdateMazeWindow(MazeEndNode.NodePoint);
			//'
			if (MovingObstacles.Count() > 0)
			{
				for (var s = 0; s < MovingObstacles.Count(); s++)
				{
					CreateObstacleDangerZone(ref MovingObstacles[s]);
					MovingObstacles[s].SafeDynamicObstacleToMyVehicleDistance = Convert.ToInt32(SafeDistance + Math.Max(MovingObstacles[s].Width, MovingObstacles[s].Length));
				}
			}
			return null;
		}
#endregion
#region Line Clipping
		//' Defining region codes
		public const int INSIDE = 0; //' 0000
		public const int LEFT = 1; //' 0001
		public const int RIGHT = 2; //' 0010
		public const int BOTTOM = 4; //' 0100
		public const int TOP = 8; //' 1000
		public int computeCode(Point CheckPoint)
		{
			int x = CheckPoint.X;
			int y = CheckPoint.Y;
			// initialized as being inside
			int code = INSIDE;

			if (x < MazeMinPoint.X) // to the left of rectangle
			{
				code |= LEFT;
			}
			else if (x > MazeMaxPoint.X) // to the right of rectangle
			{
				code |= RIGHT;
			}
			if (y < MazeMinPoint.Y) // below the rectangle
			{
				code |= BOTTOM;
			}
			else if (y > MazeMaxPoint.Y) // above the rectangle
			{
				code |= TOP;
			}

			return code;
		}
		//Private Function LiangBarskyLineClip(ByVal LineFirstPoint As Point, ByVal LineSecondPoint As Point, ByVal WindowFirstPoint As Point, ByVal WindowSecondPoint As Point, ByRef NewLineFirstPoint As Point, NewLineSecondOint As Point) As Integer
		//    Dim i, gm As Integer, gd As Integer '= DETECT
		//    Dim x1, y1, x2, y2, xmin, xmax, ymin, ymax, xx1, xx2, yy1, yy2, dx, dy As Integer
		//    Dim t1, t2, p(4), q(4), temp As Single
		//    x1 = 120
		//    y1 = 120
		//    x2 = 300
		//    y2 = 300
		//    xmin = 100
		//    ymin = 100
		//    xmax = 250
		//    ymax = 250
		//    '
		//    dx = x2 - x1
		//    dy = y2 - y1
		//    p(0) = -dx
		//    p(1) = dx
		//    p(2) = -dy
		//    p(3) = dy
		//    q(0) = x1 - xmin
		//    q(1) = xmax - x1
		//    q(2) = y1 - ymin
		//    q(3) = ymax - y1

		//    For i = 0 To 3

		//        If p(i) = 0 Then
		//            ' "line is parallel to one of the clipping boundary"
		//            If q(i) >= 0 Then

		//                If i < 2 Then

		//                    If y1 < ymin Then
		//                        y1 = ymin
		//                    End If

		//                    If y2 > ymax Then
		//                        y2 = ymax
		//                    End If

		//                    line(x1, y1, x2, y2)
		//                End If

		//                If i > 1 Then

		//                    If x1 < xmin Then
		//                        x1 = xmin
		//                    End If

		//                    If x2 > xmax Then
		//                        x2 = xmax
		//                    End If

		//                    line(x1, y1, x2, y2)
		//                End If
		//            End If
		//        End If
		//    Next

		//    t1 = 0
		//    t2 = 1

		//    For i = 0 To 4 - 1
		//        temp = q(i) / p(i)

		//        If p(i) < 0 Then
		//            If t1 <= temp Then t1 = temp
		//        Else
		//            If t2 > temp Then t2 = temp
		//        End If
		//    Next

		//    If t1 < t2 Then
		//        xx1 = x1 + t1 * p(1)
		//        xx2 = x1 + t2 * p(1)
		//        yy1 = y1 + t1 * p(3)
		//        yy2 = y1 + t2 * p(3)
		//        line(xx1, yy1, xx2, yy2)
		//    End If

		//    Return 0
		//End Function


#endregion

#region Arnaoot Hexagon
		private object SolveByArnaoot(ref List<ObstacleLine> LocalUsedObstaclesList) //ByVal UseFireLineObstacles As Boolean) As Integer
		{
			int SearchingNo = 1;
			int S = 0;
			//Dim LocalUsedObstaclesList As List(Of ObstacleLine) '= Obstacles
			//'
			//If UseFireLineObstacles = True Then
			//    LocalUsedObstaclesList = FireLineObstacles
			//Else
			//    LocalUsedObstaclesList = Obstacles
			//End If
			//Dim ObsNo, ObsType As Integer
			//
			//If ApplyIterariveMinimumPath = True Then
			//    ApplyMinimumPath = True
			//    MinimumPathLengthFound = IterariveMinimumPathStartPercent * MazeStratToEndDisance 'initial estimated path Length
			//End If
			//
			GetPointWindow(MazeStartNode.NodePoint, ref MazeStartWindowX, ref MazeStartWindowY);
			GetPointWindow(MazeEndNode.NodePoint, ref MazeEndWindowX, ref MazeEndWindowY);
			///////////////////////////////////////////////
			//create all possible start paths and start processing them
			CreateAllStartPaths(ref LocalUsedObstaclesList);
			////////////////////////////////////////////////////////////
			//
			while (SearchingNo > 0)
			{
				SearchingNo = 0;
				for (S = FoundPaths.Count - 1; S >= 0; S--)
				{
					if (FoundPaths[S].CurrentPathStatus == PathStatusTypes.Searching)
					{
						SearchingNo = 1 + SearchingNo;
						WindowsApp2.ClassPathPlan.Path tempVar = FoundPaths[S];
						if (CheckPathTooLong(ref tempVar) == true)
						{
								FoundPaths[S] = tempVar;
						}
						else
						{
								FoundPaths[S] = tempVar;
							WindowsApp2.ClassPathPlan.Path tempVar2 = FoundPaths[S];
							CheckPath(ref tempVar2, ref LocalUsedObstaclesList);
								FoundPaths[S] = tempVar2;
						}
					}
				}
			}
			//
			//#########################################################33
			//'the following part is excuted when no path is found
			//' Iterarive Minimum Path
			//Iterative Hexagon
			if (ApplyIterativeHexagon == true && PathWasFound == false && ObstacleFilterMethod == ObstacleFilteringMethods.Hexagon)
			{
				while (!(PathWasFound == true))
				{
					HexagonHeightRatio = HexagonHeightRatio + IterativeHexagonHeightStepRatio;
					//HexagonAngle = HexagonAngle + 3
					//If HexagonAngle >= 87 Then
					if (HexagonHeightRatio >= 2)
					{
						break;
					}
					//
					FilterObstacles();
					//
					if (ClearPreviousPathonEachIteration == true)
					{
						FoundPaths.Clear();
						CreateAllStartPaths(ref Obstacles);
						SearchingNo = 1;
						while (SearchingNo > 0)
						{
							SearchingNo = 0;
							for (S = FoundPaths.Count - 1; S >= 0; S--)
							{
								if (FoundPaths[S].CurrentPathStatus == PathStatusTypes.Searching)
								{
									SearchingNo = 1 + SearchingNo;
									WindowsApp2.ClassPathPlan.Path tempVar3 = FoundPaths[S];
									if (CheckPathTooLong(ref tempVar3) == true)
									{
											FoundPaths[S] = tempVar3;
									}
									else
									{
											FoundPaths[S] = tempVar3;
										WindowsApp2.ClassPathPlan.Path tempVar4 = FoundPaths[S];
										CheckPath(ref tempVar4, ref LocalUsedObstaclesList);
											FoundPaths[S] = tempVar4;
									}
								}
							}
						}
					}
					else
					{
						//creating new path with newly added obstacles
						Path InitialPath = CreateInitialPath();
						for (S = 0; S < LocalUsedObstaclesList.Count; S++)
						{
							if (LocalUsedObstaclesList[S].TestedForPathStart == false && LocalUsedObstaclesList[S].InsideSearchRegion == true)
							{
								LocalUsedObstaclesList[S].TestedForPathStart = true;
								for (var ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType <= ObstaclePointLastTypeIndex; ObstaclePointType++)
								{
									Node TempNode = new Node();
									TempNode.NodeObstacleNumber = LocalUsedObstaclesList[S].ObstacleIndex; //S
									TempNode.NodeObstaclePointType = ObstaclePointType;
									TempNode.NodePoint = LocalUsedObstaclesList[S].PointsExtended[ObstaclePointType];
									//
									if (CheckNodeToNodeVisible(MazeStartNode, TempNode) == true)
									{
										CreateNewPath(InitialPath, TempNode);
									}
								}
							}
						}
						//unblock the paths that are not long 
						for (S = FoundPaths.Count - 1; S >= 0; S--)
						{
							if (FoundPaths[S].CurrentPathStatus == PathStatusTypes.Blocked)
							{
								WindowsApp2.ClassPathPlan.Path tempVar5 = FoundPaths[S];
								if (CheckPathTooLong(ref tempVar5) == false)
								{
										FoundPaths[S] = tempVar5;
									FoundPaths[S].CurrentPathStatus = PathStatusTypes.Searching;
									}
									else
									{
										FoundPaths[S] = tempVar5;
								}
							}
						}
						//
						//checking the paths marked as searching
						SearchingNo = 1;
						while (SearchingNo > 0)
						{
							SearchingNo = 0;
							for (S = FoundPaths.Count - 1; S >= 0; S--)
							{
								if (FoundPaths[S].CurrentPathStatus == PathStatusTypes.Searching)
								{
									WindowsApp2.ClassPathPlan.Path tempVar6 = FoundPaths[S];
									if (CheckPathTooLong(ref tempVar6) == true)
									{
											FoundPaths[S] = tempVar6;
									}
									else
									{
											FoundPaths[S] = tempVar6;
										SearchingNo = 1 + SearchingNo;
										WindowsApp2.ClassPathPlan.Path tempVar7 = FoundPaths[S];
										CheckPath(ref tempVar7, ref LocalUsedObstaclesList);
											FoundPaths[S] = tempVar7;
									}
								}
								else
								{
								}
							}
						}
					}
				}
			}
			//
			SortPaths(); //sort the resulting pathes by thier length
			return FoundPaths.Count; //- 1
		}
#endregion
#region Arnaoot Fire Line
		private object SolveByArnaootFirLine()
		{
			Path InitialPath = CreateInitialPath();
			int FoundPathesCount = 0;
			int Stopper = 0;
			int OldObstaclesFireLineCount = 0;
			//
			ObstaclesFireLine.Clear(); //clear the obstacles for new solving
			GetFireLineObstacles(MazeStartNode.NodePoint);
			FoundPathesCount = Convert.ToInt32(SolveByArnaoot(ref ObstaclesFireLine));

			if (FoundPaths.Count == 0)
			{
				//
				while (ObstaclesFireLine.Count < Obstacles.Count && Stopper < 10) //And OldObstaclesFireLineCount < ObstaclesFireLine.Count
				{
					OldObstaclesFireLineCount = ObstaclesFireLine.Count;
					for (var S = 0; S < ObstaclesFireLine.Count; S++)
					{
						for (var NodeNo = ObstaclePointTypeStart; NodeNo <= ObstaclePointLastTypeIndex; NodeNo++)
						{
							GetFireLineObstacles(ObstaclesFireLine[S].PointsExtended[NodeNo]);
						}
					}
					//
					FoundPathesCount = Convert.ToInt32(SolveByArnaoot(ref ObstaclesFireLine));
					if (OldObstaclesFireLineCount == ObstaclesFireLine.Count)
					{
						break;
					}
					Stopper = Stopper + 1;
				}
				Stopper = 0;
				if (FoundPaths.Count == 0)
				{
					//trying to add intersecting obstacles failed , adding all obstacles in range (MazeStratToEndDisance / 10)
					//
					int AddedObstacleRangeCounter = 10;
					while (AddedObstacleRangeCounter > 0 && FoundPaths.Count == 0)
					{
						for (var S = 0; S < Obstacles.Count; S++)
						{
							//
							for (var ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType < ObstaclePointLastTypeIndex; ObstaclePointType++)
							{
								if (ObstaclesFireLine.Contains(Obstacles[S]) == false && Obstacles[S].CenterDistanceToStartPoint < MazeStartToEndDistance / AddedObstacleRangeCounter)
								{
									Node TempNode = new Node();
									TempNode.NodeObstacleNumber = Obstacles[S].ObstacleIndex; //S
									TempNode.NodeObstaclePointType = ObstaclePointType;
									TempNode.NodePoint = Obstacles[S].PointsExtended[ObstaclePointType];
									//
									if (CheckNodeToNodeVisible(MazeStartNode, TempNode) == true)
									{
										ObstaclesFireLine.Add(Obstacles[S]);
									}
								}
							}
						}
						//
						SolveByArnaoot(ref ObstaclesFireLine);
						//
						AddedObstacleRangeCounter = AddedObstacleRangeCounter - 1;
					}
				}
			}
			//
			if (FoundPaths.Count > 0)
			{
// INSTANT C# NOTE: There is no C# equivalent to VB's implicit 'once only' variable initialization within loops, so the following variable declaration has been placed prior to the loop:
				Point MinDistanceToEndNodePoint = new Point();
// INSTANT C# NOTE: There is no C# equivalent to VB's implicit 'once only' variable initialization within loops, so the following variable declaration has been placed prior to the loop:
				int MinDistanceToEndPathNumber = 0;
// INSTANT C# NOTE: There is no C# equivalent to VB's implicit 'once only' variable initialization within loops, so the following variable declaration has been placed prior to the loop:
				int ObstacleNumber = 0;
			int ObstaclePointType = 0;
				while (ObstaclesFireLine.Count < Obstacles.Count && PathWasFound == false)
				{
					float MinDistanceToEndNodeLength = MazeStartToEndDistance * 10; //setting an intial very large distance value
	//				Dim MinDistanceToEndNodePoint As Point
	//				Dim MinDistanceToEndPathNumber As Integer
	//				Dim ObstacleNumber, ObstaclePointType As Integer
					//
					for (var S = 0; S < FoundPaths.Count; S++)
					{
						//If FoundPaths(S).CurrentPathStatus = PathStatusTypes.Blocked Then
						//    FoundPaths(S).CurrentPathStatus = PathStatusTypes.Searching
						//End If
						ObstacleNumber = FoundPaths[S].PathNode[FoundPaths[S].PathNode.Count - 1].NodeObstacleNumber;
						ObstaclePointType = FoundPaths[S].PathNode[FoundPaths[S].PathNode.Count - 1].NodeObstaclePointType;
						if (ObstacleNumber > -1)
						{
							if (MinDistanceToEndNodeLength > (float)(Obstacles[ObstacleNumber].MazeEndDirectDistance[ObstaclePointType]) && FoundPaths[S].PathChecked == false)
							{
								MinDistanceToEndNodeLength = (float)(Obstacles[ObstacleNumber].MazeEndDirectDistance[ObstaclePointType]);
								MinDistanceToEndNodePoint = FoundPaths[S].PathNode[FoundPaths[S].PathNode.Count - 1].NodePoint;
								MinDistanceToEndPathNumber = S;
							}
						}
					}
					//
					FoundPaths[MinDistanceToEndPathNumber].PathChecked = true;
					FoundPaths[MinDistanceToEndPathNumber].CurrentPathStatus = PathStatusTypes.Searching;
					GetFireLineObstacles(MinDistanceToEndNodePoint);
					//
					for (var S = 0; S < ObstaclesFireLine.Count; S++)
					{
						if (ObstaclesFireLine[S].TestedForPathStart == false)
						{
							ObstaclesFireLine[S].TestedForPathStart = true;
							for (var NodeNo = ObstaclePointTypeStart; NodeNo <= ObstaclePointLastTypeIndex; NodeNo++)
							{
								Node TempNode = new Node();
								TempNode.NodeObstacleNumber = ObstaclesFireLine[S].ObstacleIndex; //S
								TempNode.NodeObstaclePointType = NodeNo;
								TempNode.NodePoint = ObstaclesFireLine[S].PointsExtended[NodeNo];
								//
								if (CheckNodeToNodeVisible(MazeStartNode, TempNode) == true)
								{
									CreateNewPath(InitialPath, TempNode);
								}
							}
						}
					}
					SolveByArnaoot(ref ObstaclesFireLine);
					Stopper = Stopper + 1;
					if (Stopper == 20) //no path was found after many trials
					{
						FoundPathesCount = Convert.ToInt32(SolveByArnaoot(ref Obstacles));
						return null;
					}
				}
			}
			else
			{
				//
				//FoundPaths.Count = 0
				System.Diagnostics.Debugger.Break();
			}
			return FoundPathesCount;
		}
		private List<ObstacleLine> GetFireLineObstacles(Point CurrentPoint)
		{
			//Dim FireLineObstacles As New List(Of ObstacleLine)
			Point IntersectionPoint = new Point();
			//
			//FireLineObstacles.Clear()
			//
			for (var S = 0; S < Obstacles.Count; S++)
			{
				//
				if (ObstaclesFireLine.Contains(Obstacles[S]) == false)
				{
					for (var ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType < ObstaclePointLastTypeIndex; ObstaclePointType++)
					{
						//If TwoLineIntersect(CurrentPoint, MazeEndNode.NodePoint, Obstacles(S).PointsExtended_lineIntersection(ObstaclePointType), Obstacles(S).PointsExtended_lineIntersection(ObstaclePointType + 1), IntersectionPoint) = True Then
						//If TwoLineIntersect(CurrentPoint, MazeEndNode.NodePoint, Obstacles(S).PointsExtended(ObstaclePointType), Obstacles(S).PointsExtended(ObstaclePointType + 1), IntersectionPoint) = True Then
						if (CheckTwoLineIntersect(CurrentPoint, MazeEndNode.NodePoint, Obstacles[S].Points[ObstaclePointType], Obstacles[S].Points[ObstaclePointType + 1], ref IntersectionPoint) == true)
						{
							ObstaclesFireLine.Add(Obstacles[S]);
						}
						//Obstacles(S).InsideSearchRegion = True
						//Else
						//    Obstacles(S).InsideSearchRegion = False
					}
				}
			}
			return ObstaclesFireLine;
		}
#endregion
#endregion

#endregion
#endregion
#region Obstacle   Filter
		public bool NoFilter(Point PointToCheck)
		{
			return true;
		}
		private void FilterObstacles()
		{
			int ObstaclePointType = 0;
			bool VertexInsideRegion = false;
			//############################################################################################################
			//Obstalce filtering part
			FilterFunction AppliedObstacleFilterFunction = NoFilter;
			//
			switch (ObstacleFilterMethod)
			{
				case ObstacleFilteringMethods.NoFilter:
					AppliedObstacleFilterFunction = NoFilter;
					break;
				case ObstacleFilteringMethods.Hexagon:
					CalculateHexagonData();
					AppliedObstacleFilterFunction = InsideHexagon;
					break;
				case ObstacleFilteringMethods.DVG:
					CalculateRectangleData();
					AppliedObstacleFilterFunction = InsideRectangle;
					break;
				case ObstacleFilteringMethods.ECoVG:
					CalculateEllipseData();
					AppliedObstacleFilterFunction = InEllipse;
					break;
				case ObstacleFilteringMethods.ESOVG:
					CalculateEquilateralData();
					AppliedObstacleFilterFunction = InsideEquilateral;
					break;
 			}
			//
			for (var S = 0; S < Obstacles.Count; S++)
			{
				//
				VertexInsideRegion = false;
				for (ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType <= ObstaclePointLastTypeIndex; ObstaclePointType++)
				{
					if (AppliedObstacleFilterFunction(Obstacles[S].Points[ObstaclePointType]) == true)
					{
						VertexInsideRegion = true;
						break;
					}
				}
				Obstacles[S].InsideSearchRegion = VertexInsideRegion;
			}
		}
#endregion



#region Pathes Optimaization
		public Point CalculatePerpendicularPointToLine(Point LineStartPoint, Point LineEndPoint, Point OutSidePoint)
		{
			float K = 0F;
			float Kdenominator = 0F;
			Point PerpendicularPoint = new Point();
			//
			Kdenominator = (float)(Math.Pow(LineEndPoint.Y - LineStartPoint.Y, 2) + Math.Pow(LineEndPoint.X - LineStartPoint.X, 2));
			if (Kdenominator != 0)
			{

				K = ((LineEndPoint.Y - LineStartPoint.Y) * (OutSidePoint.X - LineStartPoint.X) - (LineEndPoint.X - LineStartPoint.X) * (OutSidePoint.Y - LineStartPoint.Y)) / Kdenominator;
				PerpendicularPoint.X = Convert.ToInt32(OutSidePoint.X - K * (LineEndPoint.Y - LineStartPoint.Y));
				PerpendicularPoint.Y = Convert.ToInt32(OutSidePoint.Y + K * (LineEndPoint.X - LineStartPoint.X));
				return PerpendicularPoint;
			}
			else
			{
				System.Diagnostics.Debugger.Break();
				//'LineEndPoint and LineStartPoint are the same
				return new Point();
			}

		}
		public float CalPointToLineDistance(Point LineStartPoint, Point LineEndPoint, Point OutSidePoint)
		{
			//
			//Dim K As Single
			//Dim Kdenominator As Single
			//Dim PerpendicularPoint As Point 
			//
			//Kdenominator = ((LineEndPoint.Y - LineStartPoint.Y) ^ 2 + (LineEndPoint.X - LineStartPoint.X) ^ 2)
			//If Kdenominator <> 0 Then
			//    K = ((LineEndPoint.Y - LineStartPoint.Y) * (OutSidePoint.X - LineStartPoint.X) - (LineEndPoint.X - LineStartPoint.X) * (OutSidePoint.Y - LineStartPoint.Y)) / Kdenominator
			//    PerpendicularPoint.X = OutSidePoint.X - K * (LineEndPoint.Y - LineStartPoint.Y)
			//    PerpendicularPoint.Y = OutSidePoint.Y + K * (LineEndPoint.X - LineStartPoint.X)
			//    'Stop
			//    Return Math.Min(CalPointDis(LineStartPoint, OutSidePoint), CalPointDis(LineEndPoint, OutSidePoint)) 'SafeDistance * 3
			//Else
			//    Stop
			//End If

			Point PerpendicularPoint = CalculatePerpendicularPointToLine(LineStartPoint, LineEndPoint, OutSidePoint);
			if (PerpendicularPoint != new Point())
			{
				return Math.Min(CalPointDis(LineStartPoint, OutSidePoint), CalPointDis(LineEndPoint, OutSidePoint)); //SafeDistance * 3
			}
			else
			{
				System.Diagnostics.Debugger.Break();
			}

			//
			if (CheckifPointOnLine(PerpendicularPoint, LineStartPoint, LineEndPoint))
			{
				System.Diagnostics.Debugger.Break();
				return CalPointDis(PerpendicularPoint, OutSidePoint);
			}
			else
			{
				System.Diagnostics.Debugger.Break();
				return Math.Min(CalPointDis(LineStartPoint, OutSidePoint), CalPointDis(LineEndPoint, OutSidePoint)); //SafeDistance * 3
			}

		}
		public bool CheckObstacleToLineSafety(Point LineStartPoint, Point LineEndPoint, ref int ClosestObstacleNo, ref float ClosestLineToObstacleDistance, ref int ClosestObstaclePointType)
		{
			int S = 0;
			int ObstaclePointType = 0;
			float MinFoundDistacne = 0F;
			float NewDistance = 0F;
			int MinFoundDistanceObsatcleNo = 0;
			int MinFoundDistanceObstaclePointType = 0;
			//
			MinFoundDistacne = CalPointToLineDistance(LineStartPoint, LineEndPoint, Obstacles[0].Points[ObstaclePointTypes.ObsStart]);
			MinFoundDistanceObstaclePointType = ObstaclePointTypes.ObsStart;
			MinFoundDistanceObsatcleNo = 0;
			//
			for (S = 0; S < Obstacles.Count; S++)
			{
				for (ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType <= ObstaclePointLastTypeIndex; ObstaclePointType++)
				{
					NewDistance = CalPointToLineDistance(LineStartPoint, LineEndPoint, Obstacles[S].Points[ObstaclePointType]);
					if (NewDistance < SafeDistance)
					{
						Obstacles[S].IsMakingPathCritical = true;
					}
					if (NewDistance < MinFoundDistacne)
					{
						MinFoundDistacne = NewDistance;
						MinFoundDistanceObsatcleNo = S;
						MinFoundDistanceObstaclePointType = ObstaclePointType; //ObstaclePointType.ObsStart
					}
				}
				//
				//NewDistance = CalObsatcletoLineDistance(LineStartPoint, LineEndPoint, Obstacles(S).)
				//If NewDistance < SafeDistance Then
				//    Obstacles(S).IsMakingPathCritical = True
				//End If

				//If NewDistance < MinFoundDistacne Then
				//    MinFoundDistacne = NewDistance
				//    MinFoundDistanceObsatcleNo = S
				//    MinFoundDistanceObstaclePointType = ObstaclePointType.ObsEnd
				//End If
			}
			//
			ClosestObstacleNo = MinFoundDistanceObsatcleNo;
			ClosestLineToObstacleDistance = MinFoundDistacne;
			ClosestObstaclePointType = MinFoundDistanceObstaclePointType;
			//
			if (MinFoundDistacne > SafeDistance)
			{
				return true;
			}
			else
			{
				Obstacles[ClosestObstacleNo].IsMakingPathCritical = true;
				return false;
			}
		}
		public void Clear_Obsatcle_IsMakingPathCritical()
		{
			int S = 0;
			//
			for (S = 0; S < Obstacles.Count; S++)
			{
				Obstacles[S].IsMakingPathCritical = false;
			}
		}
		public void Clear_Obsatcle_MinDistanceMazeStartObstaclePoint()
		{
			int S = 0;
			int ObstaclePointType = 0;
			//
			for (S = 0; S < Obstacles.Count; S++)
			{
				for (ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType <= ObstaclePointLastTypeIndex; ObstaclePointType++)
				{
					Obstacles[S].MinDistanceMazeStart[ObstaclePointType] = 0;
				}
			}
		}
		public bool CheckPathSaftey(Path CheckedPath)
		{
			int S = 0;
			int ClosestObstacleNo = 0;
			float ClosestLineToObstacleDistance = 0F;
			int ClosestObstaclePointType = 0;
			//
			//For S = 0 To Obstacles.Count - 1- 1
			//    Obstacles(S).IsMakingPathCritical = False
			//Next
			Clear_Obsatcle_IsMakingPathCritical();
			//
			for (S = 0; S <= CheckedPath.PathNode.Count - 2; S++)
			{
				if (CheckObstacleToLineSafety(CheckedPath.PathNode[S].NodePoint, CheckedPath.PathNode[S + 1].NodePoint, ref ClosestObstacleNo, ref ClosestLineToObstacleDistance, ref ClosestObstaclePointType) == false)
				{
					//Debug.Print(S, ClosestObstacleNo, ClosestLineToObstacleDistance, ClosestObstaclePointType)
					// Obstacles(ClosestObstacleNo).IsMakingPathCritical = True
				}
			}
			return false;
		}
		public Point[] OptimizePath(int SelectedPath)
		{
			int S = 0;
			// Dim PathPoints() As Point
			int PathPointsNO = FoundPaths[SelectedPath].PathNode.Count;
			// Dim MyDetialedPathPoint() As DetialedPathPoint
			//ReDim MyDetialedPathPoint(PathPointsNO - 1)
			bool IncreaseAngle = false;
			Point OtherObstaclePoint = new Point();
			//
			if (FoundPaths[SelectedPath].CurrentPathStatus != PathStatusTypes.Solution || FoundPaths[SelectedPath].PathNode.Count < 3)
			{
				//Stop
				return null;
			}
			//
			//'Reading path Data
			//For S = 0 To PathPointsNO - 1
			//    '
			//    ' Initialize the object
			//    'MyDetialedPathPoint(S) = New DetialedPathPoint
			//    '
			//    MyDetialedPathPoint(S).OrginalPoint = FoundPath(SelectedPath).PathNode(S)
			//    '
			//    For S1 = 0 To Obstacles.Count - 1- 1
			//        If FoundPath(SelectedPath).PathNode(S) = Obstacles(S1).StartPointExtension Then
			//            MyDetialedPathPoint(S).ObstacleNo = S1
			//            MyDetialedPathPoint(S).MyObstaclePointType = ObstaclePointType.ObsStart
			//            Exit For     'obsatcle found , no need to continue searching among other obstacles
			//        End If
			//        If FoundPath(SelectedPath).PathNode(S) = Obstacles(S1).EndPointExtension Then
			//            MyDetialedPathPoint(S).ObstacleNo = S1
			//            MyDetialedPathPoint(S).MyObstaclePointType = ObstaclePointType.ObsEnd
			//            Exit For     'obsatcle found , no need to continue searching among other obstacles
			//        End If
			//    Next
			//Next
			//
			//Optimizing
			Point[] OptimizedPath = new Point[PathPointsNO];
			OptimizedPath[0] = MazeStartNode.NodePoint;
			FoundPaths[SelectedPath].PathNode[0].OptimizedPoint = MazeStartNode.NodePoint; //FoundPath(SelectedPath).PathNode(0).NodePoint
			//
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of PathPointsNO - 2 for every iteration:
			int tempVar = PathPointsNO - 2;
			for (S = 1; S <= tempVar; S++)
			{
				if (FoundPaths[SelectedPath].PathNode[S].NodeObstaclePointType == ObstaclePointTypes.ObsStart)
				{
					OtherObstaclePoint = Obstacles[FoundPaths[SelectedPath].PathNode[S].NodeObstacleNumber].Points[ObstaclePointTypes.ObsEnd];
				}
				else
				{
					OtherObstaclePoint = Obstacles[FoundPaths[SelectedPath].PathNode[S].NodeObstacleNumber].Points[ObstaclePointTypes.ObsStart];
				}
				if (CalAnglePointRad(FoundPaths[SelectedPath].PathNode[S - 1].OptimizedPoint, FoundPaths[SelectedPath].PathNode[S].OptimizedPoint) > CalAnglePointRad(FoundPaths[SelectedPath].PathNode[S - 1].OptimizedPoint, OtherObstaclePoint))
				{
					IncreaseAngle = true;
				}
				else
				{
					IncreaseAngle = false;
				}
				FoundPaths[SelectedPath].PathNode[S].OptimizedPoint = CenterPoint(FoundPaths[SelectedPath].PathNode[S].OptimizedPoint, FoundPaths[SelectedPath].PathNode[S].NodePoint, IncreaseAngle);
				FoundPaths[SelectedPath].PathNode[S].OptimizedPoint = CheckOpitmizedNewPoint(FoundPaths[SelectedPath].PathNode[S - 1].OptimizedPoint, FoundPaths[SelectedPath].PathNode[S].NodePoint, FoundPaths[SelectedPath].PathNode[S + 1].NodePoint, ref FoundPaths[SelectedPath].PathNode[S].OptimizedPoint);
				//If S < PathPointsNO - 2 Then
				OptimizedPath[S] = FoundPaths[SelectedPath].PathNode[S].OptimizedPoint;
				//End If
			}
			//MyDetialedPathPoint(S).NewPoint = CenterPoint(MyDetialedPathPoint(S - 1).NewPoint, MyDetialedPathPoint(S).OrginalPoint, IncreaseAngle)
			//
			OptimizedPath[S] = MazeEndNode.NodePoint;
			//
			return OptimizedPath;
		}
		private Point CheckOpitmizedNewPoint(Point PreviousPoint, Point CurrentPoint, Point FuturePoint, ref Point NewCenteredPoint)
		{
			//
			if (CheckPointToPointClear(PreviousPoint, NewCenteredPoint) == true)
			{
				if (CheckPointToPointClear(NewCenteredPoint, FuturePoint) == true)
				{
					return NewCenteredPoint;
				}
				else
				{
					return CurrentPoint;
				}
			}
			else
			{
				return CurrentPoint;
			}
		}
		private Point CenterPoint(Point PreviousPoint, Point CurrentPoint, bool IncreaseAngle)
		{
			Point NewCenteredPoint = new Point();
			float PointAngle = (float)CalAnglePointRad(PreviousPoint, CurrentPoint);
			float NewPointAngle = 0F;
			float AngleUpperLimit = 0F;
			float AngleLowerLimit = 0F;
			float OldDistance = CalPointDis(PreviousPoint, CurrentPoint);
			int S = 0;
			int ObstaclePointType = 0;
			//
			if (IncreaseAngle == true)
			{
				AngleUpperLimit = PointAngle + InitialExpansionAngle;
				AngleLowerLimit = PointAngle;
			}
			else
			{
				AngleUpperLimit = PointAngle;
				AngleLowerLimit = PointAngle - InitialExpansionAngle;

			}
			if (AngleUpperLimit > 360)
			{
				//    AngleUpperLimit = AngleUpperLimit - 360
				//Stop
			}
			if (AngleLowerLimit < 0)
			{
				//    AngleLowerLimit = AngleLowerLimit + 360
				//Stop
			}
			//
			//If IncreaseAngle = True Then
			//    For S = 0 To Obstacles.Count - 1- 1
			//        ObstaclePointAngle = CalAnglePoint(PreviousPoint, ObstaclePoint)
			//    Next

			//Else

			//End If

			for (S = 0; S < Obstacles.Count; S++)
			{
				for (ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType <= ObstaclePointLastTypeIndex; ObstaclePointType++)
				{
					UpdateAngleSpan(ref AngleUpperLimit, ref AngleLowerLimit, PreviousPoint, Obstacles[S].PointsExtended[ObstaclePointType], IncreaseAngle, OldDistance);
				}
			}
			//
			NewPointAngle = (AngleUpperLimit + AngleLowerLimit) / 2;
			//
			//NewCenteredPoint.X = OldDistance * Math.Cos(Deg2Rad(NewPointAngle - Angle90Rad)) + PreviousPoint.X
			//NewCenteredPoint.Y = OldDistance * Math.Sin(Deg2Rad(NewPointAngle - Angle90Rad)) + PreviousPoint.Y
			NewCenteredPoint.X = Convert.ToInt32(OldDistance * Math.Cos(NewPointAngle - Angle90Rad) + PreviousPoint.X);
			NewCenteredPoint.Y = Convert.ToInt32(OldDistance * Math.Sin(NewPointAngle - Angle90Rad) + PreviousPoint.Y);
			//
			//If CheckLineClear(PreviousPoint, NewCenteredPoint) = True Then
			//    If CheckLineClear(NewCenteredPoint, FuturePoint) = True Then
			//        Return NewCenteredPoint
			//    Else
			//        Return CurrentPoint
			//    End If
			//Else
			//    Return CurrentPoint
			//End If
			//Return CheckOpitmizedNewPoint(PreviousPoint, CurrentPoint, FuturePoint, NewCenteredPoint)
			return NewCenteredPoint; //CheckOpitmizedNewPoint(PreviousPoint, CurrentPoint, FuturePoint, NewCenteredPoint)
		}

		private void UpdateAngleSpan(ref float AngleUpperLimit, ref float AngleLowerLimit, Point PreviousPoint, Point ObstaclePoint, bool IncreaseAngle, float OldDistance)
		{
			float ObstaclePointAngle = (float)CalAnglePointRad(PreviousPoint, ObstaclePoint);
			float CurrentDistance = 0F; //= CalDis()
			//
			if (IncreaseAngle == true)
			{
				if (ObstaclePointAngle < AngleUpperLimit && ObstaclePointAngle > AngleLowerLimit)
				{
					if (CheckPointToPointClear(PreviousPoint, ObstaclePoint))
					{
						CurrentDistance = CalPointDis(PreviousPoint, ObstaclePoint);
						if (CurrentDistance <= (float)(OldDistance * 1.2))
						{
							AngleUpperLimit = ObstaclePointAngle;
						}
					}
				}
			}
			else
			{
				if (ObstaclePointAngle > AngleLowerLimit && ObstaclePointAngle < AngleUpperLimit)
				{
					//this will reduce the span
					if (CheckPointToPointClear(PreviousPoint, ObstaclePoint))
					{
						CurrentDistance = CalPointDis(PreviousPoint, ObstaclePoint);
						if (CurrentDistance <= (float)(OldDistance * 1.2))
						{
							AngleLowerLimit = ObstaclePointAngle;
						}
					}
				}
			}

			//  If ObstaclePointAngle < AngleUpperLimit And ObstaclePointAngle > ObstaclePointAngle Then
			//If ObstaclePointAngle < AngleUpperLimit And ObstaclePointAngle > PointAngle Then
			//    'this will reduce the span
			//    'If CalDis(PreviousPoint, ObstaclePoint) < OldDistance Then
			//    '    AngleUpperLimit = ObstaclePointAngle
			//    'End If
			//    If CheckLineClear(PreviousPoint, ObstaclePoint) Then
			//        AngleUpperLimit = ObstaclePointAngle
			//    End If
			//End If
			//'   
			//If ObstaclePointAngle > AngleLowerLimit And ObstaclePointAngle < PointAngle Then
			//    'this will reduce the span
			//    'If CalDis(PreviousPoint, ObstaclePoint) < OldDistance Then
			//    '    AngleLowerLimit = ObstaclePointAngle
			//    'End If
			//    If CheckLineClear(PreviousPoint, ObstaclePoint) Then
			//        AngleLowerLimit = ObstaclePointAngle
			//    End If

			//End If
		}

#endregion

#region Line Extend
		public double CalAnglePointRad(Point StartPoint, Point EndPoint)
		{
			return CalAngleDegree(StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
		}
		//Function CalAngleDegree(ByVal X1 As String, ByVal Y1 As String, ByVal X2 As String, ByVal Y2 As String) As Double
		//    Dim Angle270Rad As Single = Math.PI * 3 / 2
		//    ''
		//    If Y1 = Y2 Then
		//        If X1 > X2 Then Return Angle270Rad Else Return Angle90Rad
		//    End If
		//    If X1 = X2 Then
		//        If Y1 > Y2 Then Return 0 Else Return Math.PI
		//    End If
		//    Dim aNGLE As Double
		//    aNGLE = Math.Atan(Math.Abs(Val(Y2) - Val(Y1)) / Math.Abs(Val(X2) - Val(X1)))
		//    ''aNGLE = aNGLE * 180 / Math.PI
		//    If Val(X2) > Val(X1) And Val(Y2) < Val(Y1) Then Return Angle90Rad - aNGLE
		//    If Val(X2) < Val(X1) And Val(Y2) < Val(Y1) Then Return Angle270Rad + aNGLE
		//    If Val(X2) < Val(X1) And Val(Y2) > Val(Y1) Then Return Angle270Rad - aNGLE
		//    If Val(X2) > Val(X1) And Val(Y2) > Val(Y1) Then Return Angle90Rad + aNGLE
		//    Return -10000
		//End Function
		public double CalAngleDegree(float X1, float Y1, float X2, float Y2)
		{
			float Angle270Rad = (float)(Math.PI * 3 / 2);
			//'
			if (Y1 == Y2)
			{
				if (X1 > X2)
				{
					return Math.PI;
				}
				else
				{
					return 0;
				}
			}
			if (X1 == X2)
			{
				if (Y1 > Y2)
				{
					return Angle270Rad;
				}
				else
				{
					return Angle90Rad;
				}
			}
			double aNGLE;
			//' aNGLE = Math.Atan((Y2 - Y1) / (X2 - X1))(Angle90Rad * 3) 
			aNGLE = Math.Abs(Math.Atan(Math.Abs(Y2 - Y1) / Math.Abs(X2 - X1)));
			//'
			if (X2 > X1 && Y2 < Y1)
			{
				return(Math.PI * 2) - aNGLE;
			}
			if (X2 < X1 && Y2 < Y1)
			{
				return Math.PI + aNGLE;
			}
			if (X2 < X1 && Y2 > Y1)
			{
				return Math.PI - aNGLE;
			}
			if (X2 > X1 && Y2 > Y1)
			{
				return 0 + aNGLE;
			}
			System.Diagnostics.Debugger.Break();
			return -10000;
		}
		public double Deg2Rad(double deg)
		{
			return Math.PI * deg / 180;
		}
		public double Rad2Deg(double rad)
		{
			return rad / Math.PI * 180;
		}

		public Point CalLineSecondPoint(Point LineFirstPoint, float AngleRadians, float Range)
		{
			Point LineSecondPoint; //'= LineFirstPoint
			//'Dim AngleRadians As Single = AngleDegree / 180 * Math.PI
			LineSecondPoint = new Point(Convert.ToInt32(LineFirstPoint.X + (Range * Math.Cos(AngleRadians))), Convert.ToInt32(LineFirstPoint.Y + (Range * Math.Sin(AngleRadians))));
			return LineSecondPoint;
		}
		public void ExtendLine(Point StartPoint, Point EndPoint, float ExtendDistance, ref Point ExtendStartPoint, ref Point ExtendEndPoint)
		{
			float LineAngle = (float)(Math.Atan(EndPoint.Y - StartPoint.Y) / (EndPoint.X - StartPoint.X));
			//
			//If StartPoint.Y = EndPoint.Y Then 'horizontl
			//    If StartPoint.X > EndPoint.X Then LineAngle = Math.PI Else LineAngle = 0
			//End If
			//'
			//If StartPoint.X = EndPoint.X Then 'vertical
			//    If StartPoint.Y > EndPoint.Y Then LineAngle = Math.PI * 3 / 2 Else LineAngle = Math.PI / 2
			//End If
			//If StartPoint.Y = EndPoint.Y Then 'horizontl
			//    If StartPoint.X > EndPoint.X Then
			//        ExtendStartPoint.X = StartPoint.X + ExtendDistance
			//        ExtendStartPoint.Y = StartPoint.Y
			//        '
			//        ExtendEndPoint.X = EndPoint.X - ExtendDistance
			//        ExtendEndPoint.Y = EndPoint.Y
			//    Else
			//        ExtendStartPoint.X = StartPoint.X - ExtendDistance
			//        ExtendStartPoint.Y = StartPoint.Y
			//        '
			//        ExtendEndPoint.X = EndPoint.X + ExtendDistance
			//        ExtendEndPoint.Y = EndPoint.Y
			//    End If
			//    Exit Sub
			//End If
			//'
			//If StartPoint.X = EndPoint.X Then 'vertical
			//    If StartPoint.Y > EndPoint.Y Then
			//        ExtendStartPoint.X = StartPoint.X
			//        ExtendStartPoint.Y = StartPoint.Y + ExtendDistance
			//        '
			//        ExtendEndPoint.X = EndPoint.X
			//        ExtendEndPoint.Y = EndPoint.Y - ExtendDistance
			//    Else
			//        ExtendStartPoint.X = StartPoint.X
			//        ExtendStartPoint.Y = StartPoint.Y - ExtendDistance
			//        '
			//        ExtendEndPoint.X = EndPoint.X
			//        ExtendEndPoint.Y = EndPoint.Y + ExtendDistance
			//    End If
			//    Exit Sub
			//End If

			//
			//ExtendStartPoint.X = -ExtendDistance * Math.Cos(LineAngle + Math.PI) + StartPoint.X
			//ExtendStartPoint.Y = -ExtendDistance * Math.Sin(LineAngle + Math.PI) + StartPoint.Y
			//'
			//ExtendEndPoint.X = ExtendDistance * Math.Cos(LineAngle) + EndPoint.X
			//ExtendEndPoint.Y = ExtendDistance * Math.Sin(LineAngle) + EndPoint.Y
			//$$$$$$$$$$$$$$$$$$$$4
			//the following line calcualte the extensions of the line using the formula of p(t)=(1-t)p1+tp2, 
			//by decoupling the x And y into two seperate equations
			//and the extension is calculated as ratio   
			float PointDistance = CalPointDis(StartPoint, EndPoint);
			float T = 0F;
			float Ratio = 0F;
			//
			if (PointDistance > 0)
			{
				Ratio = ExtendDistance / PointDistance;
				//
				T = -Ratio;
				ExtendStartPoint.X = Convert.ToInt32((1 - T) * StartPoint.X + T * EndPoint.X);
				ExtendStartPoint.Y = Convert.ToInt32((1 - T) * StartPoint.Y + T * EndPoint.Y);
				//
				T = 1 + Ratio;
				ExtendEndPoint.X = Convert.ToInt32((1 - T) * StartPoint.X + T * EndPoint.X);
				ExtendEndPoint.Y = Convert.ToInt32((1 - T) * StartPoint.Y + T * EndPoint.Y);
			}
		}

		private Point CalMiddlePoint(Point firstPoint, Point SecondPoint)
		{
			Point ObsMiddlePoint = new Point(0, 0);
			//
			ObsMiddlePoint.X = firstPoint.X + SecondPoint.X;
			ObsMiddlePoint.Y = firstPoint.Y + SecondPoint.Y;
			//
			ObsMiddlePoint.X /= 2;
			ObsMiddlePoint.Y /= 2;
			//
			return ObsMiddlePoint;
		}
		//Public Function GetMiddlePoint(ByVal FirstPoint As Point, ByVal SecondPoint As Point) As Point
		//    Dim XSpan As Single
		//    Dim YSpan As Single
		//    '
		//    Dim X As Single
		//    Dim Y As Single
		//    '
		//    Dim MiddlePoint As Point
		//    '
		//    XSpan = Math.Abs(FirstPoint.X - SecondPoint.X) / 2
		//    YSpan = Math.Abs(FirstPoint.Y - SecondPoint.Y) / 2
		//    '
		//    X = Math.Min(FirstPoint.X, SecondPoint.X)
		//    Y = Math.Min(FirstPoint.Y, SecondPoint.Y)
		//    '
		//    X = X + XSpan
		//    Y = Y + YSpan
		//    '
		//    MiddlePoint = New Point(X, Y)
		//    '
		//    Return MiddlePoint
		//End Function
#endregion
#region line clear check 
		public bool CheckPointToPointClear(Point LineFirstPoint, Point LineSecondPoint)
		{
			int S = 0;
			Point PathObstacleIntersection = new Point();
			//

			for (S = 0; S < Obstacles.Count; S++)
			{
				if (CheckTwoLineIntersect(LineFirstPoint, LineSecondPoint, Obstacles[S].PointsExtended_lineIntersection[ObstaclePointTypes.ObsStart], Obstacles[S].PointsExtended_lineIntersection[ObstaclePointTypes.ObsEnd], ref PathObstacleIntersection) == true)
				{
					return false;
				}
			}
			//
			return true;
		}
		private int FixWindowNo(ref int WindowNo, int WindowNoMax)
		{
			if (WindowNo < 0) //WindowNo = 0
			{
				return 0;
			}
			if (WindowNo >= WindowNoMax)
			{
				return WindowNoMax - 1;
				//WindowNo = WindowNoMax '- 1
			}
			return WindowNo;
		}

		public bool CheckNodeToNodeVisible(Node FirstNode, Node SecondNode)
		{
			//
			int Node1Index = ObstacleNoToArray(FirstNode.NodeObstacleNumber, FirstNode.NodeObstaclePointType);
			int Node2Index = ObstacleNoToArray(SecondNode.NodeObstacleNumber, SecondNode.NodeObstaclePointType);
			//
			int FirstNodeWindowX = 0;
			int FirstNodeWindowY = 0;
			int SecondNodeWindowX = 0;
			int SecondNodeWindowY = 0;
			//Dim XDirection As Integer
			//Dim YDirection As Integer
			// Dim LastSearchedX, LastSearchedY As Integer
			//
			int WindowX = 0;
			int WindowY = 0;
			bool NodeVisible = true;
			//'
			int Xmin = 0;
			int Xmax = 0;
			int Ymin = 0;
			int Ymax = 0;
			//
			// check if new path line is clear from obsatcles
			switch (NodeToNodeVisibility[Node1Index, Node2Index])
			{
				case NodeToNodeVisibilityType.NotTested:
				break;
					  //go through the code to test the point for being visible to another
				case NodeToNodeVisibilityType.Visible:
					//nothing to do
					return true;
				case NodeToNodeVisibilityType.blocked:
					//nothing to do
					return false;
			}
			//
			if (Node1Index == Node2Index)
			{
				//this means the node is not visible to itself, prevent going into an endless meaningless loop
				return false;
			}
			//
			GetPointWindow(FirstNode.NodePoint, ref FirstNodeWindowX, ref FirstNodeWindowY);
			GetPointWindow(SecondNode.NodePoint, ref SecondNodeWindowX, ref SecondNodeWindowY);
			//
			//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
			//seacrh part of the windows starting by start node
			//If FirstNodeWindowX > SecondNodeWindowX Then
			//    XDirection = -1
			//    '          
			//    FirstNodeWindowX = FixWindowNo(FirstNodeWindowX + 1, WindowsNoHorizontal)
			//    SecondNodeWindowX = FixWindowNo(SecondNodeWindowX - 1, WindowsNoHorizontal)
			//Else
			//    XDirection = 1
			//    FirstNodeWindowX = FixWindowNo(FirstNodeWindowX - 1, WindowsNoHorizontal)
			//    SecondNodeWindowX = FixWindowNo(SecondNodeWindowX + 1, WindowsNoHorizontal)
			//End If
			//If FirstNodeWindowY > SecondNodeWindowY Then
			//    YDirection = -1
			//    '
			//    FirstNodeWindowY = FixWindowNo(FirstNodeWindowY + 1, WindowsNoVertical)
			//    SecondNodeWindowY = FixWindowNo(SecondNodeWindowY - 1, WindowsNoVertical)
			//Else
			//    YDirection = 1
			//    '
			//    FirstNodeWindowY = FixWindowNo(FirstNodeWindowY - 1, WindowsNoVertical)
			//    SecondNodeWindowY = FixWindowNo(SecondNodeWindowY + 1, WindowsNoVertical)
			//End If
			//For WindowX = FirstNodeWindowX To SecondNodeWindowX Step XDirection
			//    For WindowY = FirstNodeWindowY To SecondNodeWindowY Step YDirection
			//        If CheckNodeToNodeVisibleInsideWindow(FirstNode, SecondNode, WindowX, WindowY) = False Then
			//            NodeVisible = False
			//            Exit For
			//        End If
			//    Next
			//    '
			//    If NodeVisible = False Then Exit For
			//Next

			//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
			//seacrh part of the windows starting by smallest node x,y

			Xmin = Math.Min(FirstNodeWindowX, SecondNodeWindowX);
			Xmax = Math.Max(FirstNodeWindowX, SecondNodeWindowX);
			Ymin = Math.Min(FirstNodeWindowY, SecondNodeWindowY);
			Ymax = Math.Max(FirstNodeWindowY, SecondNodeWindowY);
			//
			int tempVar = Xmin - 1;
			Xmin = FixWindowNo(ref tempVar, WindowsNoHorizontal);
			int tempVar2 = Ymin - 1;
			Ymin = FixWindowNo(ref tempVar2, WindowsNoVertical);
			int tempVar3 = Xmax + 1;
			Xmax = FixWindowNo(ref tempVar3, WindowsNoHorizontal);
			int tempVar4 = Ymax + 1;
			Ymax = FixWindowNo(ref tempVar4, WindowsNoVertical);
			//
			for (WindowX = Xmin; WindowX <= Xmax; WindowX++)
			{
				for (WindowY = Ymin; WindowY <= Ymax; WindowY++)
				{
					if (Convert.ToBoolean(CheckNodeToNodeVisibleInsideWindow(FirstNode, SecondNode, WindowX, WindowY)) == false)
					{
						NodeVisible = false;
						break;
					}
				}
				//
				if (NodeVisible == false)
				{
					break;
				}
			}
			//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
			//seacrh all windows 

			//For WindowX = 0 To WindowsNoHorizontal - 1
			//    For WindowY = 0 To WindowsNoVertical - 1
			//        If CheckNodeToNodeVisibleInsideWindow(FirstNode, SecondNode, WindowX, WindowY) = False Then
			//            NodeVisible = False
			//            Exit For
			//        End If
			//    Next
			//    '
			//    If NodeVisible = False Then Exit For
			//Next
			//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
			//seacrh with all obstacles no windowing

			//Dim interSection As Point
			//For S = 0 To Obstacles.Count - 1
			//    If TwoLineIntersect(FirstNode.NodePoint, SecondNode.NodePoint, Obstacles(S).Points(ObstaclePointTypes.ObsStart), Obstacles(S).Points(ObstaclePointTypes.ObsEnd), interSection) = True Then
			//        NodeVisible = False
			//    End If
			//Next
			//
			//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
			//Result writing 
			if (NodeVisible == true)
			{
				NodeToNodeVisibility[Node1Index, Node2Index] = (byte)NodeToNodeVisibilityType.Visible;
				NodeToNodeVisibility[Node2Index, Node1Index] = (byte)NodeToNodeVisibilityType.Visible;
				return true;
			}
			else
			{
				NodeToNodeVisibility[Node1Index, Node2Index] = (byte)NodeToNodeVisibilityType.blocked;
				NodeToNodeVisibility[Node2Index, Node1Index] = (byte)NodeToNodeVisibilityType.blocked;
				return false;
			}
		}
		public object CheckNodeToNodeVisibleInsideWindow(Node LineFirstNode, Node LineSecondNode, int WindowX, int WindowY)
		{
			int S = 0;
			int ObstacleNo = 0;
			Point PathObstacleIntersection = new Point();
			int ObstaclesNoinWindow = ObstacleWindowSort[WindowX, WindowY].Count;
			//
			if (ObstaclesNoinWindow == 0)
			{
				return true;
			}
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of ObstacleWindowSort(WindowX, WindowY).Count for every iteration:
			int tempVar = ObstacleWindowSort[WindowX, WindowY].Count;
			for (S = 0; S < tempVar; S++)
			{
				ObstacleNo = ObstacleWindowSort[WindowX, WindowY][S];
				// If TwoLineIntersect(LineFirstNode.NodePoint, LineSecondNode.NodePoint, Obstacles(ObstacleNo).PointsExtentended(ObstaclePointTypes.ObsStart), Obstacles(ObstacleNo).PointsExtentended(ObstaclePointTypes.ObsEnd), PathObstacleIntersection) = True Then
				//If TwoLineIntersect(LineFirstNode.NodePoint, LineSecondNode.NodePoint, Obstacles(ObstacleNo).Points(ObstaclePointTypes.ObsStart), Obstacles(ObstacleNo).Points(ObstaclePointTypes.ObsEnd), PathObstacleIntersection) = True Then
				if (CheckTwoLineIntersect(LineFirstNode.NodePoint, LineSecondNode.NodePoint, Obstacles[ObstacleNo].PointsExtended_lineIntersection[ObstaclePointTypes.ObsStart], Obstacles[ObstacleNo].PointsExtended_lineIntersection[ObstaclePointTypes.ObsEnd], ref PathObstacleIntersection) == true)
				{
					return false;
				}
			}
			return true;
		}
		//Public Function CheckTwoLineIntersect(ByVal Line1FirstPoint As Point, ByVal Line1SecondPoint As Point, ByVal Line2FirstPoint As Point, ByVal Line2SecondPoint As Point, ByRef InterSectionPoint As Point) As Boolean
		//    '
		//    Dim dx1 As Double
		//    Dim dy1 As Double
		//    Dim dx2 As Double
		//    Dim dy2 As Double
		//    Dim t1 As Double
		//    Dim t2 As Double
		//    Dim denominator As Double
		//    '
		//    Dim Xmax, Xmin, Ymax, Ymin As Single
		//    '
		//    '################################################################################################################
		//    'this part checks if the obstacle line is inside the window with a diagonal that coincide with the next path line  
		//    Xmax = Math.Max(Line1FirstPoint.X, Line1SecondPoint.X)
		//    Ymax = Math.Max(Line1FirstPoint.Y, Line1SecondPoint.Y)
		//    '
		//    Xmin = Math.Min(Line1FirstPoint.X, Line1SecondPoint.X)
		//    Ymin = Math.Min(Line1FirstPoint.Y, Line1SecondPoint.Y)
		//    '
		//    'line is outside window, no further processing needed , returing false i.e. no intersection found
		//    If (Line2FirstPoint.X < Xmin And Line2SecondPoint.X < Xmin) Then Return False
		//    If (Line2FirstPoint.X > Xmax And Line2SecondPoint.X > Xmax) Then Return False
		//    If (Line2FirstPoint.Y < Ymin And Line2SecondPoint.Y < Ymin) Then Return False
		//    If (Line2FirstPoint.Y > Ymax And Line2SecondPoint.Y > Ymax) Then Return False
		//    'If (Line2FirstPoint.X < Xmin And Line2SecondPoint.X < Xmin) Or (Line2FirstPoint.X > Xmax And Line2SecondPoint.X > Xmax) Or (Line2FirstPoint.Y < Ymin And Line2SecondPoint.Y < Ymin) Or (Line2FirstPoint.Y > Ymax And Line2SecondPoint.Y > Ymax) Then
		//    '    Return False
		//    'End If
		//    '
		//    ' Get the segments' parameters.
		//    dx1 = Line1SecondPoint.X - Line1FirstPoint.X
		//    dy1 = Line1SecondPoint.Y - Line1FirstPoint.Y
		//    dx2 = Line2SecondPoint.X - Line2FirstPoint.X
		//    dy2 = Line2SecondPoint.Y - Line2FirstPoint.Y
		//    '
		//    ' Solve for t1 and t2.
		//    '
		//    denominator = (dy1 * dx2 - dx1 * dy2)
		//    If denominator = 0 Then
		//        'lines are parallel
		//        '''to intersect they must be over each others, check the enddistances to know if they are intersecting
		//        If CheckifPointOnLine(Line1FirstPoint, Line2FirstPoint, Line2SecondPoint) = True Then Return True
		//        If CheckifPointOnLine(Line1SecondPoint, Line2FirstPoint, Line2SecondPoint) = True Then Return True
		//        If CheckifPointOnLine(Line1FirstPoint, Line1FirstPoint, Line1SecondPoint) = True Then Return True
		//        If CheckifPointOnLine(Line2FirstPoint, Line1FirstPoint, Line1SecondPoint) = True Then Return True
		//        '
		//        Return False
		//    Else
		//        t1 = ((Line1FirstPoint.X - Line2FirstPoint.X) * dy2 + (Line2FirstPoint.Y - Line1FirstPoint.Y) * dx2) / denominator
		//        t2 = ((Line2FirstPoint.X - Line1FirstPoint.X) * dy1 + (Line1FirstPoint.Y - Line2FirstPoint.Y) * dx1) / -denominator
		//        ' Find the point of intersection.
		//        InterSectionPoint.X = Line1FirstPoint.X + dx1 * t1
		//        InterSectionPoint.Y = Line1FirstPoint.Y + dy1 * t1
		//        '
		//        'the two lines are represented in an indepedent form of equation using variable t 
		//        'instead of checking if the point on the line between the  first two points and on the line between the  second two points 
		//        'If t1 > 0 And t1 < 1 And t2 >= 0 And t2 <= 1 Then
		//        If t1 >= 0 And t1 <= 1 And t2 >= 0 And t2 <= 1 Then
		//            'If t1 > -0.00001 And t1 < 1.00001 And t2 > -0.00001 And t2 < 1.00001 Then
		//            Return True
		//        Else
		//            Return False
		//        End If
		//        '
		//    End If
		//    '
		//End Function
		public bool CheckTwoLineIntersect(Point Line1FirstPoint, Point Line1SecondPoint, Point Line2FirstPoint, Point Line2SecondPoint, ref Point InterSectionPoint)
		{
			double tempVar = 0;
			double tempVar2 = 0;
			return CheckTwoLineIntersectGetT1T2(Line1FirstPoint, Line1SecondPoint, Line2FirstPoint, Line2SecondPoint, ref InterSectionPoint, ref tempVar, ref tempVar2);
		}


		public bool CheckTwoLineIntersectGetT1T2(Point Line1FirstPoint, Point Line1SecondPoint, Point Line2FirstPoint, Point Line2SecondPoint, ref Point InterSectionPoint, ref double T1, ref double T2)
		{
			//
			double dx1 = 0D;
			double dy1 = 0D;
			double dx2 = 0D;
			double dy2 = 0D;
			//Dim t1 As Double
			//Dim t2 As Double
			double denominator = 0D;
			//
			float Xmax = 0F;
			float Xmin = 0F;
			float Ymax = 0F;
			float Ymin = 0F;
			//
			//################################################################################################################
			//this part checks if the obstacle line is inside the window with a diagonal that coincide with the next path line  
			Xmax = Math.Max(Line1FirstPoint.X, Line1SecondPoint.X);
			Ymax = Math.Max(Line1FirstPoint.Y, Line1SecondPoint.Y);
			//
			Xmin = Math.Min(Line1FirstPoint.X, Line1SecondPoint.X);
			Ymin = Math.Min(Line1FirstPoint.Y, Line1SecondPoint.Y);
			//
			//line is outside window, no further processing needed , returing false i.e. no intersection found
			if (Line2FirstPoint.X < Xmin && Line2SecondPoint.X < Xmin)
			{
				return false;
			}
			if (Line2FirstPoint.X > Xmax && Line2SecondPoint.X > Xmax)
			{
				return false;
			}
			if (Line2FirstPoint.Y < Ymin && Line2SecondPoint.Y < Ymin)
			{
				return false;
			}
			if (Line2FirstPoint.Y > Ymax && Line2SecondPoint.Y > Ymax)
			{
				return false;
			}
			//If (Line2FirstPoint.X < Xmin And Line2SecondPoint.X < Xmin) Or (Line2FirstPoint.X > Xmax And Line2SecondPoint.X > Xmax) Or (Line2FirstPoint.Y < Ymin And Line2SecondPoint.Y < Ymin) Or (Line2FirstPoint.Y > Ymax And Line2SecondPoint.Y > Ymax) Then
			//    Return False
			//End If
			//
			// Get the segments' parameters.
			dx1 = Line1SecondPoint.X - Line1FirstPoint.X;
			dy1 = Line1SecondPoint.Y - Line1FirstPoint.Y;
			dx2 = Line2SecondPoint.X - Line2FirstPoint.X;
			dy2 = Line2SecondPoint.Y - Line2FirstPoint.Y;
			//
			// Solve for t1 and t2.
			//
			denominator = (dy1 * dx2 - dx1 * dy2);
			if (denominator == 0)
			{
				//lines are parallel
				//to intersect they must be over each others, check the enddistances to know if they are intersecting
				if (CheckifPointOnLine(Line1FirstPoint, Line2FirstPoint, Line2SecondPoint) == true)
				{
					return true;
				}
				if (CheckifPointOnLine(Line1SecondPoint, Line2FirstPoint, Line2SecondPoint) == true)
				{
					return true;
				}
				if (CheckifPointOnLine(Line1FirstPoint, Line1FirstPoint, Line1SecondPoint) == true)
				{
					return true;
				}
				if (CheckifPointOnLine(Line2FirstPoint, Line1FirstPoint, Line1SecondPoint) == true)
				{
					return true;
				}
				//
				return false;
			}
			else
			{
				T1 = ((Line1FirstPoint.X - Line2FirstPoint.X) * dy2 + (Line2FirstPoint.Y - Line1FirstPoint.Y) * dx2) / denominator;
				T2 = ((Line2FirstPoint.X - Line1FirstPoint.X) * dy1 + (Line1FirstPoint.Y - Line2FirstPoint.Y) * dx1) / -denominator;
				// Find the point of intersection.
				InterSectionPoint.X = Convert.ToInt32(Line1FirstPoint.X + dx1 * T1);
				InterSectionPoint.Y = Convert.ToInt32(Line1FirstPoint.Y + dy1 * T1);
				//
				//the two lines are represented in an indepedent form of equation using variable t 
				//instead of checking if the point on the line between the  first two points and on the line between the  second two points 
				//If t1 > 0 And t1 < 1 And t2 >= 0 And t2 <= 1 Then
				if (T1 >= 0 && T1 <= 1 && T2 >= 0 && T2 <= 1)
				{
					//If t1 > -0.00001 And t1 < 1.00001 And t2 > -0.00001 And t2 < 1.00001 Then
					return true;
				}
				else
				{
					return false;
				}
				//
			}
			//
		}

		private bool CheckifPointOnLine(Point CheckedPoint, Point LineFirstPoint, Point LineSecondPoint)
		{
			float DistanceToFirstPoint = 0F;
			float DistanceToSecondPoint = 0F;
			float FirsttoSecondDistance = 0F;
			//
			DistanceToFirstPoint = CalPointDis(CheckedPoint, LineFirstPoint);
			DistanceToSecondPoint = CalPointDis(CheckedPoint, LineSecondPoint);
			FirsttoSecondDistance = CalPointDis(LineFirstPoint, LineSecondPoint);
			//
			if (((DistanceToFirstPoint + DistanceToSecondPoint) - FirsttoSecondDistance) > 0.2)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public float CalPointDis(Point FirstPoint, Point SecondPoint)
		{
			float dis = (float)Math.Pow(Math.Pow(SecondPoint.X - FirstPoint.X, 2) + Math.Pow(SecondPoint.Y - FirstPoint.Y, 2), 0.5);
			return dis;
		}
		public float CalNodeDis(Node FirstNode, Node SecondNode)
		{
			int X = ObstacleNoToArray(FirstNode.NodeObstacleNumber, FirstNode.NodeObstaclePointType); //(LineFirstNode.NodeObstacleNumber * 2) + LineFirstNode.NodeObstaclePointType - 1
			int Y = ObstacleNoToArray(SecondNode.NodeObstacleNumber, SecondNode.NodeObstaclePointType); //(LineSecondNode.NodeObstacleNumber * 2) + LineSecondNode.NodeObstaclePointType - 1
			//
			if (NodeToNodeDistance[X, Y] == 0)
			{
				NodeToNodeDistance[X, Y] = CalPointDis(FirstNode.NodePoint, SecondNode.NodePoint);
				NodeToNodeDistance[Y, X] = NodeToNodeDistance[X, Y];
				return NodeToNodeDistance[X, Y];
			}
			else
			{
				return NodeToNodeDistance[X, Y];
			}
		}

#endregion

#region Create Random Maze
		public void CreateRandomMaze(int MazeType, float MazeWidth, float MazeHeight, int ObstacleNo, float ObstacleMaxLength)
		{
			int S = 0;
			int S1 = 0;
			//
			ClearAllData();
			//
			MazeStartNode.NodePoint.X = Convert.ToInt32(Convert.ToSingle(Math.Floor(MazeWidth + ObstacleMaxLength)));
			MazeStartNode.NodePoint.Y = Convert.ToInt32(Convert.ToSingle(Math.Floor(MazeHeight + ObstacleMaxLength)));
			MazeEndNode.NodePoint.X = Convert.ToInt32(Math.Floor(MazeWidth * 0.05));
			MazeEndNode.NodePoint.Y = Convert.ToInt32(Math.Floor(MazeHeight * 0.05));
			//
			ObstacleLine[] H = new ObstacleLine[4];
			//
			switch (MazeType)
			{
				case RandomMazeTypes.Lines:
					for (S = 0; S <= ObstacleNo; S++)
					{
						Obstacles.Add(CreateRandomObstacleLine(MazeWidth, MazeHeight, ObstacleMaxLength));
					}
					break;
				case RandomMazeTypes.Rectangles:
					//
					for (S = 0; S < ObstacleNo; S++)
					{
						while (CreateRandomObstacleRectangle(Obstacles, MazeWidth, MazeHeight, ObstacleMaxLength, ref H) == false)
						{

						}
						for (S1 = 0; S1 <= 3; S1++)
						{
							Obstacles.Add(H[S1]);
						}
					}
					break;
			}
			//
			PreCalculationDone = false;
		}

		private bool CreateRandomObstacleRectangle(List<ObstacleLine> MyObstacle, float MazeWidth, float MazeHeight, float MaxObstacleLength, ref ObstacleLine[] H)
		{
			//Dim H(3) As ObstacleLine
			H = new WindowsApp2.ClassPathPlan.ObstacleLine[4];
			//'
			Point RectCenter = CreateRandomPoint(MazeWidth - MaxObstacleLength, MazeHeight - MaxObstacleLength);
            //
            Random rnd = new Random();
            Double RectWidth = ((rnd.NextDouble() * 0.8) + 0.2) * MaxObstacleLength;
            Double RectHeight = ((rnd.NextDouble() * 0.8) + 0.2) * MaxObstacleLength;
			int S = 0;
			//
			for (S = 0; S <= 3; S++)
			{
				H[S] = new ObstacleLine();
			}
			H[0].Points[ObstaclePointTypeStart].X = Convert.ToInt32(RectCenter.X + RectWidth);
			H[0].Points[ObstaclePointTypeStart].Y = Convert.ToInt32(RectCenter.Y + RectHeight);
			//
			H[1].Points[ObstaclePointTypeStart].X = Convert.ToInt32(RectCenter.X + RectWidth);
			H[1].Points[ObstaclePointTypeStart].Y = Convert.ToInt32(RectCenter.Y - RectHeight);
			//
			H[2].Points[ObstaclePointTypeStart].X = Convert.ToInt32(RectCenter.X - RectWidth);
			H[2].Points[ObstaclePointTypeStart].Y = Convert.ToInt32(RectCenter.Y - RectHeight);
			//
			H[3].Points[ObstaclePointTypeStart].X = Convert.ToInt32(RectCenter.X - RectWidth);
			H[3].Points[ObstaclePointTypeStart].Y = Convert.ToInt32(RectCenter.Y + RectHeight);
			//
			for (S = 1; S <= 3; S++)
			{
				H[S - 1].Points[ObstaclePointLastTypeIndex] = H[S].Points[ObstaclePointTypeStart];
			}
			H[3].Points[ObstaclePointLastTypeIndex] = H[0].Points[ObstaclePointTypeStart];
			//'
			for (S = 0; S <= 3; S++)
			{
				if (CheckPointToPointClear(H[S].Points[ObstaclePointTypeStart], H[S].Points[ObstaclePointLastTypeIndex]) == false)
				{
					return false;
				}
			}

			//'
			//For S1 = 0 To 3
			//    MyObstacle.Add(H(S1))
			//Next
			//'
			return true;
		}
		private ObstacleLine CreateRandomObstacleLine(float MazeWidth, float MazeHeight, float MaxObstacleLength)
		{
			ObstacleLine H = new ObstacleLine();
           //
            Random rnd = new Random();
            Double ObstacleAngle = rnd.NextDouble() * Math.PI; //' 360
			//
			H.Points[ObstaclePointTypeStart] = CreateRandomPoint(MazeWidth - MaxObstacleLength, MazeHeight - MaxObstacleLength);
			//
			//H.Points(ObstaclePointLastTypeIndex).X = MaxObstacleLength * Math.Cos(Deg2Rad(ObstacleAngle - Angle90Rad)) * (0.3 + (Rnd() * 0.7)) + H.Points(ObstaclePointTypeStart).X
			//H.Points(ObstaclePointLastTypeIndex).Y = MaxObstacleLength * Math.Sin(Deg2Rad(ObstacleAngle - Angle90Rad)) * (0.3 + (Rnd() * 0.7)) + H.Points(ObstaclePointTypeStart).Y
			H.Points[ObstaclePointLastTypeIndex].X = Convert.ToInt32(MaxObstacleLength * Math.Cos(ObstacleAngle - Angle90Rad) * (0.3 + (Microsoft.VisualBasic.VBMath.Rnd() * 0.7)) + H.Points[ObstaclePointTypeStart].X);
			H.Points[ObstaclePointLastTypeIndex].Y = Convert.ToInt32(MaxObstacleLength * Math.Sin(ObstacleAngle - Angle90Rad) * (0.3 + (Microsoft.VisualBasic.VBMath.Rnd() * 0.7)) + H.Points[ObstaclePointTypeStart].Y);
			//
			return H;
		}

		private Point CreateRandomPoint(float MazeWidth, float MazeHeight)
		{
			Point RandomPoint = new Point();
			//
			RandomPoint.X = Convert.ToInt32(Math.Floor(Convert.ToDouble((Microsoft.VisualBasic.VBMath.Rnd() + 0.05) * MazeWidth)));
			RandomPoint.Y = Convert.ToInt32(Math.Floor(Convert.ToDouble((Microsoft.VisualBasic.VBMath.Rnd() + 0.05) * MazeHeight)));
			//
			return RandomPoint;
		}
#endregion

#region Elliptical Concave Visibility Graph (ECoVG)
		private void CalculateEllipseData()
		{
			//
			//EllipsMajorAxisToStartEndDistanceRatio = Val(FrmGUI.TxtEllipsMajorAxisToStartEndDistanceRatio.Text)
			//EllipseMinorAxisToStartEndDistanceRatio = Val(FrmGUI.TxtEllipseMinorAxisToStartEndDistanceRatio.Text)
			//
			EllipseCenterPoint = CalMiddlePoint(MazeStartNode.NodePoint, MazeEndNode.NodePoint);
			//EllipseCenterPoint = GetMiddlePoint(MazeStartNode.NodePoint, MazeEndNode.NodePoint)
			//
			EllipseMajorAxisLength = MazeStartToEndDistance * EllipseMajorAxisToStartEndDistanceRatio;
			EllipseMinorAxisLength = EllipseMajorAxisLength * EllipseMinorAxisToStartEndDistanceRatio;
			//
			EllipseAngle = (float)CalAnglePointRad(MazeStartNode.NodePoint, MazeEndNode.NodePoint);
			//'EllipseAngle = CalAnglePointRad(MazeEndNode.NodePoint, MazeStartNode.NodePoint)
			//'
			if (EllipseAngle > (float)Math.PI)
			{
				EllipseAngle = (float)(2 * Math.PI - EllipseAngle);
			}
			else
			{
				EllipseAngle = (float)(Math.PI - EllipseAngle);
			}
		}
		//Public Function InEllipse(ByVal EllipseCenter As Point, ByVal MajorAxisLength As Single, ByVal MinorAxisLength As Single, ByVal angle As Single, ByVal PointToCheck As Point) As Boolean
		public bool InEllipse(Point PointToCheck)
		{
			//Dim PointToEllipseCenterDistanceActual As Double
			//Dim PointToEllipseCenterDistance As Double
			float MajorAxisLengthSQR = EllipseMajorAxisLength * EllipseMajorAxisLength;
			float MinorAxisLengthSQR = EllipseMinorAxisLength * EllipseMinorAxisLength;
			double SinAngle = 0D;
			double CosAngle = 0D;
			float FirstTerm = 0F;
			float SecondTerm = 0F;
			//
			//SinAngle = Math.Cos(Deg2Rad(Angle90Rad - EllipseAngle))
			//CosAngle = Math.Sin(Deg2Rad(Angle90Rad - EllipseAngle))
			SinAngle = Math.Cos(EllipseAngle);
			CosAngle = Math.Sin(EllipseAngle);
			//
			FirstTerm = (float)(((PointToCheck.X - EllipseCenterPoint.X) * CosAngle) + ((PointToCheck.Y - EllipseCenterPoint.Y) * SinAngle));
			FirstTerm = FirstTerm * FirstTerm;
			FirstTerm = FirstTerm / MinorAxisLengthSQR;
			//
			SecondTerm = (float)(((PointToCheck.X - EllipseCenterPoint.X) * SinAngle) - ((PointToCheck.Y - EllipseCenterPoint.Y) * CosAngle));
			SecondTerm = SecondTerm * SecondTerm;
			SecondTerm = SecondTerm / MajorAxisLengthSQR;
			//
			if ((SecondTerm + FirstTerm) < 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
#endregion
#region Hexagon Space Visibilty Graph
		public void CalculateHexagonData()
		{
			Point HexagonMiddlePoint = new Point();
			Point HexagonMiddleNearStartPoint = new Point();
			Point HexagonNearEndMiddlePoint = new Point();
			float HexagonMiddleLength = 0F;
			//
			float MazeStartToEndAngle = (float)CalAnglePointRad(MazeStartNode.NodePoint, MazeEndNode.NodePoint);
			//
			HexagonPoints[0] = MazeStartNode.NodePoint;
			HexagonPoints[3] = MazeEndNode.NodePoint;
			//
			HexagonMiddlePoint = CalMiddlePoint(MazeStartNode.NodePoint, MazeEndNode.NodePoint);
			HexagonMiddleNearStartPoint = CalMiddlePoint(MazeStartNode.NodePoint, HexagonMiddlePoint);
			HexagonNearEndMiddlePoint = CalMiddlePoint(HexagonMiddlePoint, MazeEndNode.NodePoint);
			//
			//HexagonMiddleLength = MazeStratToEndDisance / 4 * Math.Tan(Deg2Rad(HexagonAngle))
			HexagonMiddleLength = MazeStartToEndDistance * HexagonHeightRatio;
			ExtendPointPerPendicular(HexagonMiddleNearStartPoint, MazeStartToEndAngle, HexagonMiddleLength / 2, ref HexagonPoints[1], ref HexagonPoints[5]);
			ExtendPointPerPendicular(HexagonNearEndMiddlePoint, MazeStartToEndAngle, HexagonMiddleLength / 2, ref HexagonPoints[2], ref HexagonPoints[4]);
			//
			//HexagonArea = HexagonMiddleLength * MazeDiagonal
		}

		public bool InsideHexagon(Point PointToCheck)
		{
			return PointInPolygon(PointToCheck, HexagonPoints);
		}
#endregion
#region Equilateral Spaces Oriented Visibility Graph (ESOVG)
		public void CalculateEquilateralData()
		{
			//  Dim  StartNode.NodePointExtended, MazeEndNode.NodePointExtended As Point
			Point EquilateralMiddlePoint = new Point();
			float EquilateralMiddleLength = 0F;
			float EquilateralDiagonalLength = 0F;
			float EquilateralMajorAxisExtension = 0F;
			//Dim EquilateralMajorAxisLength As Single
			//Dim EquilateralMinorAxisLength As Single

			//
			float MazeStartToEndAngle = (float)CalAnglePointRad(MazeStartNode.NodePoint, MazeEndNode.NodePoint);
			//
			//EquilateralMajorAxisExtensionToStartEndDistanceRatio = Val(FrmGUI.TxtEquilateralMajorAxisExtensionToStartEndDistanceRatio.Text)
			//EquilateralAngle = Val(FrmGUI.TxtEquilateralAngle.Text)
			//
			EquilateralMajorAxisExtension = EquilateralMajorAxisExtensionToStartEndDistanceRatio * MazeStartToEndDistance;
			ExtendLine(MazeStartNode.NodePoint, MazeEndNode.NodePoint, EquilateralMajorAxisExtension, ref EquilateralPoints[0], ref EquilateralPoints[2]); // StartNode.NodePointExtended, MazeEndNode.NodePointExtended
			//
			EquilateralDiagonalLength = CalPointDis(EquilateralPoints[0], EquilateralPoints[2]);
			//
			EquilateralMiddlePoint = CalMiddlePoint(EquilateralPoints[0], EquilateralPoints[2]);
			//
			//'EquilateralMiddleLength = EquilateralDiagonalLength / 2 * Math.Tan(Deg2Rad(EquilateralAngle))
			EquilateralMiddleLength = (float)(EquilateralDiagonalLength / 2 * Math.Tan(EquilateralAngle));
			ExtendPointPerPendicular(EquilateralMiddlePoint, MazeStartToEndAngle, EquilateralMiddleLength / 2, ref EquilateralPoints[1], ref EquilateralPoints[3]);
			//
			//EquilateralArea = EquilateralMiddleLength * MazeDiagonal
		}
		public bool InsideEquilateral(Point PointToCheck)
		{
			//Dim tri1Area, tri2Area, tri3Area, tri4Area As Single
			//Dim triAreaSum As Single
			//
			return PointInPolygon(PointToCheck, EquilateralPoints);
			//tri1Area = areaOfTriangle(EquilateralPoints(0), EquilateralPoints(1), PointToCheck)
			//tri2Area = areaOfTriangle(EquilateralPoints(1), EquilateralPoints(2), PointToCheck)
			//tri3Area = areaOfTriangle(EquilateralPoints(2), EquilateralPoints(3), PointToCheck)
			//tri4Area = areaOfTriangle(EquilateralPoints(3), EquilateralPoints(0), PointToCheck)
			//'
			//triAreaSum = Math.Abs(tri1Area) + Math.Abs(tri2Area) + Math.Abs(tri3Area) + Math.Abs(tri4Area)
			//'
			//If EquilateralArea >= triAreaSum Then
			//    Return True
			//Else
			//    Return False
			//End If

		}
#endregion
#region Is Point in polygon check Function
		public bool PointInPolygon(Point PointTest, Point[] Points)
		{
			Point Point1 = new Point();
			Point Point2 = new Point();
			long Intersections = 0;
			long loop1 = 0;
			long NumPoints;

			NumPoints = Points.GetUpperBound(0);

			Point1 = PointTest;
			Point2 = PointTest;
			Point2.X = 10000;

			for (loop1 = 0; loop1 < NumPoints; loop1++)
			{
				if (Intersect(Point1, Point2, Points[loop1], Points[loop1 + 1]))
				{
					Intersections = Intersections + 1;
				}
			} //loop1

			if (Intersect(Point1, Point2, Points[NumPoints], Points[0]))
			{
				Intersections = Intersections + 1;
			}

			return Convert.ToBoolean(Intersections % 2);
		}
		//
		public bool Intersect(Point p1, Point p2, Point p3, Point p4)
		{
			return (((CCW(p1, p2, p3) * CCW(p1, p2, p4)) <= 0) && ((CCW(p3, p4, p1) * CCW(p3, p4, p2) <= 0)));
		}
		//
		public long CCW(Point p0, Point p1, Point p2)
		{
				long tempCCW = 0;

			long dx1 = 0;
			long dx2 = 0;
			long dy1 = 0;
			long dy2 = 0;
			dx1 = p1.X - p0.X;
			dx2 = p2.X - p0.X;

			dy1 = p1.Y - p0.Y;
			dy2 = p2.Y - p0.Y;

			if (dx1 * dy2 > dy1 * dx2)
			{
				tempCCW = 1;
			}
			else
			{
				tempCCW = -1;
			}
			return tempCCW;
		}
#endregion

#region Dynamic Visibility Graph Rectangle
		public void CalculateRectangleData()
		{
			Point MazeStartPointExtended = new Point();
			Point MazeEndNPointExtended = new Point();
			float MazeStartToEndDistance = this.MazeStartToEndDistance;
			float MazeStartToEndAngle = (float)CalAnglePointRad(MazeStartNode.NodePoint, MazeEndNode.NodePoint);
			float RectangleWidthExtension;
			//
			RectangleWidthExtension = RectangleWidthExtensionToStartEndDistanceRatio * MazeStartToEndDistance;
			RectangleWidth = MazeStartToEndDistance + RectangleWidthExtension + RectangleWidthExtension;
			//
			RectangleHeight = RectangleHeightToStartEndDistanceRatio * MazeStartToEndDistance * 2;
			//
			ExtendLine(MazeStartNode.NodePoint, MazeEndNode.NodePoint, RectangleWidthExtension, ref MazeStartPointExtended, ref MazeEndNPointExtended);
			//
			ExtendPointPerPendicular(MazeStartPointExtended, MazeStartToEndAngle, RectangleHeight / 2, ref RectanglePoints[0], ref RectanglePoints[3]);
			ExtendPointPerPendicular(MazeEndNPointExtended, MazeStartToEndAngle, RectangleHeight / 2, ref RectanglePoints[1], ref RectanglePoints[2]);
			//
			RectangleWidth = CalPointDis(RectanglePoints[0], RectanglePoints[1]);
			RectangleHeight = CalPointDis(RectanglePoints[1], RectanglePoints[2]);
			RectangleArea = RectangleWidth * RectangleHeight;
		}
		private void ExtendPointPerPendicular(Point StartPoint, float ExtendAngle, float ExtendDistance, ref Point ExtendStartPoint, ref Point ExtendEndPoint)
		{
			//
			//ExtendStartPoint.X = ExtendDistance * Math.Cos(ExtendAngle - Angle90Rad - Angle90Rad) + StartPoint.X
			//ExtendStartPoint.Y = ExtendDistance * Math.Sin(ExtendAngle - Angle90Rad - Angle90Rad) + StartPoint.Y
			//
			//ExtendEndPoint.X = ExtendDistance * Math.Cos(ExtendAngle + Angle90Rad - Angle90Rad) + StartPoint.X
			//ExtendEndPoint.Y = ExtendDistance * Math.Sin(ExtendAngle + Angle90Rad - Angle90Rad) + StartPoint.Y

			ExtendStartPoint.X = Convert.ToInt32(ExtendDistance * Math.Cos(ExtendAngle - Angle90Rad) + StartPoint.X);
			ExtendStartPoint.Y = Convert.ToInt32(ExtendDistance * Math.Sin(ExtendAngle - Angle90Rad) + StartPoint.Y);
			//'
			ExtendEndPoint.X = Convert.ToInt32(ExtendDistance * Math.Cos(ExtendAngle + Angle90Rad) + StartPoint.X);
			ExtendEndPoint.Y = Convert.ToInt32(ExtendDistance * Math.Sin(ExtendAngle + Angle90Rad) + StartPoint.Y);
		}

		private float areaOfTriangle(Point A, Point B, Point C)
		{
			//Heron 's Formula
			float Side1 = 0F;
			float Side2 = 0F;
			float Side3 = 0F;
			float semi_perimeter = 0F;
			//
			Side1 = CalPointDis(A, B);
			Side2 = CalPointDis(B, C);
			Side3 = CalPointDis(C, A);
			//
			semi_perimeter = (Side1 + Side2 + Side3) / 2;
			//
			return Convert.ToSingle(Math.Sqrt((semi_perimeter * (semi_perimeter - Side1) * (semi_perimeter - Side2) * (semi_perimeter - Side3)))) ;

		}
		public bool InsideRectangle(Point PointToCheck)
		{
			float tri1Area = 0F;
			float tri2Area = 0F;
			float tri3Area = 0F;
			float tri4Area = 0F;
			float triAreaSum = 0F;
			//
			tri1Area = areaOfTriangle(RectanglePoints[0], RectanglePoints[1], PointToCheck);
			tri2Area = areaOfTriangle(RectanglePoints[1], RectanglePoints[2], PointToCheck);
			tri3Area = areaOfTriangle(RectanglePoints[2], RectanglePoints[3], PointToCheck);
			tri4Area = areaOfTriangle(RectanglePoints[3], RectanglePoints[0], PointToCheck);
			//
			triAreaSum = Math.Abs(tri1Area) + Math.Abs(tri2Area) + Math.Abs(tri3Area) + Math.Abs(tri4Area);
			//
			if (RectangleArea >= triAreaSum)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
#endregion
#region Window

		private float MaxObstacleLength;

		public void CalculateWindowData()
		{
			int S = 0;
			int ObstaclePointType = 0;
			//Dim X2, Y2 As Integer
			//Dim ObsMiddlePoint As Point
			//Dim Obsver As Point
			//
			//set an initial values for big windows limits
			MazeMinPoint.X = Math.Min(MazeStartNode.NodePoint.X, MazeEndNode.NodePoint.X);
			MazeMinPoint.Y = Math.Min(MazeStartNode.NodePoint.Y, MazeEndNode.NodePoint.Y);
			MazeMaxPoint.X = Math.Max(MazeStartNode.NodePoint.X, MazeEndNode.NodePoint.X);
			MazeMaxPoint.Y = Math.Max(MazeStartNode.NodePoint.Y, MazeEndNode.NodePoint.Y);
			//
			//UpdateMazeWindow( StartNode.NodePoint)
			//UpdateMazeWindow(MazeEndNode.NodePoint)
			//
			MaxObstacleLength = 0;
			for (S = 0; S < Obstacles.Count; S++)
			{
				for (ObstaclePointType = ObstaclePointTypeStart; ObstaclePointType <= ObstaclePointLastTypeIndex; ObstaclePointType++)
				{
					UpdateMazeWindow(Obstacles[S].Points[ObstaclePointType]);
				}
				MaxObstacleLength = Math.Max(MaxObstacleLength, CalPointDis(Obstacles[S].Points[ObstaclePointTypeStart], Obstacles[S].Points[ObstaclePointLastTypeIndex]));
			}

			//'get big Window size and diagonal
			//MazeMinPoint.X = Math.Min(MazeStartNode.NodePoint.X, MazeEndNode.NodePoint.X)
			//MazeMinPoint.Y = Math.Min(MazeStartNode.NodePoint.Y, MazeEndNode.NodePoint.Y)
			//MazeMaxPoint.X = Math.Max(MazeStartNode.NodePoint.X, MazeEndNode.NodePoint.X)
			//MazeMaxPoint.Y = Math.Max(MazeStartNode.NodePoint.Y, MazeEndNode.NodePoint.Y)
			//
			if (MaxObstacleLength > 0)
			{
				WindowsNoHorizontal = Convert.ToInt32(Math.Abs(MazeMaxPoint.X - MazeMinPoint.X) / MaxObstacleLength);
				WindowsNoVertical = Convert.ToInt32(Math.Abs(MazeMaxPoint.Y - MazeMinPoint.Y) / MaxObstacleLength);
			}
			else
			{
				WindowsNoHorizontal = 20;
				WindowsNoVertical = 10;
			}

			WindowWidth = (float)((MazeMaxPoint.X - MazeMinPoint.X) / (double)(WindowsNoHorizontal));
			WindowWidth = WindowWidth + 1; // 1 is added so that the max point x will not result in WindowsNoHorizontal which will cause out of range
			WindowHeight = (float)((MazeMaxPoint.Y - MazeMinPoint.Y) / (double)(WindowsNoVertical));
			WindowHeight = WindowHeight + 1; // 1 is added so that the max point y will not result in WindowsNoVertical which will cause out of range
			//
			//classify obstacles
			//
		}
		public void CreateWindoWObstalcesMatrix()
		{
			int X = 0;
			int Y = 0;
			int X1 = 0;
			int Y1 = 0;
			//
			ObstacleWindowSort = new List<int>[WindowsNoHorizontal, WindowsNoVertical];
			for (X = 0; X < WindowsNoHorizontal; X++)
			{
				for (Y = 0; Y < WindowsNoVertical; Y++)
				{
					ObstacleWindowSort[X, Y] = new List<int>();
				}
			}
			//
			for (var S = 0; S < Obstacles.Count; S++)
			{
				//
				GetPointWindow(Obstacles[S].ObstacleMiddlePoint, ref X1, ref Y1);
				ObstacleWindowSort[X1, Y1].Add(S);
				Obstacles[S].ObstacleWindowX = X1;
				Obstacles[S].ObstacleWindowY = Y1;
			}

		}
		//Private Sub ClassifyObstaclesIntoWindows()

		//End Sub
		private void GetPointWindow(Point CheckedPoint, ref int WindowX, ref int WindowY)
		{
			WindowX = Convert.ToInt32(Convert.ToSingle(Math.Floor((CheckedPoint.X - MazeMinPoint.X) / WindowWidth)));
			WindowY = Convert.ToInt32(Convert.ToSingle(Math.Floor((CheckedPoint.Y - MazeMinPoint.Y) / WindowHeight)));
			if (WindowX < 0)
			{
				//Stop
				WindowX = 0;
				//StopSimulation = True
			}
			if (WindowY < 0)
			{
				//Stop
				WindowY = 0;
				//StopSimulation = True
			}
		}

		public void UpdateMazeWindow(Point UpdatePoint)
		{
			MazeMinPoint.X = Math.Min(MazeMinPoint.X, UpdatePoint.X);
			MazeMinPoint.Y = Math.Min(MazeMinPoint.Y, UpdatePoint.Y);
			MazeMaxPoint.X = Math.Max(MazeMaxPoint.X, UpdatePoint.X);
			MazeMaxPoint.Y = Math.Max(MazeMaxPoint.Y, UpdatePoint.Y);
		}
#endregion
#region dijkstra’s algorithm
		private int NodesNumber;
		private int INF; //= 99999 'Infinity value.
		public void SolveMazeDijkstra()
		{
			int X = 0;
			int Y = 0;
			int ObstaclePointTypeX = 0;
			int ObstaclePointTypeY = 0;
			Node FirstNode = new Node();
			Node SecondNode = new Node();
			NodesNumber = ObstacleNoToArray(Obstacles.Count - 1, ObstaclePointLastTypeIndex);
			double[,] NodeToNodedistacne = new double[NodesNumber + 1, NodesNumber + 1];
			//
			int FirstNodeNo = 0;
			int SecondNodeNo = 0;
			//set all nodes distance to each other as inifinity 
			INF = Convert.ToInt32(MazeStartToEndDistance * 100);
			for (Y = 0; Y <= NodesNumber; Y++)
			{
				for (X = 0; X <= NodesNumber; X++)
				{
					NodeToNodedistacne[X, Y] = INF;
				}
			}
			//create the visbility matrix
			for (Y = 0; Y < Obstacles.Count; Y++)
			{
				if (Obstacles[Y].InsideSearchRegion == true)
				{
					for (ObstaclePointTypeY = ObstaclePointTypeStart; ObstaclePointTypeY <= ObstaclePointLastTypeIndex; ObstaclePointTypeY++)
					{
						FirstNode.NodeObstacleNumber = Obstacles[Y].ObstacleIndex;
						FirstNode.NodeObstaclePointType = ObstaclePointTypeY;
						FirstNode.NodePoint = Obstacles[Y].PointsExtended[ObstaclePointTypeY];
						//
						for (X = 0; X < Obstacles.Count; X++)
						{
							if (Obstacles[Y].InsideSearchRegion == true)
							{
								//
								for (ObstaclePointTypeX = ObstaclePointTypeStart; ObstaclePointTypeX <= ObstaclePointLastTypeIndex; ObstaclePointTypeX++)
								{
									SecondNode.NodeObstacleNumber = Obstacles[X].ObstacleIndex;
									SecondNode.NodeObstaclePointType = ObstaclePointTypeX;
									SecondNode.NodePoint = Obstacles[X].PointsExtended[ObstaclePointTypeX];
									//
									if (X != Y)
									{
										if (CheckNodeToNodeVisible(FirstNode, SecondNode) == true)
										{
											FirstNodeNo = ObstacleNoToArray(FirstNode.NodeObstacleNumber, FirstNode.NodeObstaclePointType);
											SecondNodeNo = ObstacleNoToArray(SecondNode.NodeObstacleNumber, SecondNode.NodeObstaclePointType);
											NodeToNodedistacne[FirstNodeNo, SecondNodeNo] = CalNodeDis(FirstNode, SecondNode);
											NodeToNodedistacne[SecondNodeNo, FirstNodeNo] = NodeToNodedistacne[FirstNodeNo, SecondNodeNo];
										}
									}
									//
								}
							}
						}
					}
				}
			}
			//
			for (Y = 0; Y < Obstacles.Count; Y++)
			{
				if (Obstacles[Y].InsideSearchRegion == true)
				{
					for (ObstaclePointTypeY = ObstaclePointTypeStart; ObstaclePointTypeY <= ObstaclePointLastTypeIndex; ObstaclePointTypeY++)
					{
						FirstNode.NodeObstacleNumber = Obstacles[Y].ObstacleIndex; //Y
						FirstNode.NodeObstaclePointType = ObstaclePointTypeY;
						FirstNode.NodePoint = Obstacles[Y].PointsExtended[ObstaclePointTypeY];
						FirstNodeNo = ObstacleNoToArray(FirstNode.NodeObstacleNumber, FirstNode.NodeObstaclePointType);
						//
						if (CheckNodeToNodeVisible(FirstNode, MazeStartNode) == true)
						{
							NodeToNodedistacne[FirstNodeNo, 0] = CalNodeDis(FirstNode, MazeStartNode);
							NodeToNodedistacne[0, FirstNodeNo] = NodeToNodedistacne[FirstNodeNo, 0];
						}
						//
						if (CheckNodeToNodeVisible(FirstNode, MazeEndNode) == true)
						{
							NodeToNodedistacne[FirstNodeNo, 1] = CalNodeDis(FirstNode, MazeEndNode);
							NodeToNodedistacne[1, FirstNodeNo] = NodeToNodedistacne[FirstNodeNo, 1];
						}
					}
				}
			}
			Dijkstra(NodeToNodedistacne, 0, 1);
		}


		public float Dijkstra(double[,] cost, int source, int target)
		{
			int[] prev = new int[NodesNumber + 1];
			int[] selected = new int[NodesNumber + 1];
			int m = 0;
			int min = 0;
			int start = 0;
			int j = 0;
			double d = 0D;
			double[] dist = new double[NodesNumber + 1];
			List<int> ReversedPathMAtrix = new List<int>();
			//
			for (var index = 0; index <= NodesNumber; index++)
			{
				dist[index] = INF;
				prev[index] = -1;
			}
			//
			start = source;
			selected[start] = 1;
			dist[start] = 0;

			while (selected[target] == 0)
			{
				min = INF;
				m = 0;
				//
				for (var index = 0; index <= NodesNumber; index++)
				{
					d = dist[start] + cost[start, index];
					//
					if (d < dist[index] && selected[index] == 0)
					{
						dist[index] = d;
						prev[index] = start;
					}
					if (min > dist[index] && selected[index] == 0)
					{
						min = Convert.ToInt32(dist[index]);
						m = index;
					}
				}
				start = m;
				selected[start] = 1;
			}

			start = target;
			j = 0;
			//create an initial path 
			FoundPaths.Add(CreateInitialPath());
			FoundPaths[0].PathNode.Clear(); //making the path empty because the order is reversed in Dijkstra

			FoundPaths[0].CurrentPathStatus = PathStatusTypes.Solution;
			while (start != -1)
			{
				ReversedPathMAtrix.Add(start);
				j += 1;
				start = prev[start];
			}
			//
			for (var s = ReversedPathMAtrix.Count - 1; s >= 0; s--)
			{
				FoundPaths[0].PathNode.Add(GetNodeFromNo(ReversedPathMAtrix[s]));
			}
			//
			FoundPaths[0].PathLength = (float)CalPathLength(0);
			//
			PathWasFound = true;
			return FoundPaths[0].PathLength;
		}
		public double CalPathLength(int PathNo)
		{
			int s = 0;
			double PathLength = 0D;
			//
			if (FoundPaths[PathNo].PathNode.Count < 2)
			{
				System.Diagnostics.Debugger.Break();
				return 0D;
			}
// INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of FoundPaths(PathNo).PathNode.Count - 2 for every iteration:
			int tempVar = FoundPaths[PathNo].PathNode.Count - 2;
			for (s = 0; s <= tempVar; s++)
			{
				PathLength = PathLength + CalNodeDis(FoundPaths[PathNo].PathNode[s], FoundPaths[PathNo].PathNode[s + 1]);
			}
			//
			//FoundPath(PathNo).PathLength = 10 'PathLength
			//
			return PathLength;
		}
		private Node GetNodeFromNo(int NodeNo)
		{
			// Return (ObstacleNo * 2) + 1 + ObstacleEndPointType
			int ObstacleNumber = 0;
			int ObstaclePointType = 0;
			float S = 0F;
			Node TempObstacleNode = new Node();
			//
			if (NodeNo < 2)
			{
				if (NodeNo == 0)
				{
					return MazeStartNode;
				}
				if (NodeNo == 1)
				{
					return MazeEndNode;
				}
			}
			//
			S = (float)((NodeNo - 1 - ObstaclePointLastTypeIndex) / 2.0);
			ObstacleNumber = Convert.ToInt32(Math.Floor(S + 0.999));
			//
			S = NodeNo - 1 - ObstacleNumber * 2;
			ObstaclePointType = Convert.ToInt32(S);
			//
			TempObstacleNode.NodeObstacleNumber = ObstacleNumber;
			TempObstacleNode.NodeObstaclePointType = ObstaclePointType;
			TempObstacleNode.NodePoint = Obstacles[ObstacleNumber].PointsExtended[ObstaclePointType];
			//
			return TempObstacleNode;
		}
#endregion
	}
}
