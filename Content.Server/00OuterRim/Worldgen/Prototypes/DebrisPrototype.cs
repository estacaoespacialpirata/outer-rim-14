using Content.Server._00OuterRim.Worldgen.Populators.Debris;
using Content.Shared.Maps;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.List;

namespace Content.Server._00OuterRim.Worldgen.Prototypes;

[Prototype("debris")]
public sealed class DebrisPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; } = default!;

    /// <summary>
    /// The type of floorplan to be used for the given asteroid. This decides what shape it'll take.
    /// </summary>
    [DataField("floorplanStyle", required: true)]
    public DebrisFloorplanStyle FloorplanStyle { get; } = default!;

    /// <summary>
    /// The populator to use, which fills the debris with contents.
    /// </summary>
    [DataField("populator", required: true)]
    public DebrisPopulator Populator { get; } = default!;

    /// <summary>
    /// How many times the generator can place another "section" of floor
    /// </summary>
    /// <returns></returns>
    [DataField("floorPlacements", required: true)]
    public uint FloorPlacements { get; } = default!;

    // TODO: Make this some sort of weighted list!
    /// <summary>
    /// List of tile types to construct the floor with.
    /// </summary>
    [DataField("floorTiles", required: true, customTypeSerializer:typeof(PrototypeIdListSerializer<ContentTileDefinition>))]
    public List<string> FloorTiles { get; } = default!;

    [DataField("radius", required: true)]
    public uint Radius { get; } = default!;

    [DataField("debrisRadarColor")]
    public Color DebrisRadarColor { get; } = Color.SandyBrown;
}

public enum DebrisFloorplanStyle
{
    /// <summary>
    /// Produces a "squiggly" floorplan, as the generator simply places a tile randomly next to an existing tile.
    /// </summary>
    Tiles,

    /// <summary>
    /// Similar to tiles, but places a small blob instead.
    /// </summary>
    Blobs,
}

