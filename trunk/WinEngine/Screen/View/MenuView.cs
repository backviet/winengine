using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using WinEngine.Entity.UI;
using WinEngine.Entity.Modifier;
using WinEngine.Util.Interpolation;

namespace WinEngine.Screen.View
{
    public class MenuView : BaseView
    {
        //================================================================
        //Constants
        //================================================================
        public const byte NONE = 0;
        public const byte LEFT_RIGHT = 1;
        public const byte RIGHT_LEFT = 2;
        public const byte TOP_BOTTOM = 3;
        public const byte BOTTOM_TOP = 4;
        public const byte MIX_VERTICAL = 5;
        public const byte MIX_HORIZONTAL = 6;

        //================================================================
        //Fields
        //================================================================

        //================================================================
        //Constructors
        //================================================================
        public MenuView(Game game, Vector2 position)
            : this(game, position, NONE)
        {
        }

        public MenuView(Game game, Vector2 position, byte type)
            : base(game, position)
        {
            Direction = type;
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public IInterpolation Iterpolation { get; set; }

        public byte Direction { get; set; }

        public Vector2 Origin { get; set; }

        public bool NeedBuidAnimation { get; set; }

        //================================================================
        //Methodes
        //================================================================
        public void BuildAnimation(IInterpolation interpolation, double duration)
        {
            if (NeedBuidAnimation)
            {
                byte direction = Direction;
                switch (direction)
                {
                    case LEFT_RIGHT:
                        for (int i = 0; i < countchildren; i++)
                        {
                            if (childrens[i].NeedBuildUI)
                            {
                                continue;
                            }
                            if (!childrens[i].IgnoreUpdate && !(childrens[i] is Text))
                            {
                                float x = -childrens[i].Width;

                                MoveXModifier modifier = new MoveXModifier(duration, x, childrens[i].Position.X,
                                    null, interpolation);
                                childrens[i].RegisterModifier(modifier);
                            }
                        }
                        break;

                    case RIGHT_LEFT:
                        for (int i = 0; i < countchildren; i++)
                        {
                            if (childrens[i].NeedBuildUI)
                            {
                                continue;
                            }
                            if (!childrens[i].IgnoreUpdate && !(childrens[i] is Text))
                            {
                                float x = camera.width;

                                MoveXModifier modifier = new MoveXModifier(duration, x, childrens[i].Position.X,
                                    null, interpolation);
                                childrens[i].RegisterModifier(modifier);
                            }
                        }
                        break;

                    case TOP_BOTTOM:
                        for (int i = 0; i < countchildren; i++)
                        {
                            if (childrens[i].NeedBuildUI)
                            {
                                continue;
                            }
                            if (!childrens[i].IgnoreUpdate && !(childrens[i] is Text))
                            {
                                float y = -childrens[i].Height;

                                MoveYModifier modifier = new MoveYModifier(duration, y, childrens[i].Position.Y,
                                    null, interpolation);
                                childrens[i].RegisterModifier(modifier);
                            }
                        }
                        break;

                    case BOTTOM_TOP:
                        for (int i = 0; i < countchildren; i++)
                        {
                            if (childrens[i].NeedBuildUI)
                            {
                                continue;
                            }
                            if (!childrens[i].IgnoreUpdate && !(childrens[i] is Text))
                            {
                                float y = camera.height;

                                MoveYModifier modifier = new MoveYModifier(duration, y, childrens[i].Position.Y,
                                    null, interpolation);
                                childrens[i].RegisterModifier(modifier);
                            }
                        }
                        break;

                    case MIX_HORIZONTAL:

                        break;

                    case MIX_VERTICAL:

                        break;

                    default:
                        break;
                }
            }
        }

        //================================================================
        //Methodes overridde
        //================================================================
    }
}
