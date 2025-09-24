using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroParagon.Models.Expressions;

/// <summary>
/// Stores keyword strings used in value definition which are to reference other places.
/// For example, if Unit(Name=angel).Abilities contains Ability(Name=angel_resurrection),
/// then during Definition Parsing, this ability name must be registered here.
/// </summary>
public class KeywordRepository
{
    private Dictionary<string, Reference> references = [];
    public bool TryGet(string refKey, out Reference? reference)
    {
        reference = null;
        if (references.TryGetValue(refKey, out var r))
        {
            reference = r;
            return true;
        }
        return false;
    }
}
