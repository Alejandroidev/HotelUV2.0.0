using System.Collections.Generic;

namespace Common.Helper;

/// <summary>
/// Custom project configuration (appsettings)
/// </summary>
public class CustomConfig
{
    /// <summary>
    /// General project data
    /// </summary>
    public ProjectData Project { get; set; }
}

/// <summary>
/// Project data
/// </summary>
public class ProjectData
{
    /// <summary>
    /// Project name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Friendly module name
    /// </summary>
    public string ModuleName { get; set; }

    /// <summary>
    /// OpenAPI Servers
    /// </summary>
    public List<ServerData> Servers { get; set; }
}

/// <summary>
/// OpenAPI server data
/// </summary>
public class ServerData
{
    /// <summary>
    /// Server Url
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Server description
    /// </summary>
    public string Description { get; set; }
}