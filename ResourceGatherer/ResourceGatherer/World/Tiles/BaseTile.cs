﻿using ResourceGatherer.Drawers.TileDrawers;
using ResourceGatherer.Entities;
using ResourceGatherer.Util;
using ResourceGatherer.World.Graphs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Tiles {
    public abstract class BaseTile {
        public static readonly int tileWidth = 20;
        public static readonly int tileHeight = 20;

        public Bitmap sprite;
        public Vector2D position;
        public Vertex tileVertex;

        public RectangleF vertexRectangle {
            get {
                return new RectangleF(position.x + (tileWidth / 3), position.y + (tileHeight / 3), tileWidth - (tileWidth / 3 * 2), tileHeight - (tileHeight / 3 * 2));
            }
        }

        public bool isWalkable;

        private List<StaticEntity> _entityList;
        public List<StaticEntity> entityList {
            get {
                if (_entityList == null)
                    _entityList = new List<StaticEntity>();
                return _entityList;
            }
        }

        public int entityCount {
            get {
                if (_entityList == null)
                    return 0;
                else
                    return _entityList.Count;
            }
        }

        private static ITileDrawer tileDrawer;

        public BaseTile(Vector2D pos) {
            position = pos;
        }

        public void Render(Graphics g) {
            tileDrawer.Draw(g, this);
        }

        public void CreateTileVertex() {
            if (tileVertex == null && isWalkable)
                tileVertex = new Vertex(position.ToString(), this);
        }

        public void DestroyTileVertex() {
            tileVertex = null;
        }

        public static void SetTileDrawer(ITileDrawer drawer) {
            tileDrawer = drawer;
        }

        public bool HasAdjacent(BaseTile other) {
            foreach (Edge e in tileVertex.adj)
                if (e.destination.parentTile == other)
                    return true;

            return false;
        }

        public TileRiver GetRiverTile() {
            return new TileRiver(position);
        }

        public void AddEntityToTile(StaticEntity entity) {
            if (!entityList.Contains(entity))
                entityList.Add(entity);
        }

        public override bool Equals(object obj) {
            var tile = obj as BaseTile;
            return tile != null &&
                   EqualityComparer<Vector2D>.Default.Equals(position, tile.position) &&
                   isWalkable == tile.isWalkable &&
                   EqualityComparer<List<StaticEntity>>.Default.Equals(_entityList, tile._entityList);
        }

        public override int GetHashCode() {
            var hashCode = 978046299;
            hashCode = hashCode * -1521134295 + EqualityComparer<Vector2D>.Default.GetHashCode(position);
            hashCode = hashCode * -1521134295 + isWalkable.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<StaticEntity>>.Default.GetHashCode(_entityList);
            return hashCode;
        }
    }
}
