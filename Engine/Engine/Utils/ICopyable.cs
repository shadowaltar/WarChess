using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utils;
public interface ICopyable<T>
{
    void CopyFrom(T other);
}
