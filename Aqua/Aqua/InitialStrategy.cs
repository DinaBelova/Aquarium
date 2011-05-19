using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aqua
{
    class InitialStrategy:Strategy
    {
        public InitialStrategy(Fish fish) 
            : base (fish)
        {            
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override Strategy Next()
        {
            return new LifeStrategy(fish, 0.5 + Tools.random.NextDouble());
        }
    }
}
