//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Base class for all the objects that the player can teleport to
//
//=============================================================================

using System;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public abstract class TeleportMarkerBase : MonoBehaviour
	{
		public bool locked = false;
		public bool markerActive = true;
        public bool VisibleOnTeleportOnly = true;

		//-------------------------------------------------
		public virtual bool showReticle
		{
			get
			{
				return true;
			}
		}


		//-------------------------------------------------
		public void SetLocked( bool locked )
		{
			this.locked = locked;

			UpdateVisuals();
		}


		//-------------------------------------------------
		public virtual void TeleportPlayer( Vector3 pointedAtPosition )
		{
		}


		//-------------------------------------------------
		public abstract void UpdateVisuals();

		//-------------------------------------------------
		public abstract void Highlight( bool highlight );

		//-------------------------------------------------
		public abstract void SetAlpha( float tintAlpha, float alphaPercent );

		//-------------------------------------------------
		public abstract bool ShouldActivate( Vector3 playerPosition );

		//-------------------------------------------------
		public abstract bool ShouldMovePlayer();

        public virtual bool ValidateLocation(Vector3 pointedAtPosition)
        {
            return true;
        }
    }
}
