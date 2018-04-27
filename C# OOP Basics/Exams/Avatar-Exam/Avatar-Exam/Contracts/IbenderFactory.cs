using System.Collections.Generic;

public interface IBenderFactory
{
    Bender CreateBender(List<string> args);
}