﻿using System;
using DevExpress.ExpressApp.Security;

namespace Xpand.ExpressApp.StateMachine.Security.Improved {
    [Serializable]
    public class StateMachineTransitionOperationRequest : OperationPermissionRequestBase, IStateMachineTransitionPermission {
        public StateMachineTransitionOperationRequest(IStateMachineTransitionPermission permission)
            : base(StateMachineTransitionPermission.OperationName) {
            Modifier = permission.Modifier;
            StateCaption = permission.StateCaption;
            StateMachineName = permission.StateMachineName;
            Hide = permission.Hide;
        }

        public StateMachineTransitionModifier Modifier { get; set; }
        public string StateMachineName { get; set; }
        public string StateCaption { get; set; }
        public override object GetHashObject() {
            return "StateMachineTransitionOperationRequest";
        }

        public bool Hide { get; set; }
    }
}
