using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelRouteDrawing : Command
{
    public WindSourceController windSource;
    public RouteManager routeManager;
    private GameManager gameManager;
    public List<Vector3> route = new List<Vector3>();
    public CancelRouteDrawing(WindSourceController windSource, RouteManager routeManager, List<Vector3> route)
    {
        this.windSource = windSource;
        this.routeManager = routeManager;
        this.route = new List<Vector3>();
        this.route.AddRange(route);
        this.gameManager = GameManager.instance;
    }
    public override void Execute()
    {
        routeManager.DeleteTiles();
        gameManager.route.Clear();
        routeManager.validPos.Clear();

        gameManager.curWindSource.windSP = GameManager.instance.curWindSource.defWindSP;
        ///gameManager.curWindSource.route.Clear();
        gameManager.curWindSource = null;
        gameManager.state = GameState.Waiting;
        executionTime = Time.time;
    }

    public override void Undo()
    {
        // Undo wind source power
        windSource.windSP = windSource.defWindSP - route.Count;

        // Undo game manager stuff
        GameManager.instance.curWindSource = windSource;
        GameManager.instance.route = new List<Vector3>();
        GameManager.instance.route.AddRange(route);
        GameManager.instance.state = GameState.DrawingRoute;

        // Undo route tile manager stuff
        routeManager.route = new List<Vector3>();
        routeManager.route.AddRange(route);
        routeManager.UpdateValidPositions(route[route.Count - 1]);
        routeManager.DrawRoute(route);
    }
}