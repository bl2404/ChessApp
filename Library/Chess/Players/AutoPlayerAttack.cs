using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess.Players
{
    public class AutoPlayerAttack : AutoPlayer
    {
        public AutoPlayerAttack(Game game) : base(game) { }

        public override void InitiateMove()
        {
            Move();
        }

        protected override void Move()
        {
            if (PossibleMoves.Count > 0)
            {
                Color currentPlayerColor = this.Game.CurrentPlayer.Color;
                Rook rook = (Rook)Game.Figures.First(f => f.Color == currentPlayerColor && f is Rook);
                King king = (King)Game.Figures.First(f => f.Color == currentPlayerColor && f is King);
                var pole = CalculateRestrictedField(rook.Field.Horizontal, rook.Field.Vertical);
                var restrictionMoves=FindSmallerRestrictedFields();
                if(restrictionMoves.Count>0)
                {
                    rook.Move(restrictionMoves.Last());
                    return;
                }
                var oppositions = FindOppositions();
                if (oppositions.Count > 0)
                {
                    king.Move(oppositions.First());
                    return;
                }
                else
                {
                    RandomKingMove();
                }
            }
        }

        private int CalculateRestrictedField(Horizontal horizontalRookLoc, Vertical verticalRookLoc)
        {
            Color currentPlayerColor = this.Game.CurrentPlayer.Color;
            int horizontalLocation = (int)horizontalRookLoc;
            int verticalLocation = (int)verticalRookLoc;

            int northWestField = (horizontalLocation - 1) * (8 - verticalLocation);
            int northEast = (8 - horizontalLocation) * (8 - verticalLocation);
            int southWest = (horizontalLocation - 1) * (verticalLocation - 1);
            int southEast = (8 - horizontalLocation) * (verticalLocation - 1);

            King king = (King)Game.Figures.First(f => f.Color != currentPlayerColor && f is King);

            if (king.Field.Vertical > verticalRookLoc)
            {
                if (king.Field.Horizontal > horizontalRookLoc)
                {
                    return northEast;
                }
                else if(king.Field.Horizontal == horizontalRookLoc)
                {
                    return northEast + northWestField;
                }
                else
                {
                    return northWestField;
                }
            }

            else if(king.Field.Vertical == verticalRookLoc)
            {
                if (king.Field.Horizontal > horizontalRookLoc)
                {
                    return northEast+southEast;
                }
                else
                {
                    return northWestField + southWest;
                }
            }
            else
            {
                if (king.Field.Horizontal > horizontalRookLoc)
                {
                    return southEast;
                }
                else if(king.Field.Horizontal == horizontalRookLoc)
                {
                    return southWest + southWest;
                }
                else
                {
                    return southWest;
                }
            }
        }

        private bool IsRookProtected(Field rookField,Field kingField)
        {
            int horizontalDifference = Math.Abs((int)kingField.Horizontal - (int)rookField.Horizontal);
            int verticalDifference = Math.Abs((int)kingField.Vertical - (int)rookField.Vertical);

            if(horizontalDifference ==1 || verticalDifference == 1)
            {
                int totalDifference = Math.Max(horizontalDifference, verticalDifference);
                if (totalDifference <= 1)
                    return true;
            }
            return false;
        }

        private List<Field> FindSmallerRestrictedFields()
        {
            Color currentPlayerColor = this.Game.CurrentPlayer.Color;
            Rook rook = (Rook)Game.Figures.First(f => f.Color == currentPlayerColor && f is Rook);
            King king = (King)Game.Figures.First(f => f.Color == currentPlayerColor && f is King);

            int fieldSize = CalculateRestrictedField(rook.Field.Horizontal, rook.Field.Vertical);
            List<Field> possibleRookMoves = new List<Field>();
            foreach (var field in rook.PossibleMoves)
            {
                if (IsRookProtected(field,king.Field))
                {
                    var calculatedFieldSize = CalculateRestrictedField(field.Horizontal, field.Vertical);
                    if (calculatedFieldSize < fieldSize)
                        possibleRookMoves.Add(field);
                }
            }
            return possibleRookMoves;
        }

        private bool IsOpposition(Horizontal horizontalKingLoc, Vertical verticalKingLoc)
        {
            Color currentPlayerColor = this.Game.CurrentPlayer.Color;
            //Rook rook = (Rook)Game.Figures.First(f => f.Color == currentPlayerColor && f is Rook);
            King foreginKing = (King)Game.Figures.First(f => f.Color != currentPlayerColor && f is King);

            if (horizontalKingLoc == foreginKing.Field.Horizontal || verticalKingLoc == foreginKing.Field.Vertical)
            {
                int horizontalDifference = Math.Abs((int)horizontalKingLoc - (int)foreginKing.Field.Horizontal);
                int verticalDifference = Math.Abs((int)verticalKingLoc - (int)foreginKing.Field.Vertical);
                int totalDifference = Math.Max(horizontalDifference, verticalDifference);
                if (totalDifference == 2)
                    return true;
            }
            return false;
        }

        private List<Field> FindOppositions()
        {
            Color currentPlayerColor = this.Game.CurrentPlayer.Color;
            King king = (King)Game.Figures.First(f => f.Color == currentPlayerColor && f is King);
            Rook rook = (Rook)Game.Figures.First(f => f.Color == currentPlayerColor && f is Rook);
            King foreginKing = (King)Game.Figures.First(f => f.Color != currentPlayerColor && f is King);

            List<Field> possibleKingMoves = new List<Field>();
            foreach (var field in king.PossibleMoves)
            {
                if (IsRookProtected(rook.Field, field) && IsOpposition(field.Horizontal, field.Vertical))
                    possibleKingMoves.Add(field);
            }
            return possibleKingMoves;
        }

        private void RandomKingMove()
        {
            Color currentPlayerColor = this.Game.CurrentPlayer.Color;
            King king = (King)Game.Figures.First(f => f.Color == currentPlayerColor && f is King);
            Rook rook = (Rook)Game.Figures.First(f => f.Color == currentPlayerColor && f is Rook);
            //King foreginKing = (King)Game.Figures.First(f => f.Color != currentPlayerColor && f is King);

            var potentialKingsMoves = king.PossibleMoves.Where(x => IsRookProtected(rook.Field, x));
            king.Move(potentialKingsMoves.First());
        }
    }
}
