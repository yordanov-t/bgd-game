// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Cinemachine;

namespace HutongGames.PlayMaker.Actions.ecosystem.cinemachine
{
    [ActionCategory("Cinemachine")]
    [Tooltip("Gets the lens settings of a FreeLook Camera")]
    public class FreeLookCameraGetLensSettings : CinemachineActionGetLensSettingsBase<CinemachineFreeLook>
    {
        [RequiredField]
		[Tooltip("The Cinemachine FreeLook Camera")]
        [CheckForComponent(typeof(CinemachineFreeLook))]
        public FsmOwnerDefault gameObject;

		[Tooltip("repeat every frame, useful for animation")]
		public bool everyFrame;

        public override void Reset()
        {   
            base.Reset();

            gameObject = null;
			everyFrame = false;
        }

		public override void OnEnter()
		{
			Execute();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			Execute();
		}


        void Execute()
        {
            if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
            {
                return;
            }

            this.GetLensSettings(ref this.cachedComponent.m_Lens);

        }
    }
}