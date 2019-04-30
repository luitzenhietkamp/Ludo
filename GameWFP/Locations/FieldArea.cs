namespace GameWFP
{
    /// <summary>
    /// Represents all the different kind of fields in the game
    /// </summary>
    public enum FieldArea
    {
        // The four starting positions
        GreenHome,
        YellowHome,
        RedHome,
        BlueHome,
        // The finishing positions
        GreenFinish,
        YellowFinish,
        RedFinish,
        BlueFinish,
        // Any of the regular squares on the field.
        SquareX,
        // Default value
        None
    }
}