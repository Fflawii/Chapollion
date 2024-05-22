using System;

namespace Chapollion.ScriptableObjects.Data
{
    
    // [Flags]
    // public enum Charactéristiques
    // {
    //     None    = 0,     // 0000
    //     Griffe   = 1 << 0, // 0001
    //     Poil  = 1 << 1, // 0010
    //     Oeil   = 1 << 2, // 0100
    //     Queue  = 1 << 3, // 1000
    //     Caresse   = 1 << 4, // 0001
    //     Ronronnement  = 1 << 5, // 0010
    //     Coussinet   = 1 << 6, // 0100
    //     Vibirisse  = 1 << 7, // 1000
    //     All     = ~0     // 1111
    // }
    public enum Charactéristique
    {
        Aucune = 0,
        Griffe = 1,
        Poil = 2,
        Oeil = 3,
        Queue = 4,
        Caresse = 5,
        Ronronnement = 6,
        Coussinet = 7,
        Vibrisse = 8
    }
}