using System;
using System.Collections;
using System.Collections.Generic;
using TDS.Entities;
using TDS.Events;

namespace TDS.Worlds
{
    public interface INotifiableWorld : IWorld
    {
        
    }

    public interface ISomethingEntityRegister : IEntityRegister, IEventBus
    {
        
    }
    
}