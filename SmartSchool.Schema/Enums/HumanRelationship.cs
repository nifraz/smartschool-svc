using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Enums
{
    /// <summary>
    /// GEDCOM Human Relationship
    /// </summary>
    public enum HumanRelationship : byte
    {
        NotKnown = 0,
        Husband = 1,
        Wife = 2,
        Father = 3,
        Mother = 4,
        Son = 5,
        Daughter = 6,
        Brother = 7,
        Sister = 8,
        Uncle = 9,
        Aunt = 10,
        Nephew = 11,
        Niece = 12,
        Cousin = 13,
        Grandfather = 14,
        Grandmother = 15,
        Grandson = 16,
        Granddaughter = 17,
        Stepfather = 18,
        Stepmother = 19,
        Stepson = 20,
        Stepdaughter = 21,
        FatherInLaw = 22,
        MotherInLaw = 23,
        SonInLaw = 24,
        DaughterInLaw = 25,
        BrotherInLaw = 26,
        SisterInLaw = 27
    }

}
