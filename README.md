# Artificial-Int.-for-Games-Assignment-2
A project developed for Assignment 2 of the course Artificial Intelligence for Games. This project is a mining and resource management game using assets from Factorio and a provided Unity template.

Note: This project was built using a course-provided basic template and is shared for portfolio purposes only.

Gameplay
4 different resources types, 3 nodes each, 50 units of the given resource per node.
The storage starts with 0 of each.
Resources can be gathered manually, or with drills.
Gathering gathers resources at a rate of one unit every 5 seconds.
Drills stock up resources that need to be collected with drones.
Drills gather resources at a rate of one unit every 5 seconds.
Power plants speed up the rate at which drills gather resources to one unit every 2 seconds.
Drills cost 2 iron and 2 wood to create.
Power plants cost 10 copper, 10 iron, and 15 coal to create.
Drones cost 2 copper, 2 iron, and 15 wood.

![Gameplay](Media/Gameplay.gif)

Controls
Hold left click on a resource node to mine resource.
Right click on a resource node to create a drill.
Right click on a drill to create a power plant.
Right click on storage to create a drone.

Limitations
The project was built with Unity console logs in mind, so updates of the mining progress when gathering a resource manually, or alerts about not have enough resources to create something are not shown in a built .exe of the project.

Languages Used
C#

Unity Assets Used
Behvaiour Designer - A proprietary asset not included in the repo.

Implemented/Modified the Following Files
DepositResource.cs
FetchResource.cs
GoToDestination.cs
CheckDrill.cs
ExtractResource.cs
TimerLogic.cs
AddDrillToList.cs
StorageController.cs
ResourceController.cs
InputController.cs

How to run the game
1. Download Build folder
2. Run exe

How to build/run the project from source
Unity Editor Version 2022.3.12f1
1. Clone repo locally.
2. Open Unity Hub and add project.
3. Purchase and import Behavior Designer from the Asset Store.
4. Navigate to Assets/Scenes in the project window.
5. Drag SampleScene.unity to the hierarchy.
6. Press play.

Credits
Template for the project is from the Artificial Intelligence for Games course at Sheridan College. Included assets from the game Factorio.
Behavior Designer by Opsive.
TextMeshPro (built into Unity, still worth mentioning).
