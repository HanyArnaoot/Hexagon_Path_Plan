Hexagon Path Plan: Efficient 2D Path Planning AlgorithmOverviewWelcome to the Hexagon Path Plan, an innovative 2D path planning algorithm developed by Hany M. Arnaoot, a college professor and researcher at the Alexandria Higher Institute of Engineering & Technology, Egypt. This algorithm tackles key challenges in visibility graph-based path planning, such as long computation times and unsafe paths that come too close to static obstacles. It introduces a novel approach using two sets of points for each 2D line:A longer set to identify potential nodes for navigation.
A shorter set for visibility checking, ensuring safer paths.

Unlike traditional methods that compute an entire visibility graph upfront, this algorithm generates visibility on-demand, significantly improving efficiency. While designed for 2D environments, it has potential extensions to 3D path planning, making it ideal for applications like agricultural drones, archaeological surveys, and civilian logistics.PurposeThis code is shared to advance research and development in civilian, non-military applications, including:Precision Agriculture: Navigating drones or robots through farms to monitor crops or spray pesticides in Egypt’s Nile Delta or reclaimed lands.
Archaeological Surveys: Guiding drones to map historical sites in Egypt (e.g., Giza, Luxor) without colliding with structures.
Urban Logistics: Planning safe drone delivery paths in cities like Cairo or Alexandria.
Environmental Monitoring: Supporting drones to track Nile River pollution or desertification.

Important: This algorithm is intended for peaceful, civilian use only. Any military or defense-related use is strictly prohibited.FeaturesEfficient Computation: Reduces processing time by generating visibility graphs as needed.
Enhanced Safety: Uses dual-point sets to ensure paths maintain a safe distance from obstacles, addressing limitations of traditional visibility graph methods.
Scalable Design: Applicable to 2D environments with potential for 3D extensions (e.g., drone navigation).
Open-Source: Freely available for non-commercial, civilian use under the license below.

LicenseThis project is licensed under the Creative Commons Attribution-NonCommercial 4.0 International License (CC BY-NC 4.0). You are free to:Share and adapt the code for non-commercial purposes.
Attribute the original author (Hany M. Arnaoot).

Restrictions:No Military Use: Use in military or defense applications is strictly prohibited.
No Commercial Use: Contact the author for permission for commercial applications.
Attribution Required: You must give credit to Hany M. Arnaoot when using or modifying this code.

See the LICENSE (LICENSE.md) file for full details. For inquiries about commercial or other uses, contact:Email: hanyarnaoot@yahoo.com (mailto:hanyarnaoot@yahoo.com) or dr.hany.arnaout@aiet.edu.eg (mailto:dr.hany.arnaout@aiet.edu.eg)

InstallationClone the Repository:bash

git clone https://github.com/HanyArnaoot/Hexagon_Path_Plan.git

Prerequisites:.NET Framework or .NET Core (specify version if known, e.g., .NET 6.0)
MapWinGIS (ActiveX control for GIS functionality)
Visual Studio or another C# IDE

Install MapWinGIS:Download and register the MapWinGIS ActiveX control as per the MapWinGIS documentation.
Ensure the control is properly referenced in your project.

Build the Project:Open the solution file (.sln) in Visual Studio.
Restore dependencies and build the project.

UsageInput: Provide a 2D environment map with static obstacles (e.g., as lines or shapes compatible with MapWinGIS).
Configuration: Set start and goal points, and adjust parameters for the dual-point sets (longer for nodes, shorter for visibility).
Output: The algorithm generates an optimized, safe path avoiding obstacles.

ExampleBelow is a basic example of how to use the Hexagon Path Plan algorithm (replace with your actual code structure if different):csharp

using HexagonPathPlan;

class Program
{
    static void Main(string[] args)
    {
        var planner = new HexagonPathPlanner();
        var start = new Point(0, 0);
        var goal = new Point(10, 10);
        var obstacles = // Load obstacles using MapWinGIS (e.g., shapefile or in-memory shapes);
        var path = planner.PlanPath(start, goal, obstacles);
        // Process or display the path
    }
}

See the examples/ folder for sample code and datasets (if provided).ContributingContributions are welcome for civilian applications only. To contribute:Fork the repository.
Create a branch for your changes:bash

git checkout -b feature-name

Commit your changes:bash

git commit -m "Added feature X"

Push to your branch:bash

git push origin feature-name

Open a pull request with a description of your changes.

Please ensure contributions align with the non-military, civilian focus of this project.ContactFor questions, collaboration opportunities, or feedback, contact:Author: Hany M. Arnaoot
Email: hanyarnaoot@yahoo.com (mailto:hanyarnaoot@yahoo.com) or dr.hany.arnaout@aiet.edu.eg (mailto:dr.hany.arnaout@aiet.edu.eg)
Institution: Alexandria Higher Institute of Engineering & Technology, Egypt
GitHub: HanyArnaoot

AcknowledgmentsDeveloped as part of Hany M. Arnaoot’s research in Egypt, focused on advancing ethical robotics.
Inspired by challenges in visibility graph path planning and the need for efficient, safe navigation in civilian applications.
Built using MapWinGIS for GIS functionality.

