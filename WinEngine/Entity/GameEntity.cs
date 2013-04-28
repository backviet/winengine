using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WinEngine.Util;
using WinEngine.Util.Modifier;
using WinEngine.Entity.Modifier;

namespace WinEngine.Entity
{
    public class GameEntity : IEntity
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        private List<IEntity> children;

        protected Vector2 position;

        private EntityModifierList modifiers;

        //================================================================
        //Constructors
        //================================================================
        public GameEntity(Vector2 pos)
        {
            Position = pos;

            Visible = true;

            Alpha = 0;
            Rotation = 0;
            Scaling = 1;
            IgnoreUpdate = false;
            Origin = Vector2.Zero;
            Flip = SpriteEffects.None;
        }

        public GameEntity(float x, float y)
            : this(new Vector2(x, y))
        {
        }
        //================================================================
        //Getter and Setter
        //================================================================

        //================================================================
        //Methodes
        //================================================================

        //================================================================
        //Methodes overridde
        //================================================================
        public virtual void Update(GameTime gameTime)
        {
            if (modifiers != null)
            {
                modifiers.Update(gameTime);
            }
            if (children != null)
            {
                for (int i = 0; i < children.Count; i++)
                {
                    IEntity entity = children[i];
                    if (!entity.IgnoreUpdate)
                    {
                        entity.Update(gameTime);
                    }
                }
            }
        }

        public virtual void Reset()
        {
            Visible = true;

            Alpha = 0;
            Rotation = 0;
            Scaling = 1;
            IgnoreUpdate = false;
            Origin = Vector2.Zero;
            Flip = SpriteEffects.None;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (children != null)
            {
                for (int i = 0; i < children.Count; i++)
                {
                    children[i].Draw(spriteBatch);
                }
            }
        }

        public void RegisterModifier(IEntityModifier modifier)
        {
            if (modifiers == null)
            {
                modifiers = new EntityModifierList(this);
            }

            if (modifiers.Contains(modifier))
            {
                return;
            }
            modifiers.AddModifier(modifier);
        }

        public void UnregisterModifier(IEntityModifier modifier)
        {
            if (modifier == null || modifiers == null)
                return;
            if (modifiers.Contains(modifier))
                modifiers.Remove(modifier);
        }

        public void ClearEntityModifier()
        {
            if (modifiers != null)
            {
                modifiers.Clear();
            }
        }

        public Vector2 Position 
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public float X
        { 
            get { return this.position.X; }
            set { this.position.X = value; }
        }
        public float Y
        {
            get { return this.position.Y; }
            set { this.position.Y = value; }
        }

        public int ZIndex { get; set; }

        public virtual int Width { get; set; }

        public virtual int Height { get; set; }

        public int ChildCount { get { return children.Count; } }

        public float Alpha { get; set; }

        public float Scaling { get; set; }

        public float Rotation { get; set; }

        public bool IgnoreUpdate { get; set; }

        public bool HasParent { get; set; }

        public bool Visible { get; set; }

        public bool Contains(Vector2 point, int x, int y, int width, int height)
        {
            if (point.X > x && point.X < x + width && point.Y > y && point.Y < y + height)
                return true;
            return false;
        }

        public IEntity Parent { get; set; }

        public Vector2 Origin { get; set; }

        public SpriteEffects Flip { get; set; }

        public Color Color { get; set; }

        public void AttachChild(IEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            if (children == null)
            {
                children = new List<IEntity>(4);
            }

            entity.HasParent = true;
            entity.Parent = this;

            children.Add(entity);
        }

        public void AttachChild(IEntity entity, int index)
        {
            if (entity == null || entity.HasParent)
            {
                throw new Exception("entity = null or entity already has a parent");
            }
            if (children == null)
            {
                children = new List<IEntity>(4);
            }

            entity.HasParent = true;
            entity.Parent = this;

            children.Insert(index, entity);
        }

        public bool DetachChild(IEntity entity)
        {
            if (children == null || entity == null || entity.HasParent)
            {
                throw new Exception("children = null or entity = null or entity already has a parent");
            }
            if (!children.Contains(entity))
            {
                return false;
            }

            entity.Parent = null;
            entity.HasParent = false;
            children.Remove(entity);
            return true;
        }

        public bool DetachChildren()
        {
            if (children == null)
            {
                return false;
            }

            for (int i = 0; i < children.Count; i++)
            {
                children[i].HasParent = false;
                children[i].Parent = null;
            }

            children.Clear();

            return true;
        }

        public bool DetachSelf()
        {
            IEntity parent = this.Parent;

            if (parent != null)
            {
                return parent.DetachChild(this);
            }
            else
            {
                return false;
            }
        }

        public void SortChildren()
        {
            if (children == null)
            {
                return;
            }

            ZIndexSorter.Instance().Sort(children);
        }

        public void SortChildren(IComparator<IEntity> compare)
        {
            if (children == null)
            {
                return;
            }

            ZIndexSorter.Instance().Sort(children, compare);
        }

        public virtual void ToString()
        {

        }
        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================


    }

    public class CompareEntity
    {
        public int Compare(IEntity entityA, IEntity entityB)
        {
            return entityA.ZIndex - entityB.ZIndex;
        }
    }

    public interface IEntity
    {
        int ZIndex { get; set; }
        int Width { get; }
        int Height { get; }
        int ChildCount { get; }

        float X { get; set; }
        float Y { get; set; }
        float Alpha { get; set; }
        float Scaling { get; set; }
        float Rotation { get; set; }

        bool Visible { get; set; }
        bool IgnoreUpdate { get; set; }
        bool HasParent { get; set; }
        bool Contains(Vector2 point, int x, int y, int width, int height);

        Vector2 Position { get; set; }

        IEntity Parent { get; set; }

        Vector2 Origin { get; set; }
        SpriteEffects Flip { get; set; }
        Color Color { get; set; }

        void AttachChild(IEntity entity);
        void AttachChild(IEntity entity, int index);
        bool DetachChild(IEntity entity);
        bool DetachChildren();
        bool DetachSelf();

        void SortChildren();
        void SortChildren(IComparator<IEntity> compare);

        void RegisterModifier(IEntityModifier modifier);
        void UnregisterModifier(IEntityModifier modifier);
        void ClearEntityModifier();

        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void Reset();
        void ToString();
    }
}
