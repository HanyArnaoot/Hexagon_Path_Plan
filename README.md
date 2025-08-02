Hexagon Path Plan: Efficient 2D Path Planning Algorithm Overview 
Welcome to the Hexagon Path Plan, an innovative 2D path planning algorithm developed by Hany M. Arnaoot, a college professor and researcher at the Alexandria Higher Institute of Engineering & Technology, Egypt. This algorithm tackles key challenges in visibility graph-based path planning, such as long computation times and unsafe paths that come too close to static obstacles. It introduces a novel approach using two sets of points for each 2D line:A longer set to identify potential nodes for navigation.
A shorter set for visibility checking, ensuring safer paths.
parts of this algorithm were published in the following papers:

1- Visibility Graph-Based Path Planning Algorithm Safety Evaluation and Optimization
     https://ieeexplore.ieee.org/document/9855737
2-Hexagon path planning algorithm
     https://ietresearch.onlinelibrary.wiley.com/doi/10.1049/rsn2.12250
3- Enhancing the Hexagon Path Planning Algorithm for Dense Obstacle Environments (Iterative Hexagon Algorithm)
    https://journals.ekb.eg/article_370885.html
4- A real-time trajectory planning approach for dynamic environments with dense obstacles
   https://www.academia.edu/2994-7065/2/1/10.20935/AcadEng7567
    

Unlike traditional methods that compute an entire visibility graph upfront, this algorithm generates visibility on demand, significantly improving efficiency. While designed for 2D environments, it has potential extensions to 3D path planning, making it ideal for applications like agricultural drones, archaeological surveys, and civilian logistics.This code is shared to advance research and development in civilian, non-military applications, including: Precision Agriculture: Navigating drones or robots through farms to monitor crops or spray pesticides in Egypt’s Nile Delta or reclaimed lands.
Archaeological Surveys: Guiding drones to map historical sites in Egypt (e.g., Giza, Luxor) without colliding with structures.
Urban Logistics: Planning safe drone delivery paths in cities like Cairo or Alexandria.
Environmental Monitoring: Supporting drones to track Nile River pollution or desertification.

Important: This algorithm is intended for peaceful, civilian use only. Any military or defense-related use is strictly prohibited.Features Efficient Computation: Reduces processing time by generating visibility graphs as needed.
Enhanced Safety: Uses dual-point sets to ensure paths maintain a safe distance from obstacles, addressing limitations of traditional visibility graph methods.
Scalable Design: Applicable to 2D environments with potential for 3D extensions (e.g., drone navigation).
Open-Source: Freely available for non-commercial, civilian use under the license below.

LicenseThis project is licensed under the Creative Commons Attribution-NonCommercial 4.0 International License (CC BY-NC 4.0). You are free to: Share and adapt the code for non-commercial purposes.
Attribute the original author (Hany M. Arnaoot).

Restrictions:No Military Use: Use in military or defense applications is strictly prohibited.
No Commercial Use: Contact the author for permission for commercial applications.
Attribution Required: You must give credit to Hany M. Arnaoot when using or modifying this code.

See the LICENSE (LICENSE.md) file for full details. For inquiries about commercial or other uses, contact:Email: hanyarnaoot@yahoo.com (mailto:hanyarnaoot@yahoo.com) or dr.hany.arnaout@aiet.edu.eg (mailto:dr.hany.arnaout@aiet.edu.eg)
 
Prerequisites:
.NET Framework or .NET Core
MapWinGIS (ActiveX control for GIS functionality)
Visual Studio or another C# IDE

Install MapWinGIS: Download and register the MapWinGIS ActiveX control as per the MapWinGIS documentation.
Ensure the control is properly referenced in your project.

Build the Project: Open the solution file (.sln) in Visual Studio.
Restore dependencies and build the project.

Usage Input: Provide a 2D environment map with static obstacles (e.g., as lines or shapes compatible with MapWinGIS).
Configuration: Set start and goal points, and adjust parameters for the dual-point sets (longer for nodes, shorter for visibility).
Output: The algorithm generates an optimized, safe path avoiding obstacles.


Please ensure contributions align with the non-military, civilian focus of this project. Contact: For questions, collaboration opportunities, or feedback, contact:Author: Hany M. Arnaoot
Email: hanyarnaoot@yahoo.com (mailto:hanyarnaoot@yahoo.com) or dr.hany.arnaout@aiet.edu.eg (mailto:dr.hany.arnaout@aiet.edu.eg)
Institution: Alexandria Higher Institute of Engineering & Technology, Egypt
GitHub: HanyArnaoot

Acknowledgments: Developed as part of Hany M. Arnaoot’s research in Egypt, focused on advancing ethical robotics.
Inspired by challenges in visibility graph path planning and the need for efficient, safe navigation in civilian applications.
Built using MapWinGIS for GIS functionality.

