﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Router : Node {

    public IRouting<Connection> RoutingStrategy = new RoundRobinRouting<Connection>();

    public override void Process(Request request)
    {
        var routedConnection = RoutedConnection;
        if (routedConnection != null)
        {
            request.Redirect(routedConnection);
        }
    }

    public Connection RoutedConnection
    {
        get
        {
            List<Connection> connections = OutgoingConnections;
            Connection next = RoutingStrategy.GetNextElement(connections);
            return next;
        }
    }
}
