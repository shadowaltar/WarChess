﻿namespace HeroParagon.Models;

public abstract class NamedObject
{
    public string Name { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
}
