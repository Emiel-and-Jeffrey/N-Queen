using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// N Queen Solver methods
/// </summary>
public class NQueenSolver
{

    /// <summary>
    /// Get the positions for the N Queen problem
    /// </summary>
    /// <param name="size">Your value for N</param>
    /// <returns>A list of all the positions</returns>
    /// <exception cref="ArgumentException"/>
    public static List<Position> GetNQueenSolution(int size)
    {
        if (size < 1)
        {
            throw new ArgumentException($"{nameof(size)} can not be below 1");
        }
        return GetQueenPositions(size, size, size, new List<Position>());
    }

    /// <summary>
    /// Get the positions for the N Queen problem
    /// </summary>
    /// <param name="column">Should be equal to N when first called</param>
    /// <param name="row">Should be equal to N when first called</param>
    /// <param name="size">Your value for N</param>
    /// <param name="queens">An empty list</param>
    /// <returns>A list of all the positions</returns>
    private static List<Position> GetQueenPositions(int column, int row, int size, List<Position> queens)
    {
        if (column < 1)
            return new List<Position>();
        if (row < 1)
            return queens;
        Position position = new Position(column, row);
        if (IsSafe(position, size, queens))
        {
            queens.Add(position);
            List<Position> returnedQueens = GetQueenPositions(size, row - 1, size, queens);
            if (returnedQueens.Any())
                return returnedQueens;
            queens.Remove(position);
        }
        return GetQueenPositions(column - 1, row, size, queens);
    }

    /// <summary>
    /// Check this position would not be attacked by a queen
    /// </summary>
    /// <param name="position">The position that you want to check for safety</param>
    /// <param name="size">The N value</param>
    /// <param name="queens">All other queens</param>
    /// <returns>True if it is safe to place the queen</returns>
    private static bool IsSafe(Position position, int size, ICollection<Position> queens)
    {
        return !queens.Where((queen => queen.Column == position.Column || queen.Row == position.Row)).Any()
            && CheckDirection(new Position(position, Direction.DownRight), Direction.DownRight, size, queens)
            && CheckDirection(new Position(position, Direction.DownLeft), Direction.DownLeft, size, queens)
            && CheckDirection(new Position(position, Direction.UpLeft), Direction.UpLeft, size, queens)
            && CheckDirection(new Position(position, Direction.UpRight), Direction.UpRight, size, queens);
    }

    /// <summary>
    /// Check if the direction is valid
    /// </summary>
    /// <param name="position">The position you want to check</param>
    /// <param name="direction">The direction it should go towards</param>
    /// <param name="size">The N value</param>
    /// <param name="queens">The other queens</param>
    /// <returns>True if the direction has no queens</returns>
    private static bool CheckDirection(Position position, Direction direction, int size, ICollection<Position> queens)
    {
        if (!IsValid(position, size))
            return true;
        return !queens.Contains(position) && CheckDirection(new Position(position, direction), direction, size, queens);
    }

    /// <summary>
    /// Check if the position is a valid one
    /// </summary>
    /// <param name="position">The position to be checked</param>
    /// <param name="size">The N value</param>
    /// <returns>True if the position is valid</returns>
    private static bool IsValid(Position position, int size)
    {
        return position.Column > 0 && position.Column <= size &&
               position.Row > 0 && position.Row <= size;
    }
}
