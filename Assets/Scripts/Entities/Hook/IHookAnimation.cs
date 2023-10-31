using Assets.Scripts.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities
{
    public interface IHookAnimation
    {

        void SetAnimation(StateHook newState, bool isLoop);

        void EnableAnimation();
      
        void DisableAnimation();
       

    }
}
