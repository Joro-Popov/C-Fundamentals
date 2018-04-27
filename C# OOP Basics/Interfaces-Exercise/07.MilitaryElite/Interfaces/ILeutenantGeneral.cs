using System;
using System.Collections.Generic;
using System.Text;

public interface ILeutenantGeneral
{
    IEnumerable<IPrivate> Privates { get; }
}
