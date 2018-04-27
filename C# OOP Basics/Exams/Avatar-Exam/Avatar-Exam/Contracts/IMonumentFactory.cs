using System.Collections.Generic;

public interface IMonumentFactory
{
    Monument CreateMonument(List<string> args);
}