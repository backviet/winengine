using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WinEngine.Util.Modifier;
using WinEngine.Util.Interpolation;

namespace WinEngine.Entity.Modifier
{
    public class PathModifier : EntityModifier
    {
        public Action<PathModifier> PathStartedAction;
        public Action<PathModifier> PathWaypointStartedAction;
        public Action<PathModifier> PathWaypointFinishedAction;
        public Action<PathModifier> PathFinishedAction;

        private readonly SequenceModifier<IEntity> sequenceModifier;

	    private readonly Path path;

        private IEntity entity;

        public PathModifier(float pDuration, IEntity entity, Path path, IEntityModifierListener entityModiferListener,
            IInterpolation function)
            : base(entityModiferListener)
        {
            int pathSize = path.Size();

            if (pathSize < 2)
            {
                throw new Exception("Path needs at least 2 waypoints!");
            }

            this.entity = entity;

            this.path = path;

            MoveModifier[] moveModifiers = new MoveModifier[pathSize - 1];

            float[] coordinatesX = path.CoordinatesX();
            float[] coordinatesY = path.CoordinatesY();

            float velocity = path.Length() / pDuration;

            int modifierCount = moveModifiers.Length;
            for (int i = 0; i < modifierCount; i++)
            {
                float duration = path.SegmentLength(i) / velocity;
                moveModifiers[i] = new MoveModifier(duration, coordinatesX[i], coordinatesX[i + 1], coordinatesY[i],
                    coordinatesY[i + 1], null, function);
            }

            /* Create a new SequenceModifier and register the listeners that
             * call through to mEntityModifierListener and mPathModifierListener. */

            sequenceModifier = new SequenceModifier<IEntity>(moveModifiers);
            sequenceModifier.StartSequenceAction += (sender => SequenceStarted());
            sequenceModifier.FinishSequenceAction += (sender => SequenceFinished());
            sequenceModifier.StartModifierAction += (sender => SequenceListenerStarted(this.entity));
            sequenceModifier.FinishModifierAction += (sender => SequenceListenerFinished(this.entity));
        }

        // ===========================================================
	    // Getter & Setter
	    // ===========================================================

	    public Path getPath() {
		    return this.path;
	    }
        // ===========================================================
        // Methods
        // ===========================================================
        public void SequenceStarted()
        {
            if (PathWaypointStartedAction != null)
            {
                PathWaypointStartedAction(this);
            }
        }

        public void SequenceFinished()
        {
            if (PathWaypointFinishedAction != null)
            {
                PathFinishedAction(this);
            }
        }

        public void SequenceListenerStarted(IEntity entity)
        {
            this.ModifierStart(entity);
            if (PathStartedAction != null)
            {
                PathStartedAction(this);
            }
        }

        public void SequenceListenerFinished(IEntity entity)
        {
            ModifierFinish(entity);
            if (PathFinishedAction != null)
            {
                PathFinishedAction(this);
            }
        }
	    // ===========================================================
	    // Methods for/from SuperClass/Interfaces
	    // ===========================================================
	    public new bool Finish() {
		    return this.sequenceModifier.Finish;
	    }

	    public float getSecondsElapsed() {
		    return (float)this.sequenceModifier.SecondElapsedTime();
	    }

	    public float Duration() {
		    return (float)this.sequenceModifier.Duration;
	    }

	    public override void Reset() {
		    this.sequenceModifier.Reset();
	    }

        public override double Update(Microsoft.Xna.Framework.GameTime gameTime, IEntity item)
        {
 	         return sequenceModifier.Update(gameTime, item);
        }
    }

    public class Path
    {
        private readonly float[] xPositions;
        private readonly float[] yPositions;

        private int index;
        private float length;
        private bool isLengthChanged = false;

        public Path(int length)
        {
            xPositions = new float[length];
            yPositions = new float[length];

            index = length;
            isLengthChanged = false;
        }

        public Path(float[] xPos, float[] yPos)
        {
            if (xPos.Length != yPos.Length)
            {
                throw new Exception("lenght must be the same");
            }
            xPositions = xPos;
            yPositions = yPos;

            index = xPositions.Length;
            isLengthChanged = true;
        }

        // ===========================================================
		// Getter & Setter
		// ===========================================================

		public Path To(float x, float y) {
			this.xPositions[this.index] = x;
			this.yPositions[this.index] = y;

			this.index++;

			this.isLengthChanged = true;

			return this;
		}

		public float[] CoordinatesX() {
			return this.xPositions;
		}

		public float[] CoordinatesY() {
			return this.yPositions;
		}

		public int Size() {
			return this.xPositions.Length;
		}

		public float Length() {
			if(this.isLengthChanged) {
				this.UpdateLength();
			}
			return this.length;
		}

		public float SegmentLength(int pSegmentIndex) {
			float[] coordinatesX = this.xPositions;
			float[] coordinatesY = this.yPositions;

			int nextSegmentIndex = pSegmentIndex + 1;

			float dx = coordinatesX[pSegmentIndex] - coordinatesX[nextSegmentIndex];
			float dy = coordinatesY[pSegmentIndex] - coordinatesY[nextSegmentIndex];

			return (float)Math.Sqrt(dx * dx + dy * dy);
		}

		// ===========================================================
		// Methods for/from SuperClass/Interfaces
		// ===========================================================

		// ===========================================================
		// Methods
		// ===========================================================

		private void UpdateLength() {
			float length = 0.0f;

			for(int i = this.index - 2; i >= 0; i--) {
				length += this.SegmentLength(i);
			}
			this.length = length;
		}
    }
}
