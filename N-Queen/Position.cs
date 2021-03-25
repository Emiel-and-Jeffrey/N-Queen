using System;

/// <summary>
/// A position a Queen can be
/// </summary>
public class Position
{
    /// <summary>
    /// Get the column of this position
    /// </summary>
    public int Column { get; }

    /// <summary>
    /// Get the row of this position
    /// </summary>
    public int Row { get; }

    /// <summary>
    /// Initialize the position
    /// </summary>
    /// <param name="column">X value</param>
    /// <param name="row">Y value</param>
    public Position(int column, int row)
    {
        Column = column;
        Row = row;
    }

    /// <summary>
    /// Move position
    /// </summary>
    /// <param name="position">The old position</param>
    /// <param name="direction">Direction to the new position</param>
    public Position(Position position, Direction direction)
    {
        Column = position.Column + (direction == Direction.DownLeft || direction == Direction.UpLeft ? -1 : 1);
        Row = position.Row + (direction == Direction.DownLeft || direction == Direction.DownRight ? -1 : 1);
    }

    /// <summary>
    /// Check if Positions are equal
    /// </summary>
    /// <param name="obj">The other object</param>
    /// <returns>True if they are equal</returns>
    public override bool Equals(object obj)
    {
        return obj is Position position &&
               Equals(position);
    }

    /// <summary>
    /// Get the hash code for this Position
    /// </summary>
    /// <returns>The hash code</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Column, Row);
    }

    /// <summary>
    /// Check if Position are equal
    /// </summary>
    /// <param name="other">The other position</param>
    /// <returns>True if the other position is equal</returns>
    protected bool Equals(Position other)
    {
        return Column == other.Column && Row == other.Row;
    }
}
