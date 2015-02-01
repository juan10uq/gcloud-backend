using System;
using System.ComponentModel;

namespace GCloud.Models
{
    [Flags]
    public enum Operations : long
    {
        None = 0,
        [Description("Create")]
        Create = 1,
        [Description("Read")]
        Read = 2,
        [Description("Update")]
        Update = 4,
        [Description("Delete")]
        Delete = 8,
        //CRUD
        [Description("CRUD")]
        Crud = Create | Read | Update | Delete,
        /** Operations to be replaced by real operations*/
        Operation = 16,
        Operation0 = 32,
        Operation1 = 64,
        Operation2 = 128,
        Operation3 = 256,
        Operation4 = 512,
        Operation5 = 1024,
        Operation6 = 2048,
        Operation7 = 4096,
        Operation8 = 8192,
        Operation9 = 16384,
        Operation10 = 32768,
        Operation11 = 65536,
        Operation12 = 131072,
        Operation13 = 262144,
        Operation14 = 524288,
        Operation16 = 1048576,
        Operation17 = 2097152,
        Operation18 = 4194304,
        Operation19 = 8388608,
        Operation20 = 16777216,
        Operation21 = 33554432,
        Operation23 = 67108864,
        Operation24 = 134217728,
        Operation25 = 268435456,
        Operation26 = 536870912,
        Operation27 = 1073741824,
        Operation28 = 2147483648,
        Operation29 = 4294967296,
        Operation30 = 8589934592,
        Operation31 = 17179869184,
        Operation32 = 34359738368,
        /** End Operations*/
    }
}
