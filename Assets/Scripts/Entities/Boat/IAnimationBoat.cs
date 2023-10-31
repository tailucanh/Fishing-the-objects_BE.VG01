using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities
{
    public interface IAnimationBoat
    {
        void SetAnimation(StateBoat newSate, bool isLoop);
    }
}
