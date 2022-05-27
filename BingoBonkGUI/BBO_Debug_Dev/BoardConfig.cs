using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBO_Debug_Dev
{
    internal class BoardConfig
    {
        public int Seed { get;  set; }
        public int Vahki { get;  set; }
        public bool Canister { get;  set; }
        public bool CanisterSubdivide { get;  set; }
        public bool Ach1k { get;  set; }
        public bool Matoro { get;  set; }
        public bool Hewkii { get;  set; }
        public bool Shop { get;  set; }
        public bool CanisterLocator { get;  set; }
        public bool PirakaPlayground { get;  set; }
        public bool AlwaysFillMiddleSquare { get;  set; }
        public override string ToString()
        {
            return $"Seed: {Seed}\nVahki: {Vahki}\nCanister: {Canister}\nCanister Subdivide: {CanisterSubdivide}\nAch1k: {Ach1k}\nMatoro: {Matoro}\nHewkii: {Hewkii}\nShop: {Shop}\nCanister Locator: {CanisterLocator}\nPiraka Playground: {PirakaPlayground}\nAlways Fill Middle Square: {AlwaysFillMiddleSquare}";
        }
    }
}
